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

namespace IWMS.Solutions.Server.WardDataProvider.Models
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
    partial void InsertZone(Zone instance);
    partial void UpdateZone(Zone instance);
    partial void DeleteZone(Zone instance);
    partial void InsertWard(Ward instance);
    partial void UpdateWard(Ward instance);
    partial void DeleteWard(Ward instance);
    partial void InsertCordinate(Cordinate instance);
    partial void UpdateCordinate(Cordinate instance);
    partial void DeleteCordinate(Cordinate instance);
    partial void InsertLocality(Locality instance);
    partial void UpdateLocality(Locality instance);
    partial void DeleteLocality(Locality instance);
    #endregion
		
		public DataAccessDataContext() : 
				base(global::IWMS.Solutions.Server.WardDataProvider.Properties.Settings.Default.IWMSConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<Zone> Zones
		{
			get
			{
				return this.GetTable<Zone>();
			}
		}
		
		public System.Data.Linq.Table<Ward> Wards
		{
			get
			{
				return this.GetTable<Ward>();
			}
		}
		
		public System.Data.Linq.Table<Cordinate> Cordinates
		{
			get
			{
				return this.GetTable<Cordinate>();
			}
		}
		
		public System.Data.Linq.Table<Locality> Localities
		{
			get
			{
				return this.GetTable<Locality>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Zone")]
	public partial class Zone : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private int _Number;
		
		private string _Name;
		
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
    #endregion
		
		public Zone()
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cordinate")]
	public partial class Cordinate : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _WardId;
		
		private string _Latitude;
		
		private string _Longitude;
		
		private int _Rank;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnWardIdChanging(System.Guid value);
    partial void OnWardIdChanged();
    partial void OnLatitudeChanging(string value);
    partial void OnLatitudeChanged();
    partial void OnLongitudeChanging(string value);
    partial void OnLongitudeChanged();
    partial void OnRankChanging(int value);
    partial void OnRankChanged();
    #endregion
		
		public Cordinate()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Latitude", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Longitude", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rank", DbType="Int NOT NULL")]
		public int Rank
		{
			get
			{
				return this._Rank;
			}
			set
			{
				if ((this._Rank != value))
				{
					this.OnRankChanging(value);
					this.SendPropertyChanging();
					this._Rank = value;
					this.SendPropertyChanged("Rank");
					this.OnRankChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Locality")]
	public partial class Locality : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Name;
		
		private System.Guid _WardId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnWardIdChanging(System.Guid value);
    partial void OnWardIdChanged();
    #endregion
		
		public Locality()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
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
