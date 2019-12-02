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
    public partial class ConstantTableForm : Form
    {
        string _funcName;
        LuaFile.LuaFunction function;

        public ConstantTableForm(string funcName)
        {
            InitializeComponent();

            _funcName = funcName;

            function = Global.luaFile.FindFunction(_funcName);
        }

        private void UpdateControls()
        {
            listViewConstantTable.Items.Clear();

            foreach (var cur in function.Constants)
            {
                string[] curItem = { listViewConstantTable.Items.Count.ToString(), cur.Type.ToString(), (cur is LuaFile.LuaBoolean) ? ((LuaFile.LuaBoolean)cur).Value.ToString() : ((cur is LuaFile.LuaNumber) ? ((LuaFile.LuaNumber)cur).Value.ToString() : ((cur is LuaFile.LuaString) ? ((LuaFile.LuaString)cur).Value : "[Data]")) };

                listViewConstantTable.Items.Add(new ListViewItem(curItem));
            }
        }

        private void ConstantTableForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.lua_file_format_symbol;

            UpdateControls();
        }

        private void ConstantTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.constantTableForm = null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Quit without save?","Warnning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Global.luaFile.SetFunction(function, _funcName);

            Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewConstantTable.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select the item you want to edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ConstantForm newForm = new ConstantForm(listViewConstantTable.SelectedIndices[0], function.Constants[listViewConstantTable.SelectedIndices[0]]);

            newForm.ShowDialog();

            if(newForm.Confirm)
            {
                function.Constants.RemoveAt(listViewConstantTable.SelectedIndices[0]);
                function.Constants.Insert(newForm.Index, newForm.Result);

                UpdateControls();
            }
        }

        private void listViewConstantTable_DoubleClick(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(listViewConstantTable, new EventArgs());
        }
    }
}
