using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuaToolDotNet
{
    class ErrorInfo
    {
        public static void NoFileOpened()
        {
            MessageBox.Show("No file opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void NoFunctionSelected()
        {
            MessageBox.Show("No function opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
