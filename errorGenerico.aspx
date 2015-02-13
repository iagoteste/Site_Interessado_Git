<%@ Page Title="" Language="C#" MasterPageFile="~/ficha/Interessado.Master" AutoEventWireup="true" CodeBehind="errorGenerico.aspx.cs" Inherits="Site_Interessado.errorGenerico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/ErroeConfirma.css" rel="stylesheet" />
    <link href="Styles/restrito_base.css" rel="stylesheet" />
    <link href="Styles/fichas.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Corpo" runat="server">
    <div id="MsgConfirma">
    Parece que a pagina que você estava tentando acessar .<br />
    não esta mais aqui.<br />
    :(
    <br /><br />
    <a href="http://www.strong.com.br"><input type="submit" name="btnokconf" value="Pagina Inicial" id="btnokconf" class="btnokconf"></a>

</div>
</asp:Content>
