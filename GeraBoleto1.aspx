<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeraBoleto1.aspx.cs" Inherits="Site_Interessado.GeraBoleto1" %>

<!doctype html>
<!--[if lt IE 7]> <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang="pt-br"> <![endif]-->
<!--[if IE 7]>    <html class="no-js lt-ie9 lt-ie8" lang="pt-br"> <![endif]-->
<!--[if IE 8]>    <html class="no-js lt-ie9" lang="pt-br"> <![endif]-->
<!--[if IE 9]>    <html class="no-js lt-ie10" lang="pt-br"> <![endif]-->
<!--[if gt IE 9]><!--> <html class="no-js" lang="pt-br"> <!--<![endif]--> 

<head lang="pt-br" runat="server">

	<meta name="viewport" content="width=device-width" />
	<meta name="author" content="Axis Focus - www.axisfocus.com" />
	<meta name="robots" content="index,follow" />
	<meta charset="utf-8" />
	
	<title>Boleto</title>
		
	<!--[if lt IE 9]>
		<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
	
	<link rel="stylesheet" href="~/arquivos/global/css/restrito_base.css" runat="server" />
	<link rel="icon" type="image/png" href="~/arquivos/global/imagens/estrutura/favicon.png" runat="server">
	
	<asp:literal id="headScript" runat="server" />
	
</head>

<body>

<form id="frm1" method="post" class="padrao" runat="server">

	<asp:placeholder id="areaListagem" runat="server" />
	
	<asp:placeholder id="areaBoleto" visible="false" runat="server" >
		
		
		<%=TextoInicialDoBoleto%>
		
		<div id="dvPrint">
			<table width="640" cellspacing="0" cellpadding="0" border="0">  
			<tr><td >&nbsp;</td></tr>
			</table>
			
			<table width="640" cellspacing="0" cellpadding="0" border="0">  
			  <tr>
			    <td colspan= 2> 
			      <hr noshade size=1 width="640">
			      <div align="left"><b><i><font size="2"> </font></i></b></div>
			    </td>
			  </tr>
			</table>
			
			<table width="640" cellspacing="0" cellpadding="0" border="0">
			  <tr>
			    <td width="155"><p align="center"><big><strong><%=sFanBanBol%></strong></big></td>
			    <td width="69" style="border-left: thin solid; border-right: thin solid"><p align="center"><big><strong><%=sNumBanBol%></strong></big></td>
			    <td align="RIGHT" valign="BOTTOM" width="433" nowrap><font face="Arial" size="1" ><b>Recibo do Pagador </b></font></td>
			  </tr>
			</table>
			
			<table width="640" border="1" cellspacing="0" cellpadding="01">
			
			  <tr>
			    <td width="315">
			    <table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Cedente </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="LEFT"><b><font face="Arial" SIZE="1"><%=vNomeDoCedente%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			
			    <td width="90">
			    <table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Num.Docum. </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=vNumInscri%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    
			    <td width="90">
			    <table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Emissão </font></td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=sDataHoje%></font></b></td>
			      </tr>
			    </table>
			    </td>
			    
			    <td width="145">
			    <table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Nosso Número </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="RIGHT"><b><font face="Arial" SIZE="1"><%=sNumBoletoNaFicha%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>			    
			  </tr>
			  
			  <tr>			    
			    <td width="315">
			    <table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Pagador </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="LEFT"><b><font face="Arial" SIZE="1"><%=vNome%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>    
			    
			    <td width="90">
			    <table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Valor </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=vValorInscricao%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    
			    <td width="90">
			    <table border="0" height="100%" width="100%" cellpadding="0"
			    cellspacing="0">
			      <tr>
			        <td height="50%"><font face="Arial" SIZE="1">Vencimento </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=TextoVencimento%>
			        </font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    
			      <td width="145">
			    <table border="0" height="100%" width="100%" cellpadding="0"
			    cellspacing="0">
			      <tr>
			        <td height="50%"><font face="Arial" SIZE="1">Agência/Código Beneficiário</font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="RIGHT" height="50%"><b><font face="Arial" SIZE="1"><%=sTextoCodAgeCed%>
			        </font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			  </tr>			  

			  <tr>			    
			    <td width="640" colspan= 4>
			    <table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td >
                        <font face="Arial" SIZE="1">
                            Ref.: <b><%=vTextoDaReferencia%></b><br>
                            Curso : <%=vNomeDoCurso%> 
                            <br>
                            Local : <%=vNomeDaRegiao%> 
                            <br>
                            Período : <%=sPeriodo%> 
                        </font>
                        <br>
			        </td>
			      </tr>
			    </table>
			    </td>
			  <tr>
			 
			
			    </td>
			  </tr>
			<table width="640" cellspacing="0" cellpadding="0" border="0">  
			<tr>
			    <td colspan= 2> 
			     
			      <div align="left"><b><i><font size="2">&nbsp;&nbsp;&nbsp; </font></i></b></div>
			    </td>
			  </tr>
			<tr>
			    <td colspan= 2> 
			     
			      <div align="left"><b><i><font size="2">&nbsp;&nbsp;&nbsp; </font></i></b></div>
			    </td>
			  </tr>
			
			  <tr>
			    <td colspan= 2> 
			      <hr noshade size=1 width="640">
			      <div align="left"><b><i><font size="2"> </font></i></b></div>
			    </td>
			  </tr>
			</table>          
			
			<table width="640" cellspacing="0" cellpadding="0" border="0">
			  <tr>
			    <td width="155"><p align="center"><big><strong><%=sFanBanBol%></strong></big></td>
			    <td width="69" style="border-left: thin solid; border-right: thin solid"><p align="center"><big><strong><%=sNumBanBol%></strong></big></td>
			    <td align="RIGHT" valign="BOTTOM" width="433" nowrap><font size="3" face="Arial"><tt><b><%=sLinhaDigitada%></b> </tt></font></td>
			  </tr>
			</table>
			
			<table width="640" border="1" cellspacing="0" cellpadding="01">
			  <tr>
			    <td colspan="6"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td valign="top" width="120"><font face="Arial" SIZE="1">Local de Pagamento: </font><br>
			        </td>
			        <td valign="top" width="370"><font size="2" face="Arial"><b>Pagável 
			        em qualquer banco até o vencimento.</b></font></td>
			      </tr>
			    </table>
			    </td>
			    <td width="150"><table border="0" cellspacing="0" cellpadding="0" height="100%"
			    width="100%" border="01">
			      <tr>
			        <td><font face="Arial" size="1">Vencimento </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="RIGHT"><b><font face="Arial" size="3"><%=TextoVencimento%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			  </tr>
			  <tr>
			    <td colspan="6" width="487" valign="top"><table width="100%" border="0" cellspacing="0"
			    cellpadding="0">
			      <tr>
			        <td valign="top"><font face="Arial" SIZE="1">Cedente </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td valign="top"><b><font face="Arial" SIZE="2"> <%=vNomeDoCedente%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td><table width="100%" border="0" cellspacing="1" cellpadding="1">
			      <tr>
			        <td><font face="Arial" SIZE="1">Agência/Código Beneficiário </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="RIGHT"><b><font face="Arial" SIZE="1"><%=sTextoCodAgeCed%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			  </tr>
			  <tr>
			    <td width="130"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Data do documento: </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=sDataHoje%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="120" colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">No. do documento </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=vNumInscri%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="80"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Espécie doc. </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><font face="Arial" size="1"><b>RC</b></font><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="40"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Aceite </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="120"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Data Processamento </font></td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=sDataHoje%></font></b></td>
			      </tr>
			    </table>
			    </td>
			    <td width="140"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Nosso Número </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="RIGHT"><b><font face="Arial" SIZE="1"><%=sNumBoletoNaFicha%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			  </tr>
			  <tr>
			    <td width="129"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Uso do Banco </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=vUsoBanco%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="41"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Carteira </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><b><font face="Arial" SIZE="1"><%=vBancoCarteira%></font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="80"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Espécie Moeda </font><br>
			        </td>
			      </tr>
			      <tr align="CENTER">
			        <td><b><font face="Arial" SIZE="1">R$&nbsp; </font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="120" colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">Quantidade </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="CENTER"><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="120"><table width="100%" border="0" cellspacing="0" cellpadding="0">
			      <tr>
			        <td><font face="Arial" SIZE="1">(x) Valor </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td><b><font face="Arial" SIZE="1">&nbsp; </font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			    <td width="150"><table border="0" height="100%" width="100%" cellpadding="0"
			    cellspacing="0">
			      <tr>
			        <td height="50%"><font face="Arial" SIZE="1">(=) Valor do Documento </font><br>
			        </td>
			      </tr>
			      <tr>
			        <td align="RIGHT" height="50%"><b><font face="Arial" SIZE="3"><%=vValorInscricao%>
			        </font></b><br>
			        </td>
			      </tr>
			    </table>
			    </td>
			  </tr>
			  <tr>
			    <td colspan="6" valign="TOP">
			    <table width="100%" border="0" cellspacing="0"
			    cellpadding="0">
			      <tr valign="MIDDLE">
			        <td height="23"><font face="Arial" SIZE="1"><b>Instruções (Texto de responsabilidade do
			        cedente) </b><br>
			         <%=vTextoDoBoleto1%> 
			         <%=vMoraCalculada%>
			        <br>
			         <%=vTextoDoBoleto2%>
			        <br>
			         <%=vTextoDoBoleto3%>
			        <br>
			         </font></td>
			      </tr>
			      <tr valign="TOP">
			        <td>
                        <font face="Arial" size="1">
			         
			                <br>
			                Ref. : <%=vTextoDaReferencia%>
			                <br>
			        
                            <br>
                            Curso : <%=vNomeDoCurso%> 
                            <br>
                            Local : <%=vNomeDaRegiao%> 
                            <br>
                            Período : <%=sPeriodo%> 
                            <br>
                        </font>                    
                    </td>
			      </tr>
			    </table>
			    </td>
			    <td><table width="100%" border="1" cellspacing="0" cellpadding="0">
			      <tr valign="TOP">
			        <td height="23"><font face="Arial" SIZE="1">(-) Descontos/Abatimento <br>
			        </font></td>
			      </tr>
			      <tr valign="TOP">
			        <td height="23"><font face="Arial" SIZE="1">(-) Outras Deduções <br>
			        </font></td>
			      </tr>
			      <tr valign="TOP">
			        <td height="23"><font face="Arial" SIZE="1">(+) Mora/Multa <br> 
			        </font></td>
			      </tr>
			      <tr valign="TOP">
			        <td height="23"><font face="Arial" SIZE="1">(+) Outros Acréscimos <br>
			        </font></td>
			      </tr>
			      <tr valign="TOP">
			        <td height="23"><font face="Arial" SIZE="1">(=) Valor Cobrado <br>
			        </font></td>
			      </tr>
			    </table>
			    </td>
			  </tr>
			  <tr>
			    <td colspan="7">
			      <table width="100%" border="0" cellspacing="0" cellpadding="0">
			        <tr>
			          <td valign="top" width="100">
			            <font face="Arial" SIZE="1">Pagador: </font><br>
			          </td>
			          <td width="67%" valign="top" rowspan="2">
			            <font face="Arial" size="1">&nbsp;<%=vNome%><br>
			            &nbsp;<%=vEndereco%>&nbsp;<%=vNUMERO%>&nbsp;<%=vCOMPLEMENTO%>&nbsp;<%=vBairro%>&nbsp;<br>CEP:<%=vCep%> - <%=vCidade%> - <%=vEstado%></font>
			          </td>
			          <td width="33%" valign="top" rowspan="2">
			            <font face="Arial" size="1">CPF: <%=vCpf%><br>
			            RG: <%=vRg%> - <%=vRGEm%><br>&nbsp;</font></td>
			        </tr>
			  
			     
			 <tr>
			          <td valign="top" width="100">
			            &nbsp;</td>
			        </tr>
			      </table>
			    </td>
			  </tr>
			</table>
			
			
			<table width="640" cellspacing="0" cellpadding="0" border="0">
			    <td align="left" width="500" style="border:solid thin black" nowrap>
			      <img src="<%=espacoIMG%>" valign="bottom" border="0"<%=TextoHtml%>
			    </td>
			    <td valign=top align=center  style="border:solid thin black" width=300>
			      <font face=Arial SIZE=1>
			      <center><b>Autenticação Mecânica</b><p>
			  <font size="2" face="Arial">
			            <font face="Arial" size="1"><b>Ficha de Compensação</b>
			            </font>
			          </font>
			      </p>
			      </center>
			      </font>
			    </td>
			  </tr>
			</table>
			<table width="640" cellspacing="0" cellpadding="0" border="0">  
			  <tr>
			    <td colspan= 2> 
			      <hr noshade size=3 width="640">
			      <div align="left"><b><i><font size="2"> </font></i></b></div>
			    </td>
			  </tr>
			</table>
		</div>
	</asp:placeholder>
	
</form>
</body>
</html>
