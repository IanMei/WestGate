using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
    /// <summary>
    /// Object Data Class for APP_BANNER Table
    /// </summary>
    [Serializable]
	[DataTable("APP_BANNER",ResourceKey = "APP_BANNER")]
	public class APP_BANNER: BaseObject
	{
		public APP_BANNER()
		{
		}
		public APP_BANNER(DealModel initModel):base(initModel)
		{
		}
		public static APP_BANNER Convert(BaseObject from)
		{
			return (APP_BANNER)from;
		}
		/// <summary>
		/// The BANNER_ID Field of APP_BANNER Table
		/// </summary>
		private decimal _banner_id;
		public override decimal ID 
		{
			set {
				base.ID = value;
				 this.BANNER_ID = value; }
			get { return BANNER_ID; }
		}

		[RecordIDField("BANNER_ID"
			, AliasName = "BANNER_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = false
			, DisplayInMaintain = false
			, DisplayInDialog = false
			, ResourceKey = "BANNER_ID"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 0
			, DialogSequence = 0
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal BANNER_ID
		{
			set { _banner_id = value; }
			get { return _banner_id; }
		}
		/// <summary>
		/// The BANNER_NO Field of APP_BANNER Table
		/// </summary>
		private string _banner_no;
		[KeyField("BANNER_NO"
			, AliasName = "BANNER_NO"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width =100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = true
			, ResourceKey = "BANNER_NO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = true
			, SelectSequence = 3
			, DialogSequence = 3
			, IsInsertField = true
			, IsUpdateField = true
			, KeySequence = 0
			 )]
		public string BANNER_NO
		{
			set { _banner_no = value; }
			get { return _banner_no; }
		}
		/// <summary>
		/// The BANNER_TITLE Field of APP_BANNER Table
		/// </summary>
		private string _banner_title;
		[DataField("BANNER_TITLE"
			, AliasName = "BANNER_TITLE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 50
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "BANNER_TITLE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 6
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string BANNER_TITLE
		{
			set { _banner_title = value; }
			get { return _banner_title; }
		}
        /// <summary>
        /// The IMAGE_ID Field of APP_BANNER Table
        /// </summary>
        private decimal _image_id;
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
            set { _image_id = value; }
            get { return _image_id; }
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
		/// The SEQ_NO Field of APP_BANNER Table
		/// </summary>
		private decimal _seq_no;
		[DataField("SEQ_NO"
			, AliasName = "SEQ_NO"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "SEQ_NO"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 15
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public decimal SEQ_NO
		{
			set { _seq_no = value; }
			get { return _seq_no; }
		}
		/// <summary>
		/// The BANNER_TYPE Field of APP_BANNER Table
		/// </summary>
		private string _banner_type;
		[DataField("BANNER_TYPE"
			, AliasName = "BANNER_TYPE"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 2
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "BANNER_TYPE"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 18
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string BANNER_TYPE
		{
			set { _banner_type = value; }
			get { return _banner_type; }
		}
		/// <summary>
		/// The HTML_URL Field of APP_BANNER Table
		/// </summary>
		private string _html_url;
		[DataField("HTML_URL"
			, AliasName = "HTML_URL"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 100
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "HTML_URL"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 21
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string HTML_URL
		{
			set { _html_url = value; }
			get { return _html_url; }
		}
		/// <summary>
		/// The CONTENT Field of APP_BANNER Table
		/// </summary>
		private string _content;
		[DataField("CONTENT"
			, AliasName = "CONTENT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 8
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "CONTENT"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 24
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CONTENT
		{
			set { _content = value; }
			get { return _content; }
		}
		/// <summary>
		/// The IS_ENABLED Field of APP_BANNER Table
		/// </summary>
		private Int32 _is_enabled;
		[DataField("IS_ENABLED"
			, AliasName = "IS_ENABLED"
			, DataType = DbType.Int32
			, IsNullable = false
			, Size = 4
			, Width = 100
			, DisplayInCondition = true
			, DisplayInMaintain = true
			, DisplayInDialog = false
			, ResourceKey = "IS_ENABLED"
			, GroupFun = "MAX"
			, AllowEdit = false
			, Frozen = false
			, SelectSequence = 27
			, DialogSequence = -1
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public Int32 IS_ENABLED
		{
			set { _is_enabled = value; }
			get { return _is_enabled; }
		}
		/// <summary>
		/// The REMARK Field of APP_BANNER Table
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
			, SelectSequence = 30
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
		/// The CREATE_TIME Field of APP_BANNER Table
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
		/// The UPDATE_TIME Field of APP_BANNER Table
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
		/// APP_BANNER Table 
		/// </summary>
		public const string TABLE_NAME="APP_BANNER";
		public const String BANNER_ID_FIELD  ="BANNER_ID";
		public const String BANNER_NO_FIELD  ="BANNER_NO";
		public const String BANNER_TITLE_FIELD  ="BANNER_TITLE";
        public const String IMAGE_ID_FIELD = "IMAGE_ID";
        public const String SEQ_NO_FIELD  ="SEQ_NO";
		public const String BANNER_TYPE_FIELD  ="BANNER_TYPE";
		public const String HTML_URL_FIELD  ="HTML_URL";
		public const String CONTENT_FIELD  ="CONTENT";
		public const String IS_ENABLED_FIELD  ="IS_ENABLED";
		public const String REMARK_FIELD  ="REMARK";
		public const String CREATE_TIME_FIELD  ="CREATE_TIME";
		public const String UPDATE_TIME_FIELD  ="UPDATE_TIME";
	}
}