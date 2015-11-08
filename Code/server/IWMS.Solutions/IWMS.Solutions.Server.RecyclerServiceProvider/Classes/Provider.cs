using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.RecyclerServiceProvider.Models;
using Auth = IWMS.Solutions.Server.AuthProvider;

namespace IWMS.Solutions.Server.RecyclerServiceProvider
{
    public class Provider
    {
        #region Members
        private RecyclerServiceModelDataContext context = null;
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new RecyclerServiceModelDataContext();
            }
        }
        #endregion

        /// <summary>
        /// RetrieveRecyclers
        /// </summary>
        /// <returns></returns>
        public IList<RecyclerPoint> RetrieveRecyclers()
        {
            IList<RecyclerPoint> recyclerList = new List<RecyclerPoint>();
            var recyclers = context.Recyclers;

            foreach (var recyler in recyclers)
            {
                var ward = context.Wards.Where(@w => @w.Id == recyler.WardId).First();
                recyclerList.Add(new RecyclerPoint { Id = recyler.Id, Name = recyler.Name, Address = recyler.Address, Mobile = recyler.Mobile, Ward = ward.Name });
            }

            return recyclerList;
        }

        /// <summary>
        /// RetrieveRecycler
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string RetrieveRecycler(string mobile, string password)
        {
            var recycler = context.Recyclers.Where(@w => @w.Mobile == mobile && @w.Password == password).First();
            return recycler.Id.ToString();
        }

        /// <summary>
        /// RetrieveWards
        /// </summary>
        /// <returns></returns>
        public IList<string> RetrieveWards()
        {
            IList<string> wardList = new List<string>();

            var wards = context.Wards.OrderBy(@orderby => @orderby.Name.Trim());

            foreach (var ward in wards)
            {
                wardList.Add(ward.Name);
            }

            return wardList;
        }

        /// <summary>
        /// RetrieveGarbageType
        /// </summary>
        /// <returns></returns>
        public IList<string> RetrieveGarbageTypes()
        {
            IList<string> garbageTypeList = new List<string>();
            var garbageTypes = context.GarbageTypes;

            foreach (var type in garbageTypes)
            {
                garbageTypeList.Add(type.Type);
            }

            return garbageTypeList;
        }

        /// <summary>
        /// InsertRecycler
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="wardName"></param>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <param name="garbageType"></param>
        public void InsertRecycler(string name, string address, string wardName, string mobile, string password, string garbageType)
        {
            var ward = context.Wards.Where(@w => @w.Name == wardName).First();
            var garbageTypeSingle = context.GarbageTypes.Where(@w => @w.Type == garbageType).First();
            Guid recyclerId = Guid.NewGuid();

            InsertGarbageType(garbageTypeSingle.Id, recyclerId);

            Recycler recycler = new Recycler
            {
                Id = recyclerId,
                Name = name,
                Address = address,
                WardId = ward.Id,
                Mobile = mobile,
                Password = password
            };

            context.Recyclers.InsertOnSubmit(recycler);
            SubmitData();
        }

        /// <summary>
        /// InsertGarbageType
        /// </summary>
        /// <param name="garbageTypeId"></param>
        /// <param name="recyclerId"></param>
        private void InsertGarbageType(Guid garbageTypeId, Guid recyclerId)
        {
            Guid recyclerGarbageTypeId = Guid.NewGuid();

            RecyclerGarbageType recyclerGarbageType = new RecyclerGarbageType
            {
                Id = recyclerGarbageTypeId,
                GarbageTypeId = garbageTypeId,
                RecyclerId = recyclerId
            };

            context.RecyclerGarbageTypes.InsertOnSubmit(recyclerGarbageType);
            SubmitData();
        }

        /// <summary>
        /// InserRecyclerScan
        /// </summary>
        /// <param name="data"></param>
        /// <param name="scanInfoList"></param>
        /// <returns></returns>
        public int InserRecyclerScan(string recyclerId, string scanInfoList)
        {
            try
            {
                IList<RecyclerScanInfo> recyclerScanList = new List<RecyclerScanInfo>();
                var recycler = context.Recyclers.Where(@w => @w.Id == Guid.Parse(recyclerId)).First();
                string[] sep = { "," };

                foreach (var scanInfo in scanInfoList.Split(sep, StringSplitOptions.RemoveEmptyEntries))
                {
                    RecyclerScanInfo recyclerScan = new RecyclerScanInfo
                    {
                        Id = Guid.NewGuid(),
                        Tag = scanInfo.Trim(),
                        RecyclerId = recycler.Id,
                        CreateDateTime = DateTime.Now
                    };

                    if (!recyclerScanList.Select(@s => @s.Tag).ToList().Contains(scanInfo.Trim()))
                    {
                        recyclerScanList.Add(recyclerScan);
                    }
                }

                context.RecyclerScanInfos.InsertAllOnSubmit(recyclerScanList.AsEnumerable());
                SubmitData();

                return 217;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        /// <summary>
        /// InsertUsersCount
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usersCount"></param>
        /// <returns></returns>
        public int InsertUsersCount(string key, string usersCount)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var volunteer = context.Volunteers.Where(@w => @w.UserId == user.UserId).First();
                var ncus = context.NonComplaintUsers.Where(@w => @w.WardId == volunteer.WardId && @w.Accepted == null && @w.Processed == null);
                int count = 0;

                foreach (var ncu in ncus)
                {
                    ncu.VolunteerId = volunteer.Id;
                    ncu.Accepted = true;
                    count++;

                    if (count == Convert.ToInt32(usersCount))
                    {
                        break;
                    }
                }

                SubmitData();

                return 218;
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = File.AppendText(@"C:\IWMSLog.txt"))
                {
                    Log(ex.Message, sw);
                }

                return 100;
            }
        }

        /// <summary>
        /// ProcessNonComplaintUsers
        /// </summary>
        public void ProcessNonComplaintUsers()
        {
            try
            {
                IList<NonComplaintUser> ncuList = new List<NonComplaintUser>();
                var recyclerScanInfos = context.RecyclerScanInfos.Where(@w => @w.Processed == null);

                if (recyclerScanInfos != null && recyclerScanInfos.Count() > 0)
                {
                    foreach (var recyclerScan in recyclerScanInfos)
                    {
                        var garbage = context.Garbages.Where(@w => @w.Tag == recyclerScan.Tag).First();
                        var bin = context.Bins.Where(@w => @w.Id == garbage.BinId).First();
                        var recycler = context.Recyclers.Where(@w => @w.Id == recyclerScan.RecyclerId).First();
                        var ward = context.Wards.Where(@w => @w.Id == recycler.WardId).First();

                        NonComplaintUser ncu = new NonComplaintUser
                        {
                            Id = Guid.NewGuid(),
                            UserId = bin.UserId,
                            WardId = ward.Id,
                            CreatedDateTime = DateTime.Now
                        };

                        ncuList.Add(ncu);
                        recyclerScan.Processed = true;
                    }

                    context.NonComplaintUsers.InsertAllOnSubmit(ncuList.AsEnumerable());

                    var ncus = context.NonComplaintUsers.Where(@w => @w.Processed == null &&
                        DateTime.Compare(@w.CreatedDateTime, DateTime.Today.AddDays(-7)) > 1 &&
                        @w.Accepted == true);

                    if (ncus != null && ncus.Count() > 0)
                    {
                        foreach (var ncu in ncus)
                        {
                            ncu.Processed = true;
                        }
                    }

                    SubmitData();
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = File.AppendText(@"C:\IWMSLog.txt"))
                {
                    Log(ex.Message, sw);
                }
            }
        }

        /// <summary>
        /// SendNonComplaintUserNotification
        /// </summary>
        public void SendNonComplaintUserNotification()
        {
            Auth.Provider provider = new Auth.Provider();
            provider.SendTopicNotification("NU", "ClearTrashVolunteers", "Please check your Users List updated for this week!");
        }

        /// <summary>
        /// DeleteRecycler
        /// </summary>
        /// <param name="mobile"></param>
        public void DeleteRecycler(string mobile)
        {
            var recycler = context.Recyclers.Where(@w => @w.Mobile == mobile).First();
            context.Recyclers.DeleteOnSubmit(recycler);
            SubmitData();
        }

        /// <summary>
        /// Submit Database Changes
        /// </summary>
        private void SubmitData()
        {
            context.SubmitChanges();
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="w"></param>
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }
}
