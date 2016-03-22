using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marauder.BLL.ViewModels
{
    public class Response
    {
        /// <summary>
        /// 0-失敗，1-成功
        /// </summary>
        [DefaultValue(0)]
        public int Code { get; set; }

        /// <summary>
        /// 返回訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回資料
        /// </summary>
        public dynamic Data { get; set; }

        public Response()
        {
            Code = 0;
        }
    }
}
