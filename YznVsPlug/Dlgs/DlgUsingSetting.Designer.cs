namespace YznVsPlug.Dlgs
{
    partial class DlgUsingSetting
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pgController = new System.Windows.Forms.TabPage();
            this.pgApplication = new System.Windows.Forms.TabPage();
            this.pgDto = new System.Windows.Forms.TabPage();
            this.pgManager = new System.Windows.Forms.TabPage();
            this.txtController = new System.Windows.Forms.TextBox();
            this.txtApplication = new System.Windows.Forms.TextBox();
            this.txtDto = new System.Windows.Forms.TextBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.pgController.SuspendLayout();
            this.pgApplication.SuspendLayout();
            this.pgDto.SuspendLayout();
            this.pgManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.pgController);
            this.tabControl1.Controls.Add(this.pgApplication);
            this.tabControl1.Controls.Add(this.pgDto);
            this.tabControl1.Controls.Add(this.pgManager);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 395);
            this.tabControl1.TabIndex = 0;
            // 
            // pgController
            // 
            this.pgController.Controls.Add(this.txtController);
            this.pgController.Location = new System.Drawing.Point(4, 22);
            this.pgController.Name = "pgController";
            this.pgController.Padding = new System.Windows.Forms.Padding(3);
            this.pgController.Size = new System.Drawing.Size(512, 369);
            this.pgController.TabIndex = 0;
            this.pgController.Text = "Controller";
            this.pgController.UseVisualStyleBackColor = true;
            // 
            // pgApplication
            // 
            this.pgApplication.Controls.Add(this.txtApplication);
            this.pgApplication.Location = new System.Drawing.Point(4, 22);
            this.pgApplication.Name = "pgApplication";
            this.pgApplication.Padding = new System.Windows.Forms.Padding(3);
            this.pgApplication.Size = new System.Drawing.Size(512, 369);
            this.pgApplication.TabIndex = 1;
            this.pgApplication.Text = "Application";
            this.pgApplication.UseVisualStyleBackColor = true;
            // 
            // pgDto
            // 
            this.pgDto.Controls.Add(this.txtDto);
            this.pgDto.Location = new System.Drawing.Point(4, 22);
            this.pgDto.Name = "pgDto";
            this.pgDto.Size = new System.Drawing.Size(512, 369);
            this.pgDto.TabIndex = 2;
            this.pgDto.Text = "DTO";
            this.pgDto.UseVisualStyleBackColor = true;
            // 
            // pgManager
            // 
            this.pgManager.Controls.Add(this.txtManager);
            this.pgManager.Location = new System.Drawing.Point(4, 22);
            this.pgManager.Name = "pgManager";
            this.pgManager.Size = new System.Drawing.Size(512, 369);
            this.pgManager.TabIndex = 3;
            this.pgManager.Text = "Manager";
            this.pgManager.UseVisualStyleBackColor = true;
            // 
            // txtController
            // 
            this.txtController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtController.Location = new System.Drawing.Point(6, 6);
            this.txtController.Multiline = true;
            this.txtController.Name = "txtController";
            this.txtController.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtController.Size = new System.Drawing.Size(500, 357);
            this.txtController.TabIndex = 1;
            // 
            // txtApplication
            // 
            this.txtApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplication.Location = new System.Drawing.Point(6, 6);
            this.txtApplication.Multiline = true;
            this.txtApplication.Name = "txtApplication";
            this.txtApplication.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtApplication.Size = new System.Drawing.Size(500, 357);
            this.txtApplication.TabIndex = 2;
            // 
            // txtDto
            // 
            this.txtDto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDto.Location = new System.Drawing.Point(6, 6);
            this.txtDto.Multiline = true;
            this.txtDto.Name = "txtDto";
            this.txtDto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDto.Size = new System.Drawing.Size(500, 357);
            this.txtDto.TabIndex = 2;
            // 
            // txtManager
            // 
            this.txtManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManager.Location = new System.Drawing.Point(6, 6);
            this.txtManager.Multiline = true;
            this.txtManager.Name = "txtManager";
            this.txtManager.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtManager.Size = new System.Drawing.Size(500, 357);
            this.txtManager.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(128, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(320, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cancel And Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // DlgUsingSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 465);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.MinimizeBox = false;
            this.Name = "DlgUsingSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Using Setting";
            this.Load += new System.EventHandler(this.DlgUsingSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.pgController.ResumeLayout(false);
            this.pgController.PerformLayout();
            this.pgApplication.ResumeLayout(false);
            this.pgApplication.PerformLayout();
            this.pgDto.ResumeLayout(false);
            this.pgDto.PerformLayout();
            this.pgManager.ResumeLayout(false);
            this.pgManager.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pgController;
        private System.Windows.Forms.TabPage pgApplication;
        private System.Windows.Forms.TextBox txtController;
        private System.Windows.Forms.TextBox txtApplication;
        private System.Windows.Forms.TabPage pgDto;
        private System.Windows.Forms.TextBox txtDto;
        private System.Windows.Forms.TabPage pgManager;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}