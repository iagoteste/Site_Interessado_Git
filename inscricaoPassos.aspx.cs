using Site_Interessado.app_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_Interessado
{
    public partial class inscricaoPassos : System.Web.UI.Page
    {
        #region Variaveis Globais.
         String Final;
         string CodReg1, CodCat1, CodCur1;
        #endregion

        #region Page_Load
         protected void Page_Load(object sender, EventArgs e)
        {
     
            if (!IsPostBack)
            {
                string CodReg = Request.QueryString["CodReg"];
                string CodCat = Request.QueryString["CodCat"];
                string CodCur = Request.QueryString["CodCur"];

                if (CodReg != null && CodCat != null && CodCur != null)
                {
                    pupulaTipoCurso(CodCat);
                    pupulaCurso(CodCur);
                    populaRegiao(CodReg);
                    carregaddlComoSoubeInsc();
                    carregaddlClasse();
                }
                else
                {
                    populaTipoCursoInsc();
                    carregaddlComoSoubeInsc();
                    carregaddlClasse();
                }
            }
        }
        #endregion
    
        #region Envios.
         #region btnEnviar
         protected void Button1_Click(object sender, EventArgs e)
        {
             //mostra label se tiver erro= true 
            if (ValidaCamposInsc())
            {
                lMensagem.Visible = true;
                lblErroI.Style.Add("display", "block");
                return;
            }

            string retIdInteressado, EMailOrigem, ParaMail, Assunto, Anexo, comCopia;

            bool podeIncluir;
            podeIncluir = false;

            retIdInteressado = "";
            EMailOrigem = "";
            ParaMail = "";
            Assunto = "Strong - Confirmaçao de Inscrição";
            Anexo = "";
            comCopia = "";


            app_code.UmInscrito.setIdCurso(ddlCurso.SelectedValue.ToString());
            app_code.UmInscrito.setIdRegiao(ddlRegiao.SelectedValue.ToString());
            app_code.UmInscrito.setSexo(ddlSexo.SelectedValue.ToString());
            app_code.UmInscrito.setNome(realname.Text.ToString());
            app_code.UmInscrito.setDDDTEL(txtDDD.Text.ToString());
            app_code.UmInscrito.setTEL(txtTEL.Text.ToString());
            app_code.UmInscrito.setComoSoube(dllCOMOSOUBE.SelectedValue.ToString());
            app_code.UmInscrito.setnmComoSoube(dllCOMOSOUBE.SelectedItem.Text.ToString());
            app_code.UmInscrito.setemail(EMail.Text.ToString());
            app_code.UmInscrito.setIdPeriodo(ddlPeriodo.SelectedValue.ToString());
            app_code.UmInscrito.setDtNascimento(Data_Nascimento.Text.ToString());
            app_code.UmInscrito.setRG(rg.Text.ToString());
            app_code.UmInscrito.setCPF(cpf.Text.ToString());
            app_code.UmInscrito.setCidadeNasc(Cidade_Nascimento.Text.ToString());
            app_code.UmInscrito.setEstado(txtEstadoER.Text.ToString());
            app_code.UmInscrito.setEndereco(Endereco.Text.ToString());
            app_code.UmInscrito.setBairro(Bairro.Text.ToString());
            app_code.UmInscrito.setCidade(Cidade.Text.ToString());
            app_code.UmInscrito.setUFNasc(txtUF.Text.ToString());
            app_code.UmInscrito.setCEP(CEP.Text.ToString());
            app_code.UmInscrito.setDDDCEL(txtDDDCEL.Text.ToString());
            app_code.UmInscrito.setCEL(txtCEL.Text.ToString());
            app_code.UmInscrito.setCursoUniversitario(Curso_Universitario.Text.ToString());
            app_code.UmInscrito.setAnoConclusao(Ano_Conclusao.Text.ToString());
            app_code.UmInscrito.setSegCursoUniversitario(Curso_Universitario2.Text.ToString());
            app_code.UmInscrito.setSegAnoConclusao(Ano_Conclusao2.Text.ToString());
            app_code.UmInscrito.setEmpresa(Empresa.Text.ToString());
            app_code.UmInscrito.setPerfilEmpresa(Perfil.Text.ToString());
            app_code.UmInscrito.setEnderecoEmpresa(Endereco_Profissional.Text.ToString());
            app_code.UmInscrito.setBairroEmpresa(bairro_profissional.Text.ToString());
            app_code.UmInscrito.setCidadeEmpresa(Cidade_Profissional.Text.ToString());
            app_code.UmInscrito.setEstadoEmpresa(txtEstadoEP.Text.ToString());
            app_code.UmInscrito.setCEPEmpresa(CEP_Profissional.Text.ToString());
            app_code.UmInscrito.setDDDTelEmpresa(DDD_Telefone_Profissional.Text.ToString());
            app_code.UmInscrito.setTELEmpresa(Telefone_Profissional.Text.ToString());
            app_code.UmInscrito.setDDDFaxEmpresa(DDD_Fax_Profissional.Text.ToString());
            app_code.UmInscrito.setFAXEmpresa(Fax_Profissional.Text.ToString());
            app_code.UmInscrito.setOrgaoEmissor(rgem.Text.ToString());
            app_code.UmInscrito.setemailComercial(EMail_Com.Text.ToString());
            app_code.UmInscrito.setInstituicaoFormacao(formacao.Text.ToString());
            app_code.UmInscrito.setSegInstituicaoFormacao(formacao2.Text.ToString());
            app_code.UmInscrito.setNumero(NUMERO.Text.ToString());
            app_code.UmInscrito.setComplemento(COMPLEMENTO.Text.ToString());
            app_code.UmInscrito.setCargo(ddlCargo.SelectedValue.ToString());
            app_code.UmInscrito.setDataAdmissao(DTADMISSAO.Text.ToString());
            app_code.UmInscrito.setCargoCompleto(CARGOCOMPLETO.Text.ToString());
            app_code.UmInscrito.setNumeroEmpresa(NUMERO_Profissional.Text.ToString());
            app_code.UmInscrito.setComplementoEmpresa(COMPLEMENTO_Profissional.Text.ToString());
            app_code.UmInscrito.setPaisNasc(PAISNASC.Text.ToString());
            app_code.UmInscrito.setEstadoCivil(ddlESTADOCIVIL.SelectedValue.ToString());
            //app_code.UmInscrito.setFolder(folder.SelectedValue.ToString());

            if (Session["insertRealizadoPor"] == null) // 1a. entrada - pode incluir
            {
                Session["insertRealizadoPor"] = "interesse_" + app_code.UmInscrito.getIdCurso() + "_" + app_code.UmInscrito.getIdRegiao() + "_" + app_code.UmInscrito.getNome();
                podeIncluir = true;
            }
            else
                if (Session["insertRealizadoPor"].ToString() != "interesse_" + app_code.UmInscrito.getIdCurso() + "_" + app_code.UmInscrito.getIdRegiao() + "_" + app_code.UmInscrito.getNome()) // não é 1a. entrada mas mudou algo - pode incluir
                {
                    Session["insertRealizadoPor"] = "interesse_" + app_code.UmInscrito.getIdCurso() + "_" + app_code.UmInscrito.getIdRegiao() + "_" + app_code.UmInscrito.getNome();
                    podeIncluir = true;
                }


            if (ValidaCamposInsc())
            {
            }
            else
            {
                //Verifica se pode incluir
                if (podeIncluir)
                {
                    retIdInteressado = app_code.Aplicacao.InsertDadosInteressadoInsc();

		            DataTable dt = app_code.Aplicacao.RetornaParametroEmail(app_code.UmInscrito.getIdCurso(), app_code.UmInscrito.getIdRegiao());

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        EMailOrigem = dr["EMAilFrom"].ToString();
                        ParaMail = dr["EMailName"].ToString();
                    }                         

                    bool enviado, enviado1;
                    enviado = false;
                    enviado1 = false;

                    enviado = app_code.Funcoes.EnviarEMail(app_code.UmInscrito.getemail(), Assunto, app_code.Aplicacao.RetornaTextoHtmlEmail(app_code.UmInscrito.getIdCurso(), app_code.UmInscrito.getIdRegiao()), Anexo, comCopia);

                    //Enviar o e-mail com a url de geração da 2 via do boleto.
                    if (retIdInteressado == "" || retIdInteressado == null)
                    {}
                    else
                    {
                        enviado1 = EnviaURLPorEmail(retIdInteressado.ToString(), app_code.UmInscrito.getIdCurso(), app_code.UmInscrito.getIdRegiao());
                    }

                    if (enviado && enviado1)
                    {
                        //string destinationURL = "acao=0&nome=" + app_code.UmInscrito.getNome() + "&curso=" + app_code.UmInscrito.getIdCurso() + "&regiao=" + app_code.UmInscrito.getIdRegiao() + "&idInte=" + retIdInteressado.ToString() ;
                        //UrlAmigavel UrlAmigavel = new UrlAmigavel();
                        //UrlAmigavel.AdicionarUrlAmigavel("Confirmar", "~/confirma.aspx?" + destinationURL);
                        //Response.Redirect("Confirmar",false);
                        Response.Redirect("~/confirma.aspx?acao=0&nome=" + app_code.UmInscrito.getNome() + "&curso=" + app_code.UmInscrito.getIdCurso() + "&regiao=" + app_code.UmInscrito.getIdRegiao() + "&idInte=" + retIdInteressado.ToString() + "", false);
                    }
                    else
                    {
                        //deu errado redirect erro
                        Response.Redirect("~/erro.aspx", false);
                    }
                }
                else
                {
                    //deu errado redirect erro
                    Response.Redirect("~/erro.aspx", false);
                }
            }

        }
        #endregion
         #region EnviarURLPorEmail
        public static bool EnviaURLPorEmail(string idInteressado, string vCurso, string vRegiao)
        {

            string sql = "", curso = "";

            sql = " Select Site_Curso.Descricao AS NomeDoCurso" +
                " FROM Site_Curso_Regiao" +
                " LEFT OUTER JOIN Site_Curso ON Site_Curso_Regiao.CodCurso = Site_Curso.CodCurso" +
                " LEFT OUTER JOIN REGIAO ON Site_Curso_Regiao.CodRegiao = REGIAO.CODREGIAO" +
                " WHERE (Site_Curso_Regiao.CodCurso = " + vCurso + ") AND (Site_Curso_Regiao.CodRegiao = " + vRegiao + ")";

            DataTable dt;
            dt = app_code.Contexto.getdataTable(sql);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                curso = dr["NomeDoCurso"].ToString();
            }
            //desenvolvimento
            //string url =  "http://desenvolvimento:106/GeraBoleto1.aspx";
            string url = "http://ficha.strong.com.br/GeraBoleto1.aspx";


            string htm = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd" + "\"> " +
                                   "<HTML><HEAD><meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"/></HEAD>" +
                                   "<BODY><CENTER>" +
            "<img src=\"http://www.strong.com.br/wwwsite/images/Logo-Strong-Educacional.png\" style=\"float: left;margin-left: 20%;\" id=\"headerImage campaign-icon\" mc:label=\"header_image\" mc:edit=\"header_image\" mc:allowdesignermc:allowtext=\"\">"+
            "<img src=\"http://www.strong.com.br/wwwsite/images/FGVIDE.png\" style=\"float: right;margin-right: 20%;\" id=\"headerImage campaign-icon\" mc:label=\"header_image\" mc:edit=\"header_image\" mc:allowdesignermc:allowtext=\"\">"+
                                   "<br><br>Informamos que a sua inscrição para o curso " + curso + " foi enviada com sucesso! " +
                                   "<br>Clique no link a seguir para emitir o boleto da taxa de inscrição e/ou segunda via: " +
                                   "<A HREF=\""+ url +"?cu=" + vCurso + "&re=" + vRegiao + "&int=" + idInteressado +
                                   " \">" +
                                   "Boleto </A> <div mc:edit=\"std_footer\"><em>Strong Educacional.<br/></CENTER></BODY></HTML>";

            return app_code.Funcoes.EnviarEMail(app_code.UmInscrito.getemail(), "Boleto de Inscrição", htm, "", "");
        }
        #endregion
        #endregion

        #region Populaçao dos Campos.
         #region pupulaCursoPelaQueryString
        public void pupulaCurso(string cur)
        {

            if (ddlCatCur.SelectedValue == "-1")
            {
                ddlCurso.SelectedIndex = 0;
                ddlRegiao.SelectedIndex = 0;
                ddlCurso.Enabled = false;
                ddlRegiao.Enabled = false;
            }
            else
            {
                ddlCurso.Enabled = true;
                ddlCurso.DataSource = app_code.Aplicacao.RetornoCurso(ddlCatCur.SelectedValue.ToString());
                ddlCurso.DataTextField = "Descricao";
                ddlCurso.DataValueField = "CodCurso";
                ddlCurso.DataBind();

            }

            if (cur != "99")
            {
                ddlCurso.SelectedValue = cur;
            }
        }
        #endregion
         #region PopulaCurso
        protected void ddlCatCur_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlCatCur.SelectedValue == "-1")
            {
                ddlCurso.SelectedIndex = 0;
                ddlRegiao.SelectedIndex = 0;
                ddlCurso.Enabled = false;
                ddlRegiao.Enabled = false;
            }
            else
            {
                ddlCurso.Enabled = true;
                ddlCurso.DataSource = app_code.Aplicacao.RetornoCurso(ddlCatCur.SelectedValue.ToString());
                ddlCurso.DataTextField = "Descricao";
                ddlCurso.DataValueField = "CodCurso";
                ddlCurso.DataBind();

                ListItem listCat = new ListItem("Selecione Cursos", "-1");
                ddlCurso.Items.Insert(0, listCat);

            }
        }
        #endregion
         #region populaRegiaoPelaQueryString

        public void populaRegiao(string reg)
        {
            if (ddlCurso.SelectedValue == "-1")
            {
                ddlRegiao.SelectedIndex = 0;
                ddlRegiao.Enabled = false;
            }
            else
            {
                ddlRegiao.Enabled = true;
                ddlRegiao.DataSource = app_code.Aplicacao.RetornoRegiao(ddlCurso.SelectedValue.ToString());
                ddlRegiao.DataTextField = "NomeRegiao";
                ddlRegiao.DataValueField = "CodRegiao";
                ddlRegiao.DataBind();
                ListItem listBairro = new ListItem("Selecione Bairros", "-1");
                ddlRegiao.Items.Insert(0, listBairro);
            }
            if (reg != "99")
            {
                ddlRegiao.SelectedValue = reg;
            }

        }

        #endregion
         #region populaComoSoube
        protected void carregaddlComoSoubeInsc()
        {
            DataSet ds = app_code.Aplicacao.RetornoComoSoubeInsc();
            dllCOMOSOUBE.DataSource = ds;
            dllCOMOSOUBE.DataValueField = "CODCOMOSOUBE";
            dllCOMOSOUBE.DataTextField = "DESCRICAO";
            dllCOMOSOUBE.DataBind();
            ListItem listComoSoube = new ListItem("Selecione", "-1");
            dllCOMOSOUBE.Items.Insert(0, listComoSoube);
        }
        #endregion
         #region populaClasse
        protected void carregaddlClasse()
        {
            DataSet ds = app_code.Aplicacao.RetornoClasseInsc();
            ddlCLASSE.DataSource = ds;
            ddlCLASSE.DataValueField = "CodigoDoConselho";
            ddlCLASSE.DataTextField = "NomeDoConselho";
            ddlCLASSE.DataBind();
            ListItem listClasse = new ListItem("Selecione", "-1");
            ddlCLASSE.Items.Insert(0, listClasse);
        }
        #endregion
         #region PopulaRegiao
        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCurso.SelectedValue == "-1")
            {
                ddlRegiao.SelectedIndex = 0;
                ddlRegiao.Enabled = false;
            }
            else
            {
                ddlRegiao.Enabled = true;
                ddlRegiao.DataSource = app_code.Aplicacao.RetornoRegiao(ddlCurso.SelectedValue.ToString());
                ddlRegiao.DataTextField = "NomeRegiao";
                ddlRegiao.DataValueField = "CodRegiao";
                ddlRegiao.DataBind();
                ListItem listBairro = new ListItem("Selecione Regioes", "-1");
                ddlRegiao.Items.Insert(0, listBairro);
            }
        }
        #endregion
         #region pupulaTipoCursoInsc
        public void populaTipoCursoInsc()
        {

            DataSet ds = app_code.Aplicacao.retornoTipoCursoInsc();
            ddlCatCur.DataSource = ds;
            ddlCatCur.DataValueField = "CodCatCur";
            ddlCatCur.DataTextField = "NomCatCur";
            ddlCatCur.DataBind();
            ddlCurso.Enabled = false;
            ddlRegiao.Enabled = false;

            ListItem listCat = new ListItem("Selecione Categoria", "-1");
            ddlCatCur.Items.Insert(0, listCat);
        }
        #endregion
         #region pupulaCategiriaDoCurso
        public void pupulaTipoCurso(string cat)
        {

            DataSet ds = app_code.Aplicacao.retornoTipoCurso(cat);
            ddlCatCur.DataSource = ds;
            ddlCatCur.DataValueField = "CodCatCur";
            ddlCatCur.DataTextField = "NomCatCur";
            ddlCatCur.DataBind();
            ddlCurso.Enabled = true;
            ddlRegiao.Enabled = true;

            ListItem listCat = new ListItem("Selecione Categoria", "-1");
            ddlCatCur.Items.Insert(0, listCat);
            ListItem listCur = new ListItem("Selecione Curso", "-1");
            ddlCurso.Items.Insert(0, listCur);
            ListItem listReg = new ListItem("Selecione Bairros", "-1");
            ddlRegiao.Items.Insert(0, listReg);

            if (cat != "99")
            {
                ddlCatCur.SelectedValue = cat;
            }
        }
        #endregion
        #endregion

        #region ValidaCamposFinal
        public bool ValidaCamposInsc()
        {

            if (ddlCatCur.SelectedValue == "-1")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione um tipo de curso.";
                return true;
            }

            if (ddlCurso.SelectedValue == "-1")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione um curso.";
                return true;
            }

            if (ddlRegiao.SelectedValue == "-1")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione uma região.";
                return true;
            }

            if (formacao.Text == "")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, informe a instituicao de formação.";
                return true;
            }

            if (ddlPeriodo.SelectedValue == "--Selecione--")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione um período.";
                return true;
            }

            if (realname.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o nome digitado.";
                return true;
            }

            if (Data_Nascimento.Text.Length < 10)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique a data de nascimento digitada.";
                return true;
            }

            if (Cidade_Nascimento.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique a cidade de nascimento digitada.";
                return true;
            }

            if (txtUF.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o estado (UF) digitado.";
                return true;
            }

            if (ddlESTADOCIVIL.SelectedValue == "SEL")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione um estado civil.";
                return true;
            }

            if (cpf.Text.Length < 11)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o cpf digitado.";
                return true;
            }

            if (rg.Text.Length < 8)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o rg digitado.";
                return true;
            }

            if (rgem.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o orgão emissor digitado.";
                return true;
            }

            if (PAISNASC.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o pais de nacimento digitado.";
                return true;
            }

            if (EMail.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o email digitado.";
                return true;
            }

            if (CEP.Text.Length < 8)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o cep digitado.";
                return true;
            }

            if (Endereco.Text.Length < 10)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o endereço digitado.";
                return true;
            }

            if (NUMERO.Text.Length < 1)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o numero digitado.";
                return true;
            }

            if (Bairro.Text.Length < 1)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o bairro digitado.";
                return true;
            }

            if (Cidade.Text.Length < 1)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique a cidade digitada.";
                return true;
            }

            if (txtEstadoER.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o estado empresarial digitado.";
                return true;
            }

            if (txtDDD.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o DDD do telefone digitado.";
                return true;
            }

            if (txtTEL.Text.Length < 8)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o telefone digitado.";
                return true;
            }

            if (txtDDDCEL.Text.Length < 2)
            {
                txtDDDCEL.Text = " ";
            }

            if (txtCEL.Text.Length < 9)
            {
                txtCEL.Text = " ";
            }

            if (Curso_Universitario.Text.Length < 5)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o curso universitário digitado.";
                return true;
            }

            if (Ano_Conclusao.Text.Length < 4)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o ano de conclusão digitado. ";
                return true;
            }

            //if (folder.SelectedValue == "0")
            //{
            //    lMensagem.Visible = true;
            //    lMensagem.Text = "Por Favor, selecione um Folder.";
            //    return true;
            //}

            if (ddlCLASSE.SelectedValue == "-1")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione uma associação.";
                return true;
            }

            if (dllCOMOSOUBE.SelectedValue == "-1")
            {
                lMensagem.Visible = true;

                lMensagem.Text = "Por Favor, selecione um \"Como Soube\"";
                return true;
            }

            if (Curso_Universitario2.Text.Length < 5)
            {
                Curso_Universitario2.Text = " ";
            }

            if (Ano_Conclusao2.Text.Length < 4)
            {
                Ano_Conclusao2.Text = " ";
            }

            if (formacao2.Text.Length < 2)
            {
                formacao2.Text = " ";
            }

            if (Empresa.Text.Length < 3)
            {
                Empresa.Text = " ";
            }

            if (CARGOCOMPLETO.Text.Length < 4)
            {
                CARGOCOMPLETO.Text = " ";
            }

            if (ddlCargo.Text == "Selecione")
            {
                ddlCargo.Text = " ";
            }

            if (DTADMISSAO.Text.Length < 4)
            {
                DTADMISSAO.Text = "";
            }

            if (EMail_Com.Text.Length < 5)
            {
                EMail_Com.Text = " ";
            }

            if (CEP_Profissional.Text.Length < 5)
            {
                CEP_Profissional.Text = "00000000";
            }

            if (Endereco_Profissional.Text.Length < 5)
            {
                Endereco_Profissional.Text = " ";
            }

            if (NUMERO_Profissional.Text.Length < 2)
            {
                NUMERO_Profissional.Text = "0";
            }

            if (COMPLEMENTO_Profissional.Text.Length < 2)
            {
                COMPLEMENTO_Profissional.Text = " ";
            }

            if (bairro_profissional.Text.Length < 2)
            {
                bairro_profissional.Text = " ";
            }

            if (Cidade_Profissional.Text.Length < 2)
            {
                Cidade_Profissional.Text = " ";
            }

            if (txtEstadoEP.Text.Length < 2)
            {
                txtEstadoEP.Text = " ";
            }

            if (Perfil.Text == "Selecione")
            {
                Perfil.Text = " ";
            }

            if (DDD_Telefone_Profissional.Text.Length < 2)
            {
                DDD_Telefone_Profissional.Text = "00";
            }

            if (Telefone_Profissional.Text.Length < 8)
            {
                Telefone_Profissional.Text = "00000000";
            }

            if (DDD_Fax_Profissional.Text.Length < 2)
            {
                DDD_Fax_Profissional.Text = "00";
            }

            if (Fax_Profissional.Text.Length < 8)
            {
                Fax_Profissional.Text = "00000000";
            }

            return false;
        }
        #endregion

        #region Validação Individual dos Passos.
         #region ValidaPasso1
        protected void Avanca1_Click(object sender, EventArgs e)
        {

            var bol = 0;

            if (ddlCatCur.SelectedValue == "-1")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione um tipo de curso.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (ddlCurso.SelectedValue == "-1")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione um curso.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (ddlRegiao.SelectedValue == "-1")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione uma região.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            //if (folder.SelectedValue == "0")
            //{
            //    lMensagem.Visible = true;
            //    lMensagem.Text = "Por Favor, selecione um Folder.";
            //    bol = 1;
            //    lblErroI.Style.Add("display", "block");
            //    return;
            //}

            if (ddlCLASSE.SelectedValue == "-1")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione uma associação.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (dllCOMOSOUBE.SelectedValue == "-1")
            {
                lMensagem.Visible = true;

                lMensagem.Text = "Por Favor, selecione um \"Como Soube\"";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (bol == 0) //SE BOL FOR 0 ENTAO NAO DEU NENHUM ERRO E ELE TROCA O CSS DEIXANDO O PAINEL 1 INVISIVEL E O 2 VISIVEL.
            {
                divPasso1.Style.Add("display", "none");
                divPasso2.Style.Add("display", "block");
                lMensagem.Visible = false;
                lblErroI.Style.Add("display", "none");
                pnlP1.Visible = false;
                pnlP2.Visible = true;

            }
            else
            {

            }
        }

        #endregion
         #region ValidaPasso2
        protected void Avanca2_Click(object sender, EventArgs e)
        {

            var bol = 0;

            if (realname.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o nome digitado.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (ddlSexo.Text == "Selecione")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o Sexo escolhido.";
                lblErroI.Style.Add("display", "block");
                bol = 1;
                return;
            }

            if (Data_Nascimento.Text.Length < 10)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique a data de nascimento digitada.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (Cidade_Nascimento.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique a cidade de nascimento digitada.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (txtUF.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o estado (UF) digitado.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (ddlESTADOCIVIL.SelectedValue == "SEL")
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, selecione um estado civil.";
                bol = 1;
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (cpf.Text.Length < 11)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o cpf digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (rg.Text.Length < 8)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o rg digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (rgem.Text.Length < 2)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o orgão emissor digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (PAISNASC.Text.Length < 2)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o pais de nacimento digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (EMail.Text.Length < 2)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o email digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (CEP.Text.Length < 8)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o cep digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (Endereco.Text.Length < 10)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o endereço digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (NUMERO.Text.Length < 1)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o numero digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (Bairro.Text.Length < 1)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o bairro digitado.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (Cidade.Text.Length < 1)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique a cidade digitada.";
                lblErroI.Style.Add("display", "block");
                return;
            }

            if (txtEstadoER.Text.Length < 2)
            {
                bol = 1;
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o estado empresarial digitado.";
                lblErroI.Style.Add("display", "block");
                bol = 1;
                return;
            }

            if (txtDDD.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o DDD do telefone digitado.";
                lblErroI.Style.Add("display", "block");
                bol = 1;
                return;
            }

            if (txtTEL.Text.Length < 8)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o telefone digitado.";
                lblErroI.Style.Add("display", "block");
                bol = 1;
                return;
            }

            if (txtDDDCEL.Text.Length < 2)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o DDD do celular digitado";
                lblErroI.Style.Add("display", "block");
                bol = 1;
                return;

            }

            if (txtCEL.Text.Length < 9)
            {
                lMensagem.Visible = true;
                lMensagem.Text = "Por Favor, verifique o celular digitado.";
                lblErroI.Style.Add("display", "block");
                bol = 1;
                return;
            }

          


            if (bol == 0)  //SE BOL FOR 0 ENTAO NAO DEU NENHUM ERRO E ELE TROCA O CSS DEIXANDO O PAINEL 2 INVISIVEL E O 3 VISIVEL.
            {
                divPasso2.Style.Add("display", "none");
                divPasso3.Style.Add("display", "block");
                lblErroI.Style.Add("display", "none");
                lMensagem.Visible = false;
                pnlP2.Visible = false;
                pnlP3.Visible = true;
            }

        }
        #endregion
        #endregion

        #region Menu De Navegação dos Passos.
         #region MenuPasso1
        protected void lblP12_Click(object sender, EventArgs e)
        {
            divPasso1.Style.Add("display", "block");
            pnlP1.Visible = true;
            divPasso2.Style.Add("display", "none");
            pnlP2.Visible = false;
            divPasso3.Style.Add("display", "none");
            pnlP3.Visible = false;
        }
        #endregion
         #region MenuPasso2
        protected void lblP13_Click(object sender, EventArgs e)
        {
            divPasso1.Style.Add("display", "block");
            pnlP1.Visible = true;
            divPasso2.Style.Add("display", "none");
            pnlP2.Visible = false;
            divPasso3.Style.Add("display", "none");
            pnlP3.Visible = false;
        }
        #endregion
         #region MenuPasso3
        protected void lblP23_Click(object sender, EventArgs e)
        {
            divPasso1.Style.Add("display", "none");
            pnlP1.Visible = false;
            divPasso2.Style.Add("display", "block");
            pnlP2.Visible = true;
            divPasso3.Style.Add("display", "none");
            pnlP3.Visible = false;
        }
        #endregion
        #endregion
    }
}