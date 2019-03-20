using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoatendimento.Test.Response
{
    public class TokenResponse
    {
        public TokenResponse()
        {
            InclusionDate = DateTime.Now;
        }

        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public DateTime InclusionDate { get; set; }

        internal bool IsExpired()
        {
            return InclusionDate.AddSeconds(expires_in - 2000) < DateTime.Now;
        }

        // public string GetToken { get { return token_type + " " + access_token; } }
        public string GetToken { get { return "bearer SHanATh0RXf15pL5W-iqcVDl0_gNwJ6UkM8-KQvZ2W9oJ90xm-GuMCFgQBQTu8f8-NhlP_6_91McBK1_nuQnij0ySzh2Py1_zLXTaNcFCvKYihrm8mxMULLpt2fLaLVszobzc5W-6wEEhUrxftdzNrpTNA24y17OKAccJoPrYA0LdzWGNnNRabKyQIm_rpljyA0ok7mdqatpFDT9Vw3yG5hKenqA4CAoDucmUJia3IYt8_rqQxy2lO7LyQDMUsG1rmPhKMq602cLzodgsGuz66Fg5icKsgFLQsB9-7F7uthPRX-zXE-G62Xq_oTGL5wpFx4g672iZxUYiEFhYg9QRU1-1B2s0cZfd6NE2AWI1zz6WmmZUjRTIu7mBNxG2t9q"; } }
    }
}
