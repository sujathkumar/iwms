using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using IWMS.Solutions.Server.SpotImage.Models;
using WardData = IWMS.Solutions.Server.WardDataProvider;

namespace IWMS.Solutions.Server.SpotImageServiceProvider
{
    public class Provider
    {
        #region Members
        private SpotImageModelDataContext context = null;
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new SpotImageModelDataContext();
            }
        }
        #endregion

        /// <summary>
        /// RetrievSpotImages
        /// </summary>
        /// <returns></returns>
        public IList<SpotImagePoint> RetrievSpotImages()
        {
            IList<SpotImagePoint> spotImageList = new List<SpotImage.Models.SpotImagePoint>();
            var spotImages = context.SpotImages;

            foreach (var spotImage in spotImages)
            {
                var ward = context.Wards.Where(@w => @w.Id == spotImage.WardId).First();
                var user = context.Users.Where(@w => @w.Id == spotImage.UserId).First();
                spotImageList.Add(new SpotImagePoint { Id = spotImage.Id, ImagePath = spotImage.ImagePath, Latitude = spotImage.Latitude, Longitude = spotImage.Longitude, UploadedTime = spotImage.UploadedTime, UserAddress = spotImage.UserAddress, UserName = user.Name, Verified = spotImage.Verified, WardName = ward.Name });
            }

            return spotImageList;
        }

        /// <summary>
        /// RetrievSpotImage
        /// </summary>
        /// <returns></returns>
        public SpotImagePoint RetrievSpotImage(string imagePath)
        {
            var spotImage = context.SpotImages.Where(@w => @w.ImagePath.Contains(imagePath)).First();
            var ward = context.Wards.Where(@w => @w.Id == spotImage.WardId).First();
            var user = context.Users.Where(@w => @w.Id == spotImage.UserId).First();
            return new SpotImagePoint { Id = spotImage.Id, ImagePath = spotImage.ImagePath, Latitude = spotImage.Latitude, Longitude = spotImage.Longitude, UploadedTime = spotImage.UploadedTime, UserAddress = spotImage.UserAddress, UserName = user.Name, Verified = spotImage.Verified, WardName = ward.Name };
        }

        /// <summary>
        /// InsertSpotImage
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="wardName"></param>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        public string InsertSpotImage(string key, string latitude, string longitude, string imageData)
        {
            string imagePath = @"C:\Images\" + DateTime.Today.Day.ToString() +
                 DateTime.Today.Month.ToString() +
                  DateTime.Today.Year.ToString();

            imagePath = imagePath + @"\" + imageData;

            var auth = context.Auths.Where(@w => @w.Key == key).First();

            SpotImage.Models.SpotImage spotImage = new SpotImage.Models.SpotImage
            {
                Id = Guid.NewGuid(),
                ImagePath = imageData,
                Latitude = latitude,
                Longitude = longitude,
                UploadedTime = DateTime.Now,
                UserId = auth.UserId,
                Verified = false
            };

            context.SpotImages.InsertOnSubmit(spotImage);
            SubmitData();

            return "212";
        }

        /// <summary>
        /// InsertEvent
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="spotImageId"></param>
        public void InsertEvent(string name, DateTime date, Guid spotImageId)
        {
            Event cgEvent = new Event
            {
                Id = Guid.NewGuid(),
                EventName = name,
                EventDate = date,
                SpotImageId = spotImageId
            };

            context.Events.InsertOnSubmit(cgEvent);
            SubmitData();
        }

        /// <summary>
        /// PostImage
        /// </summary>
        /// <param name="image"></param>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public string PostImage(string image, string byteArray)
        {
            string imagePath = @"C:\Images\" + DateTime.Today.Day.ToString() +
                 DateTime.Today.Month.ToString() +
                  DateTime.Today.Year.ToString();
            string filePath = imagePath + "\\" + image;

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

            var bytes = Convert.FromBase64String(byteArray);
            using (var imageFile = new FileStream(filePath, FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }

            return filePath;
        }

        /// <summary>
        /// PostSpotImageProcess
        /// </summary>
        public void PostSpotImageProcess()
        {
            var spotImages = context.SpotImages.Where(@w => @w.WardId == null && @w.UserAddress == null);
            WardData.Provider provider = new WardData.Provider();

            foreach (var spotImage in spotImages)
            {
                var ward = provider.RetrieveWard(spotImage.Latitude, spotImage.Longitude);
                spotImage.WardId = context.Wards.Where(@w => @w.Name == ward).First().Id;

                string url = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false", spotImage.Latitude, spotImage.Longitude);
                XElement xml = XElement.Load(url);

                if (xml.Element("status").Value == "OK")
                {
                    spotImage.UserAddress = xml.Element("result").Element("formatted_address").Value;
                }
            }

            SubmitData();
        }

        /// <summary>
        /// VerifySpotImage
        /// </summary>
        /// <param name="spotImageId"></param>
        public void VerifySpotImage(string imagePath)
        {
            var spotImage = context.SpotImages.Where(@w => @w.ImagePath.Contains(imagePath)).First();
            var user = context.Users.Where(@w => @w.Id == spotImage.UserId).First();

            InsertSpotImagePoints(user.Id);

            spotImage.Verified = true;
            SubmitData();
        }

        /// <summary>
        /// InsertRegistrationPoints
        /// </summary>
        /// <param name="userId"></param>
        private void InsertSpotImagePoints(Guid userId)
        {
            var urPoints = context.PointConfigurations.Where(@w => @w.Type == "SG").First();

            Point point = new Point
            {
                Id = Guid.NewGuid(),
                Point1 = urPoints.Point,
                UserId = userId
            };

            context.Points.InsertOnSubmit(point);
            context.SubmitChanges();
        }

        /// <summary>
        /// DeleteSpotImage
        /// </summary>
        /// <param name="mobile"></param>
        public void DeleteSpotImage(string imagePath)
        {
            var spotImage = context.SpotImages.Where(@w => @w.ImagePath.Contains(imagePath)).First();
            context.SpotImages.DeleteOnSubmit(spotImage);
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
