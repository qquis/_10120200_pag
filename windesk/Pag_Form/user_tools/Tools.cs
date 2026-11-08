using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Pag_Form
{
    public static class UserTools
    {

        public enum PagTipoMessageBox {
            Info = 0, 
            Error = 1,
            Atencao = 3,
            Inclusao = 4, 
            Atualizacao = 5

        }

        public enum PagButtonsIcons
        {
            
            Atualiza = 1, 
            Efetiva_Seleciona = 2, 
            Detalhe = 3, 
            Novo = 4, 
            CancelUndo = 5,
            DeleteError = 6,
            Editar = 7,
            Localizar = 8,
            SetaSimples_Direita = 15,
            SetaSimpels_Esquerda = 16, 
            SetaSimples_Baixo = 17, 
            SetaSimples_Cima = 18,
            SetaDupla_Direita = 19,
            SetaDupla_Esquerda = 20,
            SetaDupla_Baixo = 21,
            SetaDupla_Cima = 22,
            _Default_Sair = 100,
            _Default_Valor = 101,
            _Default_Imprimir = 102,
            X_ICO_CMD_SERVICO_CTRL  = 1001,
            Valor = 200,
        }
        public static void _Screen_FormICON(System.Windows.Forms.Form MyFORM)
        {

        }

        public static void _Screen_MenuItem(System.Windows.Forms.ToolStripMenuItem MyButton, PagButtonsIcons Icon)
        {
            try
            {
                switch (Icon)
                {

                    case PagButtonsIcons.Detalhe:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
                        break;
                    case PagButtonsIcons.Localizar:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\find.ico");
                        break;
                    case PagButtonsIcons.Editar:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\edit.ico");
                        break;
                    case PagButtonsIcons.Atualiza:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
                        break;
                    case PagButtonsIcons.Efetiva_Seleciona:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
                        break;
                    case PagButtonsIcons.Novo:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\novo.ico");
                        break;
                    case PagButtonsIcons.CancelUndo:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\undo.ico");
                        break;
                    case PagButtonsIcons.DeleteError:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\delete.ico");
                        break;
                    case PagButtonsIcons.SetaSimples_Direita:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\direita.ico");
                        break;
                    case PagButtonsIcons.SetaSimpels_Esquerda:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                        break;
                    case PagButtonsIcons.SetaSimples_Cima:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\cima.ico");
                        break;
                    case PagButtonsIcons.SetaSimples_Baixo:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                        break;
                    case PagButtonsIcons.SetaDupla_Direita:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\direita_dupla.ico");
                        break;
                    case PagButtonsIcons.SetaDupla_Esquerda:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda_dupla.ico");
                        break;
                    case PagButtonsIcons.SetaDupla_Cima:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\cima_dupla.ico");
                        break;
                    case PagButtonsIcons.SetaDupla_Baixo:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo_dupla.ico");
                        break;
                    case PagButtonsIcons._Default_Sair:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                        break;
                    case PagButtonsIcons._Default_Valor:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\valort.ico");
                        break;
                    case PagButtonsIcons._Default_Imprimir:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\print.ico");
                        break;
                    case PagButtonsIcons.X_ICO_CMD_SERVICO_CTRL:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ICO_CMD_SERVICO_CTRL.ico");
                        break;
                    case PagButtonsIcons.Valor:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\valort.ico");
                        break;

                }
            }
            catch (Exception ex)
            {
                MyButton.Image = null;
                throw new Exception(ex.Message);

            }

        }
        public static void _Screen_ButtonImage(System.Windows.Forms.Button MyButton, PagButtonsIcons Icon)
        {
            try
            {
                switch (Icon)
                {

                    case PagButtonsIcons.Detalhe:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
                        break;
                    case PagButtonsIcons.Localizar:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\find.ico");
                        break;
                    case PagButtonsIcons.Editar:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\edit.ico");
                        break;
                    case PagButtonsIcons.Atualiza:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
                        break;
                    case PagButtonsIcons.Efetiva_Seleciona:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
                        break;
                    case PagButtonsIcons.Novo:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\novo.ico");
                        break;
                    case PagButtonsIcons.CancelUndo:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\undo.ico");
                        break;
                    case PagButtonsIcons.DeleteError:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\delete.ico");
                        break;
                    case PagButtonsIcons.SetaSimples_Direita:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\direita.ico");
                        break;
                    case PagButtonsIcons.SetaSimpels_Esquerda:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                        break;
                    case PagButtonsIcons.SetaSimples_Cima:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\cima.ico");
                        break;
                    case PagButtonsIcons.SetaSimples_Baixo:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                        break;
                    case PagButtonsIcons.SetaDupla_Direita:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\direita_dupla.ico");
                        break;
                    case PagButtonsIcons.SetaDupla_Esquerda:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda_dupla.ico");
                        break;
                    case PagButtonsIcons.SetaDupla_Cima:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\cima_dupla.ico");
                        break;
                    case PagButtonsIcons.SetaDupla_Baixo:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo_dupla.ico");
                        break;
                    case PagButtonsIcons._Default_Sair: 
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                        break;
                    case PagButtonsIcons._Default_Valor:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\valort.ico");
                        break;
                    case PagButtonsIcons._Default_Imprimir:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\print.ico");
                        break;
                    case PagButtonsIcons.X_ICO_CMD_SERVICO_CTRL:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ICO_CMD_SERVICO_CTRL.ico");
                        break;
                    case PagButtonsIcons.Valor:
                        MyButton.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\valort.ico");
                        break;

                }
            }
            catch (Exception ex)
            {
                MyButton.Image = null;
                throw new Exception(ex.Message);
               
            }
        }
        public static void _Screen_Wait(System.Windows.Forms.Form MyFORM)
        {
            if (MyFORM.Cursor == System.Windows.Forms.Cursors.WaitCursor)
                _Screen_Wait(MyFORM, false);
            else
                _Screen_Wait(MyFORM, true);
        }
        public static void _Screen_Wait(System.Windows.Forms.Form MyFORM, System.Windows.Forms.Button MyButton, bool ON)
        {
            if (ON)
            {
                MyButton.Enabled = false;
                MyFORM.Refresh();
                _Screen_Wait(MyFORM, ON);
            }
            else
            {
                MyButton.Enabled = true ;
                MyFORM.Refresh();
                _Screen_Wait(MyFORM, ON);
            }
        }
        public static void _Screen_Wait(System.Windows.Forms.Form MyFORM, bool ON)
        {
            if (ON)
            {
                MyFORM.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (findObectInForm(MyFORM, "lblwait") != null)
                    findObectInForm(MyFORM, "lblwait").Visible = true;
                MyFORM.Refresh();
                MyFORM.Refresh();
                MyFORM.Refresh();
                MyFORM.Refresh();
                MyFORM.Refresh();
                
            }
            else
            {
                MyFORM.Cursor = System.Windows.Forms.Cursors.Arrow;
                if (findObectInForm(MyFORM, "lblwait") != null)
                findObectInForm(MyFORM, "lblwait").Visible = false; 
                MyFORM.Refresh();
                MyFORM.Refresh();
                MyFORM.Refresh();
                MyFORM.Refresh();
                
            }
        }
        public static void _Screen_Wait(System.Windows.Forms.UserControl MyFORM, System.Windows.Forms.Button MyButton, bool ON )
        {
            if (ON)
            {
                MyButton.Enabled = false;
                _Screen_Wait(MyFORM, ON);

    
            }
            else
            {
                MyButton.Enabled = true;
                _Screen_Wait(MyFORM, ON);
            }
        }
        public static void _Screen_Wait(System.Windows.Forms.UserControl MyFORM, bool ON)
        {
            if (ON)
            {
                MyFORM.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                MyFORM.Refresh();
            }
            else
            {
                MyFORM.Cursor = System.Windows.Forms.Cursors.Arrow;
                MyFORM.Refresh();
            }
        }
        public static void _Screen_MessageBox(System.Windows.Forms.Form MyFORM, PagTipoMessageBox TipoMessage)
        {
            _Screen_MessageBox(MyFORM, TipoMessage, "", null);
        }
        public static void _Screen_MessageBox(System.Windows.Forms.Form MyFORM, string Message)
        {
            _Screen_MessageBox(MyFORM, PagTipoMessageBox.Info, Message, null);
        }
        public static void _Screen_MessageBox(System.Windows.Forms.Form MyFORM, PagTipoMessageBox TipoMessage, Exception ex)
        {
            _Screen_MessageBox(MyFORM, TipoMessage, "", ex);
        }        
        public static void _Screen_MessageBox(System.Windows.Forms.Form MyFORM, PagTipoMessageBox TipoMessage, string Message)
        {
            _Screen_MessageBox(MyFORM, TipoMessage, Message, null);
        }
        public static void _Screen_MessageBox(System.Windows.Forms.Form MyFORM, Exception ex)
        {
            switch (ex.HelpLink)
            {
                case "E":
                    _Screen_MessageBox(MyFORM, PagTipoMessageBox.Error, "Erro", ex);
                    break;
                case "A":
                    _Screen_MessageBox(MyFORM, PagTipoMessageBox.Atencao, ex.Message);
                    break;
                default:
                    _Screen_MessageBox(MyFORM, PagTipoMessageBox.Error, "Erro", ex);
                    break;
            }
        }
        public static void _Screen_MessageBox(System.Windows.Forms.Form MyFORM, PagTipoMessageBox TipoMessage, string Message, Exception ex)
        {
            _Screen_Wait(MyFORM, false);
            switch (TipoMessage)
            {
                case PagTipoMessageBox.Inclusao:
                    _Screen_Wait(MyFORM, false);
                    System.Windows.Forms.MessageBox.Show("Inclusão Realizada com Sucesso!", "Pag | " + MyFORM.Name.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    break;
                case PagTipoMessageBox.Atualizacao:
                    _Screen_Wait(MyFORM, false);
                    System.Windows.Forms.MessageBox.Show("Atualização Realizada com Sucesso!", "Pag | " + MyFORM.Name.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    break;
                case PagTipoMessageBox.Info:
                    System.Windows.Forms.MessageBox.Show(Message, "Pag | " + MyFORM.Name.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        break;
                case PagTipoMessageBox.Error:
                        if (Message == null) Message = "Erro: ";
                        if (Message == "") Message = "Erro: ";

                        string ERROR_MESSAGE = "";
                        if (ex != null) ERROR_MESSAGE = ex.Message;
                        System.Windows.Forms.MessageBox.Show(Message 
                                                            + '\n'
                                                            + '\n'
                                                            + '\n'
                                                            + '\n' 
                                                            + "Mensagem do Erro" + "\n" + "-------------------------------------------------------------------" 
                                                            + "\n" 
                                                            + ERROR_MESSAGE, "Pag | " + MyFORM.Name, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    break;
                case PagTipoMessageBox.Atencao:
                    System.Windows.Forms.MessageBox.Show(Message, "Pag | " + MyFORM.Name.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                        break;
            }
            
        }
        public static bool _Screen_MessageBox_OkCancel(System.Windows.Forms.Form MyFORM, string Message)
        {
            bool ResultConfirm = false ;
            if ( System.Windows.Forms.MessageBox.Show(Message,"Pag | " + MyFORM.Name.ToString(),System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question ) == System.Windows.Forms.DialogResult.Yes )
            {
                ResultConfirm = true;
            }
            return ResultConfirm;
        }
        public static void _Screen_DataBinding_Set_FromDataGrid(System.Windows.Forms.Form MyFORM, System.Windows.Forms.DataGridView DataGrid)
        {
            foreach (object i in MyFORM.Controls)
            {

                UserTools._Screen_DataBinding_Set(i, DataGrid.DataSource, "");
            }
        }
        public static void _Screen_DataBinding_Set(object _Object, object _DataSource, string _DataMember)
        {
            _Screen_DataBinding_Set(_Object, "Text", _DataSource, _DataMember);
        }
        public static void _Screen_DataBinding_Set(object _Object, string _Propriedade, object _DataSource, string _DataMember)
        {
            try
            {
                if (_Object.GetType().Name == "Label")
                {
                    ((Label)_Object).DataBindings.Clear();
                    if (((Label)_Object).Tag != null)
                    {
                        if (((Label)_Object).Tag.ToString() != "")
                        {
                            ((Label)_Object).Text = "";
                            ((Label)_Object).DataBindings.Add(_Propriedade, _DataSource, ((Label)_Object).Tag.ToString());
                        }
                    }
                    else
                    {
                        if (((Label)_Object).Name.Substring(0, 4) == "lbl_")
                        {
                            ((Label)_Object).Text = "";
                            ((Label)_Object).DataBindings.Add(_Propriedade, _DataSource, ((Label)_Object).Name.Substring(4));
                        }
                    }
                }
                
                if (_Object.GetType().Name == "TextBox")
                {
                    ((TextBox)_Object).DataBindings.Clear();
                    if (((TextBox)_Object).Tag != null)
                    {
                        if (((TextBox)_Object).Tag.ToString() != "")
                        {
                            ((TextBox)_Object).Text = "";
                            ((TextBox)_Object).DataBindings.Add(_Propriedade, _DataSource, ((TextBox)_Object).Tag.ToString());

                        }
                    }
                    else
                    {
                        if (((TextBox)_Object).Name.Substring(0, 4) == "txt_")
                        {
                            ((TextBox)_Object).Text = "";
                            ((TextBox)_Object).DataBindings.Add(_Propriedade, _DataSource, ((TextBox)_Object).Name.Substring(4));
                        }
                    }
                }

                if (_Object.GetType().Name == "ComboBox")
                {
                    ((ComboBox)_Object).DataBindings.Clear();
                    if (((ComboBox)_Object).Tag != null)
                    {
                        if (((ComboBox)_Object).Tag.ToString() != "")
                        {
                            ((ComboBox)_Object).Text = "";
                            ((ComboBox)_Object).DataBindings.Add(_Propriedade, _DataSource, ((ComboBox)_Object).Tag.ToString());

                        }
                    }
                    else
                    {
                        if (((ComboBox)_Object).Name.Substring(0, 4) == "cmb_")
                        {
                            ((ComboBox)_Object).Text = "";
                            ((ComboBox)_Object).DataBindings.Add(_Propriedade, _DataSource, ((ComboBox)_Object).Name.Substring(4));
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void _Screen_Form_Open(System.Windows.Forms.Form MyFORM)
        {
            foreach (object i in MyFORM.Controls)
            {

                if (i.GetType().Name == "Label")
                    if (((System.Windows.Forms.Label)i).Name == "lblwait")
                        ((System.Windows.Forms.Label)i).Visible = false;


                if (i.GetType().Name == "DataGridView")
                    _Screen_Form_Format_DataGridView(((System.Windows.Forms.DataGridView)i));




                if (i.GetType().Name == "Button")
                {
                    if ( ((System.Windows.Forms.Button)i).Name == "cmdsair")
                    {
                        ((System.Windows.Forms.Button)i).Text = "Sair";
                        UserTools._Screen_ButtonImage(((System.Windows.Forms.Button)i), UserTools.PagButtonsIcons.SetaSimples_Direita);
                    }

                    if (((System.Windows.Forms.Button)i).Name.ToUpper() == "CMDNOVO")
                    {
                        ((System.Windows.Forms.Button)i).Text = "Novo";
                        UserTools._Screen_ButtonImage(((System.Windows.Forms.Button)i), UserTools.PagButtonsIcons.Novo);
                    }

                    if (((System.Windows.Forms.Button)i).Name.ToUpper() == "CMDEFETIVAR" || ((System.Windows.Forms.Button)i).Name.ToUpper() == "CMDEFETIVA")
                    {
                        ((System.Windows.Forms.Button)i).Text = "Efetivar";
                        UserTools._Screen_ButtonImage(((System.Windows.Forms.Button)i), UserTools.PagButtonsIcons.Efetiva_Seleciona);
                    }
                    if (((System.Windows.Forms.Button)i).Name.ToUpper() == "CMDIMPRIMIR" || ((System.Windows.Forms.Button)i).Name.ToUpper() == "CMDEFETIVA")
                    {
                        ((System.Windows.Forms.Button)i).Text = "Imprimir";
                        UserTools._Screen_ButtonImage(((System.Windows.Forms.Button)i), UserTools.PagButtonsIcons.Efetiva_Seleciona);
                    }

     
                }

            }


        }
        public static void _Screen_Form_Format_DataGridView(System.Windows.Forms.DataGridView DataGrid)
        {
            _Screen_Form_Format_DataGridView(DataGrid, false);
        }
        public static void _Screen_Form_Format_DataGridView(System.Windows.Forms.DataGridView DataGrid, bool AutoGenerateColumns)
        {
            DataGrid.AutoGenerateColumns = AutoGenerateColumns;
        }
        public static void _Delay(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
        public static string _Screen_Sender_getName(object sender)
        {
            string NameObject = "";
            if (sender.GetType().Name == "Label") NameObject = ((Label)sender).Name;
            if (sender.GetType().Name == "TextBox") NameObject = ((TextBox)sender).Name;
            if (sender.GetType().Name == "DateTimePicker") NameObject = ((DateTimePicker)sender).Name;
            if (sender.GetType().Name == "CheckBox") NameObject = ((CheckBox)sender).Name;
            if (sender.GetType().Name == "ComboBox") NameObject = ((ComboBox)sender).Name;
            if (sender.GetType().Name == "TabControl") NameObject = ((TabControl)sender).Name;
            return NameObject;
        }
        public static void _Screen_ComboBox_Select_Item(System.Windows.Forms.ComboBox MyComboBox, string itemDisplayMember)
        {

            for (int i = 0; i <= MyComboBox.Items.Count -1; i++)
            {
                MyComboBox.SelectedIndex = i;
                string vltext = MyComboBox.Text;

                if (vltext == itemDisplayMember)
                {
                    MyComboBox.SelectedIndex = i;
                    return;
                }
            }
        }

        private static Control findObectInForm(System.Windows.Forms.Form MyFORM, string nomeObjeto)
        {
            Control localizou = null;
            try
            {

                foreach (Control control in MyFORM.Controls)
                {
                    if (control is Label && control.Name == nomeObjeto)
                    {
                        localizou = control;
                        break;
                    }
                }

                return localizou;
            }
            catch (Exception ex)
            {
                return localizou;
            }
        }
        

    }
}
