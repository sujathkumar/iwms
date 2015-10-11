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

namespace IWMS.Solutions.Server.AuthProvider.Models
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
	public partial class DataAccessDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertCity(City instance);
    partial void UpdateCity(City instance);
    partial void DeleteCity(City instance);
    partial void InsertAuth(Auth instance);
    partial void UpdateAuth(Auth instance);
    partial void DeleteAuth(Auth instance);
    partial void InsertAddress(Address instance);
    partial void UpdateAddress(Address instance);
    partial void DeleteAddress(Address instance);
    #endregion
		
		public DataAccessDataContext() : 
				base(global::IWMS.Solutions.Server.AuthProvider.Properties.Settings.Default.IWMSConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataAccessDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAccessDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAccessDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAccessDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<City> Cities
		{
			get
			{
				return this.GetTable<City>();
			}
		}
		
		public System.Data.Linq.Table<Auth> Auths
		{
			get
			{
				return this.GetTable<Auth>();
			}
		}
		
		public System.Data.Linq.Table<Address> Addresses
		{
			get
			{
				return this.GetTable<Address>();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.City")]
	public partial class City : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Name;
		
		private string _Number;
		
		private string _Server;
		
		private bool _Active;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnNumberChanging(string value);
    partial void OnNumberChanged();
    partial void OnServerChanging(string value);
    partial void OnServerChanged();
    partial void OnActiveChanging(bool value);
    partial void OnActiveChanged();
    #endregion
		
		public City()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Number", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Number
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Server", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Server
		{
			get
			{
				return this._Server;
			}
			set
			{
				if ((this._Server != value))
				{
					this.OnServerChanging(value);
					this.SendPropertyChanging();
					this._Server = value;
					this.SendPropertyChanged("Server");
					this.OnServerChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Address")]
	public partial class Address : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _HouseNo;
		
		private string _HouseName;
		
		private string _ApartmentName;
		
		private string _Street;
		
		private string _Locality;
		
		private System.Guid _WardId;
		
		private bool _Registered;
		
		private int _PINCODE;
		
		private System.Guid _UserId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnHouseNoChanging(string value);
    partial void OnHouseNoChanged();
    partial void OnHouseNameChanging(string value);
    partial void OnHouseNameChanged();
    partial void OnApartmentNameChanging(string value);
    partial void OnApartmentNameChanged();
    partial void OnStreetChanging(string value);
    partial void OnStreetChanged();
    partial void OnLocalityChanging(string value);
    partial void OnLocalityChanged();
    partial void OnWardIdChanging(System.Guid value);
    partial void OnWardIdChanged();
    partial void OnRegisteredChanging(bool value);
    partial void OnRegisteredChanged();
    partial void OnPINCODEChanging(int value);
    partial void OnPINCODEChanged();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    #endregion
		
		public Address()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HouseNo", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string HouseNo
		{
			get
			{
				return this._HouseNo;
			}
			set
			{
				if ((this._HouseNo != value))
				{
					this.OnHouseNoChanging(value);
					this.SendPropertyChanging();
					this._HouseNo = value;
					this.SendPropertyChanged("HouseNo");
					this.OnHouseNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HouseName", DbType="NVarChar(50)")]
		public string HouseName
		{
			get
			{
				return this._HouseName;
			}
			set
			{
				if ((this._HouseName != value))
				{
					this.OnHouseNameChanging(value);
					this.SendPropertyChanging();
					this._HouseName = value;
					this.SendPropertyChanged("HouseName");
					this.OnHouseNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApartmentName", DbType="NVarChar(50)")]
		public string ApartmentName
		{
			get
			{
				return this._ApartmentName;
			}
			set
			{
				if ((this._ApartmentName != value))
				{
					this.OnApartmentNameChanging(value);
					this.SendPropertyChanging();
					this._ApartmentName = value;
					this.SendPropertyChanged("ApartmentName");
					this.OnApartmentNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Street", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Street
		{
			get
			{
				return this._Street;
			}
			set
			{
				if ((this._Street != value))
				{
					this.OnStreetChanging(value);
					this.SendPropertyChanging();
					this._Street = value;
					this.SendPropertyChanged("Street");
					this.OnStreetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Locality", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Locality
		{
			get
			{
				return this._Locality;
			}
			set
			{
				if ((this._Locality != value))
				{
					this.OnLocalityChanging(value);
					this.SendPropertyChanging();
					this._Locality = value;
					this.SendPropertyChanged("Locality");
					this.OnLocalityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WardId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid WardId
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Registered", DbType="Bit NOT NULL")]
		public bool Registered
		{
			get
			{
				return this._Registered;
			}
			set
			{
				if ((this._Registered != value))
				{
					this.OnRegisteredChanging(value);
					this.SendPropertyChanging();
					this._Registered = value;
					this.SendPropertyChanged("Registered");
					this.OnRegisteredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PINCODE", DbType="Int NOT NULL")]
		public int PINCODE
		{
			get
			{
				return this._PINCODE;
			}
			set
			{
				if ((this._PINCODE != value))
				{
					this.OnPINCODEChanging(value);
					this.SendPropertyChanging();
					this._PINCODE = value;
					this.SendPropertyChanged("PINCODE");
					this.OnPINCODEChanged();
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
}
#pragma warning restore 1591