using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using IWMS.Solutions.Server.AuthProvider.Models;

namespace IWMS.Solutions.Server.AuthProvider
{
    public class Provider
    {
        /// <summary>
        /// Retrieve City Details
        /// </summary>
        /// <returns></returns>
        public IList<CityPoint> RetrieveCityDetails()
        {
            IList<CityPoint> cityList = new List<CityPoint>();
            DataAccessDataContext ctx = new DataAccessDataContext();
            var cities = ctx.Cities.Where(@w => @w.Active).ToList();

            foreach (var city in cities)
            {
                cityList.Add(new CityPoint { Name = city.Name, Code = city.Number, Server = city.Server });
            }

            return cityList;
        }

        public int AuthenticateUser(string key)
        {
            DataAccessDataContext ctx = new DataAccessDataContext();
            bool isExists = ctx.Auths.Where(@w => @w.Key == key).Count() == 1;

            if (isExists)
            {
                return 201;
            }
            else
            {
                return 101;
            }
        }

        public int SignupUser(string name, string mobile, string cityCode)
        {
            DataAccessDataContext ctx = new DataAccessDataContext();
            bool isExists = ctx.Users.Where(@w => @w.Name == name && @w.Mobile == mobile).Count() == 1;

            if (isExists)
            {
                return 102;
            }
            else
            {
                Random rm = new Random();
                int vc = rm.Next(1000, 9999);
                SendSMS(mobile, vc);
                return vc;
            }
        }

        private void SendSMS(string mobile, int vc)
        {
            //Your authentication key
            string authKey = "94390AuyaH8Pb56127557";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "IWMSBL";
            //Your message to send, Add URL encoding here.
            string message = HttpUtility.UrlEncode(vc.ToString());

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobile);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "template");

            try
            {
                //Call Send SMS API
                string sendSMSUri = "https://control.msg91.com/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                throw new Exception("Error while sending SMS");
            }
        }

        /// <summary>
        /// Confirm User Signup
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="cityCode"></param>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public string ConfirmUserSignup(string name, string mobile, string cityCode, string applicationId, string gcmToken, string refCode)
        {
            string key = string.Empty;

            try
            {
                string referralCode = GenerateReferralCode();
                key = cityCode + name + mobile + applicationId;
                DataAccessDataContext ctx = new DataAccessDataContext();
                Guid cityId = RetrieveCity(cityCode, ctx);                
                Guid userId = InsertUserMetaData(name, mobile, ctx, cityId);
                Guid addressId = InsertAddressMetaData(ctx, userId);
                Guid authId = InsertAuthSingleMetaData(applicationId, gcmToken, refCode, referralCode, key, ctx, userId);

                if (!string.IsNullOrEmpty(gcmToken))
                {
                    SendNotification(gcmToken, referralCode);
                }

                return key;

            }
            catch (Exception ex)
            {
                key = "100";
            }

            return key;
        }

        /// <summary>
        /// SendNotification
        /// </summary>
        public void SendNotification(string gcmToken, string referralCode)
        {
            AndroidGCMPushNotification notification = new AndroidGCMPushNotification();
            notification.SendNotification("Welcome to ClearTrash! Your REF_CODE is " + referralCode, gcmToken);
        }

        /// <summary>
        /// InsertUserMetaData
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="ctx"></param>
        /// <param name="cityId"></param>
        /// <param name="addressId"></param>
        /// <param name="authId"></param>
        private static Guid InsertUserMetaData(string name, string mobile, DataAccessDataContext ctx, Guid cityId)
        {
            //Insert User Information.
            Guid userId = Guid.NewGuid();
            User user = new User
            {
                Id = userId,
                Name = name,
                Mobile = mobile,
                CityId = cityId,
                Active = true,
            };

            ctx.Users.InsertOnSubmit(user);
            ctx.SubmitChanges();

            return userId;
        }

        /// <summary>
        /// InsertAuthSingleMetaData
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="key"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private static Guid InsertAuthSingleMetaData(string applicationId, string gcmToken, string refCode, string genRefCode, string key, DataAccessDataContext ctx, Guid userId)
        {
            //Insert Auth key
            Guid authId = Guid.NewGuid();
            Auth authSingle = new Auth
            {
                Id = authId,
                GCMToken = gcmToken,
                REFCODE = genRefCode,
                Key = key,
                ApplicationId = applicationId,
                UserId = userId
            };

            ctx.Auths.InsertOnSubmit(authSingle);
            ctx.SubmitChanges();
            return authId;
        }

        /// <summary>
        /// GenerateReferralCode
        /// </summary>
        /// <returns></returns>
        private string GenerateReferralCode()
        {
            bool flag = false;
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rm = new Random();
            string refCode = "";
            DataAccessDataContext ctx = new DataAccessDataContext();

            while (!flag)
            {
                refCode = new string(Enumerable.Repeat(alphabet, 4).Select(@s => @s[rm.Next(4)]).ToArray()) + "01";
                flag = ctx.Auths.Where(@s => @s.REFCODE.Equals(refCode)).Count() == 0;
            }

            return refCode;
        }

        /// <summary>
        /// InsertAddressMetaData
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private static Guid InsertAddressMetaData(DataAccessDataContext ctx, Guid userId)
        {
            //Insert Address
            Guid addressId = Guid.NewGuid();
            Address address = new Address
            {
                Id = addressId,
                HouseNo = "",
                Street = "",
                Locality = "",
                WardId = Guid.NewGuid(),
                PINCODE = 560093,
                Registered = false,
                UserId = userId
            };

            ctx.Addresses.InsertOnSubmit(address);
            ctx.SubmitChanges();
            return addressId;
        }

        /// <summary>
        /// Retrieve City
        /// </summary>
        /// <param name="cityCode"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private static Guid RetrieveCity(string cityCode, DataAccessDataContext ctx)
        {
            //Get City
            Guid cityId = ctx.Cities.Where(@w => @w.Number == cityCode).First().Id;
            return cityId;
        }

        /// <summary>
        /// Signin User
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="cityCode"></param>
        /// <returns></returns>
        public int SigninUser(string name, string mobile, string cityCode, string gcmToken)
        {
            DataAccessDataContext ctx = new DataAccessDataContext();
            var user = ctx.Users.Where(@w => @w.Name == name && @w.Mobile == mobile);
            bool isExists = user.Count() == 1;

            if (!isExists)
            {
                return 103;
            }
            else
            {
                if (!string.IsNullOrEmpty(gcmToken))
                {
                    var authSingle = ctx.Auths.Where(@w => @w.UserId == user.First().Id).First();
                    authSingle.GCMToken = gcmToken;
                    ctx.SubmitChanges();
                }

                return 202;
            }
        }

        /// <summary>
        /// Confirm User Signin
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int ConfirmUserSignin(string mobile, string key)
        {
            DataAccessDataContext ctx = new DataAccessDataContext();
            bool isExists = ctx.Auths.Where(@w => @w.Key == key).Count() == 1;

            if (isExists)
            {
                return 201;
            }
            else
            {
                Random rm = new Random();
                int vc = rm.Next(1000, 9999);
                SendSMS(mobile, vc);
                return vc;
            }
        }

        /// <summary>
        /// RegisterKey
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mobileNumber"></param>
        /// <returns></returns>
        public int RegisterUserKey(string key, string mobile)
        {
            DataAccessDataContext ctx = new DataAccessDataContext();
            var user = ctx.Users.Where(@w => @w.Mobile == mobile).First();
            var authSingle = ctx.Auths.Where(@w => @w.UserId == user.Id).First();

            authSingle.Key = key;
            authSingle.ApplicationId = key.Replace(user.Name, "").Replace(mobile, "");
            ctx.SubmitChanges();

            return 203;
        }

        /// <summary>
        /// DeleteUser
        /// </summary>
        /// <param name="mobile"></param>
        public int DeleteUser(string mobile)
        {
            DataAccessDataContext ctx = new DataAccessDataContext();
            var userList = ctx.Users.ToList();
            foreach(var user in userList)
            {
                ctx.Users.DeleteOnSubmit(user);
            }

            var addressList = ctx.Addresses.ToList();
            foreach (var address in addressList)
            {
                ctx.Addresses.DeleteOnSubmit(address);
            }

            var authList = ctx.Auths.ToList();

            foreach (var auth in authList)
            {
                ctx.Auths.DeleteOnSubmit(auth);
            }

            ctx.SubmitChanges();

            return 204;
        }

        public int DeleteAllUsers()
        {
            DataAccessDataContext ctx = new DataAccessDataContext();
            
            var userList = ctx.Users.ToList();
            ctx.Users.DeleteAllOnSubmit(userList);

            var addressList = ctx.Addresses.ToList();
            ctx.Addresses.DeleteAllOnSubmit(addressList);

            var authList = ctx.Auths.ToList();
            ctx.Auths.DeleteAllOnSubmit(authList);

            ctx.SubmitChanges();

            return 204;
        }
    }
}
