using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using Helpers;
using MySql.Data.MySqlClient;

using 画折线图.MenuItem;
using System.IO;

namespace 画折线图
{
    public partial class OperationFrm : Form
    {
        public OperationFrm()
        {
            InitializeComponent();
        }

        #region 登陆时，模式选择
        public int SelectModel { get; set; }
        public string username { get; set; }
        private int smodel = 0;
        #endregion

        #region 建立下位机通信
        Socket socketSend;
        public static string Ip = "";
        public static string Port = "";
        public static int Modular;
        private string OPIp = "";
        private string OPPort = "";


        /// <summary>
        /// 不停的接受服务器发来的消息
        /// </summary>
        void Recive()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    int r = socketSend.Receive(buffer);
                    //实际接收到的有效字节数
                    if (r == 0)
                    {
                        break;
                    }
                    string s = Encoding.UTF8.GetString(buffer, 0, r);
                    Console.WriteLine(s);

                }
                catch { }

            }
        }
        #endregion

        #region 窗体加载
        Thread thmsg;
        private const int _Interval = 3000;//3秒
        private MyTimer _Timer;
        private void OperationFrm_Load(object sender, EventArgs e)
        {
            #region 加载系统时间
            this.toolStripStatusLabel3.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Start();
            Control.CheckForIllegalCrossThreadCalls = false; 
            #endregion

            #region 加载过程，等待数据加载完成
            loadingControl1.InnerCircleRadius = 20;
            loadingControl1.OutnerCircleRadius = 40;
            loadingControl1.ThemeColor = Color.Green;
            loadingControl1.LineWidth = 10;
            loadingControl1.Start(); 
            #endregion

            #region 窗体数据加载

            thmsg = new Thread(LoadingFromMsg);
            thmsg.IsBackground = true;
            thmsg.Start(); 
            #endregion

            #region 每个3秒执行一次函数，用于界面数据更新

            _Timer = new MyTimer();
            _Timer.Interval = _Interval;
            _Timer.Start(); //开始
            _Timer.OnElapsed += Timer_OnElapsed; 
            #endregion

        }
        void Timer_OnElapsed()
        {
            LoadingFromMsg();
            publicGetSensorId(username);
            Invalidate();
        }

        public void LoadingFromMsg()
        {
            SetUserControlParameter();
            SetModelDetail_md1();
            SetModelDetail_md2();
            SetModelDetail_md3();
            SetModelDetail_md4();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void OperationFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_Timer != null)
            {
                _Timer.OnElapsed -= Timer_OnElapsed;
                _Timer.Stop();
            }
            if (smodel == 0)
            {
                Application.Exit();
            }
             
        }
        #endregion

        #region 判断IP地址是否合法
        public bool RunSnippet(string ip)
        {
            Regex rx = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
            if (rx.IsMatch(ip))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 菜单切换
        private void picbox_Click(object sender, EventArgs e)
        {
            Button pbx = (Button)sender;
            int number = Convert.ToInt32(pbx.Tag);
            try
            {
                switch (number)
                {
                    case 1:
                        {
                            this.tabConModelPages.SelectedIndex = 0;
                            OperationFrm_Load(sender,e);
                            break;
                        }
                    case 2:
                        {
                            this.tabConModelPages.SelectedIndex = 1;
                            break;
                        }
                    case 3:
                        {
                            this.tabConModelPages.SelectedIndex = 2;
                            break;
                        }
                    case 4:
                        {
                            this.tabConModelPages.SelectedIndex = 3;
                            break;
                        }
                    case 5:
                        {
                            this.tabConModelPages.SelectedIndex = 4;
                            break;
                        }
                    case 6:
                        {
                            this.tabConModelPages.SelectedIndex = 5;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("异常错误。");
                            break;
                        }

                }

            }
            catch (System.IO.FileNotFoundException ex)
            {

                MessageBox.Show("错误：" + ex.Message);
            }
        }
        #endregion

        #region 向下位机发送数据
        public void SendDataToLowermachine(string data)
        {
            try
            {
                tProgressBar.Value = 0;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                socketSend.Send(buffer);
                toollable.Text = "命令发送完毕！";
                tProgressBar.Value = 100;
            }
            catch (Exception)
            {

                MessageBox.Show("当前没有建立通信连接！");
            }
        }
        #endregion

        #region 设置模块显示数据格式
        string[] Setmodel=new string[10];
        
        string setone = "", settwo ="", setthree = "", setfour = "";
        public void SetUserControlParameter()
        {
            Setmodel = GetSensorId(username);
            for (int i = 0; i < Setmodel.Length; i++)
            {
                if (GetSensorName(Setmodel[i]) == "温度传感器")
                {
                    setone = Setmodel[i];
                    #region 温湿度模块
                    userControl.SetTitle(GetSensorName(Setmodel[i]));
                    userControl.SetIdTitle("设备号：");
                    userControl.SetIdNumber(Setmodel[i]);//需要从数据库获取
                    userControl.SetTemperatureTitle("温度：");
                    userControl.SetTemperatureNumber(publicSelectData(Setmodel[i])+"度");//需要从数据库获取
                    userControl.SetType1Title("类型号：");
                    userControl.SetType1Number(publicSelectType(Setmodel[i]));//需要从数据库获取
                    userControl.SetType2Title("连接状态：");
                    userControl.SetType2Number(GetSensorOnline(Setmodel[i]));//需要从数据库获取
                    userControl.SetlabHumidityTitle("");
                    userControl.SetlabHumidityNumber("");
                    userControl.SetXTitle("数据个数");
                    userControl.SetYTitle("温度值");
                    userControl.SetYCurveTitle("温度");
                    userControl.SetCurveTitle("温湿度折线图");
                    userControl.StrMysql("select DataValue from (select * from Sensor WHERE DeviceNumber='" + Setmodel[i] + "') t order by t.ReceiveTime desc LIMIT 20");
                    userControl.SetMySql("120.27.119.115", "root", "123456", "ebox");
                    #endregion
                }
                if (GetSensorName(Setmodel[i]) == "CO2传感器")
                {
                    settwo = Setmodel[i];
                    #region 二氧化碳模块
                    userControlco2.SetTitle("CO2模块");
                    userControlco2.SetIdTitle("设备号：");
                    userControlco2.SetIdNumber(Setmodel[i]);//需要从数据库获取
                    userControlco2.SetTemperatureTitle("CO2浓度");
                    userControlco2.SetTemperatureNumber(publicSelectData(Setmodel[i]) + "ppm");//需要从数据库获取
                    userControlco2.SetType1Title("CO2类型号：");
                    userControlco2.SetType1Number(publicSelectType(Setmodel[i]));//需要从数据库获取
                    userControlco2.SetType2Title("连接状态：");
                    userControlco2.SetType2Number(GetSensorOnline(Setmodel[i]));//需要从数据库获取
                    userControlco2.SetlabHumidityTitle("");
                    userControlco2.SetlabHumidityNumber("");
                    userControlco2.SetXTitle("数据个数");
                    userControlco2.SetYTitle("浓度值");
                    userControlco2.SetYCurveTitle("CO2浓度");
                    userControlco2.SetCurveTitle("CO2浓度折线图");
                    userControlco2.StrMysql("select DataValue from (select * from Sensor WHERE DeviceNumber='" + Setmodel[i] + "') t order by t.ReceiveTime desc LIMIT 20");
                    userControlco2.SetMySql("120.27.119.115", "root", "123456", "ebox");
                    #endregion
                }
                if (GetSensorName(Setmodel[i]) == "粉尘（PM2.5）传感器")
                {
                    setthree = Setmodel[i];
                    #region 粉尘传感器模块
                    userControldust.SetTitle("粉尘传感器模块");
                    userControldust.SetIdTitle("设备号：");
                    userControldust.SetIdNumber(Setmodel[i]);//需要从数据库获取
                    userControldust.SetTemperatureTitle("粉尘浓度");
                    userControldust.SetTemperatureNumber(publicSelectData(Setmodel[i]) + "g/m3");//需要从数据库获取
                    userControldust.SetType1Title("粉尘浓度类型号：");
                    userControldust.SetType1Number(publicSelectType(Setmodel[i]));//需要从数据库获取
                    userControldust.SetType2Title("连接状态：");
                    userControldust.SetType2Number(GetSensorOnline(Setmodel[i]));//需要从数据库获取
                    userControldust.SetlabHumidityTitle("");
                    userControldust.SetlabHumidityNumber("");
                    userControldust.SetXTitle("数据个数");
                    userControldust.SetYTitle("浓度值");
                    userControldust.SetYCurveTitle("PM2.5");
                    userControldust.SetCurveTitle("PM2.5折线图");
                    userControldust.StrMysql("select DataValue from (select * from Sensor WHERE DeviceNumber='" + Setmodel[i] + "') t order by t.ReceiveTime desc LIMIT 20");
                    userControldust.SetMySql("120.27.119.115", "root", "123456", "ebox");
                    #endregion
                }
                if (GetSensorName(Setmodel[i]) == "甲醛传感器")
                {
                    setfour = Setmodel[i];
                    #region 有害气体模块
                    userControlgas.SetTitle("有害气体模块");
                    userControlgas.SetIdTitle("设备号：");
                    userControlgas.SetIdNumber(Setmodel[i]);//需要从数据库获取
                    userControlgas.SetTemperatureTitle("甲醛浓度：");
                    userControlgas.SetTemperatureNumber(publicSelectData(Setmodel[i])+ "ppb");//需要从数据库获取
                    userControlgas.SetType1Title("甲醛浓度类型号：");
                    userControlgas.SetType1Number(publicSelectType(Setmodel[i]));//需要从数据库获取
                    userControlgas.SetType2Title("连接状态：");
                    userControlgas.SetType2Number(GetSensorOnline(Setmodel[i]));//需要从数据库获取
                    userControlgas.SetlabHumidityTitle(" ");
                    userControlgas.SetlabHumidityNumber(" ");//需要从数据库获取
                    userControlgas.SetXTitle("数据个数");
                    userControlgas.SetYTitle("浓度值");
                    userControlgas.SetYCurveTitle("有害气体");
                    userControlgas.SetCurveTitle("甲醛浓度折线图");
                    userControlgas.StrMysql("select DataValue from (select * from Sensor WHERE DeviceNumber='" + Setmodel[i] + "') t order by t.ReceiveTime desc LIMIT 20");
                    userControlgas.SetMySql("120.27.119.115", "root", "123456", "ebox");
                    #endregion
                }

                //MessageBox.Show(Setmodel[i]);

            }
          
            loadingControl1.Stop();
          
            this.loadingControl1.Hide();
        }
        #endregion

        #region 设置单个模块信息【状态显示】
        public void SetModelDetail_md1()
        {
           
            md1.SetModelDetailTitle("温湿度模块");
            md1.SetIdNumber(setone);
            md1.SetType1Number(publicSelectType(setone));
            md1.SetType2Title("温度：");
            md1.SetType2Number(publicSelectData(setone) + "度");
            md1.SetConcentrationTitle(" ");
            md1.SetValue(" ");
        }
        public void SetModelDetail_md2()
        {
             
            md2.SetModelDetailTitle("二氧化碳模块");
            md2.SetIdNumber(settwo);
            md2.SetType1Number(publicSelectType(settwo));
            md2.SetType2Title("浓度：");
            md2.SetType2Number(publicSelectData(settwo) + "ppm");
            md2.SetConcentrationTitle("");
            md2.SetValue("");
        }
        public void SetModelDetail_md3()
        {
            md3.SetModelDetailTitle("粉尘传感器模块");
            md3.SetIdNumber(setthree);
            md3.SetType1Number(publicSelectType(setthree)); 
            md3.SetType2Title("浓度：");
            md3.SetType2Number(publicSelectData(setthree) + "g/m3");
            md3.SetConcentrationTitle(" ");
            md3.SetValue(" ");
        }
        public void SetModelDetail_md4()
        {
            md4.SetModelDetailTitle("有害气体模块");
            md4.SetIdNumber(setfour);
            md4.SetType1Number(publicSelectType(setfour));
            md4.SetType2Title("浓度：");
            md4.SetType2Number(publicSelectData(setfour) + "ppb");
            md4.SetConcentrationTitle(" ");
            md4.SetValue(" ");
        }
        #endregion
    
        #region 顶部菜单
        #region 关于
        public static int AboutState = 0;
        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AboutState == 0)
            {
                AboutState = 1;
                AboutFrm af = new AboutFrm();
                af.Show();
            }

        }
        #endregion

        #region 注册模块信息
        public static string ModelName;
        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 注册模块信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterModel rm = new RegisterModel();
            rm.Rfstate = 0;
            if (rm.ShowDialog() == DialogResult.OK)
            {
                Insert_Delete_Msg(0, "注册成功！", username, ModelName);
            }
        }

        private void 删除模块信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterModel rm = new RegisterModel();
            rm.Rfstate = 1;
            if (rm.ShowDialog() == DialogResult.OK)
            {
                Insert_Delete_Msg(1, "删除成功！", username, ModelName);
            }
        }
        #endregion

        private void 建立连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tProgressBar.Value = 0;
                //创建负责通信的Socket
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(Ip);
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(Port));
                //获得要连接的远程服务器应用程序的IP地址和端口号
                socketSend.Connect(point);
                ConnectState.Text = "已建立连接";
                tProgressBar.Value = 100;
                //开启一个新的线程不停的接收服务端发来的消息
                Thread th = new Thread(Recive);
                th.IsBackground = true;
                th.Start();
            }
            catch
            {
                ConnectState.Text = "请输入正确的IP地址！";
            }
        }

        private void 参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketSet lg = new SocketSet();
            if (lg.ShowDialog() == DialogResult.OK)
            {
                bool s = RunSnippet(Ip);
                if (s)
                {
                    OPIp = Ip;
                    OPPort = Port;
                }
                else
                {
                    OPIp = "0.0.0.0";
                    OPPort = "0";
                    MessageBox.Show("IP地址不合法！");
                }

            }
        }

        private void 室内模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smodel = 1;
            Login lg = new Login();
            lg.Show();
            this.Close();
        }
        #endregion

        #region WIFI设置
        public static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
        Helpers.MySqlHelper mysqlhelper = new Helpers.MySqlHelper(connstr);
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketSet lg = new SocketSet();
            if (lg.ShowDialog() == DialogResult.OK)
            {
                string order = "0xFF03" + Ip + "0xFF" + Port + "0xFF";
                publicfunction(1, 2, order, "N", Modular);
            }
        }
        #endregion


        #region 温湿度启动--待机---模式切换--复位
        bool temp = true;

        private void btntempstart_Click(object sender, EventArgs e)
        {
            if (temp == true)
            {
                btntempstart.Text = "待机";
                temp = false;
                publicfunction(1, 2, "2", "N", 1);
            }
            else if (temp == false)
            {
                btntempstart.Text = "启动";
                temp = true;
                publicfunction(1, 2, "1", "N", 1);
            }
        }
 
        private void btnTmodel_Click(object sender, EventArgs e)
        {
            
                publicfunction(1, 2, "238", "N", 1);
 
        }

        private void btntempreset_Click(object sender, EventArgs e)
        {
            publicfunction(1, 2, "204", "N", 1);
        }

        #endregion

        #region 二氧化碳启动--待机---模式切换--复位
        bool co2 = true;
        private void btnco2start_Click(object sender, EventArgs e)
        {
            if (co2 == true)
            {
                btnco2start.Text = "待机";
                co2 = false;
                publicfunction(1, 2, "2", "N", 2);
            }
            else if (co2 == false)
            {
                btnco2start.Text = "启动";
                co2 = true;
                publicfunction(1, 2, "1", "N", 2);
            }

        }

         
        private void btnco2model_Click(object sender, EventArgs e)
        {
             
                publicfunction(1, 2, "238", "N", 2);
            
        }

        private void btnco2reset_Click(object sender, EventArgs e)
        {
            publicfunction(1, 2, "204", "N", 2);
        }
        #endregion

        #region 粉尘启动--待机---模式切换--复位
        bool dust = true;
        private void btnduststart_Click(object sender, EventArgs e)
        {
            if (dust == true)
            {
                btnduststart.Text = "待机";
                dust = false;
                publicfunction(1, 2, "2", "N", 3);
            }
            else if (dust == false)
            {
                btnduststart.Text = "启动";
                dust = true;
                publicfunction(1, 2, "1", "N", 3);
            }
        }


       
        private void btndustmodel_Click(object sender, EventArgs e)
        {
            
                publicfunction(1, 2, "238", "N", 3);
           
        }

        private void btndustreset_Click(object sender, EventArgs e)
        {
            publicfunction(1, 2, "204", "N", 3);
        }
        #endregion

        #region 有害气体启动--待机---模式切换--复位
        bool harm = true;
        private void btnharmstart_Click(object sender, EventArgs e)
        {
            if (harm == true)
            {
                btnharmstart.Text = "待机";
                harm = false;
                publicfunction(1, 2, "2", "N", 4);
            }
            else if (harm == false)
            {
                btnharmstart.Text = "启动";
                harm = true;
                publicfunction(1, 2, "1", "N", 4);
            }
        }

        
        private void btnharmmodel_Click(object sender, EventArgs e)
        {
           publicfunction(1, 2, "238", "N", 4);
        }

        private void btnharmreset_Click(object sender, EventArgs e)
        {
            publicfunction(1, 2, "204", "N", 4);
        }
        #endregion

        #region 模式切换
        static bool bStop = true;
        private void 模式切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////定义线程   
            //Thread LogThread = new Thread(new ThreadStart(DoService));
            ////设置线程为后台线程,那样进程里就不会有未关闭的程序了
            //LogThread.IsBackground = true;
            //if (bStop == true)
            //{
            //    LogThread.Start();//起线程
            //}
        }
        private static void DoService()
        {
            while (true)
            {
                bStop = false;
                MessageBox.Show("单曲循环");

                System.Threading.Thread.Sleep(10000);
            }
        }
        #endregion

        #region 公共函数，避免重复的写【操作数据库】

        #region 写命令
        public void publicfunction(int Ordertotal, int Ordernumber, string orders, string OrderState, int Modular)
        {

            try
            {
                DateTime times = DateTime.Now;
                string sql = "insert into `Order`(OrderTotal,OrderTime,OrderNumber,OrderScript,OrderPerform,OrderFnumber) Values('" + Ordertotal + "','" + times + "','" + Ordernumber + "','" + orders + "','" + OrderState + "','" + Modular + "')";
                int result = mysqlhelper.ExecuteNonQuery(connstr, sql, new MySqlParameter[0]);
                if (result > 0)
                {
                   
                    toollable.Text="设置成功";
                }
                else
                {
                    toollable.Text="设置失败";
                }
            }
            catch  
            {

            }
        }
        #endregion

        #region 取模块最新数据值
        string datavalue;
        public string publicSelectData(string deviceNumber)
        {
            string redata;
            try
            {
                string sql = "select DataValue from (select * from Sensor WHERE DeviceNumber='" + deviceNumber + "') t order by t.ReceiveTime desc LIMIT 1";
                DataSet ds = new DataSet();
                ds = mysqlhelper.ExecuteDataSet(sql, new MySqlParameter[0]);
                foreach (DataRow mDr in ds.Tables[0].Rows)
                {
                    foreach (DataColumn mDc in ds.Tables[0].Columns)
                    {
                        redata = mDr[mDc].ToString();
                        datavalue = redata;
                    }
                }
                return datavalue;
            }
            catch 
            {
                return null;
            }

        }
        #endregion

        //#region 确认存在
        //string existence;
        //public string GetModelExistrnce(string deviceNumber)
        //{
        //    string redata;
        //    try
        //    {
        //        string sql = "select DeviceNumber from (select * from Sensor WHERE DeviceName='" + deviceName + "') t order by t.ReceiveTime desc LIMIT 1";
        //        DataSet ds = new DataSet();
        //        ds = mysqlhelper.ExecuteDataSet(sql, new MySqlParameter[0]);
        //        foreach (DataRow mDr in ds.Tables[0].Rows)
        //        {
        //            foreach (DataColumn mDc in ds.Tables[0].Columns)
        //            {
        //                redata = mDr[mDc].ToString();
        //                modelvalue = redata;
        //            }
        //        }
        //        return modelvalue;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
        //#endregion

        #region 获取类型号
        string typevalue;
        public string publicSelectType(string deviceNumber)
        {
            string redata;
            try
            {
                string sql = "select Type from (select * from Sensor WHERE DeviceNumber='" + deviceNumber + "') t order by t.ReceiveTime desc LIMIT 1";
                DataSet ds = new DataSet();
                ds = mysqlhelper.ExecuteDataSet(sql, new MySqlParameter[0]);
                foreach (DataRow mDr in ds.Tables[0].Rows)
                {
                    foreach (DataColumn mDc in ds.Tables[0].Columns)
                    {
                        redata = mDr[mDc].ToString();
                        typevalue = redata;
                    }
                }
                return typevalue;
            }
            catch  
            {
                return null;
            }

        }
        #endregion

        #region 注册----删除  模块信息
        private void Insert_Delete_Msg(int model, string showmsg, string users, string id)
        {
            try
            {
                if (model == 0)
                {
                    string sql = "insert into `Facility`(OwnerNamer,Fnumber) Values('" + users + "','" + id + "')";
                    int result = mysqlhelper.ExecuteNonQuery(connstr, sql, new MySqlParameter[0]);
                    if (result > 0)
                    {

                        toollable.Text = showmsg;
                    }
                    else
                    {
                       toollable.Text="操作失败";
                    }
                }
                else if (model == 1)
                {
                    string sql = "delete from `Facility` where OwnerNamer='" + users + "' and Fnumber='" + id + "'";
                    int result = mysqlhelper.ExecuteNonQuery(connstr, sql, new MySqlParameter[0]);
                    if (result > 0)
                    {
                        toollable.Text=showmsg;
                    }
                    else
                    {
                        toollable.Text="操作失败";
                    }
                }
            }
            catch 
            {

            }
        } 
        #endregion

        //#region 获取连接状态
        //string line;
        //public string publicOnline(string deviceName)
        //{
        //    string redata;
        //    try
        //    {

        //        string sql = "select Online from (select * from HaveAccess WHERE Fnumber='" + deviceName + "') t order by t.RecentTime desc LIMIT 1";
        //        DataSet ds = new DataSet();
        //        ds = mysqlhelper.ExecuteDataSet(sql, new MySqlParameter[0]);
        //        foreach (DataRow mDr in ds.Tables[0].Rows)
        //        {
        //            foreach (DataColumn mDc in ds.Tables[0].Columns)
        //            {
        //                redata = mDr[mDc].ToString();
        //                line = redata;
        //            }
        //        }
        //        if (line=="ON")
        //        {
        //            line = "已连接！";
        //        }
        //        else { line = "未连接！"; }
        //        return line;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
        //#endregion

        #region 获取设备-----信息----存档
        public void publicGetSensorId(string userName)
        {
            try
            {
                //获取总共有多少设备
                string CountSql = "SELECT (COUNT(*)) FROM `Facility` WHERE OwnerNamer='" + userName + "'";
                object result = mysqlhelper.ExecuteScalar(CountSql, new MySqlParameter[0]);
                int count = int.Parse(result.ToString());
                string[] redata = new string[count];//存储设备号
                string[] SensoeMessage = new string[count];//存储是否在线
                string[] rename = new string[count];//设备名
                
                //获取设备号，需要存入数组
                string SensorIdSql = "SELECT Fnumber FROM `Facility` WHERE OwnerNamer='" + userName + "'";
                DataSet dsSensorId = new DataSet();
                dsSensorId = mysqlhelper.ExecuteDataSet(SensorIdSql, new MySqlParameter[0]);
                int index = 0;
                foreach (DataRow mDr in dsSensorId.Tables[0].Rows)
                {
                    foreach (DataColumn mDc in dsSensorId.Tables[0].Columns)
                    {
                        redata[index] = mDr[mDc].ToString();
                        index++;
                    }
                }
                index = 0;
                #region 创建文件，保存用户设备信息

                FileStream fs = new FileStream(Application.StartupPath + "\\Device.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
              
                #endregion
                

                //根据设备号获取设备名 ----  设备是否在线
                for (int i = 0; i < count; i++)
                {
                    string SensorNameSql = "SELECT SensorName FROM `SensorRelation` WHERE SensorId='" + redata[i] + "'";                   
                    object resultname = mysqlhelper.ExecuteScalar(SensorNameSql, new MySqlParameter[0]);              
                    rename[i] = resultname.ToString();//传感器
                    sw.Write(rename[i] + "#" + redata[i]+"\n");

                }



                //MessageBox.Show("用户名：" + username + "\n" + "行数:" + result.ToString());

                //DataSet dsCount = new DataSet();
                //DataSet dsSensorId = new DataSet();
                //DataSet dsSensorName = new DataSet();
                //DataSet dsOnline = new DataSet();
                //dsCount = mysqlhelper.ExecuteDataSet(CountSql, new MySqlParameter[0]);
                //dsSensorId = mysqlhelper.ExecuteDataSet(SensorIdSql, new MySqlParameter[0]);
                //dsSensorName = mysqlhelper.ExecuteDataSet(SensorNameSql, new MySqlParameter[0]);
                //dsOnline = mysqlhelper.ExecuteDataSet(Onlinesql, new MySqlParameter[0]);
                //int index=0;
                //foreach (DataRow mDr in dsCount.Tables[0].Rows)
                //{
                //    foreach (DataColumn mDc in dsCount.Tables[0].Columns)
                //    {
                //        redata[index] = mDr[mDc].ToString();
                //        index++;
                //    }
                //}
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

            }
            catch
            {
                //return null;
                // MessageBox.Show(e.ToString());
             
            }

        }
        #endregion
         

        ///////////////////////////////

        #region 获取用户所有的设备号
        public string[] GetSensorId(string userName)
        {
            try
            {
                //获取总共有多少设备
                string CountSql = "SELECT (COUNT(*)) FROM `Facility` WHERE OwnerNamer='" + userName + "'";
                object result = mysqlhelper.ExecuteScalar(CountSql, new MySqlParameter[0]);
                int count = int.Parse(result.ToString());
                string[] redata = new string[count];//存储设备号
                //获取设备号，需要存入数组
                string SensorIdSql = "SELECT Fnumber FROM `Facility` WHERE OwnerNamer='" + userName + "'";
                DataSet dsSensorId = new DataSet();
                dsSensorId = mysqlhelper.ExecuteDataSet(SensorIdSql, new MySqlParameter[0]);
                int index = 0;
                foreach (DataRow mDr in dsSensorId.Tables[0].Rows)
                {
                    foreach (DataColumn mDc in dsSensorId.Tables[0].Columns)
                    {
                        redata[index] = mDr[mDc].ToString();
                        index++;
                    }
                }
                return redata;
            }
            catch
            {
                return null;
            }

        } 
        #endregion

        #region 获取用户设备是否在线
        public string GetSensorOnline(string deviceId)
        {
            try
            {
                string Onlinesql = "select Online from (select * from HaveAccess WHERE Fnumber='" + deviceId + "') t order by t.RecentTime desc LIMIT 1";
                object resultonline = mysqlhelper.ExecuteScalar(Onlinesql, new MySqlParameter[0]);
                return resultonline.ToString();
            }
            catch
            {
                return null;
            }
        } 
        #endregion

        #region 获取用户传感器名
        public string GetSensorName(string deviceId)
        {
            try
            {
                string SensorNameSql = "SELECT SensorName FROM `SensorRelation` WHERE SensorId='" + deviceId + "'";
                object resultname = mysqlhelper.ExecuteScalar(SensorNameSql, new MySqlParameter[0]);
                return resultname.ToString();
            }
            catch
            {
                return null;

            }
        } 
        #endregion


     
        #endregion
       
    }
}
