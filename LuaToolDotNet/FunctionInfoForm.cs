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
    public partial class FunctionInfoForm : Form
    {
        private string _name;
        private LuaFile.FunctionHeader _header;

        public FunctionInfoForm(LuaFile.FunctionHeader header, string name)
        {
            InitializeComponent();

            _header = header;
            _name = name;
        }

        private void FunctionInfoForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.lua_file_format_symbol;

            labelFuntion.Text = _name;

            textBoxName.Text = _header.Name;
            labelLineDefined.Text = _header.LineDefined.ToString();
            labelLastLine.Text = _header.LastLineDefined.ToString();
            labelNups.Text = _header.Nups.ToString();
            labelArgNum.Text = _header.NumOfArgs.ToString();
            labelIsVarArg.Text = _header.IsVarArg == 1 ? "Yes" : "No";
            labelStackSize.Text = _header.MaxStackSize.ToString();

            textBoxName.Select(textBoxName.Text.Length, 0);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text != _header.Name.Trim(new char[]{ '\0' }))
            {
                textBoxName.Text = _header.Name;
                textBoxName.Select(textBoxName.Text.Length, 0);
            }
        }
    }
}
