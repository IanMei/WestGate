using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_LINK Table
	/// </summary>
	[Serializable]
	[DataTable("APP_LINK", ResourceKey = "APP_LINK")]
	public class APP_LINK : BaseObject
	{
		public APP_LINK()
		{
		}
		public APP_LINK(DealModel initModel) : base(initModel)
		{
		}
		public static APP_LINK Convert(BaseObject from)
		{
			return (APP_LINK)from;
		}
		/// <summary>
		/// The LINK_ID Field of APP_LINK Table
		/// </summary>
		public override decimal ID
		{
			set
			{
				base.ID = value;
				this.LINK_ID = value;
			}
			get { return LINK_ID; }
		}

		[RecordIDField("LINK_ID"
			, AliasName = "LINK_ID"
			, DataType = DbType.Decimal
			, IsNullable = false
			, Size = 10
			, Width = 100
			, ResourceKey = "LINK_ID"
			, GroupFun = "MAX"
			, IsInsertField = false
			, IsUpdateField = false
			 )]
		public decimal LINK_ID
		{
			set;
			get;
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
		/// The LINK_NAME Field of APP_LINK Table
		/// </summary>
		[DataField("LINK_NAME"
			, AliasName = "LINK_NAME"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 20
			, Width = 100
			, ResourceKey = "LINK_NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LINK_NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The LINK_URL Field of APP_LINK Table
		/// </summary>
		[DataField("LINK_URL"
			, AliasName = "LINK_URL"
			, DataType = DbType.String
			, IsNullable = false
			, Size = 200
			, Width = 100
			, ResourceKey = "LINK_URL"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LINK_URL
		{
			set;
			get;
		}
		/// <summary>
		/// The REMARK Field of APP_LINK Table
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
		/// The CREATE_TIME Field of APP_LINK Table
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
		/// The UPDATE_TIME Field of APP_LINK Table
		/// </summary>
		[DataField("UPDATE_TIME"
			, AliasName = "UPDATE_TIME"
			, DataType = DbType.DateTime
			, IsNullable = false
			, Size = 20
			, ResourceKey = "UPDATE_TIME"
			, GroupFun = "MAX"
			, SelectSequence = 104
			, IsInsertField = true
			, IsUpdateField = true
			, DefaultValue = "SysDate"
			 )]
		public DateTime UPDATE_TIME
		{
			set;
			get;
		}
		/// <summary>
		/// APP_LINK Table 
		/// </summary>
		public const string TABLE_NAME = "APP_LINK";
		public const String LINK_ID_FIELD = "LINK_ID";
		public const String IMAGE_ID_FIELD = "IMAGE_ID";
		public const String LINK_NAME_FIELD = "LINK_NAME";
		public const String LINK_URL_FIELD = "LINK_URL";
		public const String REMARK_FIELD = "REMARK";
		public const String CREATE_TIME_FIELD = "CREATE_TIME";
		public const String UPDATE_TIME_FIELD = "UPDATE_TIME";
	}
}