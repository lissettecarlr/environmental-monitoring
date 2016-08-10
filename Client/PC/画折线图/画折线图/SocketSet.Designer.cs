namespace 画折线图
{
    partial class SocketSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtip = new System.Windows.Forms.TextBox();
            this.txtport = new System.Windows.Forms.TextBox();
            this.btnsure = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbConModular = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "WIFI参数设置";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP 地址 :";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号  :";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // txtip
            // 
            this.txtip.Location = new System.Drawing.Point(102, 112);
            this.txtip.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(121, 23);
            this.txtip.TabIndex = 3;
            this.txtip.Text = "192.168.237.2";
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(102, 167);
            this.txtport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(121, 23);
            this.txtport.TabIndex = 4;
            this.txtport.Text = "50000";
            // 
            // btnsure
            // 
            this.btnsure.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnsure.Location = new System.Drawing.Point(40, 224);
            this.btnsure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(55, 35);
            this.btnsure.TabIndex = 5;
            this.btnsure.Text = "确定";
            this.btnsure.UseVisualStyleBackColor = true;
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(132, 224);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(51, 35);
            this.btncancel.TabIndex = 6;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "连接模块 :";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.label4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.label4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // cbConModular
            // 
            this.cbConModular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConModular.FormattingEnabled = true;
            this.cbConModular.Items.AddRange(new object[] {
            "温湿度",
            "二氧化碳浓度",
            "粉尘",
            "有害气体"});
            this.cbConModular.Location = new System.Drawing.Point(102, 61);
            this.cbConModular.Name = "cbConModular";
            this.cbConModular.Size = new System.Drawing.Size(121, 22);
            this.cbConModular.TabIndex = 8;
            // 
            // SocketSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(246, 289);
            this.Controls.Add(this.cbConModular);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.txtport);
            this.Controls.Add(this.txtip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("隶书", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SocketSet";
            this.Text = "SocketSet";
            this.Load += new System.EventHandler(this.SocketSet_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtip;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.Button btnsure;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbConModular;
    }
}