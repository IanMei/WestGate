using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_ACTIVITY Table
	/// </summary>
	[Serializable]
	[DataTable("APP_ACTIVITY",ResourceKey = "APP_ACTIVITY")]
	public class APP_ACTIVITY: BaseObject
	{
		public APP_ACTIVITY()
		{
		}
		public APP_ACTIVITY(DealModel initModel):base(initModel)
		{
		}
		public static APP_ACTIVITY Convert(BaseObject from)
		{
			return (APP_ACTIVITY)from;
		}
		/// <summary>
		/// The ACTIVITY_ID Field of APP_ACTIVITY Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ACTIVITY_ID = value; }
			get { return ACTIVITY_ID; }
		}

		[RecordIDField("ACTIVITY_ID"
			, AliasName = "ACTIVITY_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "ACTIVITY_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ACTIVITY_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The ACTIVITY_NO Field of APP_ACTIVITY Table
		/// </summary>
		[KeyField("ACTIVITY_NO"
			, AliasName = "ACTIVITY_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, ResourceKey = "ACTIVITY_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string ACTIVITY_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The ACTIVITY_NAME Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("ACTIVITY_NAME"
			, AliasName = "ACTIVITY_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "ACTIVITY_NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ACTIVITY_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The ACTIVITY_DATE Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("ACTIVITY_DATE"
			, AliasName = "ACTIVITY_DATE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "ACTIVITY_DATE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ACTIVITY_DATE
		{
			set;
			get;
		}
		/// <summary>
		/// The ACTIVITY_ADDRESS Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("ACTIVITY_ADDRESS"
			, AliasName = "ACTIVITY_ADDRESS"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 50
			, Width = 100
			, ResourceKey = "ACTIVITY_ADDRESS"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ACTIVITY_ADDRESS
		{
			set;
			get;
		}
		/// <summary>
		/// The ACTIVITY_QTY Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("ACTIVITY_QTY"
			, AliasName = "ACTIVITY_QTY"
			, DataType = DbType.Int32
			, IsNullable = true
			, Size = 4
			, Width = 100
			, ResourceKey = "ACTIVITY_QTY"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 ACTIVITY_QTY
		{
			set;
			get;
		}
		/// <summary>
		/// The CONTENT Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("CONTENT"
			, AliasName = "CONTENT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 8
			, Width = 100
			, ResourceKey = "CONTENT"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CONTENT
		{
			set;
			get;
		}
		/// <summary>
		/// The DATE_PUBLISH Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("DATE_PUBLISH"
			, AliasName = "DATE_PUBLISH"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "DATE_PUBLISH"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public DateTime DATE_PUBLISH
		{
			set;
			get;
		}
		/// <summary>
		/// The SEQ_NO Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("SEQ_NO"
			, AliasName = "SEQ_NO"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "SEQ_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal SEQ_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The IMAGE_ID Field of APP_BANNER Table
		/// </summary>
		[ForeignKeyField("PICTURE_MINI"
			 , AliasName = "PICTURE_MINI"
			 , DataType = DbType.Int32
			 , IsNullable = false
			 , Size = 20
			 , Width = 100
			 , DisplayInCondition = true
			 , DisplayInMaintain = true
			 , DisplayInDialog = false
			 , ResourceKey = "PICTURE_MINI"
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
			 , TableJoinSequence = 12
			  )]
		public int PICTURE_MINI
		{
			get; set;
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
		/// The PICTURE_NAME Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("PICTURE_NAME"
			, AliasName = "PICTURE_NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, ResourceKey = "PICTURE_NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PICTURE_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The KEYLIST Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("KEYLIST"
			, AliasName = "KEYLIST"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, ResourceKey = "KEYLIST"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string KEYLIST
		{
			set;
			get;
		}
		/// <summary>
		/// The DESCRIPTION Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("DESCRIPTION"
			, AliasName = "DESCRIPTION"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 200
			, Width = 100
			, ResourceKey = "DESCRIPTION"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string DESCRIPTION
		{
			set;
			get;
		}
		/// <summary>
		/// The READ_TMES Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("READ_TMES"
			, AliasName = "READ_TMES"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "READ_TMES"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal READ_TMES
		{
			set;
			get;
		}
		/// <summary>
		/// The LIKED_TMES Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("LIKED_TMES"
			, AliasName = "LIKED_TMES"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "LIKED_TMES"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal LIKED_TMES
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_HEAD Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("IS_HEAD"
			, AliasName = "IS_HEAD"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, ResourceKey = "IS_HEAD"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 IS_HEAD
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_HOT Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("IS_HOT"
			, AliasName = "IS_HOT"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, ResourceKey = "IS_HOT"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 IS_HOT
		{
			set;
			get;
		}
		/// <summary>
		/// The IS_ENABLED Field of APP_ACTIVITY Table
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
		/// The REMARK Field of APP_ACTIVITY Table
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
		/// The CREATE_BY Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("CREATE_BY"
			, AliasName = "CREATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, ResourceKey = "CREATE_BY"
			, GroupFun = "MAX"
			, SelectSequence = 101
			, IsInsertField = true
			, IsUpdateField = false
			, DefaultValue = "UserID"
			 )]
		public decimal CREATE_BY
		{
			set;
			get;
		}
		/// <summary>
		/// The CREATE_TIME Field of APP_ACTIVITY Table
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
		/// The UPDATE_BY Field of APP_ACTIVITY Table
		/// </summary>
		[DataField("UPDATE_BY"
			, AliasName = "UPDATE_BY"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 9
			, ResourceKey = "UPDATE_BY"
			, GroupFun = "MAX"
			, SelectSequence = 103
			, IsInsertField = true
			, IsUpdateField = true
			, DefaultValue = "UserID"
			 )]
		public decimal UPDATE_BY
		{
			set;
			get;
		}
		/// <summary>
		/// The UPDATE_TIME Field of APP_ACTIVITY Table
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
		/// APP_ACTIVITY Table 
		/// </summary>
		public const string TABLE_NAME="APP_ACTIVITY";
		public const String ACTIVITY_ID_FIELD  ="ACTIVITY_ID";
		public const String ACTIVITY_NO_FIELD  ="ACTIVITY_NO";
		public const String ACTIVITY_NAME_FIELD  ="ACTIVITY_NAME";
		public const String ACTIVITY_DATE_FIELD  ="ACTIVITY_DATE";
		public const String ACTIVITY_ADDRESS_FIELD  ="ACTIVITY_ADDRESS";
		public const String ACTIVITY_QTY_FIELD  ="ACTIVITY_QTY";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String DATE_PUBLISH_FIELD  ="DATE_PUBLISH";
		public const String SEQ_NO_FIELD  ="SEQ_NO";
		public const String PICTURE_MINI_FIELD  ="PICTURE_MINI";
		public const String PICTURE_NAME_FIELD  ="PICTURE_NAME";
		public const String KEYLIST_FIELD  ="KEYLIST";
		public const String DESCRIPTION_FIELD  ="DESCRIPTION";
		public const String READ_TMES_FIELD  ="READ_TMES";
		public const String LIKED_TMES_FIELD  ="LIKED_TMES";
		public const String IS_HEAD_FIELD  ="IS_HEAD";
		public const String IS_HOT_FIELD  ="IS_HOT";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}