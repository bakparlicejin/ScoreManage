namespace ScoreManager.WebApp.Models
{
    /// <summary>
    /// 通用接口返回格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult
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
        public object Body { get; set; }

        public static ApiResult OK() 
        {
            return new ApiResult()
            {
                Code = 0,
                Message = string.Empty,
                Body = null
            };
        }

        public static ApiResult OK<T>(T detail)where T:class,new()
        {
            return new ApiResult()
            {
                Code = 0,
                Message = string.Empty,
                Body = detail
            };
        }
        public static ApiResult Error(string errMsg)
        {
            return new ApiResult()
            {
                Code = -1,
                Message = errMsg,
                Body = null
            };
        }

        public static ApiResult Error<T>(string errMsg,T detail) where T : class, new()
        {
            return new ApiResult()
            {
                Code = -1,
                Message = errMsg,
                Body = detail
            };
        }
    }
}
