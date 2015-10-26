using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.PointServiceProvider.Models;

namespace IWMS.Solutions.Server.PointServiceProvider
{
    public class Provider
    {
        #region Members
        private PointServiceModelDataContext context = null;
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new PointServiceModelDataContext();
            }
        }
        #endregion

        /// <summary>
        /// RetrievePoints
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrievePoints(string key)
        {
            int totalPoints = 0;
            var user = context.Auths.Where(@w => @w.Key == key).First();
            var points = context.Points.Where(@w => @w.UserId == user.UserId);

            foreach(var point in points)
            {
                totalPoints += point.Point1;
            }

            return totalPoints.ToString();
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
