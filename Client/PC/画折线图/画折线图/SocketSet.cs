using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 画折线图
{
    public partial class SocketSet : Form
    {
        public SocketSet()
        {
            InitializeComponent();
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

        private void SocketSet_Load(object sender, EventArgs e)
        {
            cbConModular.SelectedIndex = 0;
        }
        
        private void btnsure_Click(object sender, EventArgs e)
        {

            if (cbConModular.SelectedIndex == 0)
            {
                OperationFrm.Modular = 1;
            }
            else if (cbConModular.SelectedIndex == 1)
            {
                OperationFrm.Modular = 2;
            }
            else if (cbConModular.SelectedIndex == 2)
            {
                OperationFrm.Modular = 3;
            }
            else
            {
                OperationFrm.Modular = 4;
            }
            OperationFrm.Ip = txtip.Text;
            OperationFrm.Port = txtport.Text;

            DirectFrm.Ip = txtip.Text;
            DirectFrm.Port = txtport.Text;
            DialogResult = DialogResult.OK;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
