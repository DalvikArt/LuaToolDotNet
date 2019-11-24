using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaToolDotNet
{
    static class Global
    {
        public static LuaFile luaFile = null;
        public static string fileName = "";

        public static ConstantTableForm constantTableForm = null;

        public static string GetFuncName(LuaFile.LuaFunction func)
        {
            return func.Header.LineDefined.ToString() + "," + func.Header.LastLineDefined.ToString();
        }
    }
}
