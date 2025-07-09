using CMS.Core.Common;
using System;
using System.Data;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for USER_DEVICE Table
	/// </summary>
	[Serializable]
	[DataTable("USER_DEVICE",ResourceKey = "USER_DEVICE")]
	public class USER_DEVICE: BaseObject
	{
		public USER_DEVICE()
		{
		}
		public USER_DEVICE(DealModel initModel):base(initModel)
		{
		}
		public static USER_DEVICE Convert(BaseObject from)
		{
			return (USER_DEVICE)from;
		}
		/// <summary>
		/// The USER_DEVICE_ID Field of USER_DEVICE Table
		/// </summary>
		private decimal _user_device_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.USER_DEVICE_ID = value; }
			get { return USER_DEVICE_ID; }
		}

		[RecordIDField("USER_DEVICE_ID"
			, AliasName = "USER_DEVICE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "USER_DEVICE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal USER_DEVICE_ID
		{
			set { _user_device_id = value; }
			get { return _user_device_id; }
		}
		/// <summary>
		/// The USER_ID Field of USER_DEVICE Table
		/// </summary>
		private decimal _user_id;
		[DataField("USER_ID"
			, AliasName = "USER_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 3
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal USER_ID
		{
			set { _user_id = value; }
			get { return _user_id; }
		}
		/// <summary>
		/// The DEVICE_TYPE Field of USER_DEVICE Table
		/// </summary>
		private Int32 _device_type;
		[DataField("DEVICE_TYPE"
			, AliasName = "DEVICE_TYPE"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "DEVICE_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 DEVICE_TYPE
		{
			set { _device_type = value; }
			get { return _device_type; }
		}
		/// <summary>
		/// The IP Field of USER_DEVICE Table
		/// </summary>
		private string _ip;
		[DataField("IP"
			, AliasName = "IP"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IP"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string IP
		{
			set { _ip = value; }
			get { return _ip; }
		}
		/// <summary>
		/// The TOKEN Field of USER_DEVICE Table
		/// </summary>
		private string _token;
		[DataField("TOKEN"
			, AliasName = "TOKEN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 512
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "TOKEN"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TOKEN
		{
			set { _token = value; }
			get { return _token; }
		}
		/// <summary>
		/// The ACTIVE_TIME Field of USER_DEVICE Table
		/// </summary>
		private DateTime _active_time;
		[DataField("ACTIVE_TIME"
			, AliasName = "ACTIVE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "ACTIVE_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime ACTIVE_TIME
		{
			set { _active_time = value; }
			get { return _active_time; }
		}
		/// <summary>
		/// The EXPIRED_TIME Field of USER_DEVICE Table
		/// </summary>
		private DateTime _expired_time;
		[DataField("EXPIRED_TIME"
			, AliasName = "EXPIRED_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "EXPIRED_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime EXPIRED_TIME
		{
			set { _expired_time = value; }
			get { return _expired_time; }
		}
		/// <summary>
		/// The CREATE_TIME Field of USER_DEVICE Table
		/// </summary>
		private DateTime _create_time;
		[DataField("CREATE_TIME"
			, AliasName = "CREATE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "CREATE_TIME"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 102
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
            , DefaultValue = "SysDate"
			 )]
		public DateTime CREATE_TIME
		{
			set { _create_time = value; }
			get { return _create_time; }
		}
		/// <summary>
		/// USER_DEVICE Table 
		/// </summary>
		public const string TABLE_NAME="USER_DEVICE";
		public const String USER_DEVICE_ID_FIELD  ="USER_DEVICE_ID";
		public const String USER_ID_FIELD  ="USER_ID";
		public const String DEVICE_TYPE_FIELD  ="DEVICE_TYPE";
		public const String IP_FIELD  ="IP";
		public const String TOKEN_FIELD  ="TOKEN";
		public const String ACTIVE_TIME_FIELD  ="ACTIVE_TIME";
		public const String EXPIRED_TIME_FIELD  ="EXPIRED_TIME";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
	}
}