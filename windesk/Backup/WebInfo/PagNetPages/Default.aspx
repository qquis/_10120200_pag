<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebInfo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<table style="width: 100%;">
    <tr>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server">Cadastro de Produtos/Estoque</asp:HyperLink>
        </td>
        
        
    </tr>
    <tr>
        
        <td>
            <asp:HyperLink ID="HyperLink2" runat="server">Faturamento</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        
    </tr>
</table>    
</asp:Content>


