namespace LuaToolDotNet
{
    partial class FunctionListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionListForm));
            this.treeViewFunctions = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewFunctions
            // 
            this.treeViewFunctions.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.treeViewFunctions, "treeViewFunctions");
            this.treeViewFunctions.Name = "treeViewFunctions";
            this.treeViewFunctions.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewFunctions_BeforeCollapse);
            this.treeViewFunctions.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFunctions_NodeMouseDoubleClick);
            // 
            // FunctionListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewFunctions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FunctionListForm";
            this.Load += new System.EventHandler(this.FunctionListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFunctions;
    }
}