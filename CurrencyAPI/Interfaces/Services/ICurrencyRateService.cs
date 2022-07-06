using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI
{
    public interface ICurrencyRateService
    {
         Currencies GetCurrencies();
         
         Currencies GetCurrencies(CurrencyEnums currencyEnum);

         Currencies GetCurrencies(DateTime dateTime);

         Currencies GetCurrencies(string currencyCode);

    }
}
