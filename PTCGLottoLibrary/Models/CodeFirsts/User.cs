using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    public class User : IdentityUser
    {
        public int Coin { get; set; }

        public List<Collection> Cards { get; set; }
    }
}
