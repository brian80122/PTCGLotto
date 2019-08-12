using Microsoft.EntityFrameworkCore;
using PTCGLottoLibrary.Interfaces;
using PTCGLottoLibrary.Models.CodeFirsts;
using PTCGLottoLibrary.Models.ServiceModels.PTCGService;
using System;
using System.Linq;

namespace PTCGLottoLibrary.Services
{
    public class PTCGService : IPTCGService
    {
        PTCGLottoContext _pTCGLottoContext { get; set; }
        public PTCGService(PTCGLottoContext pTCGLottoContext)
        {
            _pTCGLottoContext = pTCGLottoContext;
        }

        public Card PickCard(PickCardRequest request)
        {
            var poolQueryable = _pTCGLottoContext.Cards.AsQueryable();
            if (!string.IsNullOrEmpty(request.Expansion))
            {
                var expansionId = _pTCGLottoContext.Expansions.FirstOrDefault(c => c.Name == request.Expansion)?.Id;
                if (expansionId.HasValue)
                {
                    poolQueryable.Where(c => c.ExpansionId == expansionId);
                }
            }

            var idPool = poolQueryable.Select(c => c.Id)
                                      .ToList();
            var randomNumber = new Random().Next(0, idPool.Count - 1);
            var pickedId = idPool[randomNumber];

            return _pTCGLottoContext.Cards
                                    .FirstOrDefault(c => c.Id == pickedId);
        }
    }
}
