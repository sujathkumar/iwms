using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.SpotImage.Models;

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
