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
    public partial class ConstantForm : Form
    {
        public bool Confirm { get; private set; } = false;
        public int Index { get; private set; } = 0;
        public LuaFile.LuaConstant Result { get; private set; } = null;

        public ConstantForm()
        {
            InitializeComponent();
        }

        public ConstantForm(int index, LuaFile.LuaConstant constant) : this()
        {
            Index = index;
            Result = constant;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Confirm = false;

            Close();
        }

        private void ConstantForm_Load(object sender, EventArgs e)
        {
            foreach (var cur in Enum.GetNames(typeof(LuaFile.ConstantType)))
            {
                comboBoxType.Items.Add(cur);
            }

            textBoxIndex.Text = Index.ToString();
            comboBoxType.SelectedIndex = (int)Result.Type;

            switch(Result.Type)
            {
                case LuaFile.ConstantType.LUA_TBOOLEAN:
                    textBoxValue.Text = (Result as LuaFile.LuaBoolean).Value.ToString();
                    break;

                case LuaFile.ConstantType.LUA_TSTRING:
                    textBoxValue.Text = (Result as LuaFile.LuaString).Value;
                    break;

                case LuaFile.ConstantType.LUA_TNUMBER:
                    textBoxValue.Text = (Result as LuaFile.LuaNumber).Value.ToString();
                    break;

                default:
                    break;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Index = int.Parse(textBoxIndex.Text);
            Result.Type = (LuaFile.ConstantType)comboBoxType.SelectedIndex;

            switch(Result.Type)
            {
                case LuaFile.ConstantType.LUA_TBOOLEAN:
                    Result = new LuaFile.LuaBoolean();
                    (Result as LuaFile.LuaBoolean).Value = bool.Parse(textBoxValue.Text);
                    break;

                case LuaFile.ConstantType.LUA_TSTRING:
                    Result = new LuaFile.LuaString();
                    (Result as LuaFile.LuaString).Value = textBoxValue.Text;
                    break;

                case LuaFile.ConstantType.LUA_TNUMBER:
                    Result = new LuaFile.LuaNumber();
                    (Result as LuaFile.LuaNumber).Value = double.Parse(textBoxValue.Text);
                    break;

                default:
                    break;
            }

            Confirm = true;

            Close();
        }
    }
}
