using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_PizzaProject
{
    public partial class Form1 : Form
    {
        int Price=0;
        public Form1()
        {
            InitializeComponent();
            ResetForm();
        }

        //هي كم اضافة ضاف على البيتزا تعديل على السعر 
        float GetSeletedSizePrice()
        {
            if (rbSmal.Checked)
            {
                return Convert.ToSingle(rbSmal.Tag);
            }
            else if (rbMedium.Checked)
            {
                return Convert.ToSingle(rbMedium .Tag);
            }
            else {
                return Convert.ToSingle(rbLarge.Tag);
            }
        }
        float CalculateToppingsPrice ()
        {
            float ToppingTotalPrice = 0; 
            if (chkExtraChees.Checked)
            {
                ToppingTotalPrice += Convert.ToSingle(chkExtraChees.Tag);
            }

            if (chkGreenPeppers.Checked)
            {
                ToppingTotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }
            if (chkMushrooms.Checked)
            {

                ToppingTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }
            if (chkOinon.Checked)
            {

                ToppingTotalPrice += Convert.ToSingle(chkOinon.Tag);
            }
            if (chkOlives.Checked)
            {

                ToppingTotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }
            if (chkTomatoes.Checked)
            {

                ToppingTotalPrice += Convert.ToSingle(chkOlives.Tag);
            }
            return ToppingTotalPrice;
        }
        float GetSelectedCrutPrice()
        {
            if (rbThinkCrust.Checked)
            {
                return Convert.ToSingle(rbThinkCrust.Tag);
            }
            else {
                return Convert.ToSingle(rbThinCrust.Tag);   
            }
        } 
      
        void UpdateSize() {
            UpdateTotalPrice(); 
            if (rbSmal.Checked) 
            {
                lbSize.Text = "Small";
                return; 
            }else if(rbMedium.Checked) 
            {
                lbSize.Text = "Medium"; return;
            }else
            {
                lbSize.Text = "Large"; return;
            }
        }
        void UpdateCrust() { 
            if (rbThinCrust.Checked)
            {
                lbCrustType.Text = "Thin Crust"; return; 
            }else
            {
                lbCrustType.Text = "Think Crust"; return;
            }
        }
        void UpdateTooping ()
        {
            UpdateTotalPrice() ;
            string sToppings = ""; 
            if (chkExtraChees.Checked) {
                sToppings += "Extra Chees "; 
            }
            if (chkGreenPeppers.Checked) {
                sToppings += ", Green Peppers "; 
            }
            if (chkMushrooms.Checked) {
                sToppings += ", Mushroom "; 
            }if (chkOinon.Checked) {
                sToppings += ", Oinon "; 
            }if (chkOlives.Checked) {
                sToppings += ", Olives "; 
            }if (chkTomatoes.Checked) {
                sToppings += ", Tomatoes "; 
            }
            if (sToppings.StartsWith(",")) {
               sToppings=sToppings.Substring(1,sToppings.Length-1).Trim(); 
            }
            if (sToppings=="")
            {
                sToppings = "No Topping";
            }

            lbToppings.Text = sToppings.Trim() ;
        }
        void UpdateWhereToEat() { 
            if (rbTakeOut.Checked) {
                lbWhereToEat.Text = "Tak Out";
            }
            else
            {
                lbWhereToEat.Text = "Eat In"; 
            }
        }
        float CalculateTotalPrice()
        {
            return GetSeletedSizePrice() + CalculateToppingsPrice() + GetSelectedCrutPrice();
        }
        void UpdateTotalPrice() {
            lbTotalPrice.Text = "$" + CalculateTotalPrice().ToString() ;  
        }
        void ResetForm() {

            grbSize.Enabled = true;
            btnOrderPizza.Enabled = true;
            gbCrustTipe.Enabled = true;
            gbTopping.Enabled = true;
            gbWhereToEat.Enabled = true;

            rbMedium.Checked = true; 

            chkExtraChees.Checked = false;
            chkGreenPeppers.Checked = false;
            chkMushrooms.Checked = false;
            chkOinon.Checked = false;
            chkOlives.Checked = false; 
            chkTomatoes.Checked = false;
            rbThinCrust.Checked = true; 
        }

        void UpdateOrderSummary ()
        {
            UpdateSize();
            UpdateTooping();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }




        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grbSize.Enabled = false;
                btnOrderPizza.Enabled = false;
                gbCrustTipe.Enabled = false;
                gbTopping.Enabled = false;
                gbWhereToEat.Enabled = false;
            }
           
        }

        private void rbSmal_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
           
            UpdateSize();
        }
        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTooping(); 
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTooping();

        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTooping();

        }

        private void chkOinon_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTooping();

        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTooping();

        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTooping();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary(); 
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void grbSize_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetForm(); 
        }
    }
}
