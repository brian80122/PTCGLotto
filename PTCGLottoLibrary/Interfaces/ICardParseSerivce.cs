using PTCGLottoLibrary.Models.ServiceModels.CardParseService;
using System.Collections.Generic;

namespace PTCGLottoLibrary
{
    public interface ICardParseSerivce
    {
        List<List<string>> ReadFiles();
        List<CardParseResult> ParseCards(List<List<string>> datas);
    }
}
