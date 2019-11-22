namespace LuaToolDotNet
{
    partial class InstructionForm
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
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControlParams = new System.Windows.Forms.TabControl();
            this.tabPageiABC = new System.Windows.Forms.TabPage();
            this.textBoxiABC_C = new System.Windows.Forms.TextBox();
            this.textBoxiABC_B = new System.Windows.Forms.TextBox();
            this.textBoxiABC_A = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabpageiABx = new System.Windows.Forms.TabPage();
            this.textBoxiABx_Bx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxiABx_A = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageiAsBx = new System.Windows.Forms.TabPage();
            this.textBoxiAsBx_sBx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxiAsBx_A = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxIndex = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStripInstruction = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constantTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlParams.SuspendLayout();
            this.tabPageiABC.SuspendLayout();
            this.tabpageiABx.SuspendLayout();
            this.tabPageiAsBx.SuspendLayout();
            this.menuStripInstruction.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operation:";
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Location = new System.Drawing.Point(104, 97);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(141, 20);
            this.comboBoxOperation.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Params:";
            // 
            // tabControlParams
            // 
            this.tabControlParams.Controls.Add(this.tabPageiABC);
            this.tabControlParams.Controls.Add(this.tabpageiABx);
            this.tabControlParams.Controls.Add(this.tabPageiAsBx);
            this.tabControlParams.Location = new System.Drawing.Point(104, 146);
            this.tabControlParams.Name = "tabControlParams";
            this.tabControlParams.SelectedIndex = 0;
            this.tabControlParams.Size = new System.Drawing.Size(278, 161);
            this.tabControlParams.TabIndex = 3;
            this.tabControlParams.SelectedIndexChanged += new System.EventHandler(this.tabControlParams_SelectedIndexChanged);
            // 
            // tabPageiABC
            // 
            this.tabPageiABC.Controls.Add(this.textBoxiABC_C);
            this.tabPageiABC.Controls.Add(this.textBoxiABC_B);
            this.tabPageiABC.Controls.Add(this.textBoxiABC_A);
            this.tabPageiABC.Controls.Add(this.label5);
            this.tabPageiABC.Controls.Add(this.label4);
            this.tabPageiABC.Controls.Add(this.label3);
            this.tabPageiABC.Location = new System.Drawing.Point(4, 22);
            this.tabPageiABC.Name = "tabPageiABC";
            this.tabPageiABC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageiABC.Size = new System.Drawing.Size(270, 135);
            this.tabPageiABC.TabIndex = 0;
            this.tabPageiABC.Text = "iABC";
            this.tabPageiABC.UseVisualStyleBackColor = true;
            // 
            // textBoxiABC_C
            // 
            this.textBoxiABC_C.Location = new System.Drawing.Point(95, 97);
            this.textBoxiABC_C.Name = "textBoxiABC_C";
            this.textBoxiABC_C.Size = new System.Drawing.Size(112, 21);
            this.textBoxiABC_C.TabIndex = 5;
            this.textBoxiABC_C.TextChanged += new System.EventHandler(this.paramTextBox_TextChanged);
            // 
            // textBoxiABC_B
            // 
            this.textBoxiABC_B.Location = new System.Drawing.Point(95, 60);
            this.textBoxiABC_B.Name = "textBoxiABC_B";
            this.textBoxiABC_B.Size = new System.Drawing.Size(112, 21);
            this.textBoxiABC_B.TabIndex = 4;
            this.textBoxiABC_B.TextChanged += new System.EventHandler(this.paramTextBox_TextChanged);
            // 
            // textBoxiABC_A
            // 
            this.textBoxiABC_A.Location = new System.Drawing.Point(95, 24);
            this.textBoxiABC_A.Name = "textBoxiABC_A";
            this.textBoxiABC_A.Size = new System.Drawing.Size(112, 21);
            this.textBoxiABC_A.TabIndex = 3;
            this.textBoxiABC_A.TextChanged += new System.EventHandler(this.paramTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "C:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "B:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "A:";
            // 
            // tabpageiABx
            // 
            this.tabpageiABx.Controls.Add(this.textBoxiABx_Bx);
            this.tabpageiABx.Controls.Add(this.label7);
            this.tabpageiABx.Controls.Add(this.textBoxiABx_A);
            this.tabpageiABx.Controls.Add(this.label6);
            this.tabpageiABx.Location = new System.Drawing.Point(4, 22);
            this.tabpageiABx.Name = "tabpageiABx";
            this.tabpageiABx.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageiABx.Size = new System.Drawing.Size(270, 135);
            this.tabpageiABx.TabIndex = 1;
            this.tabpageiABx.Text = "iABx";
            this.tabpageiABx.UseVisualStyleBackColor = true;
            // 
            // textBoxiABx_Bx
            // 
            this.textBoxiABx_Bx.Location = new System.Drawing.Point(99, 79);
            this.textBoxiABx_Bx.Name = "textBoxiABx_Bx";
            this.textBoxiABx_Bx.Size = new System.Drawing.Size(112, 21);
            this.textBoxiABx_Bx.TabIndex = 6;
            this.textBoxiABx_Bx.TextChanged += new System.EventHandler(this.paramTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "Bx:";
            // 
            // textBoxiABx_A
            // 
            this.textBoxiABx_A.Location = new System.Drawing.Point(99, 37);
            this.textBoxiABx_A.Name = "textBoxiABx_A";
            this.textBoxiABx_A.Size = new System.Drawing.Size(112, 21);
            this.textBoxiABx_A.TabIndex = 4;
            this.textBoxiABx_A.TextChanged += new System.EventHandler(this.paramTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "A:";
            // 
            // tabPageiAsBx
            // 
            this.tabPageiAsBx.Controls.Add(this.textBoxiAsBx_sBx);
            this.tabPageiAsBx.Controls.Add(this.label9);
            this.tabPageiAsBx.Controls.Add(this.textBoxiAsBx_A);
            this.tabPageiAsBx.Controls.Add(this.label8);
            this.tabPageiAsBx.Location = new System.Drawing.Point(4, 22);
            this.tabPageiAsBx.Name = "tabPageiAsBx";
            this.tabPageiAsBx.Size = new System.Drawing.Size(270, 135);
            this.tabPageiAsBx.TabIndex = 2;
            this.tabPageiAsBx.Text = "iAsBx";
            this.tabPageiAsBx.UseVisualStyleBackColor = true;
            // 
            // textBoxiAsBx_sBx
            // 
            this.textBoxiAsBx_sBx.Location = new System.Drawing.Point(98, 81);
            this.textBoxiAsBx_sBx.Name = "textBoxiAsBx_sBx";
            this.textBoxiAsBx_sBx.Size = new System.Drawing.Size(112, 21);
            this.textBoxiAsBx_sBx.TabIndex = 7;
            this.textBoxiAsBx_sBx.TextChanged += new System.EventHandler(this.paramTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "sBx:";
            // 
            // textBoxiAsBx_A
            // 
            this.textBoxiAsBx_A.Location = new System.Drawing.Point(98, 34);
            this.textBoxiAsBx_A.Name = "textBoxiAsBx_A";
            this.textBoxiAsBx_A.Size = new System.Drawing.Size(112, 21);
            this.textBoxiAsBx_A.TabIndex = 5;
            this.textBoxiAsBx_A.TextChanged += new System.EventHandler(this.paramTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "A:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(230, 332);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(326, 332);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxIndex
            // 
            this.textBoxIndex.Location = new System.Drawing.Point(104, 48);
            this.textBoxIndex.Name = "textBoxIndex";
            this.textBoxIndex.Size = new System.Drawing.Size(112, 21);
            this.textBoxIndex.TabIndex = 6;
            this.textBoxIndex.TextChanged += new System.EventHandler(this.textBoxIndex_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "Index:";
            // 
            // menuStripInstruction
            // 
            this.menuStripInstruction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStripInstruction.Location = new System.Drawing.Point(0, 0);
            this.menuStripInstruction.Name = "menuStripInstruction";
            this.menuStripInstruction.Size = new System.Drawing.Size(413, 25);
            this.menuStripInstruction.TabIndex = 8;
            this.menuStripInstruction.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.constantTableToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // constantTableToolStripMenuItem
            // 
            this.constantTableToolStripMenuItem.Name = "constantTableToolStripMenuItem";
            this.constantTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.constantTableToolStripMenuItem.Text = "Constant Table";
            this.constantTableToolStripMenuItem.Click += new System.EventHandler(this.constantTableToolStripMenuItem_Click);
            // 
            // InstructionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 372);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxIndex);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControlParams);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxOperation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripInstruction;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstructionForm";
            this.Text = "InstructionForm";
            this.Load += new System.EventHandler(this.InstructionForm_Load);
            this.tabControlParams.ResumeLayout(false);
            this.tabPageiABC.ResumeLayout(false);
            this.tabPageiABC.PerformLayout();
            this.tabpageiABx.ResumeLayout(false);
            this.tabpageiABx.PerformLayout();
            this.tabPageiAsBx.ResumeLayout(false);
            this.tabPageiAsBx.PerformLayout();
            this.menuStripInstruction.ResumeLayout(false);
            this.menuStripInstruction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControlParams;
        private System.Windows.Forms.TabPage tabPageiABC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabpageiABx;
        private System.Windows.Forms.TabPage tabPageiAsBx;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxiABC_C;
        private System.Windows.Forms.TextBox textBoxiABC_B;
        private System.Windows.Forms.TextBox textBoxiABC_A;
        private System.Windows.Forms.TextBox textBoxiABx_Bx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxiABx_A;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxiAsBx_sBx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxiAsBx_A;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxIndex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStripInstruction;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constantTableToolStripMenuItem;
    }
}