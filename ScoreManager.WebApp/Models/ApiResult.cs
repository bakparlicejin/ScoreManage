namespace ScoreManager.WebApp.Models
{
    /// <summary>
    /// 通用接口返回格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> where T : class,new()
    {
        /// <summary>
        /// 返回编码 0：为正常 其他异常
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 具体消息内容
        /// </summary>
        public T Body { get; set; }

        public static ApiResult<T> OK()
        {
            return new ApiResult<T>()
            {
                Code = 0,
                Message = string.Empty,
                Body = null
            };
        }

        public static ApiResult<T> OK(T detail)
        {
            return new ApiResult<T>()
            {
                Code = 0,
                Message = string.Empty,
                Body = detail
            };
        }
        public static ApiResult<T> Error(string errMsg)
        {
            return new ApiResult<T>()
            {
                Code = -1,
                Message = errMsg,
                Body = null
            };
        }

        public static ApiResult<T> Error(string errMsg,T detail)
        {
            return new ApiResult<T>()
            {
                Code = -1,
                Message = errMsg,
                Body = detail
            };
        }
    }
}
