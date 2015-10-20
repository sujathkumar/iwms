using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.CollectorServiceProvider.Models;

namespace IWMS.Solutions.Server.CollectorServiceProvider
{
    public class Provider
    {
        #region Members
        private CollectorServiceModelDataContext context = null;
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new CollectorServiceModelDataContext();
            }
        }
        #endregion

        /// <summary>
        /// RetrieveCollectors
        /// </summary>
        /// <returns></returns>
        public IList<CollectorPoint> RetrieveCollectors()
        {
            IList<CollectorPoint> collectorList = new List<CollectorPoint>();
            var collectors = context.Collectors;

            foreach (var collector in collectors)
            {
                var ward = context.Wards.Where(@w => @w.Id == collector.WardId).First();
                collectorList.Add(new CollectorPoint { Id = collector.Id, Name = collector.Name, Address = collector.Address, Mobile = collector.Mobile, Ward = ward.Name });
            }

            return collectorList;
        }

        /// <summary>
        /// RetrieveCollector
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string RetrieveCollector(string mobile, string password)
        {
            var collector = context.Collectors.Where(@w => @w.Mobile == mobile && @w.Password == password).First();
            return collector.Id.ToString();
        }

        /// <summary>
        /// RetrieveFrequency
        /// </summary>
        /// <param name="collectorId"></param>
        /// <returns></returns>
        public FrequencyPoint RetrieveFrequency(Guid collectorId)
        {
            var collector = context.Collectors.Where(@w => @w.Id == collectorId).First();
            var frequency = context.CollectorFrequencies.Where(@w => @w.Id == collector.FrequencyId).First();
            var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == collector.FrequencyId).ToList();

            FrequencyPoint frequencyPoint = new FrequencyPoint
            {
                PickupFrequency = frequency.PickupFrequency,
                FrequencyType = frequency.FrequencyType,
                Capacity = frequency.Capacity,
                LastUpdateDate = frequency.LastUpdateDate,
            };

            if (slots.Count() == 1)
            {
                frequencyPoint.SlotFrom1 = slots.ElementAt(0).SlotFrom;
                frequencyPoint.SlotTo1 = slots.ElementAt(0).SlotTo;
            }
            else if (slots.Count() == 2)
            {
                frequencyPoint.SlotFrom1 = slots.ElementAt(0).SlotFrom;
                frequencyPoint.SlotTo1 = slots.ElementAt(0).SlotTo;

                frequencyPoint.SlotFrom2 = slots.ElementAt(1).SlotFrom;
                frequencyPoint.SlotTo2 = slots.ElementAt(1).SlotTo;
            }
            else if (slots.Count() == 3)
            {
                frequencyPoint.SlotFrom1 = slots.ElementAt(0).SlotFrom;
                frequencyPoint.SlotTo1 = slots.ElementAt(0).SlotTo;

                frequencyPoint.SlotFrom2 = slots.ElementAt(1).SlotFrom;
                frequencyPoint.SlotTo2 = slots.ElementAt(1).SlotTo;

                frequencyPoint.SlotFrom3 = slots.ElementAt(2).SlotFrom;
                frequencyPoint.SlotTo3 = slots.ElementAt(2).SlotTo;
            }

            return frequencyPoint;
        }

        /// <summary>
        /// RetrieveRequest
        /// </summary>
        /// <param name="collectorId"></param>
        /// <returns></returns>
        public IList<RequestPoint> RetrieveRequest(Guid collectorId)
        {
            IList<RequestPoint> requestPointList = new List<RequestPoint>();
            var requests = context.UserRequests.Where(@w => @w.CollectorId == collectorId);

            foreach (var request in requests)
            {
                var garbage = context.Garbages.Where(@w => @w.Id == request.GarbageId).First();
                var garbageType = context.GarbageTypes.Where(@w => @w.Id == request.GarbageTypeId).First();
                var user = context.Users.Where(@w => @w.Id == request.UserId).First();
                var address = context.Addresses.Where(@w => @w.UserId == request.UserId).First();

                RequestPoint requestPoint = new RequestPoint
                {
                    RequestNumber = request.RequestNumber,
                    RequestTime = request.RequestTime,
                    ScheduleTime = request.ScheduleTime,
                    Tag = garbage.Tag,
                    GarbageType = garbageType.Type,
                    UserName = user.Name,
                    UserAddress = address.HouseNo + ", " + address.HouseName + ", " + address.ApartmentName + ", " + address.Street + ", " + address.Locality,
                    Quantity = request.Quantity,
                    DonateGarbage = request.DonateGarbage
                };

                requestPointList.Add(requestPoint);
            }

            return requestPointList;
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
        /// RetrieveCollectorDates
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveCollectorDates(string key)
        {
            StringBuilder dates = new StringBuilder();

            var auth = context.Auths.Where(@w => @w.Key == key).First();
            var address = context.Addresses.Where(@w => @w.UserId == auth.UserId).First();
            var collector = context.Collectors.Where(@w => @w.WardId == address.WardId).First();
            var frequency = context.CollectorFrequencies.Where(@w => @w.Id == collector.FrequencyId).First();

            int pickupFrequency = frequency.PickupFrequency;
            int frequencyType = frequency.FrequencyType;
            DateTime lastUpdatedTime = frequency.LastUpdateDate;

            if (frequencyType > 1)
            {
                for (int i = 1; i < 10; i++)
                {
                    dates.Append(lastUpdatedTime.AddDays(frequencyType * i).ToString("dd-MMM-yyyy"));
                    dates.Append(",");
                }
            }
            else
            {
                for (int i = 1; i < 10; i++)
                {
                    dates.Append(lastUpdatedTime.AddDays(frequencyType * i).ToString("dd-MMM-yyyy"));
                    dates.Append(",");
                }
            }

            return dates.ToString();
        }

        /// <summary>
        /// RetrieveCollectorTimes
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveCollectorTimes(string key)
        {
            StringBuilder times = new StringBuilder();

            var auth = context.Auths.Where(@w => @w.Key == key).First();
            var address = context.Addresses.Where(@w => @w.UserId == auth.UserId).First();
            var collector = context.Collectors.Where(@w => @w.WardId == address.WardId).First();
            var frequency = context.CollectorFrequencies.Where(@w => @w.Id == collector.FrequencyId).First();

            int pickupFrequency = frequency.PickupFrequency;
            int frequencyType = frequency.FrequencyType;
            DateTime lastUpdatedTime = frequency.LastUpdateDate;

            if (pickupFrequency == 1)
            {
                var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == frequency.Id).First();
                times.Append(slots.SlotFrom);
            }
            else if (pickupFrequency == 2)
            {
                var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == frequency.Id).ToList();
                times.Append(slots.ElementAt(0).SlotFrom);
                times.Append(",");
                times.Append(slots.ElementAt(1).SlotFrom);
            }
            else if (pickupFrequency == 3)
            {
                var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == frequency.Id).ToList();
                times.Append(slots.ElementAt(0).SlotFrom);
                times.Append(",");
                times.Append(slots.ElementAt(1).SlotFrom);
                times.Append(",");
                times.Append(slots.ElementAt(2).SlotFrom);
            }

            return times.ToString();
        }

        /// <summary>
        /// RetrieveCredentials
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public string RetrieveCredentials(string mobile)
        {
            var collector = context.Collectors.Where(@w => @w.Mobile == mobile);

            if (collector.Count() > 0)
            {
                return collector.First().Name + "," + collector.First().Password;
            }

            return string.Empty;
        }

        /// <summary>
        /// InsertCollector
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="wardName"></param>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        public void InsertCollector(string name, string address, string wardName, string mobile, string password, int pickupFrequency, int frequencyType, int capacity, string slotFrom, string slotTo, string garbageType, DateTime lastUpdateDate)
        {
            var ward = context.Wards.Where(@w => @w.Name == wardName).First();
            var garbageTypeSingle = context.GarbageTypes.Where(@w => @w.Type == garbageType).First();
            Guid collectorId = Guid.NewGuid();
            Guid frequencyId = InsertFrequency(pickupFrequency, frequencyType, capacity, lastUpdateDate);

            for (int i = 0; i < pickupFrequency; i++)
            {
                InsertSlots(frequencyId, slotFrom.Split('|')[i], slotTo.Split('|')[i]);
            }

            InsertGarbageType(garbageTypeSingle.Id, collectorId);

            Collector collector = new Collector
            {
                Id = collectorId,
                Name = name,
                Address = address,
                WardId = ward.Id,
                Mobile = mobile,
                Password = password,
                FrequencyId = frequencyId
            };

            context.Collectors.InsertOnSubmit(collector);
            SubmitData();
        }

        /// <summary>
        /// InsertGarbageType
        /// </summary>
        /// <param name="garbageTypeId"></param>
        /// <param name="collectorId"></param>
        private void InsertGarbageType(Guid garbageTypeId, Guid collectorId)
        {
            Guid collectorGarbageTypeId = Guid.NewGuid();

            CollectorGarbageType collectorGarbageType = new CollectorGarbageType
            {
                Id = collectorGarbageTypeId,
                GarbageTypeId = garbageTypeId,
                CollectorId = collectorId
            };

            context.CollectorGarbageTypes.InsertOnSubmit(collectorGarbageType);
            SubmitData();
        }

        /// <summary>
        /// InsertFrequency
        /// </summary>
        /// <param name="pickupFrequency"></param>
        /// <param name="frequencyType"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public Guid InsertFrequency(int pickupFrequency, int frequencyType, int capacity, DateTime lastUpdatedDate)
        {
            Guid frequencyId = Guid.NewGuid();

            CollectorFrequency collectorFrequency = new CollectorFrequency
            {
                Id = frequencyId,
                PickupFrequency = pickupFrequency,
                FrequencyType = frequencyType,
                Capacity = capacity,
                LastUpdateDate = lastUpdatedDate
            };

            context.CollectorFrequencies.InsertOnSubmit(collectorFrequency);
            SubmitData();

            return frequencyId;
        }

        /// <summary>
        /// InsertSlots
        /// </summary>
        /// <param name="pickupFrequency"></param>
        /// <param name="frequencyType"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public void InsertSlots(Guid frequencyId, string slotFrom, string slotTo)
        {
            Guid slotIdId = Guid.NewGuid();

            CollectorSlot collectorSlot = new CollectorSlot
            {
                Id = slotIdId,
                SlotFrom = slotFrom,
                SlotTo = slotTo,
                FrequencyId = frequencyId
            };

            context.CollectorSlots.InsertOnSubmit(collectorSlot);
            SubmitData();
        }

        /// <summary>
        /// SchedulePickup
        /// </summary>
        public string SchedulePickup(string key, string garbageType, int quantity, bool donateGarbage, string scheduleTime)
        {
            var auth = context.Auths.Where(@w => @w.Key == key).First();
            var address = context.Addresses.Where(@w => @w.UserId == auth.UserId).First();
            var bin = context.Bins.Where(@w => @w.UserId == auth.UserId).First();
            var garbage = context.Garbages.Where(@w => @w.BinId == bin.Id).First();
            var garbageCollectorType = context.GarbageTypes.Where(@w => @w.Type == garbageType).First();
            var collctorGarbageType = context.CollectorGarbageTypes.Where(@w => @w.GarbageTypeId == garbageCollectorType.Id).First();
            var collector = context.Collectors.Where(@w => @w.WardId == address.WardId && @w.Id == collctorGarbageType.CollectorId).First();
            var frequency = context.CollectorFrequencies.Where(@w => @w.Id == collector.FrequencyId).First();
            var request = context.UserRequests.OrderByDescending(@orderby => @orderby.RequestNumber);
            Guid requestId = Guid.NewGuid();
            int requestNumber = 1;
            DateTime scheduleDateTime = DateTime.Now;

            int pickupFrequency = frequency.PickupFrequency;
            int frequencyType = frequency.FrequencyType;
            DateTime lastUpdatedTime = frequency.LastUpdateDate;

            if (string.IsNullOrEmpty(scheduleTime))
            {
                if (frequencyType > 1)
                {
                    var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == frequency.Id).First();
                    DateTime date = lastUpdatedTime.AddDays(frequencyType);
                    scheduleDateTime = new DateTime(date.Year, date.Month, date.Day, Convert.ToInt32(slots.SlotFrom), 0, 0);
                }
                else
                {
                    if (pickupFrequency == 1)
                    {
                        var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == frequency.Id).First();

                        if (DateTime.Now.Hour < Convert.ToInt32(slots.SlotFrom))
                        {
                            scheduleDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(slots.SlotFrom), 0, 0);
                        }
                        else
                        {
                            DateTime date = DateTime.Now.AddDays(1);
                            scheduleDateTime = new DateTime(date.Year, date.Month, date.Day, Convert.ToInt32(slots.SlotFrom), 0, 0);
                        }
                    }
                    else if (pickupFrequency == 2)
                    {
                        var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == frequency.Id).ToList();

                        if (DateTime.Now.Hour < Convert.ToInt32(slots.ElementAt(0).SlotFrom))
                        {
                            scheduleDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(slots.ElementAt(0).SlotFrom), 0, 0);
                        }
                        else
                        {
                            if (DateTime.Now.Hour < Convert.ToInt32(slots.ElementAt(1).SlotFrom))
                            {
                                scheduleDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(slots.ElementAt(1).SlotFrom), 0, 0);
                            }
                            else
                            {
                                DateTime date = DateTime.Now.AddDays(1);
                                scheduleDateTime = new DateTime(date.Year, date.Month, date.Day, Convert.ToInt32(slots.ElementAt(0).SlotFrom), 0, 0);
                            }
                        }
                    }
                    else if (pickupFrequency == 3)
                    {
                        var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == frequency.Id).ToList();

                        if (DateTime.Now.Hour < Convert.ToInt32(slots.ElementAt(0).SlotFrom))
                        {
                            scheduleDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(slots.ElementAt(0).SlotFrom), 0, 0);
                        }
                        else
                        {
                            if (DateTime.Now.Hour < Convert.ToInt32(slots.ElementAt(1).SlotFrom))
                            {
                                scheduleDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(slots.ElementAt(1).SlotFrom), 0, 0);
                            }
                            else
                            {
                                if (DateTime.Now.Hour < Convert.ToInt32(slots.ElementAt(2).SlotFrom))
                                {
                                    scheduleDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(slots.ElementAt(2).SlotFrom), 0, 0);
                                }
                                else
                                {
                                    DateTime date = DateTime.Now.AddDays(1);
                                    scheduleDateTime = new DateTime(date.Year, date.Month, date.Day, Convert.ToInt32(slots.ElementAt(0).SlotFrom), 0, 0);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                DateTime scheduledDate = new DateTime(Convert.ToInt32(scheduleTime.Split('_')[0]),
                    Convert.ToInt32(scheduleTime.Split('_')[1]), Convert.ToInt32(scheduleTime.Split('_')[2]),
                    Convert.ToInt32(scheduleTime.Split('_')[3]), Convert.ToInt32(scheduleTime.Split('_')[4]), 0);
                scheduleDateTime = scheduledDate;
            }

            if (request != null && request.Count() > 0)
            {
                requestNumber = Convert.ToInt32(request.First().RequestNumber) + 1;
            }

            UserRequest userRequest = new UserRequest
            {
                CollectorId = collector.Id,
                GarbageId = garbage.Id,
                GarbageTypeId = garbageCollectorType.Id,
                Id = requestId,
                RequestNumber = requestNumber.ToString(),
                RequestTime = DateTime.Now,
                ScheduleTime = scheduleDateTime,
                UserAddress = address.HouseNo + ", " + address.HouseName + ", " + address.ApartmentName + ", " + address.Street + ", " + address.Locality,
                UserId = auth.UserId,
                Quantity = quantity,
                DonateGarbage = donateGarbage
            };

            context.UserRequests.InsertOnSubmit(userRequest);
            SubmitData();

            return scheduleDateTime.ToString("dd-MMM-yyyy") + " " + scheduleDateTime.ToLongTimeString();
        }

        /// <summary>
        /// UpdateLastCollectionTime
        /// </summary>
        /// <param name="date"></param>
        public void UpdateLastCollectionTime()
        {
            var frequencies = context.CollectorFrequencies;

            foreach (var frequency in frequencies)
            {
                double frequencyType = Convert.ToDouble(frequency.FrequencyType);
                DateTime lastUpdateDate = frequency.LastUpdateDate;

                if (DateTime.Compare(lastUpdateDate.AddDays(frequencyType), DateTime.Now) <= 0 &&
                    lastUpdateDate.ToShortDateString() != DateTime.Now.AddDays(-1).ToShortDateString())
                {
                    frequency.LastUpdateDate = DateTime.Now.AddDays(-1);
                }
            }

            SubmitData();
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
        /// DeleteCollector
        /// </summary>
        /// <param name="mobile"></param>
        public void DeleteCollector(string mobile)
        {
            var collector = context.Collectors.Where(@w => @w.Mobile == mobile).First();
            var frequecies = context.CollectorFrequencies.Where(@w => @w.Id == collector.FrequencyId);
            var slots = context.CollectorSlots.Where(@w => @w.FrequencyId == collector.FrequencyId);
            var garbageTypes = context.CollectorGarbageTypes.Where(@w => @w.CollectorId == collector.Id);

            context.Collectors.DeleteOnSubmit(collector);
            context.CollectorFrequencies.DeleteAllOnSubmit(frequecies);
            context.CollectorSlots.DeleteAllOnSubmit(slots);
            context.CollectorGarbageTypes.DeleteAllOnSubmit(garbageTypes);

            SubmitData();
        }

        /// <summary>
        /// Submit Database Changes
        /// </summary>
        private void SubmitData()
        {
            context.SubmitChanges();
        }
    }
}
