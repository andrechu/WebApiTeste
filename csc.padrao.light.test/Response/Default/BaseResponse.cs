using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoatendimento.Test.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public List<MessageResponse> Messages { get; set; }

        #region Construtores

        public BaseResponse()
        {
            Messages = new List<MessageResponse>();
        }

        #endregion
    }
}
