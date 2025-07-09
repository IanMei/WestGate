using CMS.Core.Common;
using CMS.Core.Responsity.BLL;
using CMS.Core.Responsity.Db;
using CMS.Core.Responsity.Tables;
using System;
using System.Collections.Generic;

namespace CMS.Core.Responsity
{
    public interface IBaseRepository<Config> where Config : DataBasecfg
    {
        #region Find\GetID\GetKeyCode\GetKeyCodes

        /// <summary>
        /// 查询指定ID的记录是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        bool Find<T>(decimal recordID) where T : BaseObject, new();


        /// <summary>
        /// 查询指定Key值的记录是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool Find<T>(object code) where T : BaseObject, new();


        /// <summary>
        /// 查询指定Key值的记录是否存在
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        bool Find<T>(object[] codes) where T : BaseObject, new();

        /// <summary>
        /// 检查除指定ID外的KeyCode是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        bool Find<T>(decimal recordID, object code) where T : BaseObject, new();


        /// <summary>
        /// 检查除指定ID外的KeyCode是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        bool Find<T>(decimal recordID, object[] codes) where T : BaseObject, new();

        /// <summary>
        /// 检查除指定ID外的非KeyCode是否存在
        /// </summary>
        /// <param name="recordID"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        bool Find<T>(decimal recordID, string field, object codes) where T : BaseObject, new();

        /// <summary>
        /// 根据KeyCode返回ID
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        decimal GetID<T>(object code) where T : BaseObject, new();

        /// <summary>
        /// 根据第一个Key值返回指定的栏位值
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="fieldName"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        object GetFieldValue<T>(Object keyCode, string fieldName) where T : BaseObject, new();

        /// <summary>
        /// 根据所有Key值返回指定栏位值
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <param name="fieldName"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        object GetFieldValue<T>(Object[] keyCodes, string fieldName) where T : BaseObject, new();

        /// <summary>
        /// 根据查询条件返回指定栏位值
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="fieldName"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        object GetFieldValue<T>(ParamCollection _paramCollection, string fieldName) where T : BaseObject, new();

        /// <summary>
        /// 根据查询条件返回栏位值
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="fieldName"></param>
        /// <param name="sort"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        object GetFieldValue<T>(ParamCollection _paramCollection, string fieldName, string sort) where T : BaseObject, new();

        /// <summary>
        /// 根据KeyCodes返回ID
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <returns></returns>
        decimal GetID<T>(object[] keyCodes) where T : BaseObject, new();


        /// <summary>
        /// 根据ID返回KeyCode
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        object GetCode<T>(decimal recordID) where T : BaseObject, new();

        /// <summary>
        /// 根据ID返回所有KeyCodes
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        object[] GetCodes<T>(decimal recordID) where T : BaseObject, new();


        #endregion

        #region Insert,Update,Delete

        /// <summary>
        /// 修改一个实体数据，返回影响的行数，是新增时返回ID
        /// </summary>
        /// <param name="instanceData"></param>
        /// <returns></returns>
        decimal Update(BaseObject instanceData);


        /// <summary>
        /// 删除一条实体数据，返回影响的行数
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        decimal Delete(BaseObject instanceData);

        /// <summary>
        /// 更新主从表
        /// </summary>
        /// <param name="masterData">主表</param>
        /// <param name="datas">从表的数组</param>
        decimal UpdateMasterDetail(BaseObject masterData, params BaseList[] datas);

        /// <summary>
        /// 使用参数的方式更新数据集
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        bool UpdateAllByParams(BaseList masterData);

        /// <summary>
        /// 更新多表
        /// </summary>
        /// <param name="datas"></param>
        void UpdateMultiData(BaseList[] datas);

        /// <summary>
        /// 删除指定数据
        /// </summary>
        /// <param name="masterData"></param>
        /// <returns></returns>
        void Delete(BaseList masterData);

        /// <summary>
        /// 通过ID删除记录
        /// </summary>
        /// <param name="recordID"></param>
        int Delete<T>(decimal recordID) where T : BaseObject, new();

        /// <summary>
        /// 根据第一个Key Code值删除记录
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        int Delete<T>(object keyCode) where T : BaseObject, new();

        /// <summary>
        /// 按条件删除资料
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        int Delete<T>(ParamCollection _paramCollection) where T : BaseObject, new();

        #endregion

        #region Select

        /// <summary>
        /// 根据条件获取记录数
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        int GetCount<T>(ParamCollection _paramCollection) where T : BaseObject, new();



        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sumField">汇总的字段名</param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        decimal GetSum<T>(ParamCollection _paramCollection, string sumField) where T : BaseObject, new();


        /// <summary>
        /// 根据ID查询记录集
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        T Get<T>(decimal recordID) where T : BaseObject, new();


        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        T Get<T>(object keycode) where T : BaseObject, new();


        /// <summary>
        /// 根据KeyCode值查询结果集
        /// </summary>
        /// <param name="keycodes"></param>
        /// <returns></returns>
        T Get<T>(object[] keycodes) where T : BaseObject, new();



        /// <summary>
        /// 返回所有数据
        /// </summary>
        /// <returns></returns>
        List<T> Select<T>() where T : BaseObject, new();

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <returns></returns>
        List<T> Select<T>(ParamCollection _paramCollection) where T : BaseObject, new();


        /// <summary>
        /// 获取满足查询条件的记录并放到记录集
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        List<T> Select<T>(ParamCollection _paramCollection, string orderby) where T : BaseObject, new();

        /// <summary>
        /// 查询满足条件的前N条记录
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <param name="topcount"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        List<T> Select<T>(ParamCollection _paramCollection, string orderby, Int16 topcount) where T : BaseObject, new();



        /// <summary>
        /// 返回Group by语句的查询结果
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="groupby"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        List<T> SelectGroup<T>(ParamCollection _paramCollection, string groupby, string sort) where T : BaseObject, new();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="_paramCollection"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        List<T> SelectByPageIndex<T>(ParamCollection _paramCollection, string sort, int pageIndex, int pageSize, out int pageCount) where T : BaseObject, new();


        #endregion

        /// <summary>
        /// 获取系统编号
        /// </summary>
        /// <param name="noType"></param>
        /// <returns></returns>
        string GetSeqNo(string noType);
        string GetSerialNo(string noType);

        /// <summary>
        /// 获取系统编号
        /// </summary>
        /// <param name="noType"></param>
        /// <param name="CodeLen"></param>
        /// <returns></returns>
        string GetSeqNo(string noType, int CodeLen);

        /// <summary>
        /// 该用户功能权限
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="operationCode">功能代号</param>
        /// <returns></returns>
        bool GetUserOperationPermission(decimal userId, string operationCode);
        /// <summary>
        /// 用户权限验证
        /// </summary>
        /// <param name="token">TOKEN</param>
        /// <param name="funid">功能代码</param>
        /// <returns></returns>
        bool GetUserRight(string token, string funid);
        string GetPermissionArray(decimal userId, string userType);

        /// <summary>
        /// 用户是否购买本课程
        /// </summary>
        /// <param name="userCode">用户编号</param>
        /// <param name="courseNo">课程编号</param>
        /// <returns></returns>
        int GetPayCourse(string userCode, string courseNo);
        /// <summary>
        /// 用户是否购买本资料
        /// </summary>
        /// <param name="userCode">用户编号</param>
        /// <param name="downloadNo">课程编号</param>
        /// <returns></returns>
        int GetPayDownload(string userCode, string downloadNo);
        /// <summary>
        /// 获取直播状态
        /// </summary>
        /// <param name="courseNo">直播课程编号</param>
        /// <returns></returns>
        int GetLiveState(string courseNo);
    }
}
