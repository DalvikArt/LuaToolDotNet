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
        private readonly string _title = "Lua Instruction Editor";

        LuaFile.LuaFunction curFunction = null;
        string curFuncName = null;

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

            curFunction = Global.luaFile.FunctionTree.Function;
            curFuncName = Global.GetFuncName(curFunction);

            Text = _title + " (" + fileName + ")";

            UpdateControls();
        }

        string GetParamString(LuaFile.Instruction ins)
        {
            string paramStr;
            switch (ins.GetOpMode())
            {
                case LuaFile.OpMode.iABC:
                    uint[] ABC = ins.GetiABC();
                    paramStr = ABC[0] + ", " + ABC[1] + ", " + ABC[2];
                    break;

                case LuaFile.OpMode.iABx:
                    uint[] ABx = ins.GetiABx();
                    paramStr = ABx[0] + ", " + ABx[1];
                    break;

                case LuaFile.OpMode.iAsBx:
                    int[] AsBx = ins.GetiAsBx();
                    paramStr = AsBx[0] + ", " + AsBx[1];
                    break;

                default:
                    paramStr = ins.Params.ToString();
                    break;
            }

            return paramStr;
        }

        private void UpdateControls()
        {
            listViewMain.Items.Clear();

            LuaFile.LuaFunction curFunction = Global.luaFile.FindFunction(curFuncName);

            for (int i = 0; i < curFunction.Code.Count; ++i)
            {
                LuaFile.Instruction curIns = curFunction.Code[i];

                string paramStr = GetParamString(curIns);

                string[] curItemStr = { i.ToString(), curIns.Operation.ToString(), paramStr, curIns.GetOpMode().ToString(), "" };
                ListViewItem curItem = new ListViewItem(curItemStr);

                listViewMain.Items.Add(curItem);
            }
        }

        private void ExportFileHeader(LuaFile.LuaHeader header, FileStream fs)
        {
            // file name
            string bufStr = "Bytecode file: " + Global.fileName + "\r\n";

            bufStr += "<File Header>\r\n";

            // signature
            bufStr += "Signature: " + Encoding.ASCII.GetString(header.Signature) + "\r\n";

            string verStr = header.Version.ToString("X");
            string headerStr = "Luac Version:\t\t" + verStr[0] + "." + verStr[1] + "\t\t";
            headerStr += "Format:\t\t\t\t\t" + header.Format + "\r\n";

            headerStr += "Endian:\t\t\t\t" + (header.IsLittleEndian != 0 ? "Little" : "Big") + "\t";
            headerStr += "Size Of Int:\t\t\t" + header.SizeOfInt + "\r\n";

            headerStr += "Size Of Sizet:\t\t" + header.SizeOfSizeT + "\t\t";
            headerStr += "Size Of Instruction:\t" + header.SizeOfInstruction + "\r\n";

            headerStr += "Size Of LuaNumber:\t" + header.SizeOfLuaNumber + "\t\t";
            headerStr += "LuaNumber Integral:\t\t" + (header.LuaNumIntegral != 0 ? "No" : "Yes") + "\r\n";

            headerStr += "\r\n";

            bufStr += headerStr;

            byte[] buffer = Encoding.UTF8.GetBytes(bufStr);
            fs.Write(buffer, 0, buffer.Length);
        }

        private void ExportFunctionHeader(LuaFile.FunctionHeader header, FileStream fs)
        {
            string headerStr = "<Header>\r\n";

            headerStr += "Line Defined:\t\t" + header.LineDefined + "\t";
            headerStr += "Last Line:\t\t" + header.LastLineDefined + "\r\n";

            headerStr += "Nups:\t\t\t\t" + header.Nups + "\t";
            headerStr += "Num Of Args:\t" + header.NumOfArgs + "\r\n";

            headerStr += "Is Var Arg:\t\t\t" + (header.IsVarArg != 0 ? "Yes" : "No") + "\t";
            headerStr += "Max Stack Size:\t" + header.MaxStackSize + "\r\n";

            byte[] buffer = Encoding.UTF8.GetBytes(headerStr);
            fs.Write(buffer, 0, buffer.Length);
        }

        private void ExportFunction(LuaFile.FuncNode curNode, FileStream fs)
        {
            /// export current function
            // export function name
            byte[] buffer = Encoding.UTF8.GetBytes("@" + Global.fileName + ": " + curNode.Function.Header.LineDefined + "," + curNode.Function.Header.LastLineDefined + "\r\n");
            fs.Write(buffer, 0, buffer.Length);

            // export function header
            ExportFunctionHeader(curNode.Function.Header, fs);

            buffer = Encoding.UTF8.GetBytes("<Disassambling>\r\n");
            fs.Write(buffer, 0, buffer.Length);

            // export code
            for (int i = 0; i < curNode.Function.Code.Count; ++i)
            {
                LuaFile.Instruction curIns = curNode.Function.Code[i];

                // export index
                buffer = Encoding.UTF8.GetBytes("[" + i + "]\t");
                fs.Write(buffer, 0, buffer.Length);

                // export operation
                buffer = Encoding.UTF8.GetBytes(Enum.GetName(typeof(LuaFile.OpCode), curIns.Operation) + "\t\t");
                fs.Write(buffer, 0, buffer.Length);

                // export params
                buffer = Encoding.UTF8.GetBytes(GetParamString(curIns) + "\t");
                fs.Write(buffer, 0, buffer.Length);

                // change line
                buffer = Encoding.UTF8.GetBytes("\r\n");
                fs.Write(buffer, 0, buffer.Length);
            }

            buffer = Encoding.UTF8.GetBytes("\r\n");
            fs.Write(buffer, 0, buffer.Length);

            /// export children
            foreach (var cur in curNode.Children)
            {
                ExportFunction(cur, fs);
            }
        }

        private void ExportToFile(string fileName)
        {
            FileStream fsExportFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            ExportFileHeader(Global.luaFile.FileHeader, fsExportFile);
            ExportFunction(Global.luaFile.FunctionTree, fsExportFile);

            fsExportFile.Close();
        }

        #endregion

        #region EVENTS
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.lua_file_format_symbol;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Working on it...");
            return;

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

            InstructionForm insForm = new InstructionForm(curFuncName);
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

            InstructionForm insForm = new InstructionForm(curFunction.Code[listViewMain.SelectedIndices[0]], listViewMain.SelectedIndices[0], curFuncName);
            insForm.ShowDialog();

            if (insForm.Confirm)
            {
                curFunction.Code.RemoveAt(listViewMain.SelectedIndices[0]);


                curFunction.Code.Insert(insForm.Index, insForm.Result);

                Global.luaFile.SetFunction(curFunction, curFuncName);

                UpdateControls();
            }
        }

        private void constantTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(curFuncName == null)
            {
                ErrorInfo.NoFunctionSelected();
                return;
            }

            if(Global.constantTableForm != null)
            {
                Global.constantTableForm.Close();
            }

            Global.constantTableForm = new ConstantTableForm(curFuncName);
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

            if (MessageBox.Show("Save file?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Global.luaFile.SaveFile(Global.fileName);

                MessageBox.Show("Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            buttonFunctions.Text = "Functions";
            Text = _title;
        }

        private void functionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(curFuncName == null)
            {
                ErrorInfo.NoFunctionSelected();
                return;
            }

            new FunctionInfoForm(curFunction.Header, curFuncName).ShowDialog();
        }

        private void buttonFunctions_Click(object sender, EventArgs e)
        {
            if(Global.luaFile == null)
            {
                ErrorInfo.NoFileOpened();
                return;
            }

            FunctionListForm funcListForm = new FunctionListForm(buttonFunctions.Text == "Functions" ? "" : buttonFunctions.Text);

            funcListForm.ShowDialog();

            // function choosed
            if (funcListForm.Confirm == true)
            {
                curFuncName = funcListForm.FuncName;
                buttonFunctions.Text = curFuncName;
                curFunction = Global.luaFile.FindFunction(curFuncName);

                UpdateControls();
            }
        }

        private void debuggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebuggerForm debuggerForm = new DebuggerForm();

            debuggerForm.Show();

            debuggerForm.Left = Right;
            debuggerForm.Top = Top / 2;
        }

        Point dragPoint;

        private void listViewMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
                dragPoint = new Point(e.X, e.Y);
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void listViewMain_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] dragFileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                if(curFunction != null)
                {
                    if (MessageBox.Show("Open file \"" + dragFileNames[0] + "\"?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                }

                closeToolStripMenuItem_Click(sender, e);
                LoadFile(dragFileNames[0]);
            }
            else if(e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem dragItem = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
                int dragIndex = dragItem.Index;

                int dropIndex;
                Point dropPoint = listViewMain.PointToClient(new Point(e.X, e.Y));
                ListViewItem dropItem = listViewMain.GetItemAt(dropPoint.X, dropPoint.Y);

                if (dropItem == null)
                {
                    if (e.Y < dragPoint.Y)
                        dropIndex = 0;
                    else
                        dropIndex = listViewMain.Items.Count;
                }
                else
                    dropIndex = dropItem.Index;

                LuaFile.Instruction dragIns = curFunction.Code[dragIndex];

                curFunction.Code.RemoveAt(dragIndex);
                curFunction.Code.Insert(dropItem == null ? dropIndex - 1 : dropIndex, dragIns);

                UpdateControls();
            }
        }

        private void listViewMain_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog() { Title = "Export disassambling result", Filter = "Text file|*.txt|All Files|*.*", DefaultExt = ".txt" };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToFile(saveDialog.FileName);

                MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void addFuncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Working on it...");
            return;
        }

        private void deleteFuncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Working on it...");
            return;
        }
    }
}
