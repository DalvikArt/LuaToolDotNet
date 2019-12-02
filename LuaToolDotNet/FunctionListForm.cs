using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuaToolDotNet
{
    public partial class FunctionListForm : Form
    {
        public bool Confirm { get; private set; } = false;
        public string FuncName { get; private set; }

        private string _curFuncName;

        public FunctionListForm(string curFuncName)
        {
            InitializeComponent();

            _curFuncName = curFuncName;
        }

        private void FunctionListForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.lua_file_format_symbol;

            // init func list
            LuaFile.FuncNode funcTree = Global.luaFile.FunctionTree;

            TreeNode root = new TreeNode(Global.GetFuncName(funcTree.Function));
            treeViewFunctions.Nodes.Add(root);

            AddChilds(ref root, funcTree);

            treeViewFunctions.ExpandAll();

            // choose current function
            if (!string.IsNullOrEmpty(_curFuncName))
            {
                TreeNode[] nodeFound = treeViewFunctions.Nodes.Find(_curFuncName, true);
                treeViewFunctions.SelectedNode = nodeFound[0];
            }
        }

        private void AddChilds(ref TreeNode curTreeNode, LuaFile.FuncNode curFuncNode)
        {
            foreach(var cur in curFuncNode.Childs)
            {
                TreeNode newNode = new TreeNode(Global.GetFuncName(cur.Function));
                curTreeNode.Nodes.Add(newNode);

                foreach (var curChild in cur.Childs)
                    AddChilds(ref newNode, curChild);
            }
        }

        private void treeViewFunctions_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void treeViewFunctions_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FuncName = treeViewFunctions.SelectedNode.Text;
            Confirm = true;

            Close();
        }
    }
}
