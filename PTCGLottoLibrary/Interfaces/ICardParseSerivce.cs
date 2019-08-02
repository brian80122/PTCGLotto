using PTCGLottoLibrary.Models.ServiceModels.CardParseService;
using System.Collections.Generic;

namespace PTCGLottoLibrary
{
    public interface ICardParseSerivce
    {
        List<List<string>> ReadFiles(string basePath);
        CardParseResult ParseCard(List<string> cardData);
        List<CardParseResult> ParseCards(List<List<string>> datas);
    }
}
