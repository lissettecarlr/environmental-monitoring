using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;
using 画折线图.MenuItem;
using System.IO;

namespace 画折线图
{
    public partial class DirectFrm : Form
    {
        public DirectFrm()
        {
            InitializeComponent();
        }

        #region 窗体加载与退出程序

        private int s = 0;
        public string msg;
        private void DirectFrm_Load(object sender, EventArgs e)
        {
            #region 加载系统时间
            this.tooltime.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Start();
            Control.CheckForIllegalCrossThreadCalls = false;
            toolState.Text = "无"; 
            #endregion
            //CreatSocketFile();//创建文件，保存Socket连接信息

            #region 读取文件，用户已安装设备信息
            deviceinfo = Read(Application.StartupPath + "\\Device.txt");
            msg = deviceinfo[0] + "#";
            for (int i = 1; i < deviceinfo.Length; i++)
            {
                msg += deviceinfo[i] + "#";
            }
            sArray = Regex.Split(msg, "#", RegexOptions.IgnoreCase); 
            #endregion
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tooltime.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void DirectFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (s == 0)
            {
                DialogResult result = MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.
                  Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    return;
                }
                Application.Exit();
            }
        } 
        #endregion

        #region 创建文件，保存Socket连接信息
        public void CreatSocketFile()
        {
            string activeDir = @"";
            string newPath = System.IO.Path.Combine(activeDir, "SocketFile");
            System.IO.Directory.CreateDirectory(newPath);
            string fileNameOne = "socketinfo.txt";
            string filePathOne = System.IO.Path.Combine(newPath, fileNameOne);
            System.IO.File.Create(filePathOne);
        }
        #endregion

        #region 建立下位机通信
        public Socket ClientSocket { get; set; }
        //public string Ip = "192.168.237.2";
        //public string Port = "50000";
        public static string Ip = "";
        public static string Port = "";
        public static int Modular;
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

        #region 向下位机发送数据
        public void SendDataToLowermachine(byte[] data)
        {
            try
            {
                
                //string str = data;//向下位机发送的数据
               // byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
               // ClientSocket.Send(buffer);
                ClientSocket.Send(data);

                toolOrder.Text = "命令发送完毕！";
                
            }
            catch  
            {
                toolOrder.Text = "当前没有建立通信连接！";
            }
        }
        #endregion

        #region 顶部菜单功能选项

        private void wIFI连接ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SocketSet lg = new SocketSet();
            if (lg.ShowDialog() == DialogResult.OK)
            {
                if (RunSnippet(Ip))
                {
                    //客户端连接服务器端
                    //1 创建Socket对象
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


                    ClientSocket = socket;

                    //2 连接服务器端
                    try
                    {
                        socket.Connect(IPAddress.Parse(Ip), int.Parse(Port));
                    }
                    catch (Exception ex)
                    {
                        toolState.Text = "连接失败！";
                        //Thread.Sleep(500);
                        //btnConnect_Click(this,e);
                        return;
                    }

                    //3 发送消息，接收消息。
                    toolState.Text = "已建立连接！";
                    Thread thread = new Thread(new ParameterizedThreadStart(ReceiveData));
                    thread.IsBackground = true;
                    thread.Start(ClientSocket);
                }
                else { toolState.Text = "IP地址不合法！"; }
            }
        }

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopContnet();
            toolState.Text="连接已断开！";
        }

        #endregion

        #region 接受服务器发来的数据
        public void ReceiveData(object socket)
        {
            var proxSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                    len = proxSocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    //异常退出
                    toolState.Text = "连接已断开！";
                    StopContnet();//关闭连接
                    return;
                }

                if (len <= 0)
                {
                    //客户端正常退出
                    toolState.Text = "连接已断开！";

                    StopContnet();//停止连接

                    return;//让方法结束，终结当前接受客户端数据的异步线程。
                }

                //把接收到的数据放到文本框上去

                //接收的数据中第一个字节如果是1：那么是字符串，如果是2是闪屏，如果是3 是文件
                #region 接收的是字符串

                string strMsg = ProcessRecieveString(data);
                MessageBox.Show(strMsg);
                #endregion


            }
        } 
        #endregion

        #region 处理接收到的字符串
        public string ProcessRecieveString(byte[] data)
        {
            //把实际的字符串拿到
            string str = Encoding.Default.GetString(data, 0, data.Length);
            return str;
        }
        #endregion

        #region 断开所有连接
        private void StopContnet()
        {
            try
            {
                if (ClientSocket.Connected)
                {
                    ClientSocket.Shutdown(SocketShutdown.Both);
                    ClientSocket.Close(100);
                }
            }
            catch (Exception ex)
            {

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
                            this.tabControl1.SelectedIndex = 0;
                            break;
                        }
                    case 2:
                        {
                            this.tabControl1.SelectedIndex = 1;
                            break;
                        }
                    case 3:
                        {
                            this.tabControl1.SelectedIndex = 2;
                            break;
                        }
                    case 4:
                        {
                            this.tabControl1.SelectedIndex = 3;
                            break;
                        }
                    case 5:
                        {
                            this.tabControl1.SelectedIndex = 4;
                            break;
                        }
                    case 6:
                        {
                            this.tabControl1.SelectedIndex = 5;
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

        #region 室外模式
        private void 室外模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s = 1;
            Login lg = new Login();
            lg.Show();
            this.Close();
        } 
        #endregion

        #region 数据传输
        public static string wifinumber;
        public static string wifipwd;
        private void 数据传输ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WifiFrm wf = new WifiFrm();
            if (wf.ShowDialog() == DialogResult.OK)
            {
                string str = wifinumber + "#" + wifipwd;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                SendDataToLowermachine(buffer);
            }
        } 
        #endregion

        #region 关于
        public static int AboutState = 0;
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AboutState == 0)
            {
                AboutState = 1;
                AboutFrm af = new AboutFrm();
                af.Show();
            } 
        }
        #endregion

        #region 功能选择
        string[] deviceinfo = new string[4];
        string[] sArray = new string[9];//存储的用户  设备+设备号
        //检查用户是否拥有该设备
        private bool Findname(string name)
        {
            int id = 0;
            for (int i = 0; i < sArray.Length; i++)
            {
                if (sArray[i] == name)
                {
                    id = i + 1;
                    break;
                }
                else { id = -1; }
            }
            if (id > 0)
            { return true; }
            else
            {
                return false;
            }
        }
        //查找设备ID,并封装
        private byte[] FindId(string name)
        {
            int id=0;
            byte[] by = new byte[4] { 0, 0, 0, 0 };
            for (int i = 0; i < sArray.Length; i++)
            {
                if (sArray[i] == name)
                {
                    id = i + 1;
                    break;
                }
                else { id = -1; }
            }
            if (id > 0)
            {
                byte[] b = System.BitConverter.GetBytes(int.Parse(sArray[id]));
                return b;
            }
            else
            {
                return by;
            }
        }

        //启动--待机----复位
        private void Start_StartBy_Reset(byte order,string name)
        {
            byte[] dataBaotou = new byte[8];//包头
            byte[] EquipId = new byte[4];//设备号
            dataBaotou[0] = 0xff;
            dataBaotou[1] = 0xdd;
            dataBaotou[6] = order;
            if (Findname(name))
            {
                EquipId = FindId(name);
                for (int i = 0; i < 4; i++)
                {
                    dataBaotou[i + 2] = EquipId[3 - i];
                }
            }
            int sum = FillCheckSum(dataBaotou);
            dataBaotou[7] = (byte)sum;
            SendDataToLowermachine(dataBaotou);
        }
        #endregion

        #region 计算校验和
        /// <summary>  
        /// 累加校验和  
        /// </summary>  
        /// <param name="memorySpage">需要校验的数据</param>  
        /// <returns>返回校验和结果</returns>  
        public int FillCheckSum(byte[] memorySpage)
        {
            int num = 0;
            for (int i = 0; i < memorySpage.Length; i++)
            {
                num = (num + memorySpage[i]) % 0xffff;
            }

            //实际上num 这里已经是结果了，如果只是取int 可以直接返回了  
            //memorySpage = BitConverter.GetBytes(num);
            ////返回累加校验和  
            //return BitConverter.ToInt16(new byte[] { memorySpage[0], memorySpage[1] }, 0);
            return num;
        } 
        #endregion


        #region 读取设备信息文件
        public string[] Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            String line;
            int i = 0;
            string[] device = new string[4];
            while ((line = sr.ReadLine()) != null)
            {
                device[i] = line.ToString();
                i++;
            }
            i = 0;
            return device;
        } 
        #endregion

        #region 温度传感器命令
        private void TStart_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0x02, "温度传感器");
        }

        private void TStandby_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0x01, "温度传感器");
        }

        private void TReset_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0xcc, "温度传感器");
        }
        
        #endregion

        #region CO2命令
        private void co2Start_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0x02, "CO2传感器");
        }

        private void co2Standby_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0x01, "CO2传感器");
        }

        private void co2Reset_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0xcc, "CO2传感器");
        } 
        #endregion

        #region PM2.5
        private void pmStart_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0x02, "粉尘（PM2.5）传感器");
        }

        private void pmStandby_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0x01, "粉尘（PM2.5）传感器");
        }

        private void pmReset_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0xcc, "粉尘（PM2.5）传感器");
        } 
        #endregion

        #region 有害气体
        private void gasStart_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0x02, "甲醛传感器");
        }

        private void gasStandby_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0x01, "甲醛传感器");
        }

        private void gasReset_Click(object sender, EventArgs e)
        {
            Start_StartBy_Reset(0xcc, "甲醛传感器");
        } 
        #endregion
        

    }
}
