using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PTCGLottoLibrary.Models.ServiceModels.CardParseService;

namespace PTCGLottoLibrary.Services
{
    public class CardParseSerivce : ICardParseSerivce
    {
        public List<List<string>> ReadFiles()
        {
            var datas = new List<List<string>>();
            var filePaths = Directory.GetFiles(Path.Combine("StaticFiles", "CardDatas"));
            foreach (var filePath in filePaths)
            {
                var data = File.ReadAllText(filePath)
                                .Split(
                                       new[] { "\r\n", "\r", "\n" },
                                       StringSplitOptions.None
                                      );
                datas.Add(data.ToList());
            }

            return datas;
        } 
        public List<CardParseResult> ParseCards(List<List<string>> datas)
        {
            var result = new List<CardParseResult>();


            return result;
        }

    }
}
