using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cal_Electricity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListViewItem add1 = new ListViewItem();
            add1.Text = "01";
            add1.SubItems.Add("Khải");
            add1.SubItems.Add("0705158986");
            add1.SubItems.Add(" Yên Sơn");
            add1.SubItems.Add("MALE");

            lv_hienthi.Items.Add(add1);

        }
        // ListView_1
        private void lv_hienthi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_hienthi.SelectedItems.Count > 0)
            {
                ListViewItem select_Item = lv_hienthi.SelectedItems[0];
                
                string ID = select_Item.SubItems[0].Text;
                string Name = select_Item.SubItems[1].Text;
                string Phone = select_Item.SubItems[2].Text;
                string Address = select_Item.SubItems[3].Text;
                string Gender = select_Item.SubItems[4].Text;
               
                // đẩy dữ liệu lên form
                txtB_id.Text = ID;
                txtB_name.Text = Name;
                txtB_phone.Text = Phone;
                txtB_address.Text = Address;
                if (Gender == "FEMALE")
                {
                    rad_fema.Checked = true;
                }
                else if (Gender == "MALE")
                {
                    rad_male.Checked = true;
                }
            }
            else
            {
                // Xóa các giá trị trên form nếu không có mục nào được chọn
                txtB_id.Text = "";
                txtB_name.Text = "";
                txtB_phone.Text = "";
                txtB_address.Text = "";
                rad_fema.Checked = false;
                rad_male.Checked = false;
            }
        }
        // Add btn_add
        private void btn_add_Click(object sender, EventArgs e)
        {
            string ID = txtB_id.Text;
            string Name = txtB_name.Text;
            string Phone = txtB_phone.Text;
            string Address = txtB_address.Text;
            
            string Gender = null;
            if (rad_fema.Checked)
            {
                Gender = "FEMALE";
            }
            else if (rad_male.Checked)
            {
                Gender = "MALE";
            }
            /*string Type = txtB_address.Text;
            string People = txtB_people.Text;
            string thismonth = txtB_thismonth.Text;
            string lastmonth = txtB_lastmonth.Text;*/

            //  Tạo một ListView để nhận giá trị vào form
            ListViewItem item = new ListViewItem();
            item.Text = ID;
            item.SubItems.Add(Name);
            item.SubItems.Add(Phone);
            item.SubItems.Add(Address);
            item.SubItems.Add(Gender);

            // đẩy giá trị vào form 
            lv_hienthi.Items.Add(item);
        }
        
        // Add btn_edit
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (lv_hienthi.SelectedItems.Count > 0)
            {
                ListViewItem item = lv_hienthi.SelectedItems[0];
                item.SubItems.Clear();

                string ID = txtB_id.Text;
                string Name = txtB_name.Text;
                string Phone = txtB_phone.Text;
                string Address = txtB_address.Text;
                string Gender = null;
                if (rad_fema.Checked)
                {
                    Gender = "FEMALE";
                }
                else if (rad_male.Checked)
                {
                    Gender = "MALE";
                }
                /*string Type = txtB_type.Text;
                string People = txtB_people.Text;
                string thismonth = txtB_thismonth.Text;
                string lastmonth = txtB_lastmonth.Text;*/

                // Nhận giá trị mới trên form
                item.Text = ID;
                item.SubItems.Add(Name);
                item.SubItems.Add(Phone);
                item.SubItems.Add(Address);
                item.SubItems.Add(Gender);
                /*item.SubItems.Add(Type);
                item.SubItems.Add(People);
                item.SubItems.Add(thismonth);
                item.SubItems.Add(lastmonth);*/
                // Xóa dl cũ trên form
                txtB_id.Text = null;
                txtB_name.Text = null;
                txtB_phone.Text = null;
                txtB_address.Text = null;
                rad_fema.Checked = false;
                rad_male.Checked = false;
                /*txtB_type.Text = null;
                txtB_people.Text = null;
                txtB_thismonth.Text = null;
                txtB_lastmonth.Text = null;*/
            }
        }

        // Add btn_calculate
        private void btn_calculate_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có giá trị trong cả 2 textbox không
            if (string.IsNullOrEmpty(txtB_lastmonth.Text) || string.IsNullOrEmpty(txtB_thismonth.Text))
            {
                MessageBox.Show("Vui lòng nhập giá trị vào cả 2 textbox.");
                return;
            }

            // Chuyển đổi giá trị từ textbox thành số nguyên
            if (int.TryParse(txtB_lastmonth.Text, out int LastMonth) && int.TryParse(txtB_thismonth.Text, out int ThisMonth))

                // Kiểm tra xem giá trị tháng trước có lớn hơn hoặc bằng tháng hiện tại không
                if (LastMonth >= ThisMonth) 
                {
                    MessageBox.Show("Giá trị tháng trước phải nhỏ hơn giá trị tháng hiện tại.");
                    return;
                }
            // lấy giá trị tiêu  thụ từ textB
            int consump = int.Parse(txtB_thismonth.Text) - int.Parse(txtB_lastmonth.Text);

            double type = int.Parse(txtB_type.Text);        
            int people = int.Parse(txtB_people.Text);
            double consumpPerson = consump / people;
            //Tính tiền điện dựa trên 4 mức tiêu thụ
            double price = 0;
            if (type == 1) 
            {          
                if (consump <= 10)
                {
                    price = consump * 5.937;
                }
                else if (consump <= 20)
                {
                    price = (10 * 5.973) + ((consump - 10) * 7.052);
                }
                else if (consump <= 30)
                {
                    price = (10 * 5.973) + (10 * 7.052) + ((consump - 20) * 8.699);
                }
                else
                {
                    price = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + ((consump - 30) * 15.929);
                }
            }
            else if (type == 2) 
            {
                price = consump * 22.068;
            }
            else if (type == 3) 
            {
                price = consump * 9.955;
            }
            else if (type == 4) 
            {
                price = consump * 11.615;
            }
            else
            {
                MessageBox.Show("Loại khách hàng không hợp lệ.");
                return;
            }
            double envFee = price * 0.1;
            double VAT = price  * 0.1;
            double totalBill = price + VAT + envFee;
            // Hiện kq ở lv_hienthi
            if (lv_hienthi.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lv_hienthi.SelectedItems[0];
                selectedItem.SubItems.Add(consump.ToString("") + " m3");
                selectedItem.SubItems.Add(totalBill.ToString("") + " VND");
            }
        }
        // Add btn_print
        private void btn_print_Click(object sender, EventArgs e)
        {
            string name = txtB_name.Text;
            string phone = txtB_phone.Text;
            string address = txtB_address.Text;
            string lastmonth = txtB_lastmonth.Text;                   
            string thismonth = txtB_thismonth.Text;
            // thông tin từ listV
            string consump = "";
            string totalBills = "";
            if (lv_hienthi.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lv_hienthi.SelectedItems[0];
                consump = selectedItem.SubItems[5].Text;
                totalBills = selectedItem.SubItems[6].Text;
            }
            Form3 form3 = new Form3(name, phone, address, lastmonth, thismonth, consump, totalBills);
                form3.Show();
                Hide();
        }

        // Add btn_delete
        private void btn_dele_Click(object sender, EventArgs e)
        {
            if (lv_hienthi.SelectedItems.Count > 0)
            {
                lv_hienthi.Items.Remove(lv_hienthi.SelectedItems[0]);
            }
        }

        // Add btn_exit

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Bạn có muốn thoát thật không",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (exit == DialogResult.No)
            {
                MessageBox.Show("Ở lại mà làm tiếp đi ");
            }
            else
            {
                Hide();
            }           
        }
    }
}
