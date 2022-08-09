using CurrencyAPI.Controllers;
using SAPbouiCOM;
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

        public Form1Controller form1Controller { get; set; }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            //    this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button2.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button2_PressedAfter);
            this.Button2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button2_ClickBefore);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.OptionBtn OptionBtn2;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Matrix Matrix0;
        private void OnCustomInitialize()
        {
            form1Controller = new Form1Controller((SAPbobsCOM.Company)SAPbouiCOM.Framework.Application.SBO_Application.Company.GetDICompany(), UIAPIRawForm);
            form1Controller.InitMatrix();
        }
       

        private void OptionBtn0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          
        }
        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            Form1 curr = new Form1();
            curr.Show();
        }

        private void Button2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            var ds = UIAPIRawForm.DataSources.UserDataSources.Item("UD_0");
            //var date = DateTime.Parse(ds.Value); //DateTime.ParseExact(ds.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture); // exception
        }

        private SAPbouiCOM.Button Button0;


        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            UIAPIRawForm.Close();
        }

        private void Button2_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            form1Controller.GetCheckboxValue();

            //var ds = UIAPIRawForm.DataSources.UserDataSources.Item("UD_1");
            //var ds1 = UIAPIRawForm.DataSources.UserDataSources.Item("UD_0");

            //var startDate = DateTime.ParseExact(ds.Value, "yyyyMMdd", CultureInfo.InvariantCulture);
            //var endDate = DateTime.ParseExact(ds1.Value, "yyyyMMdd", CultureInfo.InvariantCulture);


            //List<string> selectedCurrency = new List<string>();
            //var dt = UIAPIRawForm.DataSources.DataTables.Item("DT_0");

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if ((string)dt.GetValue("Check", i) == "Y")
            //    {
            //        selectedCurrency.Add((string)dt.GetValue("Currnecy", i));
            //    }
            //}

            //if (selectedCurrency.Count == 0)
            //    return;

            //while (startDate <= endDate)
            //{

            //    foreach (var curr in selectedCurrency)
            //    {
            //        //var rate = CurrencyService.GetCurrency(startdate, curr);
            //        //SAPCurrencyService.SetCurrency(curr, startdate, rate);
            //    }

            //    startDate.AddDays(1);
            //}

            //if (form1Controller.Vaidate())
            //    form1Controller.UpdateExhcnageRates();
            
        }
    }

}