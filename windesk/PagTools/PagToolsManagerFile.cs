using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using Pag_Net.Tools;

namespace Pag_Net.Tools
{
    public class ManagerFileInfo
    {
        public string FileName { get; set; }
        public string FileTypeImport { get; set; }
        public string FileDate { get; set; }
        public int FileColumns { get; set; }
        public int FileRows { get; set; }
        public string FileType { get; set; }
        public long FileLenth { get; set; }
        public string FilePath { get; set; }
        public string TipoArquivo { get; set; }
        //string FileRegistro = Convert.ToDateTime(Arquivo.FileDate.ToString()).ToString("yyyyMMdd") + Convert.ToInt32(Arquivo.FileLenth).ToString("0000000000000000");
        public override string ToString()
        {
            return Convert.ToDateTime(FileDate.ToString()).ToString("yyyyMMdd") + Convert.ToInt32(FileLenth).ToString("0000000000000000");
        }
    }



    public class ManagerFile
    {
        // Excel.Application xlApp = new Excel.Application();
        public List<ManagerFileInfo> DirectoryList(string pathInfo)
        {
            try
            {
                List<ManagerFileInfo> _DirectoryList = new List<ManagerFileInfo>();
                string[] FilesList = Directory.GetFiles(pathInfo);
                foreach (string i in FilesList)
                {
                    ManagerFileInfo _BlueSoftFile = FileOut(new FileInfo(i.ToString()));
                    _DirectoryList.Add(_BlueSoftFile);
                }
                return _DirectoryList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public ManagerFileInfo FileOut(FileInfo _file)
        {
            ManagerFileInfo Arquivo = new ManagerFileInfo();
            Arquivo.FileName = _file.FullName;
            Arquivo.FileDate = _file.CreationTime.ToShortDateString();
            Arquivo.FileType = _file.Extension.ToString();
            Arquivo.FileLenth = _file.Length;
            //if (_file.Extension.ToString() == ".xlsx" || _file.Extension.ToString() == ".xls")
            //{
            //    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@_file.FullName);
            //    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //    Excel.Range xlRange = xlWorksheet.UsedRange;
            //    Arquivo.FileRows = xlRange.Rows.Count;
            //    Arquivo.FileColumns = xlRange.Columns.Count;
            //    xlWorkbook.Close();
            //}
            return Arquivo;
        }
        public DataTable View(ManagerFileInfo _file)
        {

            try
            {
                DataTable _TableView = new DataTable("Arquivo");


                string arquivo = _file.FileName;
                System.Data.DataSet ds = new System.Data.DataSet();
                if (_file.FileType == ".xls" || _file.FileType == ".xlsx") /// ARQUIVOS DO TIPO EXCEL
                {
                    string strConexao = string.Format("Provider=Microsoft.ACE.OLEDB.14.0; Data Source={0}; Extended Properties=\"Excel 12.0; HDR=YES; IMEX=1\"", arquivo);
                    OleDbConnection conn = new OleDbConnection(strConexao);
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    //Cria o objeto dataset para receber o conteúdo do arquivo Excel
                    DataSet output = new DataSet();
                    string sheet = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        // obtem o noma da planilha corrente
                        sheet = row["TABLE_NAME"].ToString();
                        // obtem todos as linhas da planilha corrente
                    }
                    string strQuery = "SELECT * FROM [" + sheet + "]";
                    System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
                    adapter.Fill(ds);
                    conn.Close();
                }

                if (_file.FileType.ToUpper() == ".TXT")
                {

                    string[] linhas = LogFile.ReadLine(arquivo);
                    DataTable dt = new DataTable("TabTxt");
                    dt.Columns.Add("Linha", typeof(String));

                    for (int i = 0; i < linhas.Count(); i++)
                    {
                        DataRow row = dt.NewRow();
                        row["Linha"] = linhas[i];
                        dt.Rows.Add(row);
                    }
                    ds.Tables.Add(dt);

                }


                if (_file.FileType.ToUpper() == ".HTML")
                {

                    string[] linhas = LogFile.ReadLine(arquivo);
                    DataTable dt = new DataTable("TabTxt");
                    dt.Columns.Add("Linha", typeof(String));

                    for (int i = 0; i < linhas.Count(); i++)
                    {
                        DataRow row = dt.NewRow();
                        row["Linha"] = linhas[i];
                        dt.Rows.Add(row);
                    }
                    ds.Tables.Add(dt);

                }


                if (_file.FileType.ToUpper() == ".CSV")
                {

                    string[] linhas = LogFile.ReadLine(arquivo);
                    DataTable dt = new DataTable("TabTxt");
                    dt.Columns.Add("Linha", typeof(String));

                    for (int i = 0; i < linhas.Count(); i++)
                    {
                        DataRow row = dt.NewRow();
                        row["Linha"] = linhas[i];
                        dt.Rows.Add(row);
                    }
                    ds.Tables.Add(dt);

                }

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception("DataTableView XLS Error: " + ex.Message.ToString());
            }


        }



    }


}