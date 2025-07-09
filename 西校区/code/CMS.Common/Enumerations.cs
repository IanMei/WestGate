using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CMS.Core.Common
{
    /// <summary>
    /// UI中界面控件的值是否必须的属性及相应的颜色设定
    /// </summary>
    [Serializable]
    public enum FieldInputType
    {
        /// <summary>
        /// 空
        /// </summary>
        None = 0,
        /// <summary>
        /// 关键字栏位
        /// </summary>
        KeyField = 1,
        /// <summary>
        /// 必填栏位
        /// </summary>
        Required = 2,
        /// <summary>
        /// 可选栏位
        /// </summary>
        Option = 3,
        /// <summary>
        /// 只读栏位
        /// </summary>
        ReadOnly = 4,
        /// <summary>
        /// 只读但必要非空	
        /// </summary>
        ReadRequired = 5,
        /// <summary>
        /// 用户自定义栏位颜色
        /// </summary>
        UserOption1 = 6,
        /// <summary>
        /// 用户自定义栏位颜色
        /// </summary>
        UserOption2 = 7,

        /// <summary>
        /// 搜索栏位标签颜色
        /// </summary>
        Search = 8
    }

    /// <summary>
    /// Field的外键联接属性
    /// </summary>
    [Serializable]
    public enum TableJoinType
    {
        /// <summary>
        /// 无连接
        /// </summary>
        None = 0,
        /// <summary>
        /// INNER JOIN
        /// </summary>
        InnerJoin = 1,
        /// <summary>
        /// LEFT OUT JOIN
        /// </summary>
        LeftOuterJoin = 2,
        /// <summary>
        /// RIGHT OUT JOIN
        /// </summary>
        RightOuterJoin = 3,
        /// <summary>
        /// FULL OUT JOIN
        /// </summary>
        FullOuterJoin = 4
    }

    /// <summary>
    /// UI界面中控件的值需要做的验证类别
    /// </summary>
    [Serializable]
    public enum FieldRegType
    {
        /// <summary>
        /// 不做验证
        /// </summary>
        None = 0,
        /// <summary>
        /// 有效数值验证
        /// </summary>
        DecimalReg = 1,
        /// <summary>
        /// 带符号数值
        /// </summary>
        DecimalSignReg = 2,
        /// <summary>
        /// 正整数验证
        /// </summary>
        NumberReg = 3,
        /// <summary>
        /// 带符号整数
        /// </summary>
        NumberSignReg = 4,
        /// <summary>
        /// 邮件地址验证
        /// </summary>
        EmailReg = 5,
        /// <summary>
        /// 日期时间值
        /// </summary>
        DateTimeReg = 6,
        /// <summary>
        /// 电话号码值
        /// </summary>
        PhoneReg = 7,
        /// <summary>
        /// 身份证值
        /// </summary>
        IdCardReg = 8
    }

    /// <summary>
    /// 定义操作模式
    /// </summary>
    [Serializable]
    public enum DealModel
    {
        /// <summary>
        /// 查询
        /// </summary>
        Search = 0,
        /// <summary>
        /// 新增
        /// </summary>
        New = 1,
        /// <summary>
        /// 修改
        /// </summary>
        Modify = 2,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 3,
        /// <summary>
        /// 自定义
        /// </summary>
        None = 4
    }

    /// <summary>
    /// 子窗体的画面类型
    /// </summary>
    [Serializable]
    public enum TabPageType
    {
        /// <summary>
        /// Master资料维护
        /// </summary>
        MasterPage = 0,
        /// <summary>
        /// Detail资料维护
        /// </summary>
        DetailPage = 1,
        /// <summary>
        /// 资料导入界面
        /// </summary>
        ImportPage = 2,
        /// <summary>
        /// 报表界面
        /// </summary>
        ReportPage = 3,
        /// <summary>
        /// 用户自定义
        /// </summary>
        None = 4
    }

    /// <summary>
    /// 预定权限
    /// </summary>
    [Serializable]
    public class Operation
    {
        /// <summary>
        /// 目录权限
        /// </summary>
        public const decimal Cate = 10;
        /// <summary>
        /// 模块权限
        /// </summary>
        public const decimal Module = 20;
        /// <summary>
        /// 查询
        /// </summary>
        public const decimal Search = 30;
        /// <summary>
        /// 新增
        /// </summary>
        public const decimal Add = 31;
        /// <summary>
        /// 修改
        /// </summary>
        public const decimal Modify = 32;
        /// <summary>
        /// 删除
        /// </summary>
        public const decimal Delete = 33;
        /// <summary>
        /// 保存
        /// </summary>
        public const decimal Save = 34;
        /// <summary>
        /// 执行
        /// </summary>
        public const decimal Execute = 35;
        /// <summary>
        /// 导入
        /// </summary>
        public const decimal Import = 40;
        /// <summary>
        /// 导出
        /// </summary>
        public const decimal Export = 41;
        /// <summary>
        /// 打印
        /// </summary>
        public const decimal Print = 50;
        /// <summary>
        /// 预定功能1
        /// </summary>
        public const decimal Operation1 = 60;
        /// <summary>
        /// 预定功能2
        /// </summary>
        public const decimal Operation2 = 61;
        /// <summary>
        /// 预定功能3
        /// </summary>
        public const decimal Operation3 = 62;
        /// <summary>
        /// 预定功能4
        /// </summary>
        public const decimal Operation4 = 63;
    }

    /// <summary>
    /// json 状态码
    /// </summary>
    public class JsonCodes
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static readonly int SUCCESS = 1;

        /// <summary>
        /// 失败
        /// </summary>
        public static readonly int FAIL = 0;

        /// <summary>
        /// 授权过期
        /// </summary>
        public static readonly int TOKEN_TIMEOUT = 1000;

        /// <summary>
        /// 没有权限
        /// </summary>
        public static readonly int NON_AUTHORITY = 2000;
    }

    /// <summary>
    /// 表示接口返回状态可能的枚举
    /// 参数错误：10001-19999 
    /// 用户错误：20001-29999
    /// 业务错误：30001-39999
    /// 系统错误：40001-49999
    /// 数据错误：50001-599999
    /// 接口错误：60001-69999
    /// 权限错误：70001-79999
    /// </summary>
    public enum StatusType
    {
        [Text("操作成功。")]
        Success = 200,
        [Text("操作失败。")]
        Error = -1,
        [Text("服务器错误")]
        ServerError = 1000,
        [Text("参数无效")]
        ParameterInvalid = 10001,
        [Text("参数为空")]
        ParameterNull = 10002,
        [Text("参数类型错误")]
        ParameterTypeError = 10003,
        [Text("参数缺失")]
        ParameterMiss = 10004,
        [Text("用户未登录")]
        UserNotLogin = 20001,
        [Text("账号不存在或密码错误")]
        AccountError = 20002,
        [Text("账号已被禁用")]
        UserDisabled = 20003,
        [Text("用户不存在")]
        UserNotExits = 20004,
        [Text("用户已存在")]
        UserExits = 20005,
        [Text("某业务出现问题")]
        BusinessProblems = 30001,
        [Text("系统繁忙, 请稍后重试")]
        SystemBusy = 40001,
        [Text("数据未找到")]
        DataNotFound = 50001,
        [Text("数据有误")]
        DataError = 50002,
        [Text("数据已存在")]
        DataExits = 50003,
        [Text("查询出错")]
        QueryError = 50004,
        [Text("内部系统接口调用异常")]
        InternalInvokeException = 60001,
        [Text("外部系统接口调用异常")]
        ExternalInvokeException = 60002,
        [Text("该接口禁止访问")]
        BlockingAccess = 60003,
        [Text("接口地址无效")]
        URLExpireError = 60004,
        [Text("接口请求超时")]
        RequestTimeout = 60005,
        [Text("接口负载过高")]
        ExcessiveInterfaceLoad = 60006,
        [Text("无权限访问")]
        UnauthorizedAccess = 70001
    }
}
