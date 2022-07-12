using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace CurrencyAPI
{
    [FormAttribute("CurrencyAPI.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            //  this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button2_ClickBefore);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }

        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Matrix Matrix0;
        private void OnCustomInitialize()
        {
            //var company = (SAPbobsCOM.Company)SAPbouiCOM.Framework.Application.SBO_Application.Company.GetDICompany();
            var comp = (SAPbobsCOM.Company)SAPbouiCOM.Framework.Application.SBO_Application.Company.GetDICompany();
            var rs = (SAPbobsCOM.Recordset)comp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs.DoQuery("SELECT * FROM OCRN");
            var ds = UIAPIRawForm.DataSources.DataTables.Item("DT_0");
            ds.Rows.Add(rs.RecordCount);
            int count = 0;
            while (!rs.EoF)
            {
                var code = (string)rs.Fields.Item(0).Value;
                ds.SetValue("Check", count, "N");
                ds.SetValue("Currency", count++, code);
                rs.MoveNext();
            }
            Matrix0.LoadFromDataSource();

        }
       
        private void Button2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            var ds = UIAPIRawForm.DataSources.UserDataSources.Item("UD_0");
            var date = DateTime.ParseExact(ds.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        private void OptionBtn0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          
        }
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.OptionBtn OptionBtn2;

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            Form1 curr = new Form1();
            curr.Show();
        }

        private void OptionBtn1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            
        }

      

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Matrix Matrix1;

        private void OptionBtn2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            var ds = UIAPIRawForm.DataSources.UserDataSources.Item("UD_0");
            var date = DateTime.ParseExact(ds.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        private SAPbouiCOM.Button Button0;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //Exchange_Rates_and_Indexes exch = new Exchange_Rates_and_Indexes();
            //exch.show
        }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            throw new System.NotImplementedException();

        }

        //private SAPbouiCOM.Button Button2;

    }
}