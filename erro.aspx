<%@ Page Title="" Language="C#" MasterPageFile="~/ficha/Interessado.Master" AutoEventWireup="true" CodeBehind="erro.aspx.cs" Inherits="Site_Interessado.erro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/ErroeConfirma.css" rel="stylesheet" />
    <link href="Styles/restrito_base.css" rel="stylesheet" />
    <link href="Styles/fichas.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Corpo" runat="server">
<div id="MsgConfirma">
    Houve um erro ao registrar seu cadastro.<br />
    Por favor tente realizar o cadastro mais tarde.<br />
    Obrigado!
    <br /><br />
    <a href="http://www.strong.com.br"><input type="submit" name="btnokconf" value="Finalizar" id="btnokconf" class="btnokconf"></a>

</div>
</asp:Content>
