using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cal_Electricity
{
    public partial class Form3 : Form
    {
        public Form3(string name, string phone, string address, string lastmonth, string thismonth,string consump,string totalBills)
        {
            InitializeComponent();
            txtB_name.Text = name;
            txtB_phone.Text = phone;
            txtB_address.Text = address;
            txtB_lastmonth.Text = lastmonth;
            txtB_thismonth.Text = thismonth;
            txtB_consump.Text = consump;
            txtB_total.Text = totalBills;
        }

        private void btn_exit_MouseClick(object sender, MouseEventArgs e)
        {
            btn_exit.ForeColor = Color.Green;
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            DialogResult cc = MessageBox.Show("Are you want to return", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cc == DialogResult.Yes) 
            {
                Form1 form1 = new Form1();
                form1.Show();
                Close();
            }
            else 
            {
                MessageBox.Show("Nono có gì đâu mà return");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
