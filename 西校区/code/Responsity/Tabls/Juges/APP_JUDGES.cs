using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_JUDGES Table
	/// </summary>
	[Serializable]
	[DataTable("APP_JUDGES",ResourceKey = "APP_JUDGES")]
	public class APP_JUDGES: BaseObject
	{
		public APP_JUDGES()
		{
		}
		public APP_JUDGES(DealModel initModel):base(initModel)
		{
		}
		public static APP_JUDGES Convert(BaseObject from)
		{
			return (APP_JUDGES)from;
		}
		/// <summary>
		/// The JUDGES_ID Field of APP_JUDGES Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.JUDGES_ID = value; }
			get { return JUDGES_ID; }
		}

		[RecordIDField("JUDGES_ID"
			, AliasName = "JUDGES_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "JUDGES_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal JUDGES_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The JUDGES_NO Field of APP_JUDGES Table
		/// </summary>
		[KeyField("JUDGES_NO"
			, AliasName = "JUDGES_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, ResourceKey = "JUDGES_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string JUDGES_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The NICK_NAME Field of APP_JUDGES Table
		/// </summary>
		[DataField("NICK_NAME"
			, AliasName = "NICK_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "NICK_NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string NICK_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The MOBILE Field of APP_JUDGES Table
		/// </summary>
		[DataField("MOBILE"
			, AliasName = "MOBILE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "MOBILE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MOBILE
		{
			set;
			get;
		}
		/// <summary>
		/// The USER_PWD Field of APP_JUDGES Table
		/// </summary>
		[DataField("USER_PWD"
			, AliasName = "USER_PWD"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 120
			, Width = 100
			, ResourceKey = "USER_PWD"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string USER_PWD
		{
			set;
			get;
		}
		/// <summary>
		/// The IMAGE_ID Field of APP_SCHOOL Table
		/// </summary>
		[ForeignKeyField("IMAGE_ID"
			, AliasName = "IMAGE_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 20
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IMAGE_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 30
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			, ForeignTableName = APP_TEMP.TABLE_NAME
			, ForeignTableAliasName = APP_TEMP.TABLE_NAME
			, ForeignColumnName = APP_TEMP.FILE_ID_FIELD
			, IsMainTableKey = true
			, ForeignTableJoinType = TableJoinType.LeftOuterJoin
			, TableJoinSequence = 0
			 )]
		public decimal IMAGE_ID
		{
			set;
			get;
		}

		[ForeignField("FILE_PATH"
		   , AliasName = "FILE_PATH"
		   , DataType = DbType.String
		   , IsNullable = false
		   , Size = 20
		   , Width = 100
		   , DisplayInCondition = false
		   , DisplayInMaintain = false
		   , DisplayInDialog = false
		   , ResourceKey = "FILE_PATH"
		   , GroupFun = "MAX"
		   , AllowEdit = false
		   , Frozen = false
		   , SelectSequence = 30
		   , DialogSequence = -1
		   , IsInsertField = false
		   , IsUpdateField = false
		   , ForeignTableName = APP_TEMP.TABLE_NAME
		   , ForeignTableAliasName = APP_TEMP.TABLE_NAME
		   , ForeignColumnName = APP_TEMP.FILE_PATH_FIELD
			)]
		public string FILE_PATH
		{
			set;
			get;
		}
		/// <summary>
		/// The PROVINCE_NO Field of APP_JUDGES Table
		/// </summary>
		[DataField("PROVINCE_NO"
			, AliasName = "PROVINCE_NO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 6
			, Width = 100
			, ResourceKey = "PROVINCE_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PROVINCE_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The CITY_NO Field of APP_JUDGES Table
		/// </summary>
		[DataField("CITY_NO"
			, AliasName = "CITY_NO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 6
			, Width = 100
			, ResourceKey = "CITY_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CITY_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The DISYRICT_NO Field of APP_JUDGES Table
		/// </summary>
		[DataField("DISYRICT_NO"
			, AliasName = "DISYRICT_NO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 6
			, Width = 100
			, ResourceKey = "DISYRICT_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string DISYRICT_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The ADDRESS Field of APP_JUDGES Table
		/// </summary>
		[DataField("ADDRESS"
			, AliasName = "ADDRESS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, ResourceKey = "ADDRESS"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ADDRESS
		{
			set;
			get;
		}
		/// <summary>
		/// The COMPANY Field of APP_JUDGES Table
		/// </summary>
		[DataField("COMPANY"
			, AliasName = "COMPANY"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, ResourceKey = "COMPANY"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string COMPANY
		{
			set;
			get;
		}
		/// <summary>
		/// The POSITION Field of APP_JUDGES Table
		/// </summary>
		[DataField("POSITION"
			, AliasName = "POSITION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "POSITION"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string POSITION
		{
			set;
			get;
		}
		/// <summary>
		/// The LINK_TEL Field of APP_JUDGES Table
		/// </summary>
		[DataField("LINK_TEL"
			, AliasName = "LINK_TEL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "LINK_TEL"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LINK_TEL
		{
			set;
			get;
		}

		/// <summary>
		/// The LINK_MAN Field of APP_JUDGES Table
		/// </summary>
		[DataField("LINK_MAN"
			, AliasName = "LINK_MAN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "LINK_MAN"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LINK_MAN
		{
			set;
			get;
		}
		/// <summary>
		/// The EMAIL Field of APP_JUDGES Table
		/// </summary>
		[DataField("EMAIL"
			, AliasName = "EMAIL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "EMAIL"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string EMAIL
		{
			set;
			get;
		}
		/// <summary>
		/// The WECHAT Field of APP_JUDGES Table
		/// </summary>
		[DataField("WECHAT"
			, AliasName = "WECHAT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "WECHAT"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string WECHAT
		{
			set;
			get;
		}
		/// <summary>
		/// The CLIENT_ID Field of APP_JUDGES Table
		/// </summary>
		[DataField("CLIENT_ID"
			, AliasName = "CLIENT_ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, ResourceKey = "CLIENT_ID"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CLIENT_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_ENABLED Field of APP_JUDGES Table
		/// </summary>
		[DataField("IS_ENABLED"
			, AliasName = "IS_ENABLED"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, ResourceKey = "IS_ENABLED"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 IS_ENABLED
		{
			set;
			get;
		}

		/// <summary>
		/// The IS_MAIN Field of APP_JUDGES Table
		/// </summary>
		[DataField("IS_MAIN"
			, AliasName = "IS_MAIN"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, ResourceKey = "IS_MAIN"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 IS_MAIN
		{
			set;
			get;
		}

		/// <summary>
		/// The IS_SPECIAL Field of APP_JUDGES Table
		/// </summary>
		[DataField("IS_SPECIAL"
			, AliasName = "IS_SPECIAL"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, ResourceKey = "IS_SPECIAL"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 IS_SPECIAL
		{
			set;
			get;
		}
		/// <summary>
		/// The REMARK Field of APP_JUDGES Table
		/// </summary>
		[DataField("REMARK"
			, AliasName = "REMARK"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, ResourceKey = "REMARK"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string REMARK
		{
			set;
			get;
		}
		/// <summary>
		/// The CREATE_TIME Field of APP_JUDGES Table
		/// </summary>
		[DataField("CREATE_TIME"
			, AliasName = "CREATE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, ResourceKey = "CREATE_TIME"
			, GroupFun = "MAX"
			, SelectSequence = 102
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "SysDate"
			 )]
		public DateTime CREATE_TIME
		{
			set;
			get;
		}
		/// <summary>
		/// The UPDATE_TIME Field of APP_JUDGES Table
		/// </summary>
		[DataField("UPDATE_TIME"
			,AliasName = "UPDATE_TIME"
			,DataType = DbType.DateTime
			,IsNullable = false
			,Size = 20
			,ResourceKey = "UPDATE_TIME"
			,GroupFun = "MAX"
			,SelectSequence = 104
			,IsInsertField = true
			,IsUpdateField = true
			,DefaultValue = "SysDate"
			 )]
		public DateTime UPDATE_TIME
		{
			set;
			get;
		}
		/// <summary>
		/// APP_JUDGES Table 
		/// </summary>
		public const string TABLE_NAME="APP_JUDGES";
		public const String JUDGES_ID_FIELD  ="JUDGES_ID";
		public const String JUDGES_NO_FIELD  ="JUDGES_NO";
		public const String NICK_NAME_FIELD  ="NICK_NAME";
		public const String MOBILE_FIELD  ="MOBILE";
		public const String USER_PWD_FIELD  ="USER_PWD";
		public const String IMAGE_ID_FIELD  ="IMAGE_ID";
		public const String PROVINCE_NO_FIELD  ="PROVINCE_NO";
		public const String CITY_NO_FIELD  ="CITY_NO";
		public const String DISYRICT_NO_FIELD  ="DISYRICT_NO";
		public const String ADDRESS_FIELD  ="ADDRESS";
		public const String COMPANY_FIELD  ="COMPANY";
		public const String POSITION_FIELD  ="POSITION";
		public const String LINK_TEL_FIELD  ="LINK_TEL";
		public const String EMAIL_FIELD  ="EMAIL";
		public const String WECHAT_FIELD  ="WECHAT";
		public const String CLIENT_ID_FIELD  ="CLIENT_ID";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}