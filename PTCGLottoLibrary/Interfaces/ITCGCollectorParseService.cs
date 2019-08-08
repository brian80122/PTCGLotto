using PTCGLottoLibrary.Models.ServiceModels.CardParseService;
using System.Collections.Generic;

namespace PTCGLottoLibrary.Interfaces
{
    public interface ITCGCollectorParseService
    {
        CardParseResult ParseListHtml(string sourceHtml);
        Dictionary<int, string> ParseImageHtml(string sourceHtml);
    }
}
