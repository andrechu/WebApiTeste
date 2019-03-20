using System.Collections.Generic;

namespace Autoatendimento.Test.Response
{
    public class ListServicesResponse : BaseResponse
    {
        public List<ServiceResponse> Services { get; set; }
    }
}
