using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaToolDotNet
{
    public class LuaFile
    {
        #region Structures

        IOUtils.Undumper undumper;
        IOUtils.Dumper dumper;

        public LuaHeader FileHeader = new LuaHeader();
        public FuncNode FunctionTree = new FuncNode();

        public static readonly string LUA_SIGNATURE = "\x1bLua";

        public enum ConstantType { LUA_TNIL =0, LUA_TBOOLEAN, LUA_TLIGHTUSERDATA, LUA_TNUMBER, LUA_TSTRING, LUA_TTABLE, LUA_TFUNCTION, LUA_TUSERDATA, LUA_TTHREAD };
        public enum OpCode { 
            OP_MOVE, OP_LOADK, OP_LOADBOOL, OP_LOADNIL, OP_GETUPVAL, OP_GETGLOBAL, OP_GETTABLE,
            OP_SETGLOBAL, OP_SETUPVAL, OP_SETTABLE, OP_NEWTABLE, OP_SELF, OP_ADD, OP_SUB, OP_MUL, 
            OP_DIV, OP_MOD, OP_POW, OP_UNM, OP_NOT, OP_LEN, OP_CONCAT, OP_JMP, OP_EQ, OP_LT, OP_LE, 
            OP_TEST, OP_TESTSET, OP_CALL,OP_TAILCALL, OP_RETURN, OP_FORLOOP, OP_FORPREP, OP_TFORLOOP, 
            OP_SETLIST, OP_CLOSE, OP_CLOSURE, OP_VARARG };

        public enum OpMode {iABC, iABx, iAsBx };

        public static readonly OpMode[] OpModes = { OpMode.iABC, OpMode.iABx, OpMode.iABC, OpMode.iABC, OpMode.iABC,
            OpMode.iABx, OpMode.iABC, OpMode.iABx, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC,
            OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC,
            OpMode.iABC, OpMode.iAsBx, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABC,
            OpMode.iABC, OpMode.iABC, OpMode.iAsBx, OpMode.iAsBx, OpMode.iABC, OpMode.iABC, OpMode.iABC, OpMode.iABx, 
            OpMode.iABC }; 

        public class LuaHeader
        {                 
            public byte[] Signature = new byte[LUA_SIGNATURE.Length];
            public byte Version;
            public byte Format;
            public byte IsLittleEndian;
            public byte SizeOfInt;
            public byte SizeOfSizeT;
            public byte SizeOfInstruction;
            public byte SizeOfLuaNumber;
            public byte LuaNumIntegral;
        }

        public class FunctionHeader
        {
            public string Name;
            public int LineDefined;
            public int LastLineDefined;
            public byte Nups;
            public byte NumOfArgs;
            public byte IsVarArg;
            public byte MaxStackSize;
        }

        public class LuaConstant
        {
            public ConstantType Type;
            public byte[] Data;

        }

        public class LuaBoolean : LuaConstant
        {
            public LuaBoolean()
            {
                Data = new byte[1];
                Type = ConstantType.LUA_TBOOLEAN;
            }

            public bool Value
            {
                get
                {
                    return Data[0] != 0;
                }

                set
                {
                    Data[0] = (byte)(value ? 1 : 0);
                }
            }
        }

        public class LuaString : LuaConstant
        {
            public LuaString()
            {
                Type = ConstantType.LUA_TSTRING;
            }

            public string Value
            {
                get
                {
                    return Encoding.ASCII.GetString(Data);
                }

                set
                {
                    Data = Encoding.ASCII.GetBytes(value);
                }
            }
        }

        public class LuaNumber : LuaConstant
        {
            public LuaNumber()
            {
                Type = ConstantType.LUA_TNUMBER;
            }

            public double Value
            {
                get
                {
                    return BitConverter.ToDouble(Data, 0);
                }

                set
                {
                    Data = BitConverter.GetBytes(value);
                }
            }
        }

        public class DebugInfo
        {
            public class LocVar
            {
                public string VarName;
                public int StartPC;
                public int EndPC;
            }

            public List<int> LineInfo = new List<int>();
            public List<LocVar> LocVars = new List<LocVar>();
            public List<string> UpValues = new List<string>();
        }

        public class LuaFunction
        {
            public FunctionHeader Header = new FunctionHeader();
            public List<Instruction> Code;
            public List<LuaConstant> Constants;
            public DebugInfo Debug;
        }

        public class FuncNode
        {
            public LuaFunction Function = new LuaFunction();
            public List<FuncNode> Childs = new List<FuncNode>();
        }

        public class Instruction
        {
            private readonly int MAXARG_sBx = (((1 << 18) - 1) >> 1);

            public OpCode Operation;
            public uint Params;

            public Instruction()
            {
                Operation = OpCode.OP_MOVE;
                Params = 0;
            }

            public Instruction(uint operation, uint param) : this((OpCode)operation, param)
            {
                
            }

            public Instruction(OpCode operation, uint param)
            {
                Operation = operation;
                Params = param;
            }

            public OpMode GetOpMode()
            {
                return OpModes[(int)Operation];
            }

            public uint[] GetiABC()
            {
                uint[] ABC = new uint[3];

                ABC[0] = (Params >> 6) & 0xff; // A
                ABC[2] = (Params >> (6 + 8)) & 0x1ff; // C
                ABC[1] = (Params >> (6 + 8 + 9)) & 0x1ff; // B

                return ABC;
            }

            public uint[] GetiABx()
            {
                uint[] ABx = new uint[2];

                ABx[0] = (Params >> 6) & 0xff; // A
                ABx[1] = (Params >> (6 + 8)) & 0x3ffff; // Bx

                return ABx;
            }

            public int[] GetiAsBx()
            {
                uint[] ABx = GetiABx();

                int[] AsBx = new int[] { (int)ABx[0], (int)ABx[1] };

                AsBx[1] = AsBx[1] - MAXARG_sBx;

                return AsBx;
            }

            public void SetiABC(uint[] ABC)
            {
                uint param = ABC[0] << 6;

                param += ABC[1] << (6 + 8 + 9);
                param += ABC[2] << (6 + 8);

                Params = param;
            }

            public void SetiABx(uint[] ABx)
            {
                uint param = ABx[0] << 6;

                param += ABx[1] << (6 + 8);

                Params = param;
            }

            public void SetiAsBx(int[] AsBx)
            {
                uint[] ABx = new uint[] { (uint)AsBx[0], (uint)(AsBx[1] + MAXARG_sBx) };

                SetiABx(ABx);
            }
        }

        #endregion

        public LuaFile()
        {
            
        }

        public void LoadFile(string fileName)
        {
            undumper = new IOUtils.Undumper(fileName);

            LoadLuaFile();
        }

        public void SaveFile(string fileName)
        {
            dumper = new IOUtils.Dumper(fileName);

            DumpLuaFile();

            dumper.Close();
        }

        #region Interfaces
        public List<LuaFunction> GetLuaFunctions()
        {
            List<LuaFunction> functions = new List<LuaFunction>();

            functions.AddRange(GetFunc(FunctionTree));

            return functions;
        }

        private List<LuaFunction> GetFunc(FuncNode curNode)
        {
            List<LuaFunction> functions = new List<LuaFunction>();

            functions.Add(curNode.Function);

            foreach (var cur in curNode.Childs)
            {
                functions.AddRange(GetFunc(cur));
            }

            return functions;
        }

        public LuaFunction FindFunction(string index)
        {
            return FindFunc(FunctionTree, index);
        }

        private LuaFunction FindFunc(FuncNode curNode, string index)
        {
            string[] indexes = index.Split(',');

            int linedefined = int.Parse(indexes[0]);
            int lastline = int.Parse(indexes[1]);

            LuaFunction function = null;

            if (curNode.Function.Header.LineDefined == linedefined && curNode.Function.Header.LastLineDefined == lastline)
                function = curNode.Function;
            else
                foreach (var cur in curNode.Childs)
                    if ((function = FindFunc(cur, index)) != null)
                        break;

            return function;
        }

        public bool SetFunction(LuaFunction function, string index)
        {
            return SetFunc(FunctionTree, function, index);
        }

        private bool SetFunc(FuncNode curNode, LuaFunction function, string index)
        {
            string[] indexes = index.Split(',');

            int linedefined = int.Parse(indexes[0]);
            int lastline = int.Parse(indexes[1]);

            if (curNode.Function.Header.LineDefined == linedefined && curNode.Function.Header.LastLineDefined == lastline)
            {
                curNode.Function = function;

                return true;
            }
            else
            {
                foreach (var cur in curNode.Childs)
                {
                    if (SetFunc(cur, function, index) != false)
                        return true;
                }
            }

            return false;
        }
        #endregion


        #region Undump
        private void LoadLuaFile()
        {
            LoadFileHeader();
            LoadFunctions();
        }

        void LoadFileHeader()
        {
            FileHeader.Signature = undumper.LoadBlock(LUA_SIGNATURE.Length);
            FileHeader.Version = undumper.LoadByte();
            FileHeader.Format = undumper.LoadByte();
            FileHeader.IsLittleEndian = undumper.LoadByte();
            FileHeader.SizeOfInt = undumper.LoadByte();
            FileHeader.SizeOfSizeT = undumper.LoadByte();
            FileHeader.SizeOfInstruction = undumper.LoadByte();
            FileHeader.SizeOfLuaNumber = undumper.LoadByte();
            FileHeader.LuaNumIntegral = undumper.LoadByte();
        }

        void LoadFunctions()
        {
            FunctionTree = new FuncNode();
            LoadFunction(ref FunctionTree);

            FunctionTree = FunctionTree.Childs[0];
        }

        void LoadFunction(ref FuncNode upperNode)
        {
            FuncNode curNode = new FuncNode();

            curNode.Function.Header.Name = undumper.LoadString();
            curNode.Function.Header.LineDefined = undumper.LoadInt();
            curNode.Function.Header.LastLineDefined = undumper.LoadInt();
            curNode.Function.Header.Nups = undumper.LoadByte();
            curNode.Function.Header.NumOfArgs = undumper.LoadByte();
            curNode.Function.Header.IsVarArg = undumper.LoadByte();
            curNode.Function.Header.MaxStackSize = undumper.LoadByte();

            curNode.Function.Code = LoadCode();
            curNode.Function.Constants = LoadConstants(ref curNode);
            curNode.Function.Debug = LoadDebug();

            upperNode.Childs.Add(curNode);
        }

        List<Instruction> LoadCode()
        {
            int insNum = undumper.LoadInt();

            List<Instruction> instructions = new List<Instruction>();

            for (int i = 0; i < insNum; ++i)
            {
                uint curIns = undumper.LoadUInt();

                uint curOpCode = curIns & 0x3f;
                uint curParams = curIns & 0xffffffc0;

                instructions.Add(new Instruction(curOpCode, curParams));
            }

            return instructions;
        }

        List<LuaConstant> LoadConstants(ref FuncNode curNode)
        {
            int constNum = undumper.LoadInt();

            List<LuaConstant> luaConstants = new List<LuaConstant>();

            for (int i = 0; i < constNum; ++i)
            {
                byte type = undumper.LoadByte();

                LuaConstant curConst;

                switch((ConstantType)type)
                {
                    case ConstantType.LUA_TNIL:
                        curConst  = new LuaConstant();
                        break;

                    case ConstantType.LUA_TBOOLEAN:
                        curConst = new LuaBoolean();
                        break;

                    case ConstantType.LUA_TNUMBER:
                        curConst = new LuaNumber();
                        break;

                    case ConstantType.LUA_TSTRING:
                        curConst = new LuaString();
                        break;

                    default:
                        curConst = new LuaConstant();
                        break;
                }

                curConst.Type = (ConstantType)type;

                switch(curConst.Type)
                {
                    case ConstantType.LUA_TNIL:
                        // DO NOTHING
                        break;

                    case ConstantType.LUA_TBOOLEAN:
                        curConst.Data = new byte[1];
                        curConst.Data[0] = undumper.LoadByte();
                        break;

                    case ConstantType.LUA_TNUMBER:
                        curConst.Data = undumper.LoadBlock(sizeof(double));
                        break;

                    case ConstantType.LUA_TSTRING:
                        curConst.Data = Encoding.ASCII.GetBytes(undumper.LoadString());
                        break;

                    default:
                        break;
                }

                luaConstants.Add(curConst);
            }

            int funcNum = undumper.LoadInt();
            for (int i = 0; i < funcNum; ++i)
            {
                LoadFunction(ref curNode);
            }

            return luaConstants;
        }

        DebugInfo LoadDebug()
        {
            DebugInfo debug = new DebugInfo();

            int n = undumper.LoadInt();
            for (int i = 0; i < n; ++i)
            {
                debug.LineInfo.Add(undumper.LoadInt());
            }

            n = undumper.LoadInt();
            for (int i = 0; i < n; ++i)
            {
                DebugInfo.LocVar curVar = new DebugInfo.LocVar();
                curVar.VarName = undumper.LoadString();
                curVar.StartPC = undumper.LoadInt();
                curVar.EndPC = undumper.LoadInt();

                debug.LocVars.Add(curVar);
            }

            n = undumper.LoadInt();
            for (int i = 0; i < n; ++i)
            {
                debug.UpValues.Add(undumper.LoadString());
            }

            return debug;
        }
        #endregion

        #region Dump
        private void DumpLuaFile()
        {
            DumpFileHeader();
            DumpFunctions();
        }

        private void DumpFileHeader()
        {
            dumper.Dump(FileHeader.Signature);
            dumper.Dump(FileHeader.Version);
            dumper.Dump(FileHeader.Format);
            dumper.Dump(FileHeader.IsLittleEndian);
            dumper.Dump(FileHeader.SizeOfInt);
            dumper.Dump(FileHeader.SizeOfSizeT);
            dumper.Dump(FileHeader.SizeOfInstruction);
            dumper.Dump(FileHeader.SizeOfLuaNumber);
            dumper.Dump(FileHeader.LuaNumIntegral);
        }

        private void DumpFunctions()
        {
            DumpFunction(FunctionTree);
        }

        private void DumpFunction(FuncNode curFunc)
        {
            dumper.Dump(curFunc.Function.Header.Name);
            dumper.Dump(curFunc.Function.Header.LineDefined);
            dumper.Dump(curFunc.Function.Header.LastLineDefined);
            dumper.Dump(curFunc.Function.Header.Nups);
            dumper.Dump(curFunc.Function.Header.NumOfArgs);
            dumper.Dump(curFunc.Function.Header.IsVarArg);
            dumper.Dump(curFunc.Function.Header.MaxStackSize);

            DumpCode(curFunc.Function.Code);
            DumpConstants(curFunc);
            DumpDebug(curFunc.Function.Debug);
        }

        private void DumpCode(List<Instruction> code)
        {
            dumper.Dump(code.Count);

            foreach(var cur in code)
            {
                uint instruction = (uint)cur.Operation + cur.Params;

                dumper.Dump(instruction);
            }
        }

        private void DumpConstants(FuncNode curFunc)
        {
            dumper.Dump(curFunc.Function.Constants.Count);

            foreach(var cur in curFunc.Function.Constants)
            {
                dumper.Dump((byte)cur.Type);

                switch(cur.Type)
                {
                    case ConstantType.LUA_TNIL:

                        break;

                    case ConstantType.LUA_TBOOLEAN:
                        dumper.Dump((cur as LuaBoolean).Value);
                        break;

                    case ConstantType.LUA_TNUMBER:
                        dumper.Dump((cur as LuaNumber).Value);
                        break;

                    case ConstantType.LUA_TSTRING:
                        dumper.Dump((cur as LuaString).Value);
                        break;

                    default:
                        break;
                }
            }

            dumper.Dump(curFunc.Childs.Count);
            foreach(var cur in curFunc.Childs)
            {
                DumpFunction(cur);
            }
        }

        private void DumpDebug(DebugInfo debug)
        {
            dumper.Dump(debug.LineInfo.Count);
            foreach (var cur in debug.LineInfo)
                dumper.Dump(cur);

            dumper.Dump(debug.LocVars.Count);
            foreach (var cur in debug.LocVars)
            {
                dumper.Dump(cur.VarName);
                dumper.Dump(cur.StartPC);
                dumper.Dump(cur.EndPC);
            }

            dumper.Dump(debug.UpValues.Count);
            foreach (var cur in debug.UpValues)
                dumper.Dump(cur);
        }

        #endregion
    }
}
