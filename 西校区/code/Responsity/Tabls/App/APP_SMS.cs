using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for APP_SMS Table
    /// </summary>
    [Serializable]
	[DataTable("APP_SMS",ResourceKey = "APP_SMS")]
	public class APP_SMS: BaseObject
	{
		public APP_SMS()
		{
		}
		public APP_SMS(DealModel initModel):base(initModel)
		{
		}
		public static APP_SMS Convert(BaseObject from)
		{
			return (APP_SMS)from;
		}
		/// <summary>
		/// The SMS_ID Field of APP_SMS Table
		/// </summary>
		private decimal _sms_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.SMS_ID = value; }
			get { return SMS_ID; }
		}

		[RecordIDField("SMS_ID"
			, AliasName = "SMS_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "SMS_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal SMS_ID
		{
			set { _sms_id = value; }
			get { return _sms_id; }
		}
		/// <summary>
		/// The SMS_NO Field of APP_SMS Table
		/// </summary>
		private string _sms_no;
		[KeyField("SMS_NO"
			, AliasName = "SMS_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "SMS_NO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string SMS_NO
		{
			set { _sms_no = value; }
			get { return _sms_no; }
		}
		/// <summary>
		/// The SMS_TYPE Field of APP_SMS Table
		/// </summary>
		private string _sms_type;
		[DataField("SMS_TYPE"
			, AliasName = "SMS_TYPE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SMS_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SMS_TYPE
		{
			set { _sms_type = value; }
			get { return _sms_type; }
		}
		/// <summary>
		/// The USER_ID Field of APP_SMS Table
		/// </summary>
		private decimal _user_id;
		[DataField("USER_ID"
			, AliasName = "USER_ID"
			, DataType = DbType.Decimal
			, IsNullable = true
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "USER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 9
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
		/// The MOBILE Field of APP_SMS Table
		/// </summary>
		private string _mobile;
		[DataField("MOBILE"
			, AliasName = "MOBILE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MOBILE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 12
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MOBILE
		{
			set { _mobile = value; }
			get { return _mobile; }
		}
		/// <summary>
		/// The NUMBER Field of APP_SMS Table
		/// </summary>
		private string _number;
		[DataField("NUMBER"
			, AliasName = "NUMBER"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 6
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "NUMBER"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string NUMBER
		{
			set { _number = value; }
			get { return _number; }
		}
		/// <summary>
		/// The MESSAGE Field of APP_SMS Table
		/// </summary>
		private string _message;
		[DataField("MESSAGE"
			, AliasName = "MESSAGE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "MESSAGE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MESSAGE
		{
			set { _message = value; }
			get { return _message; }
		}
		/// <summary>
		/// The IS_READ Field of APP_SMS Table
		/// </summary>
		private Int32 _is_read;
		[DataField("IS_READ"
			, AliasName = "IS_READ"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IS_READ"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 IS_READ
		{
			set { _is_read = value; }
			get { return _is_read; }
		}
		/// <summary>
		/// The REMARK Field of APP_SMS Table
		/// </summary>
		private string _remark;
		[DataField("REMARK"
			, AliasName = "REMARK"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "REMARK"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REMARK
		{
			set { _remark = value; }
			get { return _remark; }
		}
		/// <summary>
		/// The CREATE_TIME Field of APP_SMS Table
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
			, IsUpdateField = false
			, DefaultValue = "SysDate"
			 )]
		public DateTime CREATE_TIME
		{
			set { _create_time = value; }
			get { return _create_time; }
		}
		/// <summary>
		/// The UPDATE_TIME Field of APP_SMS Table
		/// </summary>
		private DateTime _update_time;
		[DataField("UPDATE_TIME"
			,AliasName = "UPDATE_TIME"
			,DataType = DbType.DateTime
			,IsNullable = false
			,Size = 20
			,DisplayInCondition = false
			,DisplayInMaintain = false
			, DisplayInDialog = false
			,ResourceKey = "UPDATE_TIME"
			, GroupFun = "MAX"
			,AllowEdit = false
			,SelectSequence = 104
			, DialogSequence = -1
			,Frozen = false
			,IsInsertField = true
			,IsUpdateField = true
			,DefaultValue = "SysDate"
			 )]
		public DateTime UPDATE_TIME
		{
			set { _update_time = value; }
			get { return _update_time; }
		}
		/// <summary>
		/// APP_SMS Table 
		/// </summary>
		public const string TABLE_NAME="APP_SMS";
		public const String SMS_ID_FIELD  ="SMS_ID";
		public const String SMS_NO_FIELD  ="SMS_NO";
		public const String SMS_TYPE_FIELD  ="SMS_TYPE";
		public const String USER_ID_FIELD  ="USER_ID";
		public const String MOBILE_FIELD  ="MOBILE";
		public const String NUMBER_FIELD  ="NUMBER";
		public const String MESSAGE_FIELD  ="MESSAGE";
		public const String IS_READ_FIELD  ="IS_READ";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}