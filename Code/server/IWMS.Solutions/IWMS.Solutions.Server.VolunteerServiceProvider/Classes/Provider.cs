using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.VolunteerServiceProvider.Models;
using Ward = IWMS.Solutions.Server.WardDataProvider;
using Auth = IWMS.Solutions.Server.AuthProvider;
using System.IO;

namespace IWMS.Solutions.Server.VolunteerServiceProvider
{
    public class Provider
    {
        #region Members
        private VolunteerServiceModelDataContext context = null;
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new VolunteerServiceModelDataContext();
            }
        }
        #endregion

        /// <summary>
        /// RetrieveGCMToken
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveGCMToken(string key)
        {
            return context.Auths.Where(@w => @w.Key == key).First().GCMToken;
        }

        /// <summary>
        /// RetrieveVolunteerSubscription
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveVolunteerSubscription(string key)
        {
            var user = context.Auths.Where(@w => @w.Key == key).First();
            var volunteer = context.Volunteers.Where(@w => @w.UserId == user.UserId);

            if (volunteer != null && volunteer.Count() > 0)
            {
                var ward = context.Wards.Where(@w => @w.Id == volunteer.First().WardId).First();
                var zone = context.Zones.Where(@w => @w.Id == ward.ZoneId).First();
                string topicName = zone.Name.Replace('"', ' ').Trim() + "-" + ward.Name.Replace('"', ' ').Trim();
                var topic = context.Topics.Where(@w => @w.Name == topicName).First();
                return topic.Name;
            }

            return "";
        }

        /// <summary>
        /// RetrieveVolunteerEvents
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveVolunteerEvents(string key)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var volunteer = context.Volunteers.Where(@w => @w.UserId == user.UserId).First();
                var volunteerEvents = context.EventVolunteerMaps.Where(@w => @w.VolunteerId == volunteer.Id);
                StringBuilder sb = new StringBuilder();

                if (volunteerEvents != null)
                {
                    foreach (var ve in volunteerEvents)
                    {
                        var ev = context.Events.Where(@w => @w.Id == ve.EventId);
                        if (ev != null && ev.Count() > 0)
                        {
                            if (ev.First().Cleared == null)
                            {
                                sb.Append(ev.First().Id + "_" + ev.First().EventName + " on " + ev.First().EventDate.ToString("dd/MMM/yyyy") + ",");
                            }
                        }
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = File.AppendText(@"C:\IWMSLog.txt"))
                {
                    Log(ex.Message, sw);
                }

                return null;
            }
        }

        /// <summary>
        /// RetrieveVolunteerUsersList
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveVolunteerUsersList(string key)
        {
            try
            {
                var auth = context.Auths.Where(@w => @w.Key == key).First();
                var volunteer = context.Volunteers.Where(@w => @w.UserId == auth.UserId).First();
                var ncus = context.NonComplaintUsers.Where(@w => @w.VolunteerId == volunteer.Id && @w.Accepted == true);
                StringBuilder sb = new StringBuilder();

                if (ncus != null)
                {
                    foreach (var ncu in ncus)
                    {
                        var user = context.Users.Where(@w => @w.Id == ncu.UserId).First();
                        if (ncu.Processed == null)
                        {
                            sb.Append(user.Id + "_" + user.Name + " Mob: " + user.Mobile + ",");
                        }
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = File.AppendText(@"C:\IWMSLog.txt"))
                {
                    Log(ex.Message, sw);
                }

                return null;
            }
        }

        /// <summary>
        /// InsertVolunteer
        /// </summary>
        /// <param name="key"></param>
        /// <param name="wardName"></param>
        /// <returns></returns>
        public int InsertVolunteer(string key, string wardName)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var ward = context.Wards.Where(@w => @w.Name.Trim() == wardName).First();
                var zone = context.Zones.Where(@w => @w.Id == ward.ZoneId).First();
                string topicName = zone.Name.Replace('"', ' ').Trim() + "-" + ward.Name.Replace('"', ' ').Trim();
                var topic = context.Topics.Where(@w => @w.Name == topicName).First();

                Volunteer volunteer = new Volunteer()
                {
                    Id = Guid.NewGuid(),
                    UserId = user.UserId,
                    WardId = ward.Id
                };

                var volunteers = context.Volunteers.Where(@w => @w.UserId == user.UserId);

                if (volunteers != null && volunteers.Count() > 0)
                {
                    return 104;
                }

                context.Volunteers.InsertOnSubmit(volunteer);
                SubmitData();

                TopicUserMap topicUserMap = new TopicUserMap
                {
                    Id = Guid.NewGuid(),
                    TopicId = topic.Id,
                    UserId = user.Id
                };

                context.TopicUserMaps.InsertOnSubmit(topicUserMap);
                SubmitData();

                InsertVolunteerRegistrationPoints(user.Id);

                return 215;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        /// <summary>
        /// InsertEventVolunteerMap
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int InsertEventVolunteerMap(string key, string eventId)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var volunteer = context.Volunteers.Where(@w => @w.UserId == user.UserId).First();

                EventVolunteerMap map = new EventVolunteerMap
                {
                    Id = Guid.NewGuid(),
                    EventId = Guid.Parse(eventId),
                    VolunteerId = volunteer.Id
                };

                context.EventVolunteerMaps.InsertOnSubmit(map);
                SubmitData();

                return 216;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        public void InsertTopics()
        {
            string[] sep = new string[] { "," };
            IList<Topic> topics = new List<Topic>();
            Ward.Provider provider = new Ward.Provider();
            var zones = provider.RetrieveZones();

            if (zones != null && zones.Count() > 0)
            {
                foreach (var zone in zones.Split(sep, StringSplitOptions.RemoveEmptyEntries))
                {
                    var wards = provider.RetrieveWards(zone);

                    if (wards != null && wards.Count() > 0)
                    {
                        foreach (var ward in wards.Split(sep, StringSplitOptions.RemoveEmptyEntries))
                        {
                            Topic topic = new Topic
                            {
                                Id = Guid.NewGuid(),
                                Name = zone.Replace('"', ' ').Trim() + "-" + ward.Replace('"', ' ').Trim()
                            };

                            topics.Add(topic);
                        }
                    }
                }
            }

            context.Topics.InsertAllOnSubmit(topics.AsEnumerable());
            SubmitData();
        }

        /// <summary>
        /// InsertVolunteerRegistrationPoints
        /// </summary>
        /// <param name="userId"></param>
        private void InsertVolunteerRegistrationPoints(Guid userId)
        {
            var urPoints = context.PointConfigurations.Where(@w => @w.Type == "VR").First();

            Point point = new Point
            {
                Id = Guid.NewGuid(),
                Point1 = urPoints.Point,
                UserId = userId
            };

            context.Points.InsertOnSubmit(point);
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
