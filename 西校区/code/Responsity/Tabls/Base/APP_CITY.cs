using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CMS.Core.Common;

namespace CMS.Core.Responsity.Tables
{
	/// <summary>
	/// Object Data Class for APP_CITY Table
	/// </summary>
	[Serializable]
	[DataTable("APP_CITY",ResourceKey = "APP_CITY")]
	public class APP_CITY: BaseObject
	{
		public APP_CITY()
		{
		}
		public APP_CITY(DealModel initModel):base(initModel)
		{
		}
		public static APP_CITY Convert(BaseObject from)
		{
			return (APP_CITY)from;
		}
		/// <summary>
		/// The ID Field of APP_CITY Table
		/// </summary>
		[DataField("ID"
			, AliasName = "ID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "ID"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ID
		{
			set;
			get;
		}
		/// <summary>
		/// The NAME Field of APP_CITY Table
		/// </summary>
		[DataField("NAME"
			, AliasName = "NAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "NAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string NAME
		{
			set;
			get;
		}
		/// <summary>
		/// The PARENTID Field of APP_CITY Table
		/// </summary>
		[DataField("PARENTID"
			, AliasName = "PARENTID"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "PARENTID"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PARENTID
		{
			set;
			get;
		}
		/// <summary>
		/// The SHORTNAME Field of APP_CITY Table
		/// </summary>
		[DataField("SHORTNAME"
			, AliasName = "SHORTNAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "SHORTNAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string SHORTNAME
		{
			set;
			get;
		}
		/// <summary>
		/// The LEVELTYPE Field of APP_CITY Table
		/// </summary>
		[DataField("LEVELTYPE"
			, AliasName = "LEVELTYPE"
			, DataType = DbType.Double
			, IsNullable = true
			, Size = 8
			, Width = 100
			, ResourceKey = "LEVELTYPE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public double LEVELTYPE
		{
			set;
			get;
		}
		/// <summary>
		/// The CITYCODE Field of APP_CITY Table
		/// </summary>
		[DataField("CITYCODE"
			, AliasName = "CITYCODE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "CITYCODE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string CITYCODE
		{
			set;
			get;
		}
		/// <summary>
		/// The ZIPCODE Field of APP_CITY Table
		/// </summary>
		[DataField("ZIPCODE"
			, AliasName = "ZIPCODE"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "ZIPCODE"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string ZIPCODE
		{
			set;
			get;
		}
		/// <summary>
		/// The MERGERNAME Field of APP_CITY Table
		/// </summary>
		[DataField("MERGERNAME"
			, AliasName = "MERGERNAME"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "MERGERNAME"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string MERGERNAME
		{
			set;
			get;
		}
		/// <summary>
		/// The LNG Field of APP_CITY Table
		/// </summary>
		[DataField("LNG"
			, AliasName = "LNG"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "LNG"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LNG
		{
			set;
			get;
		}
		/// <summary>
		/// The LAT Field of APP_CITY Table
		/// </summary>
		[DataField("LAT"
			, AliasName = "LAT"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "LAT"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string LAT
		{
			set;
			get;
		}
		/// <summary>
		/// The PINYIN Field of APP_CITY Table
		/// </summary>
		[DataField("PINYIN"
			, AliasName = "PINYIN"
			, DataType = DbType.String
			, IsNullable = true
			, Size = 255
			, Width = 100
			, ResourceKey = "PINYIN"
			, GroupFun = "MAX"
			, IsInsertField = true
			, IsUpdateField = true
			 )]
		public string PINYIN
		{
			set;
			get;
		}
		/// <summary>
		/// APP_CITY Table 
		/// </summary>
		public const string TABLE_NAME="APP_CITY";
		public const String ID_FIELD  ="ID";
		public const String NAME_FIELD  ="NAME";
		public const String PARENTID_FIELD  ="PARENTID";
		public const String SHORTNAME_FIELD  ="SHORTNAME";
		public const String LEVELTYPE_FIELD  ="LEVELTYPE";
		public const String CITYCODE_FIELD  ="CITYCODE";
		public const String ZIPCODE_FIELD  ="ZIPCODE";
		public const String MERGERNAME_FIELD  ="MERGERNAME";
		public const String LNG_FIELD  ="LNG";
		public const String LAT_FIELD  ="LAT";
		public const String PINYIN_FIELD  ="PINYIN";
	}
}