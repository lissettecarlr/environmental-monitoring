using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 画折线图.MenuItem
{
    public partial class RegisterModel : Form
    {
        public RegisterModel()
        {
            InitializeComponent();
        }


        public int Rfstate;

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtsbh.Text=="")
            {
                MessageBox.Show("信息不能为空！");
                return;
            }
            else
            {
                OperationFrm.ModelName = txtsbh.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void labCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 移动无边框窗口
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标记是否为左键
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        #endregion

        private void RegisterModel_Load(object sender, EventArgs e)
        {
            //cbModelName.SelectedIndex = 0;
            if (Rfstate == 0)
            {
                labtitle.Text = "注册模块信息";
            }
            else if (Rfstate == 1)
            {
                labtitle.Text = "删除模块信息";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsbh_KeyPress(object sender, KeyPressEventArgs e)
        {
        if (e.KeyChar.ToString() == " " || e.KeyChar.ToString()==" ")
            {
                e.Handled = true;
            }
        }
    }
}
