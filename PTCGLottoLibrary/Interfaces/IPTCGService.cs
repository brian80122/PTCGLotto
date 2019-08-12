using PTCGLottoLibrary.Models.CodeFirsts;
using PTCGLottoLibrary.Models.ServiceModels.PTCGService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTCGLottoLibrary.Interfaces
{
    public interface IPTCGService
    {
        Card PickCard(PickCardRequest request);
    }
}
