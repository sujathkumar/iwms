using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.BinServiceProvider.Models;

namespace IWMS.Solutions.Server.BinServiceProvider
{
    public class Provider
    {
        #region Members
        private BinServiceModelDataContext context = null;
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new BinServiceModelDataContext();
            }
        }
        #endregion

        /// <summary>
        /// RetrieveHHUserInfo
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int RetrieveHHUserInfo(string key)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var registerdUser = context.Addresses.Where(@w => @w.UserId == user.UserId).First();

                if (!registerdUser.Registered)
                {
                    return 205;
                }
                else
                {
                    var bin = context.Bins;

                    if (bin != null && bin.Count() > 0)
                    {
                        int status = Convert.ToInt32(bin.First().Status);

                        if (status == 0)
                        {
                            return 206;
                        }
                        else if (status == 1)
                        {
                            return 207;
                        }
                        else if (status == 2)
                        {
                            return 208;
                        }
                    }
                    else
                    {
                        return 205;
                    }
                }
            }
            catch (Exception ex)
            {
                return 100;
            }

            return 100;
        }

        /// <summary>
        /// RetrieveGarbageTag
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveGarbageTag(string key)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var bin = context.Bins.Where(@w => @w.UserId == user.UserId).First();
                var garbage = context.Garbages.Where(@w => @w.BinId == bin.Id).First();

                return garbage.Tag;
            }
            catch (Exception ex)
            {
                return "100";
            }
        }

        /// <summary>
        /// RetrieveGarbageTags
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IList<GarbagePoint> RetrieveOrders()
        {
            try
            {
                IList<GarbagePoint> garbageList = new List<GarbagePoint>();
                var orders = context.Orders.Where(@w => @w.Printed == null && @w.QRCodeRequired == true);

                foreach (var order in orders)
                {
                    var garbage = context.Garbages.Where(@w => @w.Id == order.GarbageId).First();
                    var garbageType = context.GarbageTypes.Where(@w => @w.Id == order.GarbageTypeId).First();
                    var bin = context.Bins.Where(@w => @w.Id == garbage.BinId).First();
                    var user = context.Users.Where(@w => @w.Id == bin.UserId).First();
                    var address = context.Addresses.Where(@w => @w.UserId == user.Id).First();

                    string userAddress = user.Name + ", " + address.HouseNo + ", " + address.HouseName + ", " +
                    address.ApartmentName + ", " + address.Street + ", " + address.Locality + ", " + address.PINCODE;

                    garbageList.Add(new GarbagePoint { Name = user.Name, Address = userAddress, Tag = garbage.Tag, GarbageType = garbageType.Type,  GeneratedDate = garbage.CreateDateTime });
                }

                return garbageList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// RetrieveAddress
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveAddress(string key)
        {
            try
            {
                string cityNumber = key.Substring(0, 2);
                var city = context.Cities.Where(@w => @w.Number == cityNumber).First();
                var auth = context.Auths.Where(@w => @w.Key == key).First();
                var user = context.Users.Where(@w => @w.Id == auth.UserId).First();
                var address = context.Addresses.Where(@w => @w.UserId == auth.UserId).First();

                return user.Name + "s_lash" + address.HouseNo + "s_lash" + address.HouseName + "s_lash" +
                    address.ApartmentName + "s_lash" + address.Street + "s_lash" +
                    address.Locality + "s_lash" + city.Name + "s_lash" + address.PINCODE;
            }
            catch (Exception ex)
            {
                return "100";
            }
        }

        /// <summary>
        /// InsertAddress
        /// </summary>
        /// <param name="key"></param>
        /// <param name="houseNo"></param>
        /// <param name="houseName"></param>
        /// <param name="ApartmentName"></param>
        /// <param name="street"></param>
        /// <param name="locality"></param>
        /// <param name="ward"></param>
        /// <param name="registered"></param>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public int InsertAddress(string key, string houseNo, string houseName, string ApartmentName, string street, string locality, string ward, bool registered, int pincode)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var addressSingle = context.Addresses.Where(@w => @w.UserId == user.UserId).First();
                var selectedWard = context.Wards.Where(@w => @w.Name.ToLower() == ward.ToLower()).First();

                addressSingle.Id = addressSingle.Id;
                addressSingle.HouseNo = houseNo;
                addressSingle.HouseName = houseName;
                addressSingle.ApartmentName = ApartmentName;
                addressSingle.Street = street;
                addressSingle.Locality = locality;
                addressSingle.WardId = selectedWard.Id;
                addressSingle.PINCODE = pincode;
                addressSingle.Registered = registered;
                addressSingle.UserId = user.UserId;

                SubmitData();

                return 209;

            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        /// <summary>
        /// InsertBin
        /// </summary>
        /// <param name="key"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int InsertBin(string key, string status)
        {
            try
            {
                var userId = context.Auths.Where(@w => @w.Key == key).First().UserId;
                short binStatus = Convert.ToInt16(status);
                Guid binId = Guid.NewGuid();

                Bin bin = new Bin
                {
                    Id = binId,
                    Status = binStatus,
                    UserId = userId
                };

                context.Bins.InsertOnSubmit(bin);
                InsertGarbage(binId, userId);
                SubmitData();
                return 210;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        /// <summary>
        /// InsertGarbage
        /// </summary>
        /// <param name="binId"></param>
        private int InsertGarbage(Guid binId, Guid userId)
        {
            try
            {
                var garbageId = Guid.NewGuid();
                var tag = GenerateTag(userId);
                Garbage garbage = new Garbage
                {
                    Id = garbageId,
                    Tag = tag,
                    BinId = binId,
                    CreateDateTime = DateTime.Now
                };

                context.Garbages.InsertOnSubmit(garbage);                
                SubmitData();

                InsertOrder(tag, "WET");
                InsertOrder(tag, "DRY");

                return 211;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        /// <summary>
        /// InsertOrder
        /// </summary>
        /// <param name="binId"></param>
        public int InsertOrder(string tag, string type)
        {
            try
            {
                var garbage = context.Garbages.Where(@w => @w.Tag == tag).First();
                var garbageType = context.GarbageTypes.Where(@w => @w.Type == type).First();

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    DateOrdered = DateTime.Now,
                    GarbageId = garbage.Id,
                    GarbageTypeId = garbageType.Id,
                    Promotion = false,
                    QRCodeRequired = true,
                };

                context.Orders.InsertOnSubmit(order);
                SubmitData();

                return 214;
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
        /// GenerateOrder
        /// </summary>
        /// <param name="binId"></param>
        public Order GenerateOrder(string tag, string type)
        {
            try
            {
                var garbage = context.Garbages.Where(@w => @w.Tag == tag).First();
                var garbageType = context.GarbageTypes.Where(@w => @w.Type == type).First();
                var order = context.Orders.Where(@w => @w.GarbageId == garbage.Id && @w.GarbageTypeId == garbageType.Id).First();

                order.DatePrinted = DateTime.Now;
                order.Printed = true;
                order.Quantity = 30;

                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// GenerateTag
        /// </summary>
        /// <returns></returns>
        public string GenerateTag(Guid userId)
        {
            string generatedTag = "";
            int tagNumber = 1;

            var address = context.Addresses.Where(@w => @w.UserId == userId).First();
            var ward = context.Wards.Where(@w => @w.Id == address.WardId).First();
            var zone = context.Zones.Where(@w => @w.Id == ward.ZoneId).First();

            var wardTag = context.WardTags.Where(@w => @w.WardId == ward.Id);

            if (wardTag != null && wardTag.Count() > 0)
            {
                tagNumber = wardTag.First().TagNo + 1;
                generatedTag = "Z" + zone.Number + "-W" + ward.Number + "-" + tagNumber;
                wardTag.First().TagNo = tagNumber;
            }
            else
            {
                WardTag tag = new WardTag
                {
                    Id = Guid.NewGuid(),
                    TagNo = tagNumber,
                    WardId = ward.Id
                };

                generatedTag = "Z" + zone.Number + "-W" + ward.Number + "-" + tagNumber;
                context.WardTags.InsertOnSubmit(tag);
            }

            SubmitData();


            return generatedTag;
        }

        /// <summary>
        /// InsertOrders
        /// </summary>
        /// <param name="orders"></param>
        public void InsertOrders(IList<Order> orders)
        {
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
        public void Log(string logMessage, TextWriter w)
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
