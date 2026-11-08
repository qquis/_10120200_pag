using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;


namespace Pag_Net.Bll.Operacionais.Varejo.Execucao
{

    public class EtiquetaGondola
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

        private Pag_Net.Models.modelSistemaUsuario _MyConnect;


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        public EtiquetaGondola(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            _MyConnect = __myConnect;
            List = new UspEtiquetaGondola(_MyConnect);
            Complementos = new Cadastros.ProdutosComplementos(_MyConnect);
        }
        
        public static void Imprimir(UVWEtiquetaGondola[] __etiquetas)
        {
            try
            {
                string crlf = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
                string command = "CT~~CD,~CC^~CT~" + crlf;
                command += "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3~SD15^JUS^LRN^CI0^XZ" + crlf;

                foreach (UVWEtiquetaGondola item in __etiquetas)
                {
                    string DescricaoProtudoEtiqueta = item.Descricao;
                    string DescricaoTipoEmbalagem = "UNIDADE";


                    switch (item.Embalagem)
                    {
                        case "UN":
                            DescricaoProtudoEtiqueta = item.Descricao;
                            DescricaoTipoEmbalagem = "UNIDADE";
                            break;

                        case "BD":
                            DescricaoProtudoEtiqueta = item.EmbalagemDescricao;
                            DescricaoTipoEmbalagem = "BANDEJA";
                            break;

                        default:
                            DescricaoProtudoEtiqueta = item.EmbalagemDescricao;
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
                        DataCodigoInterno +=  " [" + item.CodigoBarra + "]";
                    }


                    string valorpreco = item.ValorPreco.ToString("0.00");
                    if (valorpreco.Length == 3) valorpreco = "   " + valorpreco;
                    if (valorpreco.Length == 4) valorpreco = "  " + valorpreco;
                    if (valorpreco.Length == 5) valorpreco = " " + valorpreco;


                    

                    if (DescricaoProtudoEtiqueta.TrimEnd().Length < 25)
                    {
                        command += "^XA" + crlf +
                            "^XA" + crlf +
                            "^MMT" + crlf +
                            "^PW863" + crlf +
                            "^LL0240" + crlf +
                            "^LS0" + crlf +
                                    "^cf0,55" + crlf +
                                    "^FO45,20" + crlf +
                                    "^FD" + DescricaoProtudoEtiqueta.TrimEnd() + "^FS" + crlf;
                    }

                    if (DescricaoProtudoEtiqueta.TrimEnd().Length >= 25 )
                    {
                        command += "^XA" + crlf +
                                    "^MMT" + crlf +
                                    "^PW863" + crlf +
                                    "^LL0240" + crlf +
                                    "^LS0" + crlf +
                                    "^cf0,45" + crlf +
                                    "^FO45,20" + crlf +
                                    "^FD" + DescricaoProtudoEtiqueta.TrimEnd() + "^FS" + crlf;
                    }


                    command +=
                               "^cf0,15" + crlf +
                               "^FO630,3" + crlf +
                               "^FD" + DataCodigoInterno + "^FS" + crlf;

                    if (item.AtacadoQtdePromocional == 0 || item.Embalagem != "UN")
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
                            command += "^FO270,185" + crlf +
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

                        double VlUnitario = Math.Round(item.AtacadoValorPreco / item.AtacadoQtdeMinima, 2);
                        command += "^cf0,45" + crlf +
                                   "^FO30,80" + crlf +
                                   "^FD" + DescricaoTipoEmbalagem + "^FS" + crlf +
                                   "^FO30,85" + crlf +
                                   "^FD________________^FS" + crlf +

                                   "^cf0,30" + crlf +
                                   "^FO30,120" + crlf +
                                   "^FDR$^FS" + crlf +
                                   "^cf0,115" + crlf +
                                   "^FO100,120" + crlf +
                                   "^FD" + Convert.ToDouble(valorpreco).ToString("0.00") + "^FS" + crlf +



                                   "^cf0,40" + crlf +
                                   "^FO500,70" + crlf +
                                   "^FD*A partir de:" + "^FS" + crlf +

                                   "^cf0,50" + crlf +
                                   "^FO705,50" + crlf +
                                   "^FD" + item.AtacadoQtdePromocional.ToString("000").Trim() + "^FS" + crlf +

                                   "^cf0,25" + crlf +
                                   "^FO715,100" + crlf +
                                   "^FDUnds^FS" + crlf +

                                   "^cf0,40" + crlf +
                                   "^FO500,85" + crlf +
                                   "^FD________________^FS" + crlf +
                                   "^cf0,30" + crlf +
                                   "^FO500,135" + crlf +
                                   "^FDR$^FS" + crlf +
                                   "^cf0,90" + crlf +
                                   "^FO550,135" + crlf +
                                   "^FD" + Convert.ToDouble( VlUnitario).ToString("0.00") + "^FS" + crlf;

                        if (CodigoBarraEtiqueta != "")
                        {
                            command += "^FO630,215" + crlf +
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
                //SafeFileHandle printer = CreateFile("e:\\back\\TESTE.TXT", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);

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
    
}
