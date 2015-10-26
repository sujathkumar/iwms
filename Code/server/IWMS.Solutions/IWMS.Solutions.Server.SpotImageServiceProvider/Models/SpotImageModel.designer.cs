﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IWMS.Solutions.Server.SpotImage.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="IWMS")]
	public partial class SpotImageModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAuth(Auth instance);
    partial void UpdateAuth(Auth instance);
    partial void DeleteAuth(Auth instance);
    partial void InsertSpotImage(SpotImage instance);
    partial void UpdateSpotImage(SpotImage instance);
    partial void DeleteSpotImage(SpotImage instance);
    partial void InsertWard(Ward instance);
    partial void UpdateWard(Ward instance);
    partial void DeleteWard(Ward instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertEvent(Event instance);
    partial void UpdateEvent(Event instance);
    partial void DeleteEvent(Event instance);
    partial void InsertPoint(Point instance);
    partial void UpdatePoint(Point instance);
    partial void DeletePoint(Point instance);
    partial void InsertPointConfiguration(PointConfiguration instance);
    partial void UpdatePointConfiguration(PointConfiguration instance);
    partial void DeletePointConfiguration(PointConfiguration instance);
    #endregion
		
		public SpotImageModelDataContext() : 
				base(global::IWMS.Solutions.Server.SpotImage.Properties.Settings.Default.IWMSConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SpotImageModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SpotImageModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SpotImageModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SpotImageModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Auth> Auths
		{
			get
			{
				return this.GetTable<Auth>();
			}
		}
		
		public System.Data.Linq.Table<SpotImage> SpotImages
		{
			get
			{
				return this.GetTable<SpotImage>();
			}
		}
		
		public System.Data.Linq.Table<Ward> Wards
		{
			get
			{
				return this.GetTable<Ward>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Event> Events
		{
			get
			{
				return this.GetTable<Event>();
			}
		}
		
		public System.Data.Linq.Table<Point> Points
		{
			get
			{
				return this.GetTable<Point>();
			}
		}
		
		public System.Data.Linq.Table<PointConfiguration> PointConfigurations
		{
			get
			{
				return this.GetTable<PointConfiguration>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Auth")]
	public partial class Auth : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Key;
		
		private string _ApplicationId;
		
		private string _GCMToken;
		
		private string _REFCODE;
		
		private System.Guid _UserId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnKeyChanging(string value);
    partial void OnKeyChanged();
    partial void OnApplicationIdChanging(string value);
    partial void OnApplicationIdChanged();
    partial void OnGCMTokenChanging(string value);
    partial void OnGCMTokenChanged();
    partial void OnREFCODEChanging(string value);
    partial void OnREFCODEChanged();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    #endregion
		
		public Auth()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Key]", Storage="_Key", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Key
		{
			get
			{
				return this._Key;
			}
			set
			{
				if ((this._Key != value))
				{
					this.OnKeyChanging(value);
					this.SendPropertyChanging();
					this._Key = value;
					this.SendPropertyChanged("Key");
					this.OnKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GCMToken", DbType="NVarChar(500)")]
		public string GCMToken
		{
			get
			{
				return this._GCMToken;
			}
			set
			{
				if ((this._GCMToken != value))
				{
					this.OnGCMTokenChanging(value);
					this.SendPropertyChanging();
					this._GCMToken = value;
					this.SendPropertyChanged("GCMToken");
					this.OnGCMTokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REFCODE", DbType="NVarChar(10)")]
		public string REFCODE
		{
			get
			{
				return this._REFCODE;
			}
			set
			{
				if ((this._REFCODE != value))
				{
					this.OnREFCODEChanging(value);
					this.SendPropertyChanging();
					this._REFCODE = value;
					this.SendPropertyChanged("REFCODE");
					this.OnREFCODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SpotImage")]
	public partial class SpotImage : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Latitude;
		
		private string _Longitude;
		
		private System.Guid _UserId;
		
		private System.Nullable<System.Guid> _WardId;
		
		private string _UserAddress;
		
		private bool _Verified;
		
		private string _ImagePath;
		
		private System.DateTime _UploadedTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnLatitudeChanging(string value);
    partial void OnLatitudeChanged();
    partial void OnLongitudeChanging(string value);
    partial void OnLongitudeChanged();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    partial void OnWardIdChanging(System.Nullable<System.Guid> value);
    partial void OnWardIdChanged();
    partial void OnUserAddressChanging(string value);
    partial void OnUserAddressChanged();
    partial void OnVerifiedChanging(bool value);
    partial void OnVerifiedChanged();
    partial void OnImagePathChanging(string value);
    partial void OnImagePathChanged();
    partial void OnUploadedTimeChanging(System.DateTime value);
    partial void OnUploadedTimeChanged();
    #endregion
		
		public SpotImage()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Latitude", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				if ((this._Latitude != value))
				{
					this.OnLatitudeChanging(value);
					this.SendPropertyChanging();
					this._Latitude = value;
					this.SendPropertyChanged("Latitude");
					this.OnLatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Longitude", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				if ((this._Longitude != value))
				{
					this.OnLongitudeChanging(value);
					this.SendPropertyChanging();
					this._Longitude = value;
					this.SendPropertyChanged("Longitude");
					this.OnLongitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WardId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> WardId
		{
			get
			{
				return this._WardId;
			}
			set
			{
				if ((this._WardId != value))
				{
					this.OnWardIdChanging(value);
					this.SendPropertyChanging();
					this._WardId = value;
					this.SendPropertyChanged("WardId");
					this.OnWardIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserAddress", DbType="NVarChar(250)")]
		public string UserAddress
		{
			get
			{
				return this._UserAddress;
			}
			set
			{
				if ((this._UserAddress != value))
				{
					this.OnUserAddressChanging(value);
					this.SendPropertyChanging();
					this._UserAddress = value;
					this.SendPropertyChanged("UserAddress");
					this.OnUserAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Verified", DbType="Bit NOT NULL")]
		public bool Verified
		{
			get
			{
				return this._Verified;
			}
			set
			{
				if ((this._Verified != value))
				{
					this.OnVerifiedChanging(value);
					this.SendPropertyChanging();
					this._Verified = value;
					this.SendPropertyChanged("Verified");
					this.OnVerifiedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImagePath", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ImagePath
		{
			get
			{
				return this._ImagePath;
			}
			set
			{
				if ((this._ImagePath != value))
				{
					this.OnImagePathChanging(value);
					this.SendPropertyChanging();
					this._ImagePath = value;
					this.SendPropertyChanged("ImagePath");
					this.OnImagePathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadedTime", DbType="DateTime NOT NULL")]
		public System.DateTime UploadedTime
		{
			get
			{
				return this._UploadedTime;
			}
			set
			{
				if ((this._UploadedTime != value))
				{
					this.OnUploadedTimeChanging(value);
					this.SendPropertyChanging();
					this._UploadedTime = value;
					this.SendPropertyChanged("UploadedTime");
					this.OnUploadedTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Ward")]
	public partial class Ward : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private int _Number;
		
		private string _Name;
		
		private System.Guid _ZoneId;
		
		private string _LeftCordinate;
		
		private string _RightCordinate;
		
		private string _TopCordinate;
		
		private string _BottomCordinate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnNumberChanging(int value);
    partial void OnNumberChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnZoneIdChanging(System.Guid value);
    partial void OnZoneIdChanged();
    partial void OnLeftCordinateChanging(string value);
    partial void OnLeftCordinateChanged();
    partial void OnRightCordinateChanging(string value);
    partial void OnRightCordinateChanged();
    partial void OnTopCordinateChanging(string value);
    partial void OnTopCordinateChanged();
    partial void OnBottomCordinateChanging(string value);
    partial void OnBottomCordinateChanged();
    #endregion
		
		public Ward()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Number", DbType="Int NOT NULL")]
		public int Number
		{
			get
			{
				return this._Number;
			}
			set
			{
				if ((this._Number != value))
				{
					this.OnNumberChanging(value);
					this.SendPropertyChanging();
					this._Number = value;
					this.SendPropertyChanged("Number");
					this.OnNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZoneId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ZoneId
		{
			get
			{
				return this._ZoneId;
			}
			set
			{
				if ((this._ZoneId != value))
				{
					this.OnZoneIdChanging(value);
					this.SendPropertyChanging();
					this._ZoneId = value;
					this.SendPropertyChanged("ZoneId");
					this.OnZoneIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LeftCordinate", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LeftCordinate
		{
			get
			{
				return this._LeftCordinate;
			}
			set
			{
				if ((this._LeftCordinate != value))
				{
					this.OnLeftCordinateChanging(value);
					this.SendPropertyChanging();
					this._LeftCordinate = value;
					this.SendPropertyChanged("LeftCordinate");
					this.OnLeftCordinateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RightCordinate", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string RightCordinate
		{
			get
			{
				return this._RightCordinate;
			}
			set
			{
				if ((this._RightCordinate != value))
				{
					this.OnRightCordinateChanging(value);
					this.SendPropertyChanging();
					this._RightCordinate = value;
					this.SendPropertyChanged("RightCordinate");
					this.OnRightCordinateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TopCordinate", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TopCordinate
		{
			get
			{
				return this._TopCordinate;
			}
			set
			{
				if ((this._TopCordinate != value))
				{
					this.OnTopCordinateChanging(value);
					this.SendPropertyChanging();
					this._TopCordinate = value;
					this.SendPropertyChanged("TopCordinate");
					this.OnTopCordinateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BottomCordinate", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string BottomCordinate
		{
			get
			{
				return this._BottomCordinate;
			}
			set
			{
				if ((this._BottomCordinate != value))
				{
					this.OnBottomCordinateChanging(value);
					this.SendPropertyChanging();
					this._BottomCordinate = value;
					this.SendPropertyChanged("BottomCordinate");
					this.OnBottomCordinateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Name;
		
		private string _Mobile;
		
		private System.Guid _CityId;
		
		private bool _Active;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnMobileChanging(string value);
    partial void OnMobileChanged();
    partial void OnCityIdChanging(System.Guid value);
    partial void OnCityIdChanged();
    partial void OnActiveChanging(bool value);
    partial void OnActiveChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mobile", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Mobile
		{
			get
			{
				return this._Mobile;
			}
			set
			{
				if ((this._Mobile != value))
				{
					this.OnMobileChanging(value);
					this.SendPropertyChanging();
					this._Mobile = value;
					this.SendPropertyChanged("Mobile");
					this.OnMobileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid CityId
		{
			get
			{
				return this._CityId;
			}
			set
			{
				if ((this._CityId != value))
				{
					this.OnCityIdChanging(value);
					this.SendPropertyChanging();
					this._CityId = value;
					this.SendPropertyChanged("CityId");
					this.OnCityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit NOT NULL")]
		public bool Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Event")]
	public partial class Event : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _EventName;
		
		private System.DateTime _EventDate;
		
		private System.Guid _SpotImageId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnEventNameChanging(string value);
    partial void OnEventNameChanged();
    partial void OnEventDateChanging(System.DateTime value);
    partial void OnEventDateChanged();
    partial void OnSpotImageIdChanging(System.Guid value);
    partial void OnSpotImageIdChanged();
    #endregion
		
		public Event()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string EventName
		{
			get
			{
				return this._EventName;
			}
			set
			{
				if ((this._EventName != value))
				{
					this.OnEventNameChanging(value);
					this.SendPropertyChanging();
					this._EventName = value;
					this.SendPropertyChanged("EventName");
					this.OnEventNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventDate", DbType="DateTime NOT NULL")]
		public System.DateTime EventDate
		{
			get
			{
				return this._EventDate;
			}
			set
			{
				if ((this._EventDate != value))
				{
					this.OnEventDateChanging(value);
					this.SendPropertyChanging();
					this._EventDate = value;
					this.SendPropertyChanged("EventDate");
					this.OnEventDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SpotImageId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SpotImageId
		{
			get
			{
				return this._SpotImageId;
			}
			set
			{
				if ((this._SpotImageId != value))
				{
					this.OnSpotImageIdChanging(value);
					this.SendPropertyChanging();
					this._SpotImageId = value;
					this.SendPropertyChanged("SpotImageId");
					this.OnSpotImageIdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Point")]
	public partial class Point : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private int _Point1;
		
		private System.Guid _UserId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnPoint1Changing(int value);
    partial void OnPoint1Changed();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    #endregion
		
		public Point()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Point", Storage="_Point1", DbType="Int NOT NULL")]
		public int Point1
		{
			get
			{
				return this._Point1;
			}
			set
			{
				if ((this._Point1 != value))
				{
					this.OnPoint1Changing(value);
					this.SendPropertyChanging();
					this._Point1 = value;
					this.SendPropertyChanged("Point1");
					this.OnPoint1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PointConfiguration")]
	public partial class PointConfiguration : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private int _Point;
		
		private string _Type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnPointChanging(int value);
    partial void OnPointChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    #endregion
		
		public PointConfiguration()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Point", DbType="Int NOT NULL")]
		public int Point
		{
			get
			{
				return this._Point;
			}
			set
			{
				if ((this._Point != value))
				{
					this.OnPointChanging(value);
					this.SendPropertyChanging();
					this._Point = value;
					this.SendPropertyChanged("Point");
					this.OnPointChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
