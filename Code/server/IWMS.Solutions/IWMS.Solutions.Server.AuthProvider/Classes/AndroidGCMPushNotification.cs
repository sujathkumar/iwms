using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Specialized;

namespace IWMS.Solutions.Server.AuthProvider
{
    public class AndroidGCMPushNotification
    {
        public void SendNotification(string action, string message, string gcmtoken)
        {
            string regId = gcmtoken;
            var applicationID = "AIzaSyCWAUaOoXnDuGltmH3xmGsKJylzGbFA6kc";
            var SENDER_ID = "361344693527";
            var value = message;
            WebRequest tRequest;
            tRequest = WebRequest.Create("https://gcm-http.googleapis.com/gcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            //Data post to server                                                                                                                                         
            string postData = "time_to_live=108&delay_while_idle=1&data.message="
                  + value + "&data.action=" + action + "&registration_id=" +
                     regId + "";

            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;
            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse tResponse = tRequest.GetResponse();
            dataStream = tResponse.GetResponseStream();
            StreamReader tReader = new StreamReader(dataStream);
            String sResponseFromServer = tReader.ReadToEnd();
            string response = sResponseFromServer;
            tReader.Close();
            dataStream.Close();
            tResponse.Close();
        }

        public void SendTopicNotification(string message, string topic)
        {
            var applicationID = "AIzaSyCWAUaOoXnDuGltmH3xmGsKJylzGbFA6kc";
            var SENDER_ID = "361344693527";
            string postData = "{ \"to\" : \"/topics/" + topic + "\", \"data\": {\"message\": \"" + message + "\" } }";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://gcm-http.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = "application/json";
            Request.Headers.Add(string.Format("Authorization: key={0}", applicationID));
            Request.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    //log
                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    //log
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();
            }
            catch (Exception e)
            {
            }
        }
    }
}