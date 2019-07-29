using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    public class User: IdentityUser
    {
        public int Coin { get; set; }
    }
}
