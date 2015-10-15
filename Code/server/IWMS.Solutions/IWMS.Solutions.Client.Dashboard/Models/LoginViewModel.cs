using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using IWMS.Solutions.Client.Dashboard;
using SoftArcs.WPFSmartLibrary.MVVMCommands;
using SoftArcs.WPFSmartLibrary.MVVMCore;
using SoftArcs.WPFSmartLibrary.SmartUserControls;
using CollectorService = IWMS.Solutions.Server.CollectorServiceProvider;

namespace IWMS.Solutions.Client.Dashboard
{
	public class LoginViewModel : ViewModelBase
	{
		#region Fields

		private readonly string userImagesPath = @"\Images";

		#endregion // Fields

		#region Constructors

		public LoginViewModel()
		{
			if (ViewModelHelper.IsInDesignModeStatic == false)
			{
				this.initializeAllCommands();

				User recentUser = this.getRecentUser();

				this.UserName = recentUser.UserName;
				this.UserPassword = recentUser.Password;
				this.UserImageSource = recentUser.ImageSourcePath;
                this.MobileNumber = recentUser.MobileNumber;
			}
		}

		#endregion // Constructors

		#region Public Properties

		public string UserName
		{
			get { return GetValue( () => UserName ); }
			set { SetValue( () => UserName, value ); }
		}

		public string Password
		{
			get { return GetValue( () => Password ); }
			set { SetValue( () => Password, value ); }
		}

		public string UserPassword
		{
			get { return GetValue( () => UserPassword ); }
			set { SetValue( () => UserPassword, value ); }
		}

		public string UserImageSource
		{
			get { return GetValue( () => UserImageSource ); }
			set { SetValue( () => UserImageSource, value ); }
		}

		public string MobileNumber
		{
            get { return GetValue(() => MobileNumber); }
            set { SetValue(() => MobileNumber, value); }
		}

		#endregion // Public Properties

		#region Submit Command Handler

		public ICommand SubmitCommand { get; private set; }

		private void ExecuteSubmit(object commandParameter)
		{
            Debug.WriteLine("Here you would implement the submission and a following validation of this data:\n" + this.UserName + "\n" + this.MobileNumber + "\n" + this.Password);

			var accessControlSystem = commandParameter as SmartLoginOverlay;

			if (accessControlSystem != null)
			{
				if (this.Password.Equals( this.UserPassword ))
				{
					accessControlSystem.Unlock();
				}
				else
				{
					accessControlSystem.ShowWrongCredentialsMessage();
				}
			}
		}

		private bool CanExecuteSubmit(object commandParameter)
		{
			return !string.IsNullOrEmpty( this.Password );
		}

		#endregion // Submit Command Handler

		#region Private Methods

		private void initializeAllCommands()
		{
			this.SubmitCommand = new ActionCommand( this.ExecuteSubmit, this.CanExecuteSubmit );
		}

		private User getRecentUser()
		{
            string userData = File.ReadAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/UserData.txt");
            CollectorService.Provider provider;

            if (userData != string.Empty)
            {
                provider = new CollectorService.Provider();
                string credentials = provider.RetrieveCredentials(userData.Trim());

                if (!string.IsNullOrEmpty(credentials))
                {
                    return new User()
                                 {
                                     UserName = credentials.Split(',')[0],
                                     Password = credentials.Split(',')[1],
                                     MobileNumber = userData.Trim(),
                                     ImageSourcePath = Path.Combine(userImagesPath, "DemoUser.png")
                                 };
                }
                else
                {
                    return new User()
                    {
                        UserName = "Rakesh",
                        Password = "rakesh",
                        MobileNumber = userData.Trim(),
                        ImageSourcePath = Path.Combine(userImagesPath, "DemoUser.png")
                    };
                }
            }
            else
            {
                ConfigurationWindow configuration = new ConfigurationWindow();
                configuration.ShowDialog();

                if (configuration.Mobile != "")
                {
                    File.WriteAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/UserData.txt", configuration.Mobile);

                    provider = new CollectorService.Provider();
                    string credentials = provider.RetrieveCredentials(configuration.Mobile.Trim());

                    if (!string.IsNullOrEmpty(credentials))
                    {
                        return new User()
                        {
                            UserName = credentials.Split(',')[0],
                            Password = credentials.Split(',')[1],
                            MobileNumber = configuration.Mobile.Trim(),
                            ImageSourcePath = Path.Combine(userImagesPath, "DemoUser.png")
                        };
                    }
                    else
                    {
                        return new User()
                        {
                            UserName = "Rakesh",
                            Password = "rakesh",
                            MobileNumber = userData.Trim(),
                            ImageSourcePath = Path.Combine(userImagesPath, "DemoUser.png")
                        };

                    }
                }
            }

            return null;
		}

		#endregion

		#region Public Methods

		public void ChangeRecentUser(User newRecentUser)
		{
			this.UserName = newRecentUser.UserName;
			this.UserPassword = newRecentUser.Password;
            this.MobileNumber = newRecentUser.MobileNumber;
			this.UserImageSource = newRecentUser.ImageSourcePath;
		}

		#endregion
	}
}
