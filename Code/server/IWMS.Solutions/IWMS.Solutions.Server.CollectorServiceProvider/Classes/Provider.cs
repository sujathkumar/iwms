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

        public IList<CollectorPoint> RetrieveCollectors()
        {
            IList<CollectorPoint> collectorList = new List<CollectorPoint>();
            var collectors = context.Collectors;

            foreach (var collector in collectors)
            {
                var ward = context.Wards.Where(@w => @w.Id == collector.WardId).First();
                collectorList.Add(new CollectorPoint { Name = collector.Name, Address = collector.Address, Mobile = collector.Mobile, Ward = ward.Name });
            }

            return collectorList;
        }

        /// <summary>
        /// RetrieveCollector
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CollectorPoint RetrieveCollector(string mobile, string password)
        {
            var collector = context.Collectors.Where(@w => @w.Mobile == mobile && @w.Password == password).First();
            var ward = context.Wards.Where(@w=>@w.Id == collector.WardId).First();

            return new CollectorPoint { Name = collector.Name, Address = collector.Address, Mobile = collector.Mobile, Ward = ward.Name };
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
            var slot = context.CollectorSlots.Where(@w => @w.FrequencyId == collector.FrequencyId).First();

            return new FrequencyPoint { PickupFrequency = frequency.PickupFrequency, FrequencyType = frequency.FrequencyType, 
                Capacity = frequency.Capacity, LastUpdateDate = frequency.LastUpdateDate, SlotFrom = slot.SlotFrom, SlotTo = slot.SlotTo };
        }

        /// <summary>
        /// RetrieveRequest
        /// </summary>
        /// <param name="collectorId"></param>
        /// <returns></returns>
        public RequestPoint RetrieveRequest(Guid collectorId)
        {
            var requests = context.UserRequests.Where(@w => @w.CollectorId == collectorId).First();
            var garbage = context.Garbages.Where(@w => @w.Id == requests.GarbageId).First();
            var garbageType = context.GarbageTypes.Where(@w => @w.Id == requests.GarbageTypeId).First();
            var user = context.Users.Where(@w => @w.Id == requests.UserId).First();
            var address = context.Addresses.Where(@w => @w.UserId == requests.UserId).First();

            return new RequestPoint
            {
                RequestNumber = requests.RequestNumber,
                RequestTime = requests.RequestTime,
                ScheduleTime = requests.ScheduleTime,
                Tag = garbage.Tag,
                GarbageType = garbageType.Type,
                UserName = user.Name,
                UserAddress = address.HouseNo + ", " +  address.HouseName + ", " +address.ApartmentName + ", " +address.Street + ", " + address.Locality
            };
        }

        /// <summary>
        /// IsUserPresent
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public string RetrieveCredentials(string mobile)
        {
            var collector = context.Collectors.Where(@w => @w.Mobile == mobile);

            if(collector.Count() > 0)
            {
                return collector.First().Name + "," + collector.First().Password;
            }

            return string.Empty;
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
