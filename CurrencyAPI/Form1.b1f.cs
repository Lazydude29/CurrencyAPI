using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
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
            this.OptionBtn0.ClickBefore += new SAPbouiCOM._IOptionBtnEvents_ClickBeforeEventHandler(this.OptionBtn0_ClickBefore);
            this.OptionBtn1 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_4").Specific));
            //  this.OptionBtn1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.OptionBtn1_ClickAfter);
            this.OptionBtn2 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_5").Specific));
            // this.OptionBtn2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.OptionBtn2_ClickBefore);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_6").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_0").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_2").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void OnCustomInitialize()
        {

        }
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.OptionBtn OptionBtn2;

        private void OptionBtn0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            throw new System.NotImplementedException();

        }

        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button1;

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            Form1 curr = new Form1();
            curr.Show();
        }

        private void OptionBtn1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           //logika gasaweri ukana pageze dasabrunebeli
        }

        private void OptionBtn2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            

        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Matrix Matrix1;

        
    }
}