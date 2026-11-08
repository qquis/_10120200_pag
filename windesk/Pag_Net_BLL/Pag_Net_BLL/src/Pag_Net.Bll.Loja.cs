/*
 * #26918 16/12/2022 - Alteração da posição do código de barra na etiqueta 
 * 
 * 
 */


using Microsoft.Win32.SafeHandles;
using Pag_Net.Bll.Operacionais.Varejo.Execucao;
using Pag_Net.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Pag_Net.Bll.Loja
{
    public static class Carga
    {
        public static void Processar(Pag_Net.Models.modelSistemaUsuario Myconnect)
        {
            try
            {
                Pag_Net.Bll.R0010.Select.Proc_Log_Seq(Myconnect, 100203);
                Pag_Net.P0100.Bll.Process.Execute(Myconnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Aplicar (Pag_Net.Models.modelSistemaUsuario Myconnect)
        {
            Pag_Net.Bll.R0010.Select.Proc_Log_Seq(Myconnect, 100204);
        }

    }

    public static class EtiquetaPrecos_Consultar
    {
        public static DataTable get(
                Pag_Net.Models.modelSistemaUsuario MyConnect,
                F0020_Produto.Defaut_Filter Filter_Produto,
                int vproc_log_seq, 
                bool SelecionaDataAlteracaoPreco,
                DateTime DataAlteracaoPreco_Inicial, 
                DateTime DataAlteracaoPreco_Final

            )
        {
            try
            {
                return Pag_Net.Bll.R0028.Select.get(MyConnect, Filter_Produto, vproc_log_seq, SelecionaDataAlteracaoPreco, DataAlteracaoPreco_Inicial, DataAlteracaoPreco_Final);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    public static class EtiquetaCaixa
    {
        public static DBDataTable ConsultarCaixas(Pag_Net.Models.modelSistemaUsuario MyConnect, int prb_cdprodutobluesoft_unitario)

        {
            try
            {
                string SQL = " SELECT pr.pr_cdproduto, " + 
                             "       em.prb_cdprodutobluesoft, " + 
                             "       pb.prb_descricao, " + 
                             "       COALESCE(pb.prb_descricao_gondola, left(pb.prb_descricao, 20)) AS prb_descricao_etiqueta, " + 
                             "       em.pre_embalagem AS pre_embalagem, " + 
                             "       pb.prb_cdbarra_principal AS preg_cdbarra, " + 
                             "       ap.prc_valor, " + 
                             "       ap.prc_qtde_promocional, " + 
                             "       ap.prc_valor_promocional " +
                             "   FROM tbproduto pr " +
                             "       JOIN tbprodutoembalagem em ON em.pr_cdproduto = pr.pr_cdproduto " +
                             "       JOIN tbprodutobluesoft pb ON pb.prb_cdprodutobluesoft_pk = em.prb_cdprodutobluesoft " +
                             "       JOIN tbpreco_aplicacao ap ON ap.pr_cdproduto = pr.pr_cdproduto AND ap.prb_cdprodutobluesoft = em.prb_cdprodutobluesoft " +
                             "   WHERE pr.pr_status = true " +
                             "       AND em.pre_fatorestoque <> 1 " +
                             "       AND ap.tab_pre_cd = 1 " +
                             "       and pr.prb_cdprodutobluesoft = " + prb_cdprodutobluesoft_unitario.ToString();

                DBDataTable DATA = BDCommand.DBDataTableGet(MyConnect, SQL);
               
                return DATA;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
       
    }    
    
    public class EtiquetaPrecos_Imprimir
    {
        List<Pag_Net.Bll.Loja.Db.Etiqueta> _Lista;
        public EtiquetaPrecos_Imprimir()
        {
            _Lista = new List<Pag_Net.Bll.Loja.Db.Etiqueta>();
        }
        public void Adicionar(Pag_Net.Bll.Loja.Db.Etiqueta _produto)
        {
            _Lista.Add(_produto);
        }
        public void Imprimir()
        {
            EtiquetaPreco.Imprimir(_Lista.ToArray());
        }
    }
    public class EtiquetaPreco
    {

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);




        public Pag_Net.Bll.Cadastros.ProdutosComplementos Complementos;
        public UspEtiquetaGondola List;

        //private Pag_Net.Models.TbSysUserInfo _MyConnect;


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        public EtiquetaPreco()
        {
        }

        public static void Imprimir(Pag_Net.Bll.Loja.Db.Etiqueta[] __etiquetas)
        {
            try
            {
                string crlf = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
                string command = "CT~~CD,~CC^~CT~" + crlf;
                command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3~SD15^JUS^LRN^CI0^XZ" + crlf;

                foreach (Pag_Net.Bll.Loja.Db.Etiqueta item in __etiquetas)
                {
                    string DescricaoProdutoEtiqueta = item.Descricao;
                    string DescricaoTipoEmbalagem = "UNIDADE";


                    switch (item.Embalagem)
                    {
                        case "UN":
                            DescricaoProdutoEtiqueta = item.Descricao;
                            DescricaoTipoEmbalagem = "UNIDADE";
                            break;

                        case "BD":
                            DescricaoProdutoEtiqueta = item.EmbalagemDescricao;
                            DescricaoTipoEmbalagem = "BANDEJA";
                            break;

                        case "CX":
                            DescricaoProdutoEtiqueta = item.EmbalagemDescricao;
                            DescricaoTipoEmbalagem = "CAIXA";
                            break;
                        case "FD":
                            DescricaoProdutoEtiqueta = item.EmbalagemDescricao;
                            DescricaoTipoEmbalagem = "FARDO";
                            break;
                        case "DP":
                            DescricaoProdutoEtiqueta = item.EmbalagemDescricao;
                            DescricaoTipoEmbalagem = "DISPLAY";
                            break;
                        default:
                            DescricaoProdutoEtiqueta = item.EmbalagemDescricao;
                            DescricaoTipoEmbalagem = "KILOGRAMA";
                            break;
                    }

                    string CodigoBarraEtiqueta = "";
                    if (item.TipoCodigoBarra == "EAN13")
                        CodigoBarraEtiqueta = item.CodigoBarra;

                    string AtacadoDescricaoTipoEmbalagem = "EMBALAGEM C/";
                    if (item.AtacadoEmbalagem == "CX") AtacadoDescricaoTipoEmbalagem = "CAIXA C/";
                    if (item.AtacadoEmbalagem == "FD") AtacadoDescricaoTipoEmbalagem = "FARDO C/";
                    if (item.AtacadoEmbalagem == "PC") AtacadoDescricaoTipoEmbalagem = "PACOTE C/";

                    string Dia = DateTime.Now.Day.ToString();
                    if (Dia.Length < 2) Dia = "0" + Dia;

                    string Mes = DateTime.Now.Month.ToString();
                    if (Mes.Length < 2) Mes = "0" + Mes;

                    string DataCodigoInterno = Dia + "." + Mes + "." + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour + "h" + DateTime.Now.Minute + ": " + item.CdProduto.ToString();
                    if (item.Embalagem != "UN")
                    {
                        DataCodigoInterno += " [" + item.CodigoBarra + "]";
                    }


                    string valorpreco = item.ValorPreco.ToString("0.00");
                    if (valorpreco.Length == 3) valorpreco = "   " + valorpreco;
                    if (valorpreco.Length == 4) valorpreco = "  " + valorpreco;
                    if (valorpreco.Length == 5) valorpreco = " " + valorpreco;




                    if (DescricaoProdutoEtiqueta.TrimEnd().Length < 25)
                    {
                        command += "^XA" + crlf +
                            "^XA" + crlf +
                            "^MMT" + crlf +
                            "^PW863" + crlf +
                            "^LL0240" + crlf +
                            "^LS0" + crlf +
                                    "^cf0,55" + crlf +
                                    "^FO45,20" + crlf +
                                    "^FD" + DescricaoProdutoEtiqueta.TrimEnd() + "^FS" + crlf;
                    }

                    if (DescricaoProdutoEtiqueta.TrimEnd().Length >= 25)
                    {
                        command += "^XA" + crlf +
                                    "^MMT" + crlf +
                                    "^PW863" + crlf +
                                    "^LL0240" + crlf +
                                    "^LS0" + crlf +
                                    "^cf0,45" + crlf +
                                    "^FO45,20" + crlf +
                                    "^FD" + DescricaoProdutoEtiqueta.TrimEnd() + "^FS" + crlf;
                    }


                    command +=
                               "^cf0,15" + crlf +
                               "^FO630,3" + crlf +
                               "^FD" + DataCodigoInterno + "^FS" + crlf;


                    /*      18/02/2022 #22227
                     *      item.AtacadoQtdePromocional == 0 ->>> item.AtacadoQtdePromocional == 0.00    
                     * 
                     */

                    if (item.AtacadoQtdePromocional == 0.0 || item.Embalagem != "UN")
                    {
                        if (item.AtacadoEmbalagem.Trim() != "")
                        {
                            double VlUnitario = Math.Round(item.AtacadoValorPreco / item.AtacadoQtdeMinima, 2);
                            command +=
                                "^cf0,30" + crlf +
                                "^FO45,80" + crlf +
                                "^FDATACADO: ^FS" + crlf +
                                "^cf0,25" + crlf +
                                    "^FO45,86" + crlf +
                                "^FD____________________^FS" + crlf +

                                "^cf0,25" + crlf +
                                    "^FO180,85" + crlf +
                                "^FD" + AtacadoDescricaoTipoEmbalagem + item.AtacadoQtdeMinima.ToString("0") + "^FS" + crlf +
                                  "^cf0,45" + crlf +
                                  "^FO45,135" + crlf +
                                  "^FD" + VlUnitario.ToString("0.00") + "^FS" + crlf +
                                      "^cf0,20" + crlf +
                                    "^FO45,115" +
                                    "^FDUnd^FS" + crlf +
                                    "^cf0,25" + crlf +
                                    "^FO160,115" +
                                    "^FDTotal^FS" + crlf +
                                    "^cf0,35" + crlf +
                                    "^FO160,135" +
                                    "^FD" + item.AtacadoValorPreco.ToString("0.00") + "^FS" + crlf;
                        }

                        if (CodigoBarraEtiqueta != "")
                        {
                            command += "^FO170,185" + crlf + // De "^FO270,185" -> "^FO170,185" #26918
                                       "^BEN,15,Y,N" + crlf +
                                       "^FD" + CodigoBarraEtiqueta + "^FS" + crlf;
                        }

                        command += "^cf0,45" + crlf +
                                   "^FO450,70" + crlf +
                                   "^FD" + DescricaoTipoEmbalagem + "^FS" + crlf +
                                   "^cf0,30" + crlf +
                                   "^FO450,120" + crlf +
                                   "^FDR$^FS" + crlf +
                                   "^cf0,120" + crlf +
                                   "^FO500,115" + crlf +
                                   "^FD" + valorpreco + "^FS" + crlf +
                                   "^FO450,105" + crlf +
                                   "^GB380,0,5" + crlf +
                                   "^XZ";
                    }

                    else
                    {

                        //double VlUnitario = Math.Round(item.AtacadoValorPreco / item.AtacadoQtdeMinima, 2);
                        command += "^cf0,45" + crlf +
                                   "^FO30,80" + crlf +
                                   "^FD" + DescricaoTipoEmbalagem + "^FS" + crlf +
                                   "^FO30,85" + crlf +
                                   "^FD___________^FS" + crlf +

                                   "^cf0,30" + crlf +
                                   "^FO30,133" + crlf +
                                   "^FDR$^FS" + crlf +
                                   "^cf0,100" + crlf +
                                   "^FO100,133" + crlf +
                                   "^FD" + Convert.ToDouble(valorpreco).ToString("0.00") + "^FS" + crlf +



                                   "^cf0,40" + crlf +
                                   "^FO500,70" + crlf +
                                   "^FD*A partir de:" + "^FS" + crlf +

                                   "^cf0,39" + crlf +
                                   "^FO715,65" + crlf +
                                   "^FD" + item.AtacadoQtdePromocional.ToString("000").Trim() + "^FS" + crlf +

                                   "^cf0,26" + crlf +
                                   "^FO715,100" + crlf +
                                   "^FDUnds^FS" + crlf +

                                   "^cf0,40" + crlf +
                                   "^FO500,85" + crlf +
                                   "^FD________________^FS" + crlf +
                                   "^cf0,30" + crlf +
                                   "^FO500,135" + crlf +
                                   "^FDR$^FS" + crlf +
                                   "^cf0,70" + crlf +
                                   "^FO650,135" + crlf +
                                   "^FD" + Convert.ToDouble(item.ValorPromocional).ToString("0.00") + "^FS" + crlf;

                        if (CodigoBarraEtiqueta != "")
                        {
                            command += "^FO400,180" + crlf +
                                       "^BEN,15,Y,N" + crlf +
                                       "^FD" + CodigoBarraEtiqueta + "^FS" + crlf;
                        }

                        command += "^XZ";



                        /*
                        double VlUnitario = Math.Round(item.AtacadoValorPreco / item.AtacadoQtdeMinima, 2);
                        command +=
                            "^cf0,45" + crlf +
                            "^F450,500" + crlf +
                            "^FDA PARTIR DE: ^FS" + crlf +
                            "^cf0,25" + crlf +
                            "^F450,600" + crlf +
                            "^FD____________________^FS" + crlf;
                            /*
                            "^cf0,25" + crlf +
                                "^F180,200" + crlf +
                            "^FD" + item.AtacadoQtdePromocional.ToString("0") + "^FS" + crlf +
                              "^cf0,45" + crlf +
                              "^F600,300" + crlf +
                              "^FD" + VlUnitario.ToString("0.00") + "^FS" + crlf;
                                  "^cf0,20" + crlf +
                                "^FO45,115" +
                                "^FDUnd^FS" + crlf +
                                "^cf0,25" + crlf +
                                "^FO160,115" +
                                "^FDTotal^FS" + crlf +
                                "^cf0,35" + crlf +
                                "^FO160,135" +
                                "^FD" + item.AtacadoValorPreco.ToString("0.00") + "^FS" + crlf; */
                        command += "^XZ";

                    }

                }


                // Create a buffer with the command
                Byte[] buffer = new byte[command.Length];
                buffer = System.Text.Encoding.ASCII.GetBytes(command);

                // Use the CreateFile external func to connect to the LPT1 port
                
                
                SafeFileHandle printer = CreateFile("LPT1:", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                //SafeFileHandle printer = CreateFile(@"X:\Spool\TESTE.TXT", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);

                // Test si imprimant valide
                if (!printer.IsInvalid)
                {

                    // Open the filestream to the lpt1 port and send the command
                    FileStream lpt1 = new FileStream(printer, FileAccess.ReadWrite);
                    lpt1.Write(buffer, 0, buffer.Length);
                    // Close the FileStream connection
                    lpt1.Close();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.
            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;

            // How many characters are in the string?
            // Fix from Nicholas Piasecki:
            // dwCount = szString.Length;
            dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;

            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }

    public static class BalancaMGV_Preco_Consultar
    {

        public static DataTable get(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                return Pag_Net.Bll.R0026_01.Select.get(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public static class BalancaMGV_Preco_Exportar
    {
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect, string _NomeArquivo)
        {
            try
            {
                DataTable LINHAS_DT = Pag_Net.Bll.F0003_Loja.Loja.ArquivoMGV(MyConnect);
                List<string> LINHAS = new List<string>();
                ArrayList LIN = new ArrayList();
                foreach (DataRow i in LINHAS_DT.Rows)
                {
                    LIN.Add(i["linha"].ToString());
                    // LogFile.Write(_NomeArquivo, "", null, FileMode.OpenOrCreate, FileAccess.ReadWrite, i["linha"].ToString(), Encoding.Default);
                }
                LogFile.Write(_NomeArquivo, "", LIN, FileMode.Create, FileAccess.ReadWrite, Encoding.Default);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

namespace Pag_Net.Bll.Loja.Db
{
    public class Etiqueta
    {


        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string Embalagem { get; set; }
        public string EmbalagemDescricao { get; set; }
        public double ValorPreco { get; set; }
        public double ValorPromocional { get; set; }
        public string CodigoBarra { get; set; }
        public string TipoCodigoBarra { get; set; }
        public string AtacadoEmbalagem { get; set; }
        public double AtacadoValorPreco { get; set; }
        public double AtacadoQtdeMinima { get; set; }
        public double AtacadoQtdePromocional { get; set; }
        public string AtacadoCodigoBarra { get; set; }
        public bool ImpressaoPadrao { get; set; }

        public Etiqueta() { }
        public Etiqueta(
                 int _CdProduto
            , string _Descricao
            , string _Embalagem
            , string _EmbalagemDescricao
            , double _ValorPreco
            , string _CodigoBarra
            , string _TipoCodigoBarra
            , string _AtacadoEmbalagem
            , double _AtacadoValorPreco
            , double _AtacadoQtdeMinima
            , double _AtacadoQtdePromocional
            , string _AtacadoCodigoBarra
            , bool _ImpressaoPadrao
            )
        {

            CdProduto = _CdProduto;
            Descricao = _Descricao;
            Embalagem = _Embalagem;
            EmbalagemDescricao = _EmbalagemDescricao;
            ValorPreco = _ValorPreco;
            CodigoBarra = _CodigoBarra;
            TipoCodigoBarra = _TipoCodigoBarra;
            AtacadoEmbalagem = _AtacadoEmbalagem;
            AtacadoValorPreco = _AtacadoValorPreco;
            AtacadoQtdeMinima = _AtacadoQtdeMinima;
            AtacadoQtdePromocional = _AtacadoQtdePromocional;
            AtacadoCodigoBarra = _AtacadoCodigoBarra;
            ImpressaoPadrao = _ImpressaoPadrao;






        }

    }
}