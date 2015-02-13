<%@ Page Title="" Language="C#" MasterPageFile="~/ficha/Interessado.Master" AutoEventWireup="true" CodeBehind="confirma.aspx.cs" Inherits="Site_Interessado.confirma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/ErroeConfirma.css" rel="stylesheet" />
    <link href="Styles/restrito_base.css" rel="stylesheet" />
    <link href="Styles/fichas.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Corpo" runat="server">
<div id="MsgConfirma">
    <%=fulano%> obrigado!<br />
    Você receberá em seu e-mail uma mensagem com os valores do curso<br />
    
    <br /><br />
</div>
    <form align="center" runat ="server">
        <p class="botao">
            <asp:Button ID="Confirmado" runat="server" Text="Confirmado" class="btnokconf" align="Center" OnClick="btnokconf_Click" />
        </p>

        <p class="botao">
            <asp:Button ID="ImprimirBoleto" runat="server" Text="Imprimir Boleto" class="btnokconf" align="Center" OnClick="ImprimirBoleto_Click" />
        </p>
    </form>
</asp:Content>
