namespace CMS.Core.Common {

    public class RequestMessageBase<T> where T : class
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }

    public class RequestMessageError<T> : RequestMessageBase<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">错误信息</param>
        public RequestMessageError(string message)
        {
            base.Status = 300;
            base.Message = message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status">状态码</param>
        /// <param name="message">错误信息</param>
        public RequestMessageError(int status, string message)
        {
            base.Status = status;
            base.Message = message;
        }

    }

    public class RequestMessageSuccess<T> : RequestMessageBase<T> where T : class
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">返回结果</param>
        public RequestMessageSuccess(string message)
        {
            base.Status = 200;
            base.Message = message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">返回结果</param>
        public RequestMessageSuccess(T obj)
        {
            base.Message = "success";
            base.Status = 200;
            Data = obj;
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Data { get; set; }
    }

    public class RequestMessagePageList<T> : RequestMessageBase<T> where T : class
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">分页列表</param>
        /// <param name="recordCount">总记录数</param>
        public RequestMessagePageList(T list, int recordCount, int page, int size)
        {
            base.Status = 200;
            base.Message = "success";
            Total = recordCount;
            Data = list;
            Page = page;
            Size = size;
        }


        /// <summary>
        /// 返回结果
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public int Total { get; set; }


        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }


        /// <summary>
        /// 每页记录数
        /// </summary>
        public int Size { get; set; }


        /// <summary>
        /// 更多
        /// </summary>
        public bool Move { get; set; }

    }
}
