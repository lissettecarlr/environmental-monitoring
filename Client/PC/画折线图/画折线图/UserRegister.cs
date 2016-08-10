using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 画折线图
{
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
        }
        #region 登录

        public static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
        Helpers.MySqlHelper mysqlhelper = new Helpers.MySqlHelper(connstr);
        private void btnok_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pwd = textBox2.Text;
            if (name == "" || pwd == "")
            {
                MessageBox.Show("信息不能为空！请完善……");
                return;
            }
            else
            {
                string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                MySqlConnection mycon = new MySqlConnection(connstr);
                try
                {
                    string uname = textBox1.Text;
                    string upassword = textBox2.Text;

                    mycon.Open();
                    MySqlCommand mycmd = new MySqlCommand("select * from User where binary  User.Uname='" + name + "'", mycon);
                    MySqlDataAdapter da = new MySqlDataAdapter(mycmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("该用户名已存在！");
                        textBox1.Clear();
                        textBox2.Clear();

                    }
                    else
                    {

                        string sql = "insert into `User` (Uname,Upassword) Values('" + uname + "','" + upassword + "')";
                        int result = mysqlhelper.ExecuteNonQuery(connstr, sql, new MySqlParameter[0]);
                        if (result > 0)
                        {
                            MessageBox.Show("注册成功！");
                            OperationFrm of = new OperationFrm();
                            this.Hide(); //隐藏当前窗口
                            of.Show();
                        }
                        else
                        {
                            MessageBox.Show("注册失败！");
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
            textBox1.Clear();
            textBox2.Clear();
        }
        
        #endregion

        #region 取消
        private void btncanle_Click(object sender, EventArgs e)
        {
            this.Close();
            Login f1 = new Login();
            f1.Show();
        } 
        #endregion

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

        #region 窗体加载
        private void UserRegister_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        } 
        #endregion

        #region 密码是否可见
        Boolean flag = true;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                textBox2.UseSystemPasswordChar = false;
                flag = false;
            }
            else if (!flag)
            {
                textBox2.UseSystemPasswordChar = true;
                flag = true;
            }
        } 
        #endregion

        #region 限制密码框只能输入数字和字母
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;


            }
            else
            {
                if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == 8)
                    {
                        e.Handled = false;
                    }
                    else e.Handled = true;
                }
            }
        } 
        #endregion

        #region 限制用户名不能输入空格
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == " " || e.KeyChar.ToString() == " ")
            {
                e.Handled = true;
            }
        } 
        #endregion
    }
}
