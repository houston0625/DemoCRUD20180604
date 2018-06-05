using System;

namespace DemoCRUD.CommonUtility
{
    public class CommonUtility
    {
        /// <summary>
        /// 回傳資料庫執行結果
        /// </summary>
        public class ResultObject
        {
            /// <summary>
            /// 000: Success / 999:Error
            /// </summary>
            public String ReturnCode { get; set; }
            public String ReturnMessage { get; set; }

            public ResultObject()
            {
                ReturnCode = null;
                ReturnMessage = null;
            }
        }
    }
}