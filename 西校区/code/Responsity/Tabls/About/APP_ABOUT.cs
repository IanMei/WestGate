using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_ABOUT Table
	/// </summary>
	[Serializable]
	[DataTable("APP_ABOUT",ResourceKey = "APP_ABOUT")]
	public class APP_ABOUT: BaseObject
	{
		public APP_ABOUT()
		{
		}
		public APP_ABOUT(DealModel initModel):base(initModel)
		{
		}
		public static APP_ABOUT Convert(BaseObject from)
		{
			return (APP_ABOUT)from;
		}
		/// <summary>
		/// The ABOUT_ID Field of APP_ABOUT Table
		/// </summary>
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.ABOUT_ID = value; }
			get { return ABOUT_ID; }
		}

		[RecordIDField("ABOUT_ID"
			, AliasName = "ABOUT_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "ABOUT_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal ABOUT_ID
		{
			set;
			get;
		}
		/// <summary>
		/// The ABOUT_NO Field of APP_ABOUT Table
		/// </summary>
		[KeyField("ABOUT_NO"
			, AliasName = "ABOUT_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, ResourceKey = "ABOUT_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string ABOUT_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The TYPE_NO Field of APP_ABOUT Table
		/// </summary>
		[DataField("TYPE_NO"
			, AliasName = "TYPE_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "TYPE_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TYPE_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The TITLE Field of APP_ABOUT Table
		/// </summary>
		[DataField("TITLE"
			, AliasName = "TITLE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 100
			, Width = 100
			, ResourceKey = "TITLE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string TITLE
		{
			set;
			get;
		}
		/// <summary>
		/// The DATE_PUBLISH Field of APP_ABOUT Table
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
		/// The SEQ_NO Field of APP_ABOUT Table
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
		/// The SOURCE Field of APP_ABOUT Table
		/// </summary>
		[DataField("SOURCE"
			, AliasName = "SOURCE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "SOURCE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SOURCE
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
			 , TableJoinSequence = 0
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
		/// The PICTURE_NAME Field of APP_ABOUT Table
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
		/// The KEYLIST Field of APP_ABOUT Table
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
		/// The DESCRIPTION Field of APP_ABOUT Table
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
		/// The CONTENT Field of APP_ABOUT Table
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
		/// The IS_ENABLED Field of APP_ABOUT Table
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
		/// The READ_TMES Field of APP_ABOUT Table
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
		/// The LIKED_TMES Field of APP_ABOUT Table
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
		/// The FILE_NO Field of APP_ABOUT Table
		/// </summary>
		[DataField("FILE_NO"
			, AliasName = "FILE_NO"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 20
			, Width = 100
			, ResourceKey = "FILE_NO"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string FILE_NO
		{
			set;
			get;
		}
		/// <summary>
		/// The REMARK Field of APP_ABOUT Table
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
		/// The CREATE_BY Field of APP_ABOUT Table
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
		/// The CREATE_TIME Field of APP_ABOUT Table
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
		/// The UPDATE_BY Field of APP_ABOUT Table
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
		/// The UPDATE_TIME Field of APP_ABOUT Table
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
		/// APP_ABOUT Table 
		/// </summary>
		public const string TABLE_NAME="APP_ABOUT";
		public const String ABOUT_ID_FIELD  ="ABOUT_ID";
		public const String ABOUT_NO_FIELD  ="ABOUT_NO";
		public const String TYPE_NO_FIELD  ="TYPE_NO";
		public const String TITLE_FIELD  ="TITLE";
		public const String DATE_PUBLISH_FIELD  ="DATE_PUBLISH";
		public const String SEQ_NO_FIELD  ="SEQ_NO";
		public const String SOURCE_FIELD  ="SOURCE";
		public const String PICTURE_MINI_FIELD  ="PICTURE_MINI";
		public const String PICTURE_NAME_FIELD  ="PICTURE_NAME";
		public const String KEYLIST_FIELD  ="KEYLIST";
		public const String DESCRIPTION_FIELD  ="DESCRIPTION";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String READ_TMES_FIELD  ="READ_TMES";
		public const String LIKED_TMES_FIELD  ="LIKED_TMES";
		public const String FILE_NO_FIELD  ="FILE_NO";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_BY_FIELD  ="CREATE_BY";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_BY_FIELD  ="UPDATE_BY";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}