namespace YznVsPlug.Dlgs
{
    partial class DlgAbpCoder
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
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clbCreateOptions = new System.Windows.Forms.CheckedListBox();
            this.btnGenCtl = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSubCtlPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubAppPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbInsetToSolution = new System.Windows.Forms.RadioButton();
            this.rbClipBorad = new System.Windows.Forms.RadioButton();
            this.btnGenApp = new System.Windows.Forms.Button();
            this.btnGenManager = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btnSelectInv = new System.Windows.Forms.Button();
            this.btnSelectSubCtlPath = new System.Windows.Forms.Button();
            this.btnSelectSubAppPath = new System.Windows.Forms.Button();
            this.btnUsing = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(67, 12);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(229, 21);
            this.txtModel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "实体名称";
            // 
            // clbCreateOptions
            // 
            this.clbCreateOptions.FormattingEnabled = true;
            this.clbCreateOptions.Items.AddRange(new object[] {
            "Post",
            "Get",
            "Put",
            "Export",
            "Import",
            "GetById",
            "Abandon"});
            this.clbCreateOptions.Location = new System.Drawing.Point(39, 185);
            this.clbCreateOptions.Name = "clbCreateOptions";
            this.clbCreateOptions.Size = new System.Drawing.Size(257, 148);
            this.clbCreateOptions.TabIndex = 0;
            // 
            // btnGenCtl
            // 
            this.btnGenCtl.Location = new System.Drawing.Point(39, 420);
            this.btnGenCtl.Name = "btnGenCtl";
            this.btnGenCtl.Size = new System.Drawing.Size(75, 23);
            this.btnGenCtl.TabIndex = 3;
            this.btnGenCtl.Text = "生成Ctl";
            this.btnGenCtl.UseVisualStyleBackColor = true;
            this.btnGenCtl.Click += new System.EventHandler(this.BtnGenCtl_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(39, 156);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(221, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // txtSubCtlPath
            // 
            this.txtSubCtlPath.Location = new System.Drawing.Point(103, 72);
            this.txtSubCtlPath.Name = "txtSubCtlPath";
            this.txtSubCtlPath.Size = new System.Drawing.Size(193, 21);
            this.txtSubCtlPath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "控制器存放位置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Application存放位置";
            // 
            // txtSubAppPath
            // 
            this.txtSubAppPath.Location = new System.Drawing.Point(67, 129);
            this.txtSubAppPath.Name = "txtSubAppPath";
            this.txtSubAppPath.Size = new System.Drawing.Size(229, 21);
            this.txtSubAppPath.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(133, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 10;
            this.button2.Text = "同控制器";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(103, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 21);
            this.button3.TabIndex = 11;
            this.button3.Text = "同Application";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbInsetToSolution);
            this.groupBox1.Controls.Add(this.rbClipBorad);
            this.groupBox1.Location = new System.Drawing.Point(39, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 66);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成目标";
            // 
            // rbInsetToSolution
            // 
            this.rbInsetToSolution.AutoSize = true;
            this.rbInsetToSolution.Location = new System.Drawing.Point(94, 33);
            this.rbInsetToSolution.Name = "rbInsetToSolution";
            this.rbInsetToSolution.Size = new System.Drawing.Size(95, 16);
            this.rbInsetToSolution.TabIndex = 1;
            this.rbInsetToSolution.TabStop = true;
            this.rbInsetToSolution.Text = "插入到项目中";
            this.rbInsetToSolution.UseVisualStyleBackColor = true;
            // 
            // rbClipBorad
            // 
            this.rbClipBorad.AutoSize = true;
            this.rbClipBorad.Checked = true;
            this.rbClipBorad.Location = new System.Drawing.Point(16, 33);
            this.rbClipBorad.Name = "rbClipBorad";
            this.rbClipBorad.Size = new System.Drawing.Size(59, 16);
            this.rbClipBorad.TabIndex = 0;
            this.rbClipBorad.TabStop = true;
            this.rbClipBorad.Text = "剪切板";
            this.rbClipBorad.UseVisualStyleBackColor = true;
            // 
            // btnGenApp
            // 
            this.btnGenApp.Location = new System.Drawing.Point(133, 420);
            this.btnGenApp.Name = "btnGenApp";
            this.btnGenApp.Size = new System.Drawing.Size(75, 23);
            this.btnGenApp.TabIndex = 13;
            this.btnGenApp.Text = "生成App";
            this.btnGenApp.UseVisualStyleBackColor = true;
            this.btnGenApp.Click += new System.EventHandler(this.BtnGenApp_Click);
            // 
            // btnGenManager
            // 
            this.btnGenManager.Location = new System.Drawing.Point(39, 456);
            this.btnGenManager.Name = "btnGenManager";
            this.btnGenManager.Size = new System.Drawing.Size(123, 23);
            this.btnGenManager.TabIndex = 14;
            this.btnGenManager.Text = "生成Manager";
            this.btnGenManager.UseVisualStyleBackColor = true;
            this.btnGenManager.Click += new System.EventHandler(this.BtnGenManager_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Location = new System.Drawing.Point(221, 156);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNone.TabIndex = 15;
            this.btnSelectNone.Text = "全不选";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.BtnSelectNone_Click);
            // 
            // btnSelectInv
            // 
            this.btnSelectInv.Location = new System.Drawing.Point(133, 156);
            this.btnSelectInv.Name = "btnSelectInv";
            this.btnSelectInv.Size = new System.Drawing.Size(75, 23);
            this.btnSelectInv.TabIndex = 16;
            this.btnSelectInv.Text = "反选";
            this.btnSelectInv.UseVisualStyleBackColor = true;
            this.btnSelectInv.Click += new System.EventHandler(this.BtnSelectInv_Click);
            // 
            // btnSelectSubCtlPath
            // 
            this.btnSelectSubCtlPath.Location = new System.Drawing.Point(221, 46);
            this.btnSelectSubCtlPath.Name = "btnSelectSubCtlPath";
            this.btnSelectSubCtlPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSubCtlPath.TabIndex = 17;
            this.btnSelectSubCtlPath.Text = "选择...";
            this.btnSelectSubCtlPath.UseVisualStyleBackColor = true;
            this.btnSelectSubCtlPath.Click += new System.EventHandler(this.BtnSelectSubCtlPath_Click);
            // 
            // btnSelectSubAppPath
            // 
            this.btnSelectSubAppPath.Location = new System.Drawing.Point(221, 102);
            this.btnSelectSubAppPath.Name = "btnSelectSubAppPath";
            this.btnSelectSubAppPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSubAppPath.TabIndex = 18;
            this.btnSelectSubAppPath.Text = "选择...";
            this.btnSelectSubAppPath.UseVisualStyleBackColor = true;
            this.btnSelectSubAppPath.Click += new System.EventHandler(this.BtnSelectSubAppPath_Click);
            // 
            // btnUsing
            // 
            this.btnUsing.Location = new System.Drawing.Point(10, 72);
            this.btnUsing.Name = "btnUsing";
            this.btnUsing.Size = new System.Drawing.Size(87, 23);
            this.btnUsing.TabIndex = 19;
            this.btnUsing.Text = "UsingSetting";
            this.btnUsing.UseVisualStyleBackColor = true;
            this.btnUsing.Click += new System.EventHandler(this.BtnUsing_Click);
            // 
            // DlgAbpCoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 491);
            this.Controls.Add(this.btnUsing);
            this.Controls.Add(this.btnSelectSubAppPath);
            this.Controls.Add(this.btnSelectSubCtlPath);
            this.Controls.Add(this.btnSelectInv);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btnGenManager);
            this.Controls.Add(this.btnGenApp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubAppPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubCtlPath);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnGenCtl);
            this.Controls.Add(this.clbCreateOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModel);
            this.Name = "DlgAbpCoder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABP Coder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgAbpCoder_FormClosing);
            this.Load += new System.EventHandler(this.DlgAbpCoder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbCreateOptions;
        private System.Windows.Forms.Button btnGenCtl;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSubCtlPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubAppPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbInsetToSolution;
        private System.Windows.Forms.RadioButton rbClipBorad;
        private System.Windows.Forms.Button btnGenApp;
        private System.Windows.Forms.Button btnGenManager;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnSelectInv;
        private System.Windows.Forms.Button btnSelectSubCtlPath;
        private System.Windows.Forms.Button btnSelectSubAppPath;
        private System.Windows.Forms.Button btnUsing;
    }
}