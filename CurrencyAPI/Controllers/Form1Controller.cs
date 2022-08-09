using SAPbobsCOM;
using System;
using SAPbouiCOM.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Controllers
{
    public class Form1Controller 
    {
        public Company Company { get; }
        public SAPbouiCOM.IForm Form { get; }
        public SAPbouiCOM.DataTable DataTable { get { return Form.DataSources.DataTables.Item("DT_0"); } }
        public SAPbouiCOM.Matrix Matrix { get; set; }
        public SAPbouiCOM.EditText StartDateEditText { get; set; }
        public SAPbouiCOM.UserDataSource StartDateDS { get; set; }
        public DateTimeOffset StartDate { get { return DateTime.ParseExact(StartDateDS.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture); } }
        //public SAPbouiCOM.DataTable Exchs { get { return Form.DataSources.DataTables.Item("ORTT"); } }


        public Form1Controller(SAPbobsCOM.Company Company, SAPbouiCOM.IForm Form)
        {
            this.Company = Company;
            this.Form = Form;
            Matrix = (SAPbouiCOM.Matrix)Form.Items.Item("Item_1").Specific;
            StartDateEditText = (SAPbouiCOM.EditText)Form.Items.Item("Item_0").Specific;
            StartDateDS = Form.DataSources.UserDataSources.Item("UD_1");
        }


        public void InitMatrix()
        {

            var company = (SAPbobsCOM.Company)SAPbouiCOM.Framework.Application.SBO_Application.Company.GetDICompany();

            var rs = (SAPbobsCOM.Recordset)company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            rs.DoQuery("SELECT * FROM OCRN");

            var ds = Form.DataSources.DataTables.Item("DT_0");
            ds.Rows.Add(rs.RecordCount);

            int count = 0;
            while (!rs.EoF)
            {
                var code = (string)rs.Fields.Item(0).Value;
                ds.SetValue("Check", count, "N");
                ds.SetValue("Currency", count++, code);
                rs.MoveNext();
            }
            Matrix.LoadFromDataSource();
        }

        public void UpdateExhcnageRates()
        {
            //esdarcha
        }

        public bool Vaidate()
        {
            if (StartDateDS.Value != "")
                return true;

            return false;
        }
        public void GetAllCurrencies()
        {
            CurrencyService currserv = new CurrencyService();
            var currencies = currserv.GetCurrencies();
        }
        public void GetCheckboxValue()
        {
            var rs = (SAPbobsCOM.SBObob)Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);// sdk shi chavwero
            CurrencyService currserv = new CurrencyService();
            
            //rs.SetCurrencyRate()
            Matrix.FlushToDataSource();
            for (int i = 0; i < DataTable.Rows.Count; i++)
            {
                var checkbox = (string)DataTable.GetValue("Check", i);
                var currency = (string)DataTable.GetValue("Currency", i);
                if (checkbox == "Y")
                {
                    //test = currency;
                    Matrix.FlushToDataSource();
                    if (currency == "EUR")
                    {
                        var currencies =  currserv.GetCurrencies(CurrencyEnums.EUR);
                        //Exchs.SetValue("Currency Rate", i, currencies.currencies[0]);
                        rs.SetCurrencyRate(currencies.currencies[0].Code, currencies.Date, currencies.currencies[0].Rate);
                    }
                    if (currency == "USD")
                    {
                        //CurrencyService currserv = new CurrencyService();
                        var usd = currserv.GetCurrencies(CurrencyEnums.USD);
                        rs.SetCurrencyRate(usd.currencies[0].Code, usd.Date, usd.currencies[0].Rate);
                    }
                    if (currency == "RUB")
                    {
                        //CurrencyService currserv = new CurrencyService();
                        var rub = currserv.GetCurrencies(CurrencyEnums.RUB);
                        rs.SetCurrencyRate(rub.currencies[0].Code, rub.Date, rub.currencies[0].Rate);
                    }
                    
                }
            }
        }
    }
}
