namespace 画折线图
{
    partial class OperationFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toollable = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabConModelPages = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.loadingControl1 = new LoadingControl.LoadingControl();
            this.md4 = new SimpleDetail.modelDetail();
            this.md3 = new SimpleDetail.modelDetail();
            this.md2 = new SimpleDetail.modelDetail();
            this.md1 = new SimpleDetail.modelDetail();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTmodel = new System.Windows.Forms.Button();
            this.btntempstart = new System.Windows.Forms.Button();
            this.btntempreset = new System.Windows.Forms.Button();
            this.userControl = new DetailControl.UserControl1();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnco2model = new System.Windows.Forms.Button();
            this.btnco2reset = new System.Windows.Forms.Button();
            this.btnco2start = new System.Windows.Forms.Button();
            this.userControlco2 = new DetailControl.UserControl1();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btndustmodel = new System.Windows.Forms.Button();
            this.btndustreset = new System.Windows.Forms.Button();
            this.btnduststart = new System.Windows.Forms.Button();
            this.userControldust = new DetailControl.UserControl1();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnharmmodel = new System.Windows.Forms.Button();
            this.btnharmreset = new System.Windows.Forms.Button();
            this.btnharmstart = new System.Windows.Forms.Button();
            this.userControlgas = new DetailControl.UserControl1();
            this.ms1 = new System.Windows.Forms.MenuStrip();
            this.RegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注册模块信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除模块信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式切换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.室内模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabConModelPages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.ms1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ConnectState,
            this.tProgressBar,
            this.toollable,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1030, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel1.Text = "设备连接状态：";
            // 
            // ConnectState
            // 
            this.ConnectState.Name = "ConnectState";
            this.ConnectState.Size = new System.Drawing.Size(56, 17);
            this.ConnectState.Text = "没有连接";
            // 
            // tProgressBar
            // 
            this.tProgressBar.Name = "tProgressBar";
            this.tProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toollable
            // 
            this.toollable.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toollable.Name = "toollable";
            this.toollable.Size = new System.Drawing.Size(685, 17);
            this.toollable.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel3.Text = "显示系统时间";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabConModelPages
            // 
            this.tabConModelPages.Controls.Add(this.tabPage1);
            this.tabConModelPages.Controls.Add(this.tabPage2);
            this.tabConModelPages.Controls.Add(this.tabPage3);
            this.tabConModelPages.Controls.Add(this.tabPage4);
            this.tabConModelPages.Controls.Add(this.tabPage5);
            this.tabConModelPages.Location = new System.Drawing.Point(216, 31);
            this.tabConModelPages.Name = "tabConModelPages";
            this.tabConModelPages.SelectedIndex = 0;
            this.tabConModelPages.Size = new System.Drawing.Size(774, 490);
            this.tabConModelPages.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.loadingControl1);
            this.tabPage1.Controls.Add(this.md4);
            this.tabPage1.Controls.Add(this.md3);
            this.tabPage1.Controls.Add(this.md2);
            this.tabPage1.Controls.Add(this.md1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(766, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "状态显示栏";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // loadingControl1
            // 
            this.loadingControl1.InnerCircleRadius = 5;
            this.loadingControl1.LineWidth = 3;
            this.loadingControl1.Location = new System.Drawing.Point(277, 183);
            this.loadingControl1.Name = "loadingControl1";
            this.loadingControl1.OutnerCircleRadius = 10;
            this.loadingControl1.Size = new System.Drawing.Size(102, 91);
            this.loadingControl1.Speed = 100;
            this.loadingControl1.SpokesMember = 12;
            this.loadingControl1.TabIndex = 23;
            this.loadingControl1.ThemeColor = System.Drawing.Color.DimGray;
            // 
            // md4
            // 
            this.md4.Location = new System.Drawing.Point(409, 241);
            this.md4.Name = "md4";
            this.md4.Size = new System.Drawing.Size(258, 219);
            this.md4.TabIndex = 7;
            // 
            // md3
            // 
            this.md3.Location = new System.Drawing.Point(75, 230);
            this.md3.Name = "md3";
            this.md3.Size = new System.Drawing.Size(258, 219);
            this.md3.TabIndex = 6;
            // 
            // md2
            // 
            this.md2.Location = new System.Drawing.Point(409, 19);
            this.md2.Name = "md2";
            this.md2.Size = new System.Drawing.Size(258, 219);
            this.md2.TabIndex = 5;
            // 
            // md1
            // 
            this.md1.Location = new System.Drawing.Point(75, 17);
            this.md1.Name = "md1";
            this.md1.Size = new System.Drawing.Size(258, 219);
            this.md1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnTmodel);
            this.tabPage2.Controls.Add(this.btntempstart);
            this.tabPage2.Controls.Add(this.btntempreset);
            this.tabPage2.Controls.Add(this.userControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(766, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "温湿度";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnTmodel
            // 
            this.btnTmodel.Location = new System.Drawing.Point(677, 74);
            this.btnTmodel.Name = "btnTmodel";
            this.btnTmodel.Size = new System.Drawing.Size(75, 23);
            this.btnTmodel.TabIndex = 5;
            this.btnTmodel.Text = "配置模式";
            this.btnTmodel.UseVisualStyleBackColor = true;
            this.btnTmodel.Click += new System.EventHandler(this.btnTmodel_Click);
            // 
            // btntempstart
            // 
            this.btntempstart.Location = new System.Drawing.Point(677, 6);
            this.btntempstart.Name = "btntempstart";
            this.btntempstart.Size = new System.Drawing.Size(75, 23);
            this.btntempstart.TabIndex = 4;
            this.btntempstart.Text = "启动";
            this.btntempstart.UseVisualStyleBackColor = true;
            this.btntempstart.Click += new System.EventHandler(this.btntempstart_Click);
            // 
            // btntempreset
            // 
            this.btntempreset.Location = new System.Drawing.Point(677, 40);
            this.btntempreset.Name = "btntempreset";
            this.btntempreset.Size = new System.Drawing.Size(75, 23);
            this.btntempreset.TabIndex = 3;
            this.btntempreset.Text = "复位";
            this.btntempreset.UseVisualStyleBackColor = true;
            this.btntempreset.Click += new System.EventHandler(this.btntempreset_Click);
            // 
            // userControl
            // 
            this.userControl.Location = new System.Drawing.Point(8, 2);
            this.userControl.Name = "userControl";
            this.userControl.Size = new System.Drawing.Size(747, 454);
            this.userControl.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnco2model);
            this.tabPage3.Controls.Add(this.btnco2reset);
            this.tabPage3.Controls.Add(this.btnco2start);
            this.tabPage3.Controls.Add(this.userControlco2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(766, 464);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "二氧化碳";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnco2model
            // 
            this.btnco2model.Location = new System.Drawing.Point(677, 74);
            this.btnco2model.Name = "btnco2model";
            this.btnco2model.Size = new System.Drawing.Size(75, 23);
            this.btnco2model.TabIndex = 6;
            this.btnco2model.Text = "配置模式";
            this.btnco2model.UseVisualStyleBackColor = true;
            this.btnco2model.Click += new System.EventHandler(this.btnco2model_Click);
            // 
            // btnco2reset
            // 
            this.btnco2reset.Location = new System.Drawing.Point(677, 40);
            this.btnco2reset.Name = "btnco2reset";
            this.btnco2reset.Size = new System.Drawing.Size(75, 23);
            this.btnco2reset.TabIndex = 5;
            this.btnco2reset.Text = "复位";
            this.btnco2reset.UseVisualStyleBackColor = true;
            this.btnco2reset.Click += new System.EventHandler(this.btnco2reset_Click);
            // 
            // btnco2start
            // 
            this.btnco2start.Location = new System.Drawing.Point(677, 6);
            this.btnco2start.Name = "btnco2start";
            this.btnco2start.Size = new System.Drawing.Size(75, 23);
            this.btnco2start.TabIndex = 4;
            this.btnco2start.Text = "启动";
            this.btnco2start.UseVisualStyleBackColor = true;
            this.btnco2start.Click += new System.EventHandler(this.btnco2start_Click);
            // 
            // userControlco2
            // 
            this.userControlco2.Location = new System.Drawing.Point(8, 2);
            this.userControlco2.Name = "userControlco2";
            this.userControlco2.Size = new System.Drawing.Size(747, 454);
            this.userControlco2.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btndustmodel);
            this.tabPage4.Controls.Add(this.btndustreset);
            this.tabPage4.Controls.Add(this.btnduststart);
            this.tabPage4.Controls.Add(this.userControldust);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(766, 464);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "粉尘";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btndustmodel
            // 
            this.btndustmodel.Location = new System.Drawing.Point(677, 74);
            this.btndustmodel.Name = "btndustmodel";
            this.btndustmodel.Size = new System.Drawing.Size(75, 23);
            this.btndustmodel.TabIndex = 6;
            this.btndustmodel.Text = "配置模式";
            this.btndustmodel.UseVisualStyleBackColor = true;
            this.btndustmodel.Click += new System.EventHandler(this.btndustmodel_Click);
            // 
            // btndustreset
            // 
            this.btndustreset.Location = new System.Drawing.Point(677, 40);
            this.btndustreset.Name = "btndustreset";
            this.btndustreset.Size = new System.Drawing.Size(75, 23);
            this.btndustreset.TabIndex = 5;
            this.btndustreset.Text = "复位";
            this.btndustreset.UseVisualStyleBackColor = true;
            this.btndustreset.Click += new System.EventHandler(this.btndustreset_Click);
            // 
            // btnduststart
            // 
            this.btnduststart.Location = new System.Drawing.Point(677, 6);
            this.btnduststart.Name = "btnduststart";
            this.btnduststart.Size = new System.Drawing.Size(75, 23);
            this.btnduststart.TabIndex = 4;
            this.btnduststart.Text = "启动";
            this.btnduststart.UseVisualStyleBackColor = true;
            this.btnduststart.Click += new System.EventHandler(this.btnduststart_Click);
            // 
            // userControldust
            // 
            this.userControldust.Location = new System.Drawing.Point(8, 2);
            this.userControldust.Name = "userControldust";
            this.userControldust.Size = new System.Drawing.Size(747, 454);
            this.userControldust.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnharmmodel);
            this.tabPage5.Controls.Add(this.btnharmreset);
            this.tabPage5.Controls.Add(this.btnharmstart);
            this.tabPage5.Controls.Add(this.userControlgas);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(766, 464);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "有害气体";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnharmmodel
            // 
            this.btnharmmodel.Location = new System.Drawing.Point(677, 74);
            this.btnharmmodel.Name = "btnharmmodel";
            this.btnharmmodel.Size = new System.Drawing.Size(75, 23);
            this.btnharmmodel.TabIndex = 7;
            this.btnharmmodel.Text = "配置模式";
            this.btnharmmodel.UseVisualStyleBackColor = true;
            this.btnharmmodel.Click += new System.EventHandler(this.btnharmmodel_Click);
            // 
            // btnharmreset
            // 
            this.btnharmreset.Location = new System.Drawing.Point(677, 40);
            this.btnharmreset.Name = "btnharmreset";
            this.btnharmreset.Size = new System.Drawing.Size(75, 23);
            this.btnharmreset.TabIndex = 6;
            this.btnharmreset.Text = "复位";
            this.btnharmreset.UseVisualStyleBackColor = true;
            this.btnharmreset.Click += new System.EventHandler(this.btnharmreset_Click);
            // 
            // btnharmstart
            // 
            this.btnharmstart.Location = new System.Drawing.Point(677, 6);
            this.btnharmstart.Name = "btnharmstart";
            this.btnharmstart.Size = new System.Drawing.Size(75, 23);
            this.btnharmstart.TabIndex = 5;
            this.btnharmstart.Text = "启动";
            this.btnharmstart.UseVisualStyleBackColor = true;
            this.btnharmstart.Click += new System.EventHandler(this.btnharmstart_Click);
            // 
            // userControlgas
            // 
            this.userControlgas.Location = new System.Drawing.Point(8, 2);
            this.userControlgas.Name = "userControlgas";
            this.userControlgas.Size = new System.Drawing.Size(747, 454);
            this.userControlgas.TabIndex = 3;
            // 
            // ms1
            // 
            this.ms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegisterToolStripMenuItem,
            this.模式切换ToolStripMenuItem,
            this.关于ToolStripMenuItem1});
            this.ms1.Location = new System.Drawing.Point(0, 0);
            this.ms1.Name = "ms1";
            this.ms1.Size = new System.Drawing.Size(1030, 25);
            this.ms1.TabIndex = 17;
            this.ms1.Text = "menuStrip1";
            // 
            // RegisterToolStripMenuItem
            // 
            this.RegisterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注册模块信息ToolStripMenuItem,
            this.删除模块信息ToolStripMenuItem});
            this.RegisterToolStripMenuItem.Name = "RegisterToolStripMenuItem";
            this.RegisterToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.RegisterToolStripMenuItem.Text = "模块信息设置";
            this.RegisterToolStripMenuItem.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // 注册模块信息ToolStripMenuItem
            // 
            this.注册模块信息ToolStripMenuItem.Name = "注册模块信息ToolStripMenuItem";
            this.注册模块信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.注册模块信息ToolStripMenuItem.Text = "注册模块信息";
            this.注册模块信息ToolStripMenuItem.Click += new System.EventHandler(this.注册模块信息ToolStripMenuItem_Click);
            // 
            // 删除模块信息ToolStripMenuItem
            // 
            this.删除模块信息ToolStripMenuItem.Name = "删除模块信息ToolStripMenuItem";
            this.删除模块信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除模块信息ToolStripMenuItem.Text = "删除模块信息";
            this.删除模块信息ToolStripMenuItem.Click += new System.EventHandler(this.删除模块信息ToolStripMenuItem_Click);
            // 
            // 模式切换ToolStripMenuItem
            // 
            this.模式切换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.室内模式ToolStripMenuItem});
            this.模式切换ToolStripMenuItem.Name = "模式切换ToolStripMenuItem";
            this.模式切换ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.模式切换ToolStripMenuItem.Text = "模式切换";
            this.模式切换ToolStripMenuItem.Click += new System.EventHandler(this.模式切换ToolStripMenuItem_Click);
            // 
            // 室内模式ToolStripMenuItem
            // 
            this.室内模式ToolStripMenuItem.Name = "室内模式ToolStripMenuItem";
            this.室内模式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.室内模式ToolStripMenuItem.Text = "室内模式";
            this.室内模式ToolStripMenuItem.Click += new System.EventHandler(this.室内模式ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem1.Text = "关于";
            this.关于ToolStripMenuItem1.Click += new System.EventHandler(this.关于ToolStripMenuItem1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 67);
            this.button1.TabIndex = 18;
            this.button1.Tag = "1";
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.picbox_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 67);
            this.button2.TabIndex = 19;
            this.button2.Tag = "2";
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.picbox_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 67);
            this.button3.TabIndex = 20;
            this.button3.Tag = "3";
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.picbox_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(28, 340);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 67);
            this.button4.TabIndex = 21;
            this.button4.Tag = "4";
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.picbox_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(28, 437);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 67);
            this.button5.TabIndex = 22;
            this.button5.Tag = "5";
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.picbox_Click);
            // 
            // OperationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 548);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabConModelPages);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ms1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.ms1;
            this.MaximizeBox = false;
            this.Name = "OperationFrm";
            this.Text = "OperationFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OperationFrm_FormClosed);
            this.Load += new System.EventHandler(this.OperationFrm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabConModelPages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ms1.ResumeLayout(false);
            this.ms1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ConnectState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripProgressBar tProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toollable;
        private System.Windows.Forms.TabControl tabConModelPages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip ms1;
        private System.Windows.Forms.ToolStripMenuItem RegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private SimpleDetail.modelDetail md4;
        private SimpleDetail.modelDetail md3;
        private SimpleDetail.modelDetail md2;
        private SimpleDetail.modelDetail md1;
        private System.Windows.Forms.ToolStripMenuItem 模式切换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 室内模式ToolStripMenuItem;
        private DetailControl.UserControl1 userControl;
        private DetailControl.UserControl1 userControlco2;
        private DetailControl.UserControl1 userControldust;
        private DetailControl.UserControl1 userControlgas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private LoadingControl.LoadingControl loadingControl1;
        private System.Windows.Forms.ToolStripMenuItem 注册模块信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除模块信息ToolStripMenuItem;
        private System.Windows.Forms.Button btntempstart;
        private System.Windows.Forms.Button btntempreset;
        private System.Windows.Forms.Button btnTmodel;
        private System.Windows.Forms.Button btnco2model;
        private System.Windows.Forms.Button btnco2reset;
        private System.Windows.Forms.Button btnco2start;
        private System.Windows.Forms.Button btndustmodel;
        private System.Windows.Forms.Button btndustreset;
        private System.Windows.Forms.Button btnduststart;
        private System.Windows.Forms.Button btnharmmodel;
        private System.Windows.Forms.Button btnharmreset;
        private System.Windows.Forms.Button btnharmstart;
    }
}