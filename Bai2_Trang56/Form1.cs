using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2_Trang56
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtA_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.Turquoise;
        }

        private void txtA_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.White;
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnTinhTong_Click(object sender, EventArgs e)
        {
            int soBe, soLon;
            if(txtA.Text == "")
            {
                MessageBox.Show("Cần phải nhập dữ liệu");
                txtA.Focus();
                return;
            }
            if (txtB.Text == "")
            {
                MessageBox.Show("Cần phải nhập dữ liệu");
                txtB.Focus();
                return;
            }
            if(int.Parse(txtA.Text) == int.Parse(txtB.Text))
            {
                lblKetQua.Text = "Không có tổng";
                return;
            }    
            
            soBe = int.Parse(txtA.Text) < int.Parse(txtB.Text) ? int.Parse(txtA.Text) : int.Parse(txtB.Text);
            soLon = int.Parse(txtA.Text) + int.Parse(txtB.Text) - soBe;
            double tong = 0;
            for(int i = soBe; i <= soLon; i++)
            {
                tong += i;
            }   
            lblKetQua.Text = "Tổng các số từ " + soBe + " đến " + soLon + " là: " + tong.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblKetQua.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtA.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // user clicked yes
                this.Close();
            }
        }

        
    }
}
