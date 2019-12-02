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
    public partial class InstructionForm : Form
    {
        private string FuncName;
        public bool Confirm { get; private set; } = false;
        public int Parmas { get; private set; } = 0;
        public LuaFile.Instruction Result { get; private set; } = new LuaFile.Instruction();
        public int Index { get; private set; } = 0;

        public InstructionForm(string funcName)
        {
            InitializeComponent();

            FuncName = funcName;
        }

        public InstructionForm(LuaFile.Instruction instruction, int index, string funcName) : this(funcName)
        {
            Result = instruction;
            Index = index;
        }

        private void UpdateParamControls()
        {
            switch ((LuaFile.OpMode)tabControlParams.SelectedIndex)
            {
                case LuaFile.OpMode.iABC:
                    uint[] ABC = Result.GetiABC();
                    textBoxiABC_A.Text = ABC[0].ToString();
                    textBoxiABC_B.Text = ABC[1].ToString();
                    textBoxiABC_C.Text = ABC[2].ToString();
                    break;

                case LuaFile.OpMode.iABx:
                    uint[] ABx = Result.GetiABx();
                    textBoxiABx_A.Text = ABx[0].ToString();
                    textBoxiABx_Bx.Text = ABx[1].ToString();
                    break;

                case LuaFile.OpMode.iAsBx:
                    int[] AsBx = Result.GetiAsBx();
                    textBoxiAsBx_A.Text = AsBx[0].ToString();
                    textBoxiAsBx_sBx.Text = AsBx[1].ToString();
                    break;

                default:
                    break;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Index = int.Parse(textBoxIndex.Text);
            Confirm = true;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Confirm = false;

            Close();
        }

        private void InstructionForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.lua_file_format_symbol;

            // init combobox
            foreach (var cur in Enum.GetNames(typeof(LuaFile.OpCode)))
            {
                comboBoxOperation.Items.Add(cur);
            }
             
            // init index textbox
            textBoxIndex.Text = Index.ToString();

            // init tabcontrol
            comboBoxOperation.SelectedIndex = (int)Result.Operation;

            tabControlParams.SelectedIndex = (int)Result.GetOpMode();
            UpdateParamControls();
        }

        private void tabControlParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateParamControls();
        }

        private void paramTextBox_TextChanged(object sender, EventArgs e)
        {
            string input = (sender as TextBox).Text;

            if (input.Length <= 0)
                return;

            if (System.Text.RegularExpressions.Regex.IsMatch(input, "[^0-9]"))
            {
                (sender as TextBox).Text = input.Remove(input.Length - 1);
                (sender as TextBox).SelectionStart = input.Length; 
            }

            switch((LuaFile.OpMode)tabControlParams.SelectedIndex)
            {
                case LuaFile.OpMode.iABC:
                    if (string.IsNullOrEmpty(textBoxiABC_A.Text) || string.IsNullOrEmpty(textBoxiABC_B.Text) || string.IsNullOrEmpty(textBoxiABC_C.Text))
                        break;
                    Result.SetiABC(new uint[] { uint.Parse(textBoxiABC_A.Text), uint.Parse(textBoxiABC_B.Text), uint.Parse(textBoxiABC_C.Text) });
                    break;

                case LuaFile.OpMode.iABx:
                    if (string.IsNullOrEmpty(textBoxiABx_A.Text) || string.IsNullOrEmpty(textBoxiABx_Bx.Text))
                        break;
                    Result.SetiABx(new uint[] { uint.Parse(textBoxiABx_A.Text), uint.Parse(textBoxiABx_Bx.Text) });
                    break;

                case LuaFile.OpMode.iAsBx:
                    if (string.IsNullOrEmpty(textBoxiAsBx_A.Text) || string.IsNullOrEmpty(textBoxiAsBx_sBx.Text))
                        break;
                    Result.SetiAsBx(new int[] { int.Parse(textBoxiAsBx_A.Text), int.Parse(textBoxiAsBx_sBx.Text) });
                    break;

                default:
                    break;
            }
        }

        private void textBoxIndex_TextChanged(object sender, EventArgs e)
        {
            string input = (sender as TextBox).Text;

            if (input.Length <= 0)
                return;

            if (System.Text.RegularExpressions.Regex.IsMatch(input, "[^0-9]"))
            {
                (sender as TextBox).Text = input.Remove(input.Length - 1);
                (sender as TextBox).SelectionStart = input.Length;
            }
        }

        private void constantTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.constantTableForm != null)
            {
                Global.constantTableForm.Close();
            }

            Global.constantTableForm = new ConstantTableForm(FuncName);
            Global.constantTableForm.Show();
        }
    }
}
