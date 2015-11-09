using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.SuggestionServiceProvider.Models;

namespace IWMS.Solutions.Server.SuggestionServiceProvider
{
    public class Provider
    {
        #region Members
        private SuggestionServiceModelDataContext context = null;
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new SuggestionServiceModelDataContext();
            }
        }
        #endregion

        /// <summary>
        /// InsertComplaint
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        public int InsertComplaint(string key, string subject, string description)
        {
            var user = context.Auths.Where(@w => @w.Key == key).First();
            int referenceNumber = 1;
            var complaints = context.Complaints.OrderByDescending(@orderby => @orderby.ReferenceNumber);

            if(complaints!=null && complaints.Count() > 0)
            {
                referenceNumber = complaints.First().ReferenceNumber + 1;
            }

            Complaint complaint = new Complaint
            {
                Id = Guid.NewGuid(),
                Subject = subject,
                Description = description,
                UserId = user.UserId,
                ReferenceNumber = referenceNumber
            };

            context.Complaints.InsertOnSubmit(complaint);
            SubmitData();

            return referenceNumber;
        }

        /// <summary>
        /// InsertSuggestion
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        public int InsertSuggestion(string key, string subject, string description)
        {
            var user = context.Auths.Where(@w => @w.Key == key).First();
            int referenceNumber = 1;
            var suggestions = context.Suggestions.OrderByDescending(@orderby => @orderby.ReferenceNumber);

            if (suggestions != null && suggestions.Count() > 0)
            {
                referenceNumber = suggestions.First().ReferenceNumber + 1;
            }

            Suggestion suggestion = new Suggestion
            {
                Id = Guid.NewGuid(),
                Subject = subject,
                Description = description,
                UserId = user.UserId,
                ReferenceNumber = referenceNumber
            };

            context.Suggestions.InsertOnSubmit(suggestion);
            SubmitData();

            return referenceNumber;
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
