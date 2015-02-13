<%@ Page Title="" Language="C#" MasterPageFile="~/ficha/inscricao.Master" AutoEventWireup="true" CodeBehind="inscricaoPassos.aspx.cs" Inherits="Site_Interessado.inscricaoPassos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <link href="styles/fichas.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/formata_data.js"></script>
    <script src="Scripts/formatadigitacao.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js" language="javascript"></script>
    <script type="text/javascript"  lang="js">
    
        var $j = jQuery.noConflict();

        $j(document).ready(function () {
            $j("#Corpo_CEP").blur(function (e) {
                if ($j.trim($j("#Corpo_CEP").val()) != "") {
                    $j.getScript("http://cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + $j("#Corpo_CEP").val(), function () {
                        if (resultadoCEP["resultado"] == "1") {
                            $j("#Corpo_Endereco").val(unescape(resultadoCEP["tipo_logradouro"]) + " " + unescape(resultadoCEP["logradouro"]));
                            $j("#Corpo_Bairro").val(unescape(resultadoCEP["bairro"]));
                            $j("#Corpo_Cidade").val(unescape(resultadoCEP["cidade"]));
                            $j("#Corpo_txtEstadoER").val(unescape(resultadoCEP["uf"]));
                            $j("#Corpo_NUMERO").focus();
                        } else {
                            document.getElementById("Corpo_lbl").value = "Não foi possivel encontrar o endereço";
                        }
                    });
                }
            })
        });

        $j(document).ready(function () {
            $j("#Corpo_CEP_Profissional").blur(function (e) {
                if ($j.trim($j("#Corpo_CEP_Profissional").val()) != "") {
                    $j.getScript("http://cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + $j("#Corpo_CEP_Profissional").val(), function () {
                        if (resultadoCEP["resultado"] == "1") {
                            $j("#Corpo_Endereco_Profissional").val(unescape(resultadoCEP["tipo_logradouro"]) + " " + unescape(resultadoCEP["logradouro"]));
                            $j("#Corpo_bairro_profissional").val(unescape(resultadoCEP["bairro"]));
                            $j("#Corpo_Cidade_Profissional").val(unescape(resultadoCEP["cidade"]));
                            $j("#Corpo_txtEstadoEP").val(unescape(resultadoCEP["uf"]));
                            $j("#NUMERO_Profissional").focus();
                        } else {
                            document.getElementById("Corpo_lbl").value = "Não foi possivel encontrar o endereço";
                        }
                    });
                }
            })
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Corpo" runat="server">
    <form id="Form1Inscricao" runat="server">

		<div class="bg-primary" id="lblErroI" style="display:none" runat="server">
			<asp:label id="lMensagem" runat="server" Visible="false">oi o/</asp:Label>
		</div>

        <p class="instrucoes" style="margin-left:75px;width: 86%;" id="pInstrucoes">Faça agora sua <span class="bold">inscrição</span> em um dos nossos cursos preenchendo corretamente os campos abaixo. Obs: Os campos com o título <span class="bold">em negrito</span> são de preenchimento obrigatório.</p>

		    <!-- Seleção de curso -->
		    <div class = "container-fluido">

              <!-- Menu De Navegação Dos Passos. -->
                <asp:Panel ID="pnlP1" runat="server" style="margin-left:60px;" Visible="true">
                    <div id="PassosOrdem" class="breadcrumb" style="background-color: white;">
                        <asp:Label ID="lblP1" runat="server" Text="Passo 1 > " ForeColor="#2684A0" style="font-weight:bold;"></asp:Label>
                        <asp:Label ID="lblP2" runat="server" Text="Passo 2 > " style="color:gray;"></asp:Label>
                        <asp:Label ID="lblP3" runat="server" Text="Passo 3" style="color:gray;"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlP2" runat="server" style="margin-left:60px;" Visible="false">
                    <div id="PassosOrdem2" class="breadcrumb" style="background-color: white;">
                        <asp:LinkButton ID="lblP12" runat="server" OnClick="lblP12_Click"  style="color:gray;">Passo 1 > </asp:LinkButton>
                        <asp:Label ID="lblP22" runat="server" Text="Passo 2 > " ForeColor="#2684A0" style="font-weight:bold;"></asp:Label>
                        <asp:Label ID="lblP32" runat="server" Text="Passo 3" style="color:gray;"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlP3" runat="server" style="margin-left:60px;" Visible="false">
                    <div id="PassosOrdem3" class="breadcrumb" style="background-color: white;">
                        <asp:LinkButton ID="lblP13" runat="server" style="color:gray;" OnClick="lblP13_Click">Passo 1 > </asp:LinkButton>
                        <asp:LinkButton ID="lblP23" runat="server" style="color:gray;" OnClick="lblP23_Click">Passo 2 > </asp:LinkButton>
                        <asp:Label ID="lblP33" runat="server" Text="Passo 3" ForeColor="#2684A0" style="font-weight:bold;"></asp:Label>
                    </div>
                </asp:Panel>
              <!-- Fim do Menu De Navegação Dos Passos. -->

               <asp:Panel ID="divPasso1" style="margin-left: 75px;display:block;" runat="server"> <!-- PAINEL DO PASSO 1 QUE FICA VISIVEL E INVISIVEL QUE CONTEM OS CAMPOS DE CADASTRO -->

		        <h2 style="font-size: 23px;font-family:'Arial Narrow';color: rgb(12, 132, 160);margin: 20px 0 -7px 0;">Inscrição em:</h2>
		
                     <div  class = "row" id="IInscricaoUm">
                        <div  class = "col-xs-12 col-md-4" id="divTipoCursoI"> 
                              <div class="form-group" id="div2TipoCursoI">
                                   <asp:Label ID="CatCur" runat="server" Text="Label"  class="bold" >Tipo de Curso:</asp:Label><br />
                                    <asp:DropDownList ID="ddlCatCur" runat="server" class="form-control" OnSelectedIndexChanged="ddlCatCur_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                              </div>
                         </div>           

                        <div  class = "col-xs-12 col-md-4" id="divCursoI"> 
                              <div class="form-group" id="div2CursoI">
                                   <asp:Label ID="Curso" runat="server" Text="Label"  class="bold">Curso:</asp:Label><br />
                                    <asp:DropDownList ID="ddlCurso" runat="server" class="form-control" OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged"  AutoPostBack="True">
                                        <asp:ListItem Value="-1">Selecione Cursos</asp:ListItem>
                                   </asp:DropDownList>
                              </div>
                         </div>           
                    </div>

                    <div  class = "row" id="IInscricaoDois">
                        <div  class = "col-xs-12 col-md-4" id="divRegiaoI"> 
                              <div class="form-group" id="div2RegiaoI">
                                   <asp:Label ID="Regiao" runat="server" Text="Label"  class="bold">Regiao:</asp:Label><br />
                                    <asp:DropDownList ID="ddlRegiao" runat="server" class="form-control" style="width:100%">
                                        <asp:ListItem Value="-1">Selecione Regioes</asp:ListItem>
                                   </asp:DropDownList>
                              </div>
                         </div>           
            
                        <div  class = "col-xs-12 col-md-4" id="divPeriodoI"> 
                              <div class="form-group" id="div2PeriodoI">
                                   <asp:Label ID="Periodo" runat="server" Text="Label"  class="bold">Periodo:</asp:Label>
                                    <asp:DropDownList ID="ddlPeriodo" runat="server" class="form-control" >
                                        <asp:ListItem Value="--Selecione--"></asp:ListItem>
                                        <asp:ListItem Value="2">DIURNO|SÁBADOS</asp:ListItem>
                                        <asp:ListItem Value="3">NOTURNO</asp:ListItem>
                                        <asp:ListItem Value="1">TODOS</asp:ListItem>
                                    </asp:DropDownList>
                              </div>
                         </div>           
                    </div>

            
		
                    <h2 style="font-size: 23px;font-family:'Arial Narrow';color: rgb(12, 132, 160);margin: 4px 0 -7px 0;">Como soube</h2>
<%--		
                    <div class="row" id="IComoSoubeUm">
                         <div  class="col-xs-12 col-md-3" id="divFolderI">                     
                            <div class="form-group" id="div2FolderI">
                                <asp:Label ID="Label44" runat="server" Text="Label" class="bold">Você recebeu nosso folder?</asp:Label>
                                <asp:DropDownList ID="folder" runat="server" class="form-control" >
                                    <asp:ListItem Value="0">Selecione</asp:ListItem>
                                    <asp:ListItem Value="Sim">Sim</asp:ListItem>
                                    <asp:ListItem Value="Nao">Não</asp:ListItem>
                                 </asp:DropDownList>                    
                            </div>
                        </div> 
                    </div>--%>
                    <div class="row" id="IComoSoubeDois">
                         <div  class="col-xs-12 col-md-5" id="divClasseI">                     
                            <div class="form-group" id="div2ClasseI">
                                <asp:Label ID="Label45" runat="server" Text="Label" class="bold">É filiado(a) a alguma associação de classe?</asp:Label>
                                <asp:DropDownList ID="ddlCLASSE" runat="server" class="form-control">
                                        <asp:ListItem Value="-1">Selecione</asp:ListItem>
                                 </asp:DropDownList>                    
                            </div>
                        </div> 
                    </div>
                    <div class="row" id="IComoSoubeTres">
                         <div  class="col-xs-12 col-md-4" id="divComoSoubeI">                     
                            <div class="form-group" id="div2ComoSoubeI">
                                <asp:Label ID="Label46" runat="server" Text="Label" class="bold">Como soube do curso</asp:Label>
                                <asp:DropDownList ID="dllCOMOSOUBE" runat="server" class="form-control">
                                        <asp:ListItem Value="-1">Selecione</asp:ListItem>
                                </asp:DropDownList>                  
                            </div>
                        </div> 
                    </div>


                <asp:Button ID="Avanca1" runat="server" Text="Avançar" style="background: rgb(12, 132, 160);color: white;" OnClick="Avanca1_Click"/>
            </asp:Panel>
           
               <asp:Panel ID="divPasso2" style="display:none;margin-left: 75px;" runat="server">  <!-- PAINEL DO PASSO 2 QUE FICA VISIVEL E INVISIVEL QUE CONTEM OS CAMPOS DE CADASTRO -->

		        <h2 style="font-size: 23px;font-family:'Arial Narrow';color: rgb(12, 132, 160);margin: 20px 0 -7px 0;">Dados Pessoais</h2>
		
                <div class="row" id="IPessoaisUm">
                    <div  class="col-xs-12 col-md-5" id="divNomeI"> 
                        <div class="form-group" id="div2NomeI">
                            <asp:Label ID="lblRealname" runat="server" class="bold">Nome completo:</asp:Label>
                          <asp:TextBox ID="realname" runat="server" size="60" maxlength="56" class="form-control"></asp:TextBox>
                        </div>
                    </div>    
                </div>
                <div class="row" id="IPessoaisDois">
                    <div  class = "col-xs-6 col-md-2" id="divSexoI"> 
                          <div class="form-group" id="div2SexoI">
                               <asp:Label ID="Sexo" runat="server" Text="Label" class="bold">Sexo:</asp:Label>
                                <asp:DropDownList ID="ddlSexo" runat="server" class="form-control" >
                                    <asp:ListItem Value="Selecione"></asp:ListItem>
                                    <asp:ListItem Value="Masculino"></asp:ListItem>
                                    <asp:ListItem Value="Feminino"></asp:ListItem>
                                </asp:DropDownList>
                          </div>
                     </div>  
                
                    <div  class="col-xs-6 col-md-2" id="divNascI"> 
                        <div class="form-group" id="div2NascI">
                            <asp:Label ID="Label1" runat="server" class="bold" >Data de Nascimento:</asp:Label>
                            <asp:TextBox ID="Data_Nascimento" runat="server" size="60" maxlength="10" class="form-control" placeholder="Dia/Mes/Ano" onKeyUp="javascript:return MascaraDeData(this.value,this,'/',event);"  ValidationGroup="&lt;&gt; &quot;&quot;"></asp:TextBox>
                        </div>
                    </div>                   
                </div>

                <div class="row" id="IPessoaisTres">
                    <div  class="col-xs-6 col-md-3" id="divCidadeNascI"> 
                        <div class="form-group" id="div2CidadeNascI">
                            <asp:Label ID="Label2" runat="server" class="bold">Cidade de Nascimento:</asp:Label>
                            <asp:TextBox ID="Cidade_Nascimento" runat="server" size="60" maxlength="30" class="form-control" ></asp:TextBox>
                        </div>
                    </div> 

                      <div  class = "col-xs-6 col-md-1" id="divUFI"> 
                        <div class="form-group" id="div2UF">
                            <asp:Label ID="Label3" runat="server" Text="Label" class="bold">UF:</asp:Label>
                            <asp:TextBox ID="txtUF" runat="server" Width="70" MaxLength="2" class="form-control"  onKeypress="return so_letras(event)"></asp:TextBox>  
                        </div>
                    </div> 
                </div>
                <div class="row" id="IPessoaisQuatro">
                    <div  class = "col-xs-6 col-md-2" id="divCivilI"> 
                        <div class="form-group" id="div2CivilI">
                            <asp:Label ID="Label4" runat="server" Text="Label" class="  bold">Estado Civil:</asp:Label>
                            <asp:DropDownList ID="ddlESTADOCIVIL" runat="server" class="form-control" >
                                <asp:ListItem Value="SEL">Selecione</asp:ListItem>
                                <asp:ListItem Value="CAS">Casado(a)</asp:ListItem>
                                <asp:ListItem Value="DES">Desquitado(a)</asp:ListItem>
                                <asp:ListItem Value="DIV">Divorciado(a)</asp:ListItem>
                                <asp:ListItem Value="SEP">Separado(a)</asp:ListItem>
                                <asp:ListItem Value="SOL">Solteiro(a)</asp:ListItem>
                                <asp:ListItem Value="VIU">Viúvo(a)</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div> 

       
                    <div  class="col-xs-6 col-md-2" id="divCPFI"> 
                        <div class="form-group" id="div2CPFI">
                            <asp:Label ID="Label5" runat="server" class="bold">CPF:</asp:Label>
                            <asp:TextBox ID="cpf" runat="server" size="60" maxlength="11" class="form-control"  onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="IPessoaisCinco">
                    <div  class="col-xs-6 col-md-3" id="divRGI"> 
                        <div class="form-group" id="div2RGI">
                            <asp:Label ID="Label6" runat="server" class="bold">RG:</asp:Label>
                            <asp:TextBox ID="rg" runat="server" size="60" maxlength="9" class="form-control" onKeypress="return numeros_e_letras_sem_espaco(event)"></asp:TextBox>
                        </div>
                    </div>

                    <div  class="col-xs-6 col-md-2" id="divOEI"> 
                        <div class="form-group" id="div2OEI">
                            <asp:Label ID="Label7" runat="server" class="bold">Órgão Emissor</asp:Label>
                            <asp:TextBox ID="rgem" runat="server" Width="70" MaxLength="3" class="form-control"  onKeypress="return so_letras(event)"></asp:TextBox>  
                        </div>
                    </div>
                </div>
                <div class="row" id="IPessoaisSeis">       
                    <div  class="col-xs-4 col-md-2" id="divPaisNascI"> 
                        <div class="form-group" id="div2PaisNascI">
                            <asp:Label ID="Label8" runat="server" class="bold">País de Nascimento:</asp:Label>
                            <asp:TextBox ID="PAISNASC" runat="server" size="60" maxlength="20" class="form-control" onKeypress="return letras_e_espacos(event)"></asp:TextBox>
                        </div>
                    </div>       
                    <div  class="col-xs-8 col-md-3" id="divEmailI"> 
                        <div class="form-group" id="div2EmailI">
                            <asp:Label ID="Label9" runat="server" class="bold">E-Mail:</asp:Label>
                            <div class="input-group">
                                <div class="input-group-addon">@</div>
                                <asp:TextBox ID="EMail" runat="server" size="60" maxlength="30" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <h2 style="font-size: 23px;font-family:'Arial Narrow';color: rgb(12, 132, 160);margin: 6px 0 0 0px;">Endereço Residencial</h2>
                

                 <div class="row" id="IResidencialUm">       
                    <div  class="col-xs-12 col-md-2" id="divCEPI"> 
                        <div class="form-group" id="div2CEPI">
                            <asp:Label ID="Label10" runat="server" class="bold">CEP:</asp:Label>
                            <asp:TextBox ID="CEP" runat="server" size="60" maxlength="8" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
     
                    <div  class="col-xs-12 col-md-3" id="divEndI"> 
                        <div class="form-group" id="div2EndI">
                            <asp:Label ID="Label11" runat="server" class="bold">Endereço:</asp:Label>
                            <asp:TextBox ID="Endereco" runat="server" size="60" maxlength="70" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="IResidencialDois">       
                     <div  class="col-xs-6 col-md-1" id="divNumI"> 
                        <div class="form-group" id="div2NumI">
                            <asp:Label ID="Label12" runat="server" class="bold">Número:</asp:Label>
                            <asp:TextBox ID="NUMERO" runat="server" size="60" maxlength="5" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                     <div  class="col-xs-6 col-md-2" id="divComplementoI"> 
                        <div class="form-group" id="div2ComplementoI">
                            <asp:Label ID="Label13" runat="server" class="bold">Complemento:</asp:Label>
                            <asp:TextBox ID="COMPLEMENTO" runat="server" size="60" maxlength="13" class="form-control"  onKeypress="return numeros_e_letras(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="IResidencialTres">       
                    <div  class="col-xs-4 col-md-2" id="divBairroI"> 
                        <div class="form-group" id="div2BairroI">
                            <asp:Label ID="Label14" runat="server" class="bold">Bairro:</asp:Label>
                            <asp:TextBox ID="Bairro" runat="server" size="60" maxlength="20" class="form-control" onKeypress="return letras_e_espacos(event)"></asp:TextBox>
                        </div>
                    </div>
                     <div  class="col-xs-5 col-md-2" id="divCidadeI"> 
                        <div class="form-group" id="div2CidadeI">
                            <asp:Label ID="Label15" runat="server" class="bold">Cidade:</asp:Label>
                            <asp:TextBox ID="Cidade" runat="server" size="60" maxlength="20" class="form-control" ></asp:TextBox>
                        </div>
                    </div>
                     <div  class="col-xs-2 col-md-1" id="divEstadoI"> 
                        <div class="form-group" style="width: 100px;" id="div2EstadoI">
                            <div class="form-group" >
                            <asp:Label ID="Label16" runat="server" Text="Label" class="bold">Estado</asp:Label>
                            <asp:TextBox ID="txtEstadoER" runat="server" Width="70" MaxLength="2" class="form-control"  onKeypress="return so_letras(event)"></asp:TextBox>  
                        </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="IResidencialQuatro">       
                    <div  class="col-xs-4 col-md-1" id="divDDDI"> 
                        <div class="form-group" id="div2DDDI">
                            <asp:Label ID="Label17" runat="server" class="bold">DDD:</asp:Label>
                            <asp:TextBox ID="txtDDD" runat="server" size="60" maxlength="3" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div  class="col-xs-8 col-md-2" id="divTelI"> 
                        <div class="form-group" id="div2TelI">
                            <asp:Label ID="Label18" runat="server" class="bold">TEL:</asp:Label>
                            <asp:TextBox ID="txtTEL" runat="server" size="60" maxlength="9" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>

                    <div  class="col-xs-4 col-md-1" id="divDDD2I"> 
                        <div class="form-group" id="div2DDD2I">
                            <asp:Label ID="Label19" runat="server" class="bold">DDD:</asp:Label>
                            <asp:TextBox ID="txtDDDCEL" runat="server" size="60" maxlength="3" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                        <div  class="col-xs-8 col-md-2" id="divCelI"> 
                        <div class="form-group" id="div2CelI">
                            <asp:Label ID="Label20" runat="server" class="bold">CEL:</asp:Label>
                            <asp:TextBox ID="txtCEL" runat="server" size="60" maxlength="9" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:Button ID="Avanca2" runat="server" Text="Avançar" style="background: rgb(12, 132, 160);color: white;" OnClick="Avanca2_Click"/>
                </asp:Panel>
        
               <asp:Panel ID="divPasso3" runat="server" style="display:none;margin-left: 75px;"> <!-- PAINEL DO PASSO 3 QUE FICA VISIVEL E INVISIVEL QUE CONTEM OS CAMPOS DE CADASTRO -->

                <h2 style="font-size: 23px;font-family:'Arial Narrow';color: rgb(12, 132, 160);">Formação Acadêmica</h2>


                <div class="row" id="IAcademicoUm">       
                    <div  class=" col-xs-12 col-md-4" id="divCursoUniUmI"> 
                        <div class="form-group" id="div2CursoUniUmI">
                            <asp:Label ID="Label21" runat="server" class="bold">Curso Universitário:</asp:Label>
                            <asp:TextBox ID="Curso_Universitario" runat="server" size="60" maxlength="30" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div  class=" col-xs-12 col-md-2" id="divAnoUmI"> 
                        <div class="form-group" id="div2AnoUmI">
                            <asp:Label ID="Label22" runat="server" class="bold">Ano de Conclusão:</asp:Label>
                            <asp:TextBox ID="Ano_Conclusao" runat="server" size="60" maxlength="4" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="IAcademicoDois">       
                    <div  class=" col-xs-12 col-md-4" id="divInstUmI"> 
                        <div class="form-group" id="div2InstUmI">
                            <asp:Label ID="Label25" runat="server" class="bold">Instituição de Formação:</asp:Label>
                            <asp:TextBox ID="formacao" runat="server" size="60" maxlength="50" class="form-control" onKeypress="return numeros_e_letras(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row" id="IAcademicoTres">       
                    <div  class=" col-xs-12 col-md-4" id="divCursoUniDoisI"> 
                        <div class="form-group" id="div2CursoUniDoisI">
                            <asp:Label ID="Label23" runat="server" class="bold">2° Curso Universitário:</asp:Label>
                            <asp:TextBox ID="Curso_Universitario2" runat="server" size="50" maxlength="30" class="form-control" onKeypress="return numeros_e_letras(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div  class=" col-xs-12 col-md-2" id="divAnoDoisI"> 
                        <div class="form-group" id="div2AnoDoisI">
                            <asp:Label ID="Label24" runat="server" class="bold">Ano de Conclusão:</asp:Label>
                            <asp:TextBox ID="Ano_Conclusao2" runat="server" size="60" maxlength="4" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="IAcademicoQuatro">       
                    <div  class="col-xs-12 col-md-4 " id="divInstDoisI"> 
                        <div class="form-group" id="div2InstDoisI">
                            <asp:Label ID="Label26" runat="server" class="bold">Instituição de Formação:</asp:Label>
                            <asp:TextBox ID="formacao2" runat="server" size="60" maxlength="50" class="form-control"  onKeypress="return numeros_e_letras(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <h2 style="font-size: 23px;font-family:'Arial Narrow';color: rgb(12, 132, 160);margin: 6px 0 0 0px;">Endereço Profissional</h2>

                <div class="row" id="IEndProfUm">       
                    <div  class=" col-xs-12 col-md-4" id="divEmpresaI"> 
                        <div class="form-group" id="div2EmpresaI">
                            <asp:Label ID="Label27" runat="server" class="bold">Empresa:</asp:Label>
                            <asp:TextBox ID="Empresa" runat="server" size="60" maxlength="70" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div  class="col-xs-12 col-md-3" id="divCargoCompI"> 
                        <div class="form-group" id="div2CargoCompI">
                            <asp:Label ID="Label28" runat="server" class="bold">Cargo Completo:</asp:Label>
                            <asp:TextBox ID="CARGOCOMPLETO" runat="server" size="60" maxlength="40" class="form-control"  onKeypress="return numeros_e_letras(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="IEndProfDois">                          
                    <div  class="col-xs-6 col-md-2 " id="divCargoI"> 
                        <div class="form-group" id="div2CargoI">
                            <asp:Label ID="Label29" runat="server" class="bold">Cargo</asp:Label>
                            <asp:DropDownList ID="ddlCargo" runat="server" class="form-control" >
                                <asp:ListItem Value="SEL">Selecione</asp:ListItem>
                                <asp:ListItem Value="2">DIREÇÃO</asp:ListItem>
                                <asp:ListItem Value="1">GERÊNCIA</asp:ListItem>
                                <asp:ListItem Value="4">OPERACIONAL</asp:ListItem>
                                <asp:ListItem Value="3">SUPERVISÂO</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div> 
                  <div  class="col-xs-6 col-md-2 " id="divDataAdI"> 
                        <div class="form-group" id="div2DataAdI">
                            <asp:Label ID="Label30" runat="server" class="bold">Data de Admissão:</asp:Label>
                            <asp:TextBox ID="DTADMISSAO" runat="server" size="60" maxlength="10" class="form-control" placeholder="Dia/Mes/Ano" onKeyUp="mascara_data(this)" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="IEndProfTres">  
                  <div  class="col-xs-12 col-md-4 " id="divEmailComI"> 
                        <div class="form-group" id="div2EmailComI">
                            <asp:Label ID="Label31" runat="server" class="bold">E-Mail Comercial:</asp:Label>
                            <div class="input-group">
                                <div class="input-group-addon">@</div>
                                <asp:TextBox ID="EMail_Com" runat="server" size="60" maxlength="43" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="IEndProfQuatro">
                      <div  class="col-xs-12 col-md-2 " id="divCEPComI"> 
                        <div class="form-group" id="div2CEPComI">
                            <asp:Label ID="Label35" runat="server" class="bold">Cep:</asp:Label>
                            <asp:TextBox ID="CEP_Profissional" runat="server" size="60" maxlength="8" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>  

                  <div  class="col-xs-12 col-md-3 " id="divEndComI"> 
                        <div class="form-group" id="div2EndComI">
                            <asp:Label ID="Label33" runat="server" class="bold">Endereço:</asp:Label>
                            <asp:TextBox ID="Endereco_Profissional" runat="server" size="60" maxlength="70" class="form-control" onKeypress="return numeros_e_letras(event)"></asp:TextBox>
                        </div>
                    </div>
                 </div>
                <div class="row" id="IEndProfCinco"> 
                    <div  class="col-xs-6 col-md-2 " id="divNumComI">  
                        <div class="form-group" id="div2NumComI">
                            <asp:Label ID="Label34" runat="server" class="bold">Numero:</asp:Label>
                            <asp:TextBox ID="NUMERO_Profissional" runat="server" size="60" maxlength="5" class="form-control"  onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                   <div  class="col-xs-6 col-md-3 " id="divCompComI"> 
                        <div class="form-group" id="div2CompComI">
                            <asp:Label ID="Label32" runat="server" class="bold">Complemento:</asp:Label>
                            <asp:TextBox ID="COMPLEMENTO_Profissional" runat="server" size="60" maxlength="28" class="form-control" onKeypress="return numeros_e_letras(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row" id="IEndProfSeis">       
                    <div  class="col-xs-5 col-md-2" id="divBairroComI"> 
                        <div class="form-group" id="div2BairroComI">
                            <asp:Label ID="Label36" runat="server" class="bold">Bairro:</asp:Label>
                            <asp:TextBox ID="bairro_profissional" runat="server" size="60" maxlength="15" class="form-control" ></asp:TextBox>
                        </div>
                    </div>
                    <div  class="col-xs-4 col-md-2" id="divCidadeComI"> 
                        <div class="form-group" id="div2CidadeComI">
                            <asp:Label ID="Label37" runat="server" class="bold">Cidade:</asp:Label>
                            <asp:TextBox ID="Cidade_Profissional" runat="server" size="60" maxlength="20" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div  class="col-xs-2 col-md-1" id="divEstadoComI">                     
                        <div class="form-group" id="div2EstadoComI">
                            <asp:Label ID="Label38" runat="server" Text="Label" class="bold">Estado</asp:Label>
                            <asp:TextBox ID="txtEstadoEP" runat="server" Width="70" MaxLength="2" class="form-control"  onKeypress="return so_letras(event)"></asp:TextBox>                    
                        </div>
                    </div>
                </div>
                <div class="row" id="IEndProfSete">
                     <div  class="col-xs-12 col-md-3" id="divPerfilComI">                     
                        <div class="form-group" id="div2PerfilComI">
                            <asp:Label ID="Label43" runat="server" Text="Label" class="bold">Perfil da empresa</asp:Label>
                            <asp:DropDownList ID="Perfil" runat="server" class="form-control" >
                                <asp:ListItem Value="0">Selecione</asp:ListItem>
                                <asp:ListItem Value="Nacional - Pequena">Nacional - Pequena</asp:ListItem>
                                <asp:ListItem Value="Nacional - Média">Nacional - Média</asp:ListItem>
                                <asp:ListItem Value="Nacional - Grande">Nacional - Grande</asp:ListItem>
                                <asp:ListItem Value="Multinacional">Multinacional</asp:ListItem>
                             </asp:DropDownList>                    
                        </div>
                    </div> 
                </div>
                <div class="row" id="IEndProfOito">       
                    <div  class="col-xs-3 col-md-1" id="divDDDComI"> 
                        <div class="form-group" id="div2DDDComI">
                            <asp:Label ID="Label39" runat="server" class="bold">DDD:</asp:Label>
                            <asp:TextBox ID="DDD_Telefone_Profissional" runat="server" size="60" maxlength="3" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div  class="col-xs-9 col-md-3" id="divTelComI"> 
                        <div class="form-group" id="div2TelComI">
                            <asp:Label ID="Label40" runat="server" class="bold">TEL:</asp:Label>
                            <asp:TextBox ID="Telefone_Profissional" runat="server" size="60" maxlength="9" class="form-control" onKeypress="return so_numeros(event)" ></asp:TextBox>
                        </div>
                    </div>
                    </div>
                <div class="row" id="IEndProfNove">
                    <div  class="col-xs-3 col-md-1" id="divDDD2ComI"> 
                        <div class="form-group" id="div2DDD2ComI">
                            <asp:Label ID="Label41" runat="server" class="bold">DDD:</asp:Label>
                            <asp:TextBox ID="DDD_Fax_Profissional" runat="server" size="60" maxlength="3" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div  class="col-xs-9 col-md-3" id="divFaxComI"> 
                        <div class="form-group" id="div2FaxComI">
                            <asp:Label ID="Label42" runat="server" class="bold">FAX:</asp:Label>
                            <asp:TextBox ID="Fax_Profissional" runat="server" size="60" maxlength="9" class="form-control" onKeypress="return so_numeros(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>

		        <p class="botao">
                    <asp:Button ID="Button1" runat="server" Text="Finalizar" class="btn btn-primary" OnClick="Button1_Click"></asp:Button>
		        </p>
        
            </asp:Panel>

            </div>

    </form>

</asp:Content>
