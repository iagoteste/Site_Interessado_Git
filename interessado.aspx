<%@ Page Title="" Language="C#" MasterPageFile="~/ficha/Interessado.Master" AutoEventWireup="true" CodeBehind="interessado.aspx.cs" Inherits="Site_Interessado.interessado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="styles/fichas.css" rel="stylesheet" type="text/css" />
    <link href="Styles/restrito_base.css" rel="stylesheet" />
    <link href="Styles/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/formatadigitacao.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Corpo" runat="server">

      <div id="ficha">
    
   <form id="Form1" runat="server">

		<div id="lblErro" style="display:none;" runat="server">
			<asp:label id="lMensagem" runat="server"></asp:Label>
		</div>

		<h3 style="font-size: 23px;font-family:'Arial Narrow';color: rgb(12, 132, 160);margin-top: 10px;margin-bottom: 6px;">Interessado em:</h3>
       <div id="infos">
        <asp:Label ID="lb1" runat="server"> Curso: </asp:Label>
        <asp:Label ID="l1" runat="server" class="bold" style="font-weight: bold;"></asp:Label>
        <asp:Label ID="lb2" runat="server" > Unidade: </asp:Label>
        <asp:Label ID="l2" runat="server" class="bold"  style="font-weight: bold;"> </asp:Label>
        <p style="margin: 1px 0px 18px 0px;">Antes de prosseguir, gostaríamos de conhecer um pouco mais sobre você.</p>
       </div>
		
            <div class="row" id="PessoaisUm">
                <div  class="col-xs-12 col-md-4" id="divNome"> 
                    <div class="form-group" id="div2Nome">
                        <asp:Label ID="lblRealname" runat="server" class="bold">Nome completo:</asp:Label>
                        <asp:TextBox ID="realname" style="width: 330px;" runat="server" size="60" maxlength="70" class="form-control" placeholder="Nome Completo" ></asp:TextBox>
                    </div>
                </div>    
            </div>

            <div class="row" id="PessoaisDois">
                <div  class="col-xs-12 col-md-4" >
                    <div class="input-group">
                        <div class="input-group-addon">@</div>
                        <asp:TextBox ID="EMail" style="width:291px;" runat="server" maxlength="70" size="60" placeholder="E-mail" class="form-control" ></asp:TextBox>     
                    </div>
                </div>
            </div>

            <div class="row" id="PessoaisTres">
                <div  class="col-xs-3 col-md-1" id="divDDD"> 
                    <div class="form-group" id="div2DDD">
                        <asp:Label ID="Label4" runat="server" class="bold" >Telefone:</asp:Label>
                        <asp:TextBox ID="DDD" runat="server" size="3" maxlength="3" class="form-control" placeholder="DDD" onKeypress="return so_numeros(event)" ></asp:TextBox>
                        
                    </div>
                </div>
                <div  class="col-xs-9 col-md-2" id="divTelefone" > 
                    <div class="form-group" id="div2Telefone">
                        
                        <asp:TextBox ID="TEL" runat="server" style="width:175px;" size="20" maxlength="9" class="form-control" placeholder="Telefone" onKeypress="return so_numeros(event)"></asp:TextBox>                        
                    </div>
                </div> 
            </div>

            <div class="row" id="PessoaisQuatro">
                <div class="col-xs-6 col-md-2" id="divSexo"> 
                    <div class="form-group" id="div2Sexo">
                        <asp:Label ID="lblSexo" runat="server" class="bold">Sexo:</asp:Label>
                        <asp:DropDownList ID="sexo" runat="server" class="form-control">
                                <asp:ListItem Value="Selecione"></asp:ListItem>
                                <asp:ListItem Value="Masculino"></asp:ListItem>
                                <asp:ListItem Value="Feminino"></asp:ListItem>
                        </asp:DropDownList>	      
                    </div>  
                </div>
           
                <div class="col-xs-6 col-md-2" id="divNasc"> 
                    <div class="form-group" id="div2Nasc">
                        <asp:Label ID="lblData_nascimento" runat="server" class="bold">Data de Nascimento:</asp:Label>
                        <asp:TextBox ID="Data_Nascimento" runat="server" maxlength="10" class="form-control"  placeholder="Dia/Mes/Ano" onKeyUp="javascript:return MascaraDeData(this.value,this,'/',event);"></asp:TextBox>      
                    </div>  
                </div>
            </div>
                 
            <br>

            <div class="row" id="PessoaisCinco">
                <div class="col-xs-12 col-md-4" id="divComoSoube"> 
                    <div class="form-group" id="div2ComoSoube">
                         <asp:Label ID="Label1" runat="server" class="bold">Como Soube:</asp:Label>
                        <asp:DropDownList ID="dllCOMOSOUBE" style="width:330px;" runat="server" class="form-control">
                        </asp:DropDownList>
                    </div>  
                </div>
            </div>

            <div  class="row" id="divPeriodo"> 
                  <div class="col-xs-12 col-md-4" id="div2Periodo">
                    <asp:Label ID="lblPeriodo" runat="server" class="bold">Período de interesse:</asp:Label><br>
                        <asp:DropDownList ID="Periodo" style="width: 330px;" runat="server" class="form-control">
                            <asp:ListItem Value="--Selecione--"></asp:ListItem>
                            <asp:ListItem Value="2">DIURNO|SÁBADOS</asp:ListItem>
                            <asp:ListItem Value="3">NOTURNO</asp:ListItem>
                            <asp:ListItem Value="1">TODOS</asp:ListItem>
                        </asp:DropDownList>		
                   </div>
                </div> 
            
            <p id="pPergunta"><asp:Label ID="lblPergunta" runat="server" class="bold titulo"></asp:Label></p>
        
            <asp:RadioButtonList ID="rdbRespostas" runat="Server" CssClass="rbl">

            </asp:RadioButtonList>
 

		    <br />
 

		    <p class="botao" id="botao" >
                <asp:Button ID="Button1" style="margin: 9px 0px 0px 0px;" runat="server" Text="Enviar" onclick="Button1_Click" class="btn btn-primary"></asp:Button>
		    </p>
       
  </form>
   </div>    
  
</asp:Content>
