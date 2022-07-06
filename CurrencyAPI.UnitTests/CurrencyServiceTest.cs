using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.UnitTests
{
    [TestClass]
     public class CurrencyServiceTest
     {
        [TestMethod]
        public void GetCurrenciesTest()
        {
            CurrencyService service = new CurrencyService();
            var obj = service.GetCurrencies();
            Assert.IsNotNull(obj);
        }
     } 
}
