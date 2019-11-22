using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaToolDotNet
{
    static class Global
    {
        public static LuaFile luaFile = new LuaFile();
        public static string fileName = "";

        public static ConstantTableForm constantTableForm = null;
    }
}
