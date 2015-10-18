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
                    UserAddress = address.HouseNo + ", " + address.HouseName + ", " + address.ApartmentName + ", " + address.Street + ", " + address.Locality
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

                if(DateTime.Compare(lastUpdateDate.AddDays(frequencyType), DateTime.Now) <= 0 &&
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
