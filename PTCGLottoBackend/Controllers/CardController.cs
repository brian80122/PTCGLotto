using Microsoft.AspNetCore.Mvc;
using PTCGLottoLibrary.Interfaces;
using PTCGLottoLibrary.Models.CodeFirsts;
using PTCGLottoLibrary.Models.ServiceModels.PTCGService;
using PTCGLottoLibrary.Services;

namespace PTCGLottoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private IPTCGService _pTCGService;
        public CardController(IPTCGService pTCGService)
        {
            _pTCGService = pTCGService;
        }

        [HttpPost]
        public ActionResult<Card> PickCard(PickCardRequest request)
        {
            return _pTCGService.PickCard(request);
        }
    }
}