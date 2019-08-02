using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTCGLottoLibrary;
using PTCGLottoLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTCGLottoTest
{
    [TestClass]
    public class CardParseServiceTest
    {
        private ICardParseSerivce _cardParseSerivce;
        public CardParseServiceTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICardParseSerivce, CardParseSerivce>();

            var serviceProvider = services.BuildServiceProvider();
            _cardParseSerivce = serviceProvider.GetService<ICardParseSerivce>();
        }

        [TestMethod]
        public void TestReadFile()
        {
           var datas = _cardParseSerivce.ReadFiles();
           Assert.IsTrue(datas.Count > 0);
        } 
    }
}
