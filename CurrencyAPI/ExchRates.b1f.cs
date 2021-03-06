
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace CurrencyAPI
{

    [FormAttribute("866", "ExchRates.b1f")]
    class Exchange_Rates_and_Indexes : SystemFormBase 
    {
        public Exchange_Rates_and_Indexes()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Button Button0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Button Button1;


        private SAPbouiCOM.Button Button2;

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Form1 curr = new Form1();
            curr.Show();
        }
    }
}
