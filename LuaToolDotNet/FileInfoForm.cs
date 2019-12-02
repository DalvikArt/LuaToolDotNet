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
    public partial class FileInfoForm : Form
    {
        private string _fileName;
        private LuaFile.LuaHeader _header;

        public FileInfoForm(LuaFile.LuaHeader header, string fileName)
        {
            InitializeComponent();

            _fileName = fileName;
            _header = header;
        }

        private void FileInfoForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.lua_file_format_symbol;


            textBoxFileName.Text = _fileName;

            labelSignature.Text = Encoding.UTF8.GetString(_header.Signature);

            string version = _header.Version.ToString("X");
            labelVersion.Text = version[0] + "." + version[1];

            labelFormat.Text = _header.Format.ToString();
            labelEndian.Text = _header.IsLittleEndian == 1 ? "Little" : "Big";
            labelIntSize.Text = _header.SizeOfInt.ToString();
            labelSizetSize.Text = _header.SizeOfSizeT.ToString();
            labelInsSize.Text = _header.SizeOfInstruction.ToString();
            labelLuaNumSize.Text = _header.SizeOfLuaNumber.ToString();
            labelIntegral.Text = _header.LuaNumIntegral == 1 ? "No" : "Yes";

            textBoxFileName.Select(textBoxFileName.Text.Length, 0);
        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFileName.Text != _fileName)
            { 
                textBoxFileName.Text = _fileName; 
                textBoxFileName.Select(textBoxFileName.Text.Length, 0); 
            }
        }
    }
}
