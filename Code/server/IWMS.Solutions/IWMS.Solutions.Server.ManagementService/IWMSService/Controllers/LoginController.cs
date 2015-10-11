using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auth = IWMS.Solutions.Server.AuthProvider;

namespace ManagementService.Controllers
{
    public class LoginController : ApiController
    {
        public string GetLogin(string key)
        {
            var values = key.Split('|');

            if (values.Length > 0)
            {
                Auth.Provider provider = new Auth.Provider();

                string method = values[0].ToLower();

                if (method == "authenticate")
                {
                    string data = values[1].Split('=')[1];
                    return provider.AuthenticateUser(data).ToString();
                }
                else if (method == "signup")
                {
                    string name = values[1].Split('=')[1];
                    string mobile = values[2].Split('=')[1];
                    string cityCode = values[3].Split('=')[1];
                    return provider.SignupUser(name, mobile, cityCode).ToString();
                }
                else if (method == "csp")
                {
                    string name = values[1];
                    string mobile = values[2];
                    string cityCode = values[3];
                    string applicationId = values[4];
                    string gcmToken = "";
                    if (values.Length > 5 && values[5] != null && !string.IsNullOrEmpty(values[5]))
                    {
                        gcmToken = values[5].Replace("c_olon", ":");
                    }
                    string refCode = "";
                    if (values.Length > 6 && values[6] != null && !string.IsNullOrEmpty(values[6]))
                    {
                        refCode = values[6];
                    }
                    return provider.ConfirmUserSignup(name, mobile, cityCode, applicationId, gcmToken, refCode);
                }
                else if (method == "si")
                {
                    string name = values[1];
                    string mobile = values[2];
                    string cityCode = values[3];
                    string gcmToken = "";
                    if (values.Length > 4 && values[4] != null && !string.IsNullOrEmpty(values[4]))
                    {
                        gcmToken = values[4].Replace("c_olon", ":");
                    }
                    return provider.SigninUser(name, mobile, cityCode, gcmToken).ToString();
                }
                else if (method == "confirmsignin")
                {
                    string mobile = values[1].Split('=')[1];
                    string data = values[2].Split('=')[1];
                    return provider.ConfirmUserSignin(mobile, data).ToString();
                }
                else if (method == "registerkey")
                {
                    string mobile = values[1].Split('=')[1];
                    string data = values[2].Split('=')[1];
                    return provider.RegisterUserKey(data, mobile).ToString();
                }
                else if (method == "du")
                {
                    string mobile = values[1];
                    return provider.DeleteUser(mobile).ToString();
                }
                else if (method == "dau")
                {
                    return provider.DeleteAllUsers().ToString();
                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return "Error, Not Found!";
        }
    }
}
