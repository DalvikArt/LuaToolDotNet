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
    public partial class DebuggerForm : Form
    {
        public DebuggerForm()
        {
            InitializeComponent();
        }

        private void AppendLog(string strLog)
        {
            string logString = "[" + DateTime.Now.ToString() + "] " + strLog;

            textBoxLog.AppendText(logString);
            textBoxLog.AppendText("\r\n");
        }

        private void DebuggerForm_Load(object sender, EventArgs e)
        {
            AppendLog("Ready to start debuggee.");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Debugger debugger = new Debugger();

            if (!debugger.ConnectToDebugee("127.0.0.1", 22334))
            {
                MessageBox.Show("Failed to connect to debuggee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
