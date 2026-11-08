    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Pag_Net.Tools
{
    public static class LogFile
    {

        public static void Write(string MyFile, String Line)
        {
            Write(MyFile, "LOG", null, FileMode.OpenOrCreate, FileAccess.ReadWrite, Line);
        }
        public static void Write(string MyFile, string MyTypeFile, ArrayList MyArrayLine, FileMode MyFileMode, FileAccess MyFileAccess)
        {
            Write(MyFile, MyTypeFile, MyArrayLine, MyFileMode, MyFileAccess, null);

        }
        public static void Write(string MyFile, string MyTypeFile, ArrayList MyArrayLine, FileMode MyFileMode, FileAccess MyFileAccess, string line)
        {
            if (MyFile == null)
            {
                throw new Exception("Arquivo de Log não definido.");
            }

            FileStream fs = new FileStream(@MyFile, MyFileMode, MyFileAccess);
            StreamWriter WriteFile = new StreamWriter(fs);
            if (MyTypeFile == "LOG")
            {
                WriteFile.BaseStream.Seek(0, SeekOrigin.End);
            }

            if (MyArrayLine != null)
            {
                foreach (string j in MyArrayLine)
                {
                    if (MyTypeFile == "LOG") { WriteFile.WriteLine(@"{0} - {1} -> {2} ", DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), j.ToString()); }
                    else { WriteFile.WriteLine(j.ToString()); }
                }
                MyArrayLine.Clear();
            }

            if (line != null)
            {
                if (MyTypeFile == "LOG") { WriteFile.WriteLine(@"{0} - {1} -> {2} ", DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), line.ToString()); }
                else { WriteFile.WriteLine(line.ToString()); }
            }
            
            WriteFile.Flush();
            WriteFile.Close();
            
        }
        public static String[] ReadLine(string _Arquivo)
        {
            return System.IO.File.ReadAllLines(@_Arquivo);
        }
    }

    public static class StringReplicate
    {
        public enum TypeReplicate
        {
            Append = 1, Prepend = 2
        }
        public static string ReturnString(string _old, string _stringReplicate, TypeReplicate _typeReplicate, int _count)
        {
            if (string.IsNullOrEmpty(_stringReplicate) == true) return _old;
            if (_count < 1) return _old;

            StringBuilder Result = new StringBuilder(_old.Length + (_stringReplicate.Length * _count));
            Result.Append(_old);

            for (int i = 0; i < _count; i++)
            {
                if (_typeReplicate == TypeReplicate.Append)
                    Result.Append(_stringReplicate);
                else
                    Result.Insert(0, _stringReplicate);
            }

            return Result.ToString();

        }
    }
}
