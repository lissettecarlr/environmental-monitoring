namespace 画折线图.MenuItem
{
    partial class RegisterModel
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
            this.labtitle = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtsbh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labtitle
            // 
            this.labtitle.AutoSize = true;
            this.labtitle.Location = new System.Drawing.Point(118, 33);
            this.labtitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labtitle.Name = "labtitle";
            this.labtitle.Size = new System.Drawing.Size(129, 20);
            this.labtitle.TabIndex = 0;
            this.labtitle.Text = "模块信息注册";
            this.labtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.labtitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.labtitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(71, 276);
            this.btnOk.Margin = new System.Windows.Forms.Padding(5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 38);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.btnOk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.btnOk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // txtsbh
            // 
            this.txtsbh.Location = new System.Drawing.Point(71, 167);
            this.txtsbh.Margin = new System.Windows.Forms.Padding(5);
            this.txtsbh.Name = "txtsbh";
            this.txtsbh.Size = new System.Drawing.Size(232, 30);
            this.txtsbh.TabIndex = 4;
            this.txtsbh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsbh_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "设备编号：";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 276);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegisterModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsbh);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labtitle);
            this.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "RegisterModel";
            this.Text = "RegisterModel";
            this.Load += new System.EventHandler(this.RegisterModel_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labtitle;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtsbh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}