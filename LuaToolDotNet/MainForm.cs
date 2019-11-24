using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LuaToolDotNet
{
    public partial class MainForm : Form
    {
        LuaFile.LuaFunction curFunction;

        public MainForm()
        {
            InitializeComponent();
        }

        #region METHODS
        private void LoadFile(string fileName)
        {
            Global.fileName = fileName;
            Global.luaFile = new LuaFile();
            Global.luaFile.LoadFile(fileName);

            UpdateFunctionList();
            UpdateControls();
        }

        private void UpdateFunctionList()
        {
            List<LuaFile.LuaFunction> functions = Global.luaFile.GetLuaFunctions();

            foreach (var curFunc in functions)
            {
                comboBoxFunctionList.Items.Add(curFunc.Header.LineDefined.ToString() + "," + curFunc.Header.LastLineDefined.ToString());
                comboBoxFunctionList.SelectedIndex = 0;
            }
        }

        private void UpdateControls()
        {
            listViewMain.Items.Clear();

            curFunction = Global.luaFile.FindFunction(comboBoxFunctionList.SelectedItem.ToString());

            for (int i = 0; i < curFunction.Code.Count; ++i)
            {
                LuaFile.Instruction curIns = curFunction.Code[i];

                string[] curItemStr = { i.ToString(), curIns.Operation.ToString(), curIns.Params.ToString(), curIns.GetOpMode().ToString(), "" };
                ListViewItem curItem = new ListViewItem(curItemStr);

                listViewMain.Items.Add(curItem);
            }
        }
        #endregion

        #region EVENTS
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.fileName = "TMPFILE";
            Global.luaFile = new LuaFile(); 

            UpdateControls();
        }
        #endregion

        private void comboBoxFunctionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the position of the instruction you want to insert!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InstructionForm insForm = new InstructionForm(comboBoxFunctionList.SelectedItem.ToString());
            insForm.ShowDialog();

            if(insForm.Confirm)
            {

            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listViewMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the instruction you want to edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InstructionForm insForm = new InstructionForm(curFunction.Code[listViewMain.SelectedIndices[0]], listViewMain.SelectedIndices[0], comboBoxFunctionList.SelectedItem.ToString());
            insForm.ShowDialog();

            if (insForm.Confirm)
            {
                curFunction.Code.RemoveAt(listViewMain.SelectedIndices[0]);


                curFunction.Code.Insert(insForm.Index, insForm.Result);

                Global.luaFile.SetFunction(curFunction, comboBoxFunctionList.SelectedItem.ToString());

                UpdateControls();
            }
        }

        private void constantTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(comboBoxFunctionList.SelectedIndex == -1)
            {
                ErrorInfo.NoFunctionSelected();
                return;
            }

            if(Global.constantTableForm != null)
            {
                Global.constantTableForm.Close();
            }

            Global.constantTableForm = new ConstantTableForm(comboBoxFunctionList.SelectedItem.ToString());
            Global.constantTableForm.Show();
        }

        private void listViewMain_DoubleClick(object sender, EventArgs e)
        {
            editToolStripMenuItem1_Click(this, new EventArgs());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog() { Title = "Select Lua Bytecode File", Filter = "Luac Output File|*.out|Lua Bytecode|*.lua|Binary File|*.bin|All Files|*.*" };

            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFile(openDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Global.luaFile == null)
            {
                ErrorInfo.NoFileOpened();
                return;
            }

            if(!File.Exists(Global.fileName))
            {
                saveAsToolStripMenuItem_Click(sender, e);
                return;
            }

            if (MessageBox.Show("Save file?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Global.luaFile.SaveFile(Global.fileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.luaFile == null)
            {
                ErrorInfo.NoFileOpened();
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog() { Title = "Save Bytecode File", Filter = "Luac Output File|*.out|Lua Bytecode|*.lua|Binary File|*.bin|All Files|*.*", DefaultExt = ".out" };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Global.luaFile.SaveFile(saveDialog.FileName);
            }
        }

        private void fileInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.luaFile == null)
                ErrorInfo.NoFileOpened();
            else
                new FileInfoForm(Global.luaFile.FileHeader, Global.fileName).ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.fileName = "";
            Global.luaFile = null;
            listViewMain.Items.Clear();
            comboBoxFunctionList.Items.Clear();
            comboBoxFunctionList.SelectedIndex = -1;
        }

        private void functionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
