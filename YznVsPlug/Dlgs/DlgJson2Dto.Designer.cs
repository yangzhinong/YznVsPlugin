namespace YznVsPlug.Dlgs
{
    partial class DlgJson2Dto
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
            this.btnOk = new System.Windows.Forms.Button();
            this.txtJson = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenModelFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnExportExcelDto = new System.Windows.Forms.Button();
            this.btnQueryParamDto = new System.Windows.Forms.Button();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(626, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(126, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "生成Json->Dto";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // txtJson
            // 
            this.txtJson.Location = new System.Drawing.Point(12, 3);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJson.Size = new System.Drawing.Size(585, 115);
            this.txtJson.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 309);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(585, 314);
            this.txtResult.TabIndex = 2;
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(12, 124);
            this.txtSrc.Multiline = true;
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSrc.Size = new System.Drawing.Size(585, 179);
            this.txtSrc.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(628, 583);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnOpenModelFile
            // 
            this.btnOpenModelFile.Location = new System.Drawing.Point(628, 124);
            this.btnOpenModelFile.Name = "btnOpenModelFile";
            this.btnOpenModelFile.Size = new System.Drawing.Size(124, 23);
            this.btnOpenModelFile.TabIndex = 5;
            this.btnOpenModelFile.Text = "打开Model类文件";
            this.btnOpenModelFile.UseVisualStyleBackColor = true;
            this.btnOpenModelFile.Click += new System.EventHandler(this.BtnOpenModelFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "dlgOpenFile";
            this.openFileDialog1.Filter = "ModelFile (*.cs)|*.cs";
            // 
            // btnExportExcelDto
            // 
            this.btnExportExcelDto.Location = new System.Drawing.Point(626, 41);
            this.btnExportExcelDto.Name = "btnExportExcelDto";
            this.btnExportExcelDto.Size = new System.Drawing.Size(126, 23);
            this.btnExportExcelDto.TabIndex = 6;
            this.btnExportExcelDto.Text = "生成ExportDto";
            this.btnExportExcelDto.UseVisualStyleBackColor = true;
            this.btnExportExcelDto.Click += new System.EventHandler(this.BtnExportExcelDto_Click);
            // 
            // btnQueryParamDto
            // 
            this.btnQueryParamDto.Location = new System.Drawing.Point(626, 70);
            this.btnQueryParamDto.Name = "btnQueryParamDto";
            this.btnQueryParamDto.Size = new System.Drawing.Size(126, 23);
            this.btnQueryParamDto.TabIndex = 7;
            this.btnQueryParamDto.Text = "生成QueryParamDto";
            this.btnQueryParamDto.UseVisualStyleBackColor = true;
            this.btnQueryParamDto.Click += new System.EventHandler(this.BtnQueryParamDto_Click);
            // 
            // btnAddModel
            // 
            this.btnAddModel.Location = new System.Drawing.Point(628, 153);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(124, 23);
            this.btnAddModel.TabIndex = 8;
            this.btnAddModel.Text = "追加Model类文件";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.BtnAddModel_Click);
            // 
            // DlgJson2Dto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 618);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddModel);
            this.Controls.Add(this.btnQueryParamDto);
            this.Controls.Add(this.btnExportExcelDto);
            this.Controls.Add(this.btnOpenModelFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSrc);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtJson);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgJson2Dto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Json To Dto And Export Dto";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgJson2Dto_FormClosing);
            this.Load += new System.EventHandler(this.DlgJson2Dto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtJson;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpenModelFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnExportExcelDto;
        private System.Windows.Forms.Button btnQueryParamDto;
        private System.Windows.Forms.Button btnAddModel;
    }
}