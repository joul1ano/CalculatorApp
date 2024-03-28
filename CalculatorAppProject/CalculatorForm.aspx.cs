using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorApp
{
    public partial class CalculatorForm : System.Web.UI.Page
    {
        calculatorService cs = new calculatorService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn0_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "0";
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "1";
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "2";
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "3";
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "4";
        }

        protected void btn5_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "5";
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "6";
        }

        protected void btn7_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "7";
        }

        protected void btn8_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "8";
        }

        protected void btn9_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "9";
        }

        protected void btnDivide_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "/";
        }

        protected void btnMultiply_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "*";
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "-";
        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            lblPanel.Text = lblPanel.Text + "+";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblPanel.Text = "";
        }

        protected void btnDeleteOne_Click(object sender, EventArgs e)
        {
            string panel;
            panel = lblPanel.Text;
            if (!String.IsNullOrEmpty(panel))
            {
                panel = panel.Remove(panel.Length - 1);
                lblPanel.Text = panel;
            }
            else lblPanel.Text = "";
        }

        protected async void btnResult_Click(object sender, EventArgs e)
        {
            string label, theResult;
          

            label = lblPanel.Text;
            label.Trim();

            theResult = cs.getResult(label);
            lblPanel.Text = theResult;
            


        }
    }
}