using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI
{
    public class BaseController
    {
        protected SAPbobsCOM.Company Company { get; set; }

        public SAPbouiCOM.IForm Form { get; set; }

        public BaseController(SAPbobsCOM.Company Company, SAPbouiCOM.IForm Form)
        {
            this.Company = Company;
            this.Form = Form;
        }
    }

}
