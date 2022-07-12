using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Controllers
{
    public class Form1Controller
    {
        public Form1Controller(SAPbobsCOM.Company Company, SAPbouiCOM.IForm Form)
        {
            this.Company = Company;
            this.Form = Form;
            Matrix = (SAPbouiCOM.Matrix)Form.Items.Item("Item_1").Specific;
            StartDateEditText = (SAPbouiCOM.EditText)Form.Items.Item("Item_0").Specific;
            StartDateDS = Form.DataSources.UserDataSources.Item("UD_1");
        }

        public Company Company { get; }
        public SAPbouiCOM.IForm Form { get; }
        public SAPbouiCOM.DataTable DataTable { get { return Form.DataSources.DataTables.Item("DT_0"); } }
        public SAPbouiCOM.Matrix Matrix { get; set; }
        public SAPbouiCOM.EditText StartDateEditText { get; set; }
        public SAPbouiCOM.UserDataSource StartDateDS { get; set; }
        public DateTimeOffset StartDate { get { return DateTime.ParseExact(StartDateDS.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture); } }

        public void InitMatrix()
        {
            
            var rs = (SAPbobsCOM.Recordset)Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs.DoQuery("SELECT * FROM OCRN");

            DataTable.Rows.Add(rs.RecordCount);
            int count = 0;
            while (!rs.EoF)
            {
                var code = (string)rs.Fields.Item(0).Value;
                DataTable.SetValue("Check", count, "N");
                DataTable.SetValue("Currency", count++, code);
                rs.MoveNext();
            }
            Matrix.LoadFromDataSource();
        }

        internal void UpdateExhcnageRates()
        {
            
        }

        internal bool Vaidate()
        {
            if (StartDateDS.Value != "")
                return true;

            return false;
        }
    }
}
