using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWMS.Solutions.Server.WardDataProvider.Models;
using Auth = IWMS.Solutions.Server.AuthProvider;
using WardData = IWMS.Solutions.Server.WardDataProvider;
using BinService = IWMS.Solutions.Server.BinServiceProvider;
using System.Net;


namespace IWMS.Solutions.Server.TestConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
            {
                //Console.WriteLine("*********************************************************");
                //Console.WriteLine("Select Options\n");
                //Console.WriteLine("*********************************************************");
                //Console.WriteLine("1. Insert Ward Cordinates 2. Insert Locality 3. Get Ward Details based on Cordinates 4. Get Ward Details based on Locality");
                //string selection = Console.ReadLine();
                //if (selection == "1")
                //{
                //    //Insert Cordinates for Ward
                //    ProcessCordinateDataforWards();
                //}
                //else if (selection == "2")
                //{
                //    //Insert Locality for Ward
                //    ProcessLocalityDataforWards();
                //}
                //else if (selection == "3")
                //{
                //    //Select Ward Information based on Cordinates
                //    RetrieveWardDataforCordinates();
                //}
                //else if (selection == "4")
                //{
                //    //Select Ward Information based on Locality
                //    RetrieveWardDataforLocality();
                //}
                //else if (selection == "5")
                //{
                //    RetrieveLocalities();
                //}

                //Console.WriteLine("*********************************************************");
                //Console.WriteLine("Select Options\n");
                //Console.WriteLine("*********************************************************");
                //Console.WriteLine("1. Get Locations 2. Authenticate 3. Signup 4. Confirm Signup 5. Sigin 6. Confirm Signin 7. Register key 8. Delete User 9. Delete All Users");
                //string selection = Console.ReadLine();
                //if (selection == "1")
                //{
                //    RetrieveCities();
                //}
                //else if (selection == "2")
                //{
                //    AuthenticateUser();
                //}
                //else if (selection == "3")
                //{
                //    SignupUser();
                //}
                //else if (selection == "4")
                //{
                //    ConfirmUserSignup();
                //}
                //else if (selection == "5")
                //{
                //    SigninUser();
                //}
                //else if (selection == "6")
                //{
                //    ConfirmUserSignin();
                //}
                //else if (selection == "7")
                //{
                //    RegisterUserKey();
                //}
                //else if(selection == "8")
                //{
                //    DeleteUser();
                //}
                //else if(selection == "9")
                //{
                //    DeleteAllUsers();
                //}

                Console.WriteLine("*********************************************************");
                Console.WriteLine("Select Options\n");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("1. Retrieve House Hold User Information");
                string selection = Console.ReadLine();
                if (selection == "")
                {
                    RetrieveHHUserInfo();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private static void RetrieveHHUserInfo()
        {
            Console.WriteLine("Input Key");
            string key = Console.ReadLine();

            BinService.Provider provider = new BinService.Provider();
            provider.RetrieveHHUserInfo(key);
        }

        /// <summary>
        /// Authenticate User
        /// </summary>
        private static void AuthenticateUser()
        {
            Console.WriteLine("Input Key");
            string key = Console.ReadLine();

            Auth.Provider provider = new Auth.Provider();
            int code = provider.AuthenticateUser(key);

            switch (code)
            {
                case 201: Console.WriteLine("User Authenticated, Key available!");
                    break;
                case 101: Console.WriteLine("Error, key not available!");
                    break;
            }
        }

        /// <summary>
        /// Signup User
        /// </summary>
        private static void SignupUser()
        {
            Console.WriteLine("Input Name");
            string name = Console.ReadLine();

            Console.WriteLine("Input Mobile");
            string mobileNumber = Console.ReadLine();

            Console.WriteLine("Input City Code");
            string cityCode = Console.ReadLine();

            Auth.Provider provider = new Auth.Provider();
            int code = provider.SignupUser(name, mobileNumber, cityCode);

            if (code > 999 && code < 10000)
            {
                int vc = code;
                Console.WriteLine("The verification code is " + vc.ToString());
            }
            else
            {
                switch (code)
                {
                    case 102: Console.WriteLine("Error, User already registered, please login!");
                        break;
                }
            }
        }

        /// <summary>
        /// Confirm User Verification Code Confirmation
        /// </summary>
        private static void ConfirmUserSignup()
        {
            Console.WriteLine("Input Name");
            string name = Console.ReadLine();

            Console.WriteLine("Input Mobile");
            string mobileNumber = Console.ReadLine();

            Console.WriteLine("Input City Code");
            string cityCode = Console.ReadLine();

            Console.WriteLine("Input Application Id");
            string applicationId = Console.ReadLine();

            Console.WriteLine("Input GCM Token");
            string gcmToken = Console.ReadLine();

            Console.WriteLine("Input Referral Code");
            string refCode = Console.ReadLine();

            Auth.Provider provider = new Auth.Provider();
            string key = provider.ConfirmUserSignup(name, mobileNumber, cityCode, applicationId, gcmToken, refCode);

            int code;
            bool error = Int32.TryParse(key, out code);

            if (!error)
            {
                Console.WriteLine("The key generated is " + key);
            }
            else
            {
                switch (code)
                {
                    case 100: Console.WriteLine("Error!");
                        break;
                }
            }
        }

        /// <summary>
        /// Signin User
        /// </summary>
        private static void SigninUser()
        {
            Console.WriteLine("Input Name");
            string name = Console.ReadLine();

            Console.WriteLine("Input Mobile");
            string mobileNumber = Console.ReadLine();

            Console.WriteLine("Input City Code");
            string cityCode = Console.ReadLine();

            Console.WriteLine("Input Application Id");
            string applicationId = Console.ReadLine();

            Console.WriteLine("Input GCM Token");
            string gcmToken = Console.ReadLine();

            Auth.Provider provider = new Auth.Provider();
            int code = provider.SigninUser(name, mobileNumber, cityCode, gcmToken);

            switch (code)
            {
                case 202: Console.WriteLine("User Exists!");
                    Console.WriteLine("The key generated by the client is " + name + mobileNumber + applicationId);
                    break;
                case 103: Console.WriteLine("Error, User not registered, please signup!");
                    break;
            }
        }

        /// <summary>
        /// Confirm User Signin
        /// </summary>
        private static void ConfirmUserSignin()
        {
            Console.WriteLine("Input Mobile");
            string mobileNumber = Console.ReadLine();

            Console.WriteLine("Input Key");
            string key = Console.ReadLine();

            Auth.Provider provider = new Auth.Provider();
            int code = provider.ConfirmUserSignin(mobileNumber, key);

            if (code > 999 && code < 10000)
            {
                int vc = code;
                Console.WriteLine("The verification code is " + vc.ToString());
            }
            else
            {
                switch (code)
                {
                    case 201: Console.WriteLine("User Authenticated, Key available!");
                        break;
                }
            }
        }

        /// <summary>
        /// RegisterKey
        /// </summary>
        private static void RegisterUserKey()
        {
            Console.WriteLine("Input Mobile");
            string mobileNumber = Console.ReadLine();

            Console.WriteLine("Input Key");
            string key = Console.ReadLine();

            Auth.Provider provider = new Auth.Provider();
            int code = provider.RegisterUserKey(key, mobileNumber);

            switch (code)
            {
                case 203: Console.WriteLine("User Authenticated, Key available!");
                    break;
            }
        }

        /// <summary>
        /// Retrieve Localities
        /// </summary>
        private static void RetrieveLocalities()
        {
            Console.WriteLine("Input Locality Name");
            string localityName = Console.ReadLine();

            WardData.Provider provider = new WardData.Provider();
            var localities = provider.RetrieveLocalities(localityName);

            foreach (var locality in localities)
            {
                Console.WriteLine(locality.Name);
            }
        }

        private static void RetrieveCities()
        {
            Auth.Provider provider = new Auth.Provider();
            var cities = provider.RetrieveCityDetails();

            foreach (var city in cities)
            {
                Console.WriteLine(city.Code + ". " + city.Name + "Server: " + city.Server);
            }
        }

        /// <summary>
        /// RetrieveWardDataforLocality
        /// </summary>
        private static void RetrieveWardDataforLocality()
        {
            Console.WriteLine("Input Locality Name");
            string localityName = Console.ReadLine();

            WardData.Provider provider = new WardData.Provider();
            string wardName = provider.RetrieveWard(localityName);
            Console.WriteLine("The ward name you belong is " + wardName);
        }

        /// <summary>
        /// ProcessLocalityDataforWards
        /// </summary>
        private static void ProcessLocalityDataforWards()
        {
            string[] files = Directory.GetFiles(@"C:\Users\nairs6\Downloads");

            foreach (var file in files)
            {
                if (file.Contains(".csv"))
                {
                    string path = file;
                    WardData.Provider provider = new WardData.Provider();
                    provider.InsertWard(path);
                }
            }
        }

        /// <summary>
        /// InsertWard Information from CSV
        /// </summary>
        private static void ProcessCordinateDataforWards()
        {
            string[] directories = Directory.GetDirectories(@"C:\Users\nairs6\Downloads");

            //Retrieve the Zone Details
            WardData.Provider provider = new WardData.Provider();
            foreach (var directory in directories)
            {
                if (!directory.Contains("Processed"))
                {
                    string zoneNumber = directory.Substring(directory.LastIndexOf('\\')).Split('-')[0].Replace("\\", "");
                    string zoneName = directory.Substring(directory.LastIndexOf('\\')).Split('-')[1].Replace(".txt", "");
                    provider.InsertZone(Convert.ToInt32(zoneNumber), zoneName);

                    Zone zone = provider.RetrieveZone(Convert.ToInt32(zoneNumber));

                    if (zone == null)
                    {
                        Environment.Exit(0);
                    }

                    Console.WriteLine("The zone selected is " + zone.Name);

                    string[] files = Directory.GetFiles(@"C:\Users\nairs6\Downloads\" + zoneNumber + "-" + zoneName);

                    foreach (var file in files)
                    {
                        if (file.Contains(".txt"))
                        {
                            string wardNumber = file.Substring(file.LastIndexOf('\\')).Split('-')[0].Replace("\\", "");
                            string wardName = file.Substring(file.LastIndexOf('\\')).Split('-')[1].Replace(".txt", "");
                            string path = file;
                            provider.InsertWard(zone.Id, Convert.ToInt32(wardNumber), wardName, path);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// RetrieveData
        /// </summary>
        private static void RetrieveWardDataforCordinates()
        {
            Console.WriteLine("Input Latitude");
            string latitude = Console.ReadLine();

            Console.WriteLine("Input Longitude");
            string longitude = Console.ReadLine();

            WardData.Provider provider = new WardData.Provider();
            string wardName = provider.RetrieveWard(latitude, longitude);
            Console.WriteLine("The ward name you belong is " + wardName);
        }

        /// <summary>
        /// DeleteAllUsers
        /// </summary>
        private static void DeleteAllUsers()
        {
            Auth.Provider provider = new Auth.Provider();
            int code = provider.DeleteAllUsers();

            switch (code)
            {
                case 204: Console.WriteLine("Deleted all users!");
                    break;
            }
        }

        /// <summary>
        /// DeleteUser
        /// </summary>
        private static void DeleteUser()
        {
            Console.WriteLine("Input Mobile");
            string mobileNumber = Console.ReadLine();

            Auth.Provider provider = new Auth.Provider();
            int code = provider.DeleteUser(mobileNumber);

            switch (code)
            {
                case 204: Console.WriteLine("Deleted user!");
                    break;
            }
        }
    }
}
