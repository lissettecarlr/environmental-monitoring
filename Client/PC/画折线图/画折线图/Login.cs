using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.Runtime.InteropServices;
using System.Reflection;
namespace 画折线图
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtusername.Text = "111";
            txtpassword.Text = "qqq";
            //debug文件夹下
            //SetCursor(this, Bitmap.FromFile(Application.StartupPath + "\\look.png"), new Point(0, 0));
        }

        public int LoginModel { get; set; }
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursorFromFile(string fileName);
        // --------------------------------------------------------------------------------------------------------------------
        //   ┏┓　　　┏┓
        // ┏┛┻━━━┛┻┓
        // ┃　　　　　　　┃ 　
        // ┃　　　━　　　┃
        // ┃　┳┛　┗┳　┃
        // ┃　　　　　　　┃
        // ┃　　　┻　　　┃
        // ┃　　　　　　　┃
        // ┗━┓　　　┏━┛
        //     ┃　　　┃   神兽保佑　　　　　　　　　
        //     ┃　　　┃   代码无BUG！
        //     ┃　　　┗━━━┓
        //     ┃　　　　　　　┣┓
        //     ┃　　　　　　　┏┛
        //     ┗┓┓┏━┳┓┏┛
        //       ┃┫┫　┃┫┫
        //       ┗┻┛　┗┻┛
       // --------------------------------------------------------------------------------------------------------------------
        #region 登录
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbModel.SelectedIndex == 1)
            {
                try
                {
                    string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                    MySqlConnection mycon = new MySqlConnection(connstr);
                    try
                    {
                        string name = txtusername.Text;
                        string password = txtpassword.Text;

                        mycon.Open();
                        MySqlCommand mycmd = new MySqlCommand("select * from User where binary  User.Uname='" + name + "' and binary  User.Upassword='" + password + "'", mycon);
                        //mycmd.Parameters.AddWithValue("@username", txtusername.Text);
                        //mycmd.Parameters.AddWithValue("@pwd", txtpassword.Text);
                        MySqlDataAdapter da = new MySqlDataAdapter(mycmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            OperationFrm of = new OperationFrm();
                           // Loadinged f = new Loadinged();
                            //if (cbModel.SelectedIndex == 0)
                            //{
                                of.SelectModel = 0;
                                of.username = txtusername.Text;//读取用户登录名
                            //}
                            //else
                            //{
                            //    of.SelectModel = 1;
                            //}
                            this.Hide(); //隐藏当前窗口
                            of.Show();
                        }
                        else
                        {
                            MessageBox.Show("用户名和密码错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }


                    }
                    catch
                    {

                    }
                    finally
                    {
                        mycon.Close();
                    }
                }
                catch (Exception)
                {


                    MessageBox.Show("连接超时！请检查网络连接");
                }
                //Loading ld = new Loading();

            }
            else if (cbModel.SelectedIndex == 0)
            {
                DirectFrm df = new DirectFrm();
                this.Hide();
                df.Show();
            }

        } 
        #endregion

        #region 窗体加载
        private void Login_Load(object sender, EventArgs e)
        {
            cbModel.SelectedIndex = 0;
           // Cursor customCursor = new Cursor(Cursor.Current.Handle);
           // IntPtr customCursorHandle = LoadCursorFromFile("D:/system/创新创业/画折线图/画折线图/Resources/loading.png");
           // customCursor.GetType().InvokeMember("handle", BindingFlags.Public |
           // BindingFlags.NonPublic | BindingFlags.Instance |
           // BindingFlags.SetField, null, customCursor,
           //new object[] { customCursorHandle });
           // this.Cursor = customCursor;

        } 
        #endregion

        #region 取消
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.
              Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }
            Application.Exit();
        } 
        #endregion

        #region 模式选择
        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbModel.SelectedIndex == 0)
            {
                txtpassword.Enabled = false;
                txtusername.Enabled = false;
            }
            else
            {
                txtpassword.Enabled = true;
                txtusername.Enabled = true;
            }

        } 
        #endregion

        #region 用户注册
        private void labregister_Click(object sender, EventArgs e)
        {
            UserRegister ur = new UserRegister();
            ur.Show();
            this.Hide();
        } 
        #endregion

        public static void SetCursor(Control control, Image cursor, Point hotPoint)
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            using (cursor)
            using (Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY))
            using (Graphics g = Graphics.FromImage(myNewCursor))
            {
                g.Clear(Color.FromArgb(0, 0, 0, 0));
                g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width, cursor.Height);
                IntPtr iptr = myNewCursor.GetHicon();
                control.Cursor = new Cursor(iptr);
            }
        }
    }
}
