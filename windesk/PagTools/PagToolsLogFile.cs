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

        public static void Write(Exception ex)
        {
            //string ARQUIVO = @"D:\TI\LOGERRO.TXT";
            string arquivolog = string.Format(@System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagTools.dll", "") + @"\spool\ERROR_{0}.txt", DateTime.Now.ToString("yyyy_mm_dd_HH_MM"));
            //Pag_Net.Tools.LogFile.Write(ARQUIVO, "ARQUIVO PARA GRAVAR NO FUTURO" + arquivolog);
            Pag_Net.Tools.LogFile.Write(arquivolog, ex.Message);

        }
        public static void Write(string MyFile, String Line)
        {
            Write(MyFile, "LOG", null, FileMode.OpenOrCreate, FileAccess.ReadWrite, Line, Encoding.Default);
        }
        public static void Write(string MyFile, string MyTypeFile, ArrayList MyArrayLine, FileMode MyFileMode, FileAccess MyFileAccess)
        {
            Write(MyFile, MyTypeFile, MyArrayLine, MyFileMode, MyFileAccess, null, Encoding.Default);

        }

        public static void Write(string MyFile, string MyTypeFile, ArrayList MyArrayLine, FileMode MyFileMode, FileAccess MyFileAccess, Encoding __encoding)
        {
            Write(MyFile, MyTypeFile, MyArrayLine, MyFileMode, MyFileAccess, null, __encoding);

        }
        public static void Write(string MyFile, string MyTypeFile, ArrayList MyArrayLine, FileMode MyFileMode, FileAccess MyFileAccess, string line, Encoding __encoding)
        {
            if (MyFile == null)
            {
                throw new Exception("Arquivo de Log não definido.");
            }

            FileStream fs = new FileStream(@MyFile, MyFileMode, MyFileAccess);
            StreamWriter WriteFile = new StreamWriter(fs, __encoding);
            
            
            //if (MyTypeFile == "LOG")
            //{
                WriteFile.BaseStream.Seek(0, SeekOrigin.End);
            //}

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

    public static class StringPag
    {
        public enum TypeReplicate
        {
            Append = 1, Prepend = 2
        }
        public static string Replicate(string _old, string _stringReplicate, TypeReplicate _typeReplicate, int _count)
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

        public static string DoubleToDataBase(double NumberToDatabase)
        {
            try
            {
                return NumberToDatabase.ToString("0.00").Replace(",", ".");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    

}
