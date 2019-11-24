namespace LuaToolDotNet
{
    partial class FileInfoForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.groupBoxFileInfo = new System.Windows.Forms.GroupBox();
            this.labelIntegral = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelLuaNumSize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelInsSize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSizetSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelIntSize = new System.Windows.Forms.Label();
            this.labelEndian = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSignature = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxFileInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "File:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(53, 16);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(404, 21);
            this.textBoxFileName.TabIndex = 19;
            this.textBoxFileName.TextChanged += new System.EventHandler(this.textBoxFileName_TextChanged);
            // 
            // groupBoxFileInfo
            // 
            this.groupBoxFileInfo.Controls.Add(this.labelIntegral);
            this.groupBoxFileInfo.Controls.Add(this.label9);
            this.groupBoxFileInfo.Controls.Add(this.labelLuaNumSize);
            this.groupBoxFileInfo.Controls.Add(this.label8);
            this.groupBoxFileInfo.Controls.Add(this.labelInsSize);
            this.groupBoxFileInfo.Controls.Add(this.label7);
            this.groupBoxFileInfo.Controls.Add(this.labelSizetSize);
            this.groupBoxFileInfo.Controls.Add(this.label6);
            this.groupBoxFileInfo.Controls.Add(this.labelIntSize);
            this.groupBoxFileInfo.Controls.Add(this.labelEndian);
            this.groupBoxFileInfo.Controls.Add(this.label5);
            this.groupBoxFileInfo.Controls.Add(this.label4);
            this.groupBoxFileInfo.Controls.Add(this.labelFormat);
            this.groupBoxFileInfo.Controls.Add(this.label3);
            this.groupBoxFileInfo.Controls.Add(this.labelVersion);
            this.groupBoxFileInfo.Controls.Add(this.label2);
            this.groupBoxFileInfo.Controls.Add(this.labelSignature);
            this.groupBoxFileInfo.Controls.Add(this.label1);
            this.groupBoxFileInfo.Location = new System.Drawing.Point(14, 57);
            this.groupBoxFileInfo.Name = "groupBoxFileInfo";
            this.groupBoxFileInfo.Size = new System.Drawing.Size(443, 179);
            this.groupBoxFileInfo.TabIndex = 20;
            this.groupBoxFileInfo.TabStop = false;
            this.groupBoxFileInfo.Text = "File Info";
            // 
            // labelIntegral
            // 
            this.labelIntegral.AutoSize = true;
            this.labelIntegral.Location = new System.Drawing.Point(374, 120);
            this.labelIntegral.Name = "labelIntegral";
            this.labelIntegral.Size = new System.Drawing.Size(29, 12);
            this.labelIntegral.TabIndex = 35;
            this.labelIntegral.Text = "NULL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "Lua Number Integral:";
            // 
            // labelLuaNumSize
            // 
            this.labelLuaNumSize.AutoSize = true;
            this.labelLuaNumSize.Location = new System.Drawing.Point(374, 90);
            this.labelLuaNumSize.Name = "labelLuaNumSize";
            this.labelLuaNumSize.Size = new System.Drawing.Size(29, 12);
            this.labelLuaNumSize.TabIndex = 33;
            this.labelLuaNumSize.Text = "NULL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "Size Of Lua Number:";
            // 
            // labelInsSize
            // 
            this.labelInsSize.AutoSize = true;
            this.labelInsSize.Location = new System.Drawing.Point(374, 59);
            this.labelInsSize.Name = "labelInsSize";
            this.labelInsSize.Size = new System.Drawing.Size(29, 12);
            this.labelInsSize.TabIndex = 31;
            this.labelInsSize.Text = "NULL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "Size Of Instruction:";
            // 
            // labelSizetSize
            // 
            this.labelSizetSize.AutoSize = true;
            this.labelSizetSize.Location = new System.Drawing.Point(374, 27);
            this.labelSizetSize.Name = "labelSizetSize";
            this.labelSizetSize.Size = new System.Drawing.Size(29, 12);
            this.labelSizetSize.TabIndex = 29;
            this.labelSizetSize.Text = "NULL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "Size Of Sizet:";
            // 
            // labelIntSize
            // 
            this.labelIntSize.AutoSize = true;
            this.labelIntSize.Location = new System.Drawing.Point(108, 151);
            this.labelIntSize.Name = "labelIntSize";
            this.labelIntSize.Size = new System.Drawing.Size(29, 12);
            this.labelIntSize.TabIndex = 27;
            this.labelIntSize.Text = "NULL";
            // 
            // labelEndian
            // 
            this.labelEndian.AutoSize = true;
            this.labelEndian.Location = new System.Drawing.Point(108, 120);
            this.labelEndian.Name = "labelEndian";
            this.labelEndian.Size = new System.Drawing.Size(29, 12);
            this.labelEndian.TabIndex = 26;
            this.labelEndian.Text = "NULL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "Size Of Int:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "Endian:";
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Location = new System.Drawing.Point(108, 90);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(29, 12);
            this.labelFormat.TabIndex = 23;
            this.labelFormat.Text = "NULL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Format:";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(108, 59);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(29, 12);
            this.labelVersion.TabIndex = 21;
            this.labelVersion.Text = "NULL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "Luac Version:";
            // 
            // labelSignature
            // 
            this.labelSignature.AutoSize = true;
            this.labelSignature.Location = new System.Drawing.Point(108, 27);
            this.labelSignature.Name = "labelSignature";
            this.labelSignature.Size = new System.Drawing.Size(29, 12);
            this.labelSignature.TabIndex = 19;
            this.labelSignature.Text = "NULL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Signature:";
            // 
            // FileInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 248);
            this.Controls.Add(this.groupBoxFileInfo);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Info";
            this.Load += new System.EventHandler(this.FileInfoForm_Load);
            this.groupBoxFileInfo.ResumeLayout(false);
            this.groupBoxFileInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.GroupBox groupBoxFileInfo;
        private System.Windows.Forms.Label labelIntegral;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelLuaNumSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelInsSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSizetSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelIntSize;
        private System.Windows.Forms.Label labelEndian;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSignature;
        private System.Windows.Forms.Label label1;
    }
}