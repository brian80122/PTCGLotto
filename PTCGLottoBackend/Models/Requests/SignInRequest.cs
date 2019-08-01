using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTCGLottoBackend.Models.Requests
{
    public class SignInRequest : BaseAccountInfoViewModel
    {
        public bool RememberMe { get; set; }
    }
}
