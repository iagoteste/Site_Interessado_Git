using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Site_Interessado
{

    public partial class interessado : System.Web.UI.Page
    {
        string lb22;
        string lb11;
        #region Construtor
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
                    populaPergunta();
                    carregaddlComoSoube();
                    l1.Text = lb11;
                    l2.Text = lb22;
                }
                else
                {
                    //99 define a seleção normal sem url
                    pupulaTipoCurso("99");
                    carregaddlComoSoube();
                }


            }
        }
        #endregion

        #region pupulaCategiriaDoCurso
        public void pupulaTipoCurso(string cat)
        {
            //DataSet ds = app_code.Aplicacao.retornoTipoCurso(cat);
            //ddlCatCur.DataSource = ds;
            //ddlCatCur.DataValueField = "CodCatCur";
            //ddlCatCur.DataTextField = "NomCatCur";
            //ddlCatCur.DataBind();
            //ddlCurso.Enabled = true;
            //ddlRegiao.Enabled = true;

            //ListItem listCat = new ListItem("Selecione Categoria", "-1");
            //ddlCatCur.Items.Insert(0, listCat);
            //ListItem listCur = new ListItem("Selecione Curso", "-1");
            //ddlCurso.Items.Insert(0, listCur);
            //ListItem listReg = new ListItem("Selecione Bairros", "-1");
            //ddlRegiao.Items.Insert(0, listReg);

            //if (cat != "99")
            //{
            //    ddlCatCur.SelectedValue = cat;
            //}

            DataTable dt = app_code.Aplicacao.retornoTipoCursoDt(cat);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                //labe = labe + dr["NomCatCur"].ToString();

            }





        }
        #endregion

        #region pupulaCursoPelaQueryString
        public void pupulaCurso(string cur)
        {

            //    if (ddlCatCur.SelectedValue == "-1")
            //    {
            //        ddlCurso.SelectedIndex = 0;
            //        ddlRegiao.SelectedIndex = 0;
            //        ddlCurso.Enabled = false;
            //        ddlRegiao.Enabled = false;
            //    }
            //    else
            //    {
            //        ddlCurso.Enabled = true;
            //        ddlCurso.DataSource = app_code.Aplicacao.RetornoCurso(ddlCatCur.SelectedValue.ToString());
            //        ddlCurso.DataTextField = "Descricao";
            //        ddlCurso.DataValueField = "CodCurso";
            //        ddlCurso.DataBind();

            //    }

            //    if (cur != "99")
            //    {
            //        ddlCurso.SelectedValue = cur;
            //    }


            DataTable dt = app_code.Aplicacao.RetornoCursoDt(cur);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];


                string b = dr["CodCurso"].ToString();
                app_code.UmInteressado.setIdCurso(b);

                lb11 = dr["Descricao"].ToString();


            }

        }
        #endregion

        #region pupulaCursoPelaCategoriaDoCurso
        //protected void ddlCatCur_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlCatCur.SelectedValue == "-1")
        //    {
        //        ddlCurso.SelectedIndex = 0;
        //        ddlRegiao.SelectedIndex = 0;
        //        ddlCurso.Enabled = false;
        //        ddlRegiao.Enabled = false;
        //    }
        //    else
        //    {
        //        ddlCurso.Enabled = true;
        //        ddlCurso.DataSource = app_code.Aplicacao.RetornoCurso(ddlCatCur.SelectedValue.ToString());
        //        ddlCurso.DataTextField = "Descricao";
        //        ddlCurso.DataValueField = "CodCurso";
        //        ddlCurso.DataBind();

        //    }
        //}
        #endregion

        #region populaRegiaoPelaQueryStrung

        public void populaRegiao(string reg)
        {
            //    if (ddlCurso.SelectedValue == "-1")
            //    {
            //        ddlRegiao.SelectedIndex = 0;
            //        ddlRegiao.Enabled = false;
            //    }
            //    else
            //    {
            //        ddlRegiao.Enabled = true;
            //        ddlRegiao.DataSource = app_code.Aplicacao.RetornoRegiao(ddlCurso.SelectedValue.ToString());
            //        ddlRegiao.DataTextField = "NomeRegiao";
            //        ddlRegiao.DataValueField = "CodRegiao";
            //        ddlRegiao.DataBind();
            //        ListItem listBairro = new ListItem("Selecione Bairros", "-1");
            //        ddlRegiao.Items.Insert(0, listBairro);
            //    }
            //    if(reg != "99")
            //    {
            //        ddlRegiao.SelectedValue = reg;
            //    }

            DataTable dt = app_code.Aplicacao.RetornoRegiaoDt(reg);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                string b = dr["CodRegiao"].ToString();
                lb22 = dr["DESCRICAO"].ToString();
                app_code.UmInteressado.setIdRegiao(b);


                //lblInteresse.Text = app_code.UmInteressado.getIdRegiao();


            }


        }

        #endregion

        #region pupulaRegiaoPeloCurso
        //protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlCurso.SelectedValue == "-1")
        //    {
        //        ddlRegiao.SelectedIndex = 0;
        //        ddlRegiao.Enabled = false;
        //    }
        //    else
        //    {
        //        ddlRegiao.Enabled = true;
        //        ddlRegiao.DataSource = app_code.Aplicacao.RetornoRegiao(ddlCurso.SelectedValue.ToString());
        //        ddlRegiao.DataTextField = "NomeRegiao";
        //        ddlRegiao.DataValueField = "CodRegiao";
        //        ddlRegiao.DataBind();
        //        ListItem listBairro = new ListItem("Selecione Bairros", "-1");
        //        ddlRegiao.Items.Insert(0, listBairro);
        //    }
        //}
        #endregion

        #region populaComoSoube
        protected void carregaddlComoSoube()
        {
            DataSet ds = app_code.Aplicacao.RetornoComoSoube();
            dllCOMOSOUBE.DataSource = ds;
            dllCOMOSOUBE.DataValueField = "CODCOMOSOUBE";
            dllCOMOSOUBE.DataTextField = "DESCRICAO";
            dllCOMOSOUBE.DataBind();
            ListItem listComoSoube = new ListItem("Selecione", "-1");
            dllCOMOSOUBE.Items.Insert(0, listComoSoube);
        }
        #endregion

        #region populaPerguntaPelaRegiao
        protected void ddlRegiao_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DataTable dt = app_code.Aplicacao.RetornaPergunta(ddlRegiao.SelectedValue.ToString());
            DataTable dt = app_code.Aplicacao.RetornaPergunta(app_code.UmInteressado.getIdRegiao());

            if (dt.Rows.Count > 0)
            {
                string idPergunta;
                idPergunta = "";

                DataRow dr = dt.Rows[0];

                lblPergunta.Text = dr["txtPergunta"].ToString();
                idPergunta = dr["idPergunta"].ToString();

                app_code.UmInteressado.setIdPergunta(idPergunta);

                DataTable dtb = app_code.Aplicacao.RetornaResposta(idPergunta);

                if (dtb.Rows.Count > 0)
                {
                    bool temResp;
                    temResp = true;

                    app_code.UmInteressado.setTemResp(temResp);

                    rdbRespostas.DataSource = dtb;
                    rdbRespostas.DataValueField = dtb.Columns[0].ToString();
                    rdbRespostas.DataTextField = dtb.Columns[2].ToString();

                    rdbRespostas.DataBind();
                }
            }

        }
        #endregion

        #region PopulaPergunta
        public void populaPergunta()
        {

            //DataTable dt = app_code.Aplicacao.RetornaPergunta(ddlRegiao.SelectedValue.ToString());
            DataTable dt = app_code.Aplicacao.RetornaPergunta(app_code.UmInteressado.getIdRegiao());

            if (dt.Rows.Count > 0)
            {
                string idPergunta;
                idPergunta = "";

                DataRow dr = dt.Rows[0];

                lblPergunta.Text = dr["txtPergunta"].ToString();
                idPergunta = dr["idPergunta"].ToString();

                app_code.UmInteressado.setIdPergunta(idPergunta);

                DataTable dtb = app_code.Aplicacao.RetornaResposta(idPergunta);

                if (dtb.Rows.Count > 0)
                {
                    bool temResp;
                    temResp = true;

                    app_code.UmInteressado.setTemResp(temResp);

                    rdbRespostas.DataSource = dtb;
                    rdbRespostas.DataValueField = dtb.Columns[0].ToString();
                    rdbRespostas.DataTextField = dtb.Columns[2].ToString();

                    rdbRespostas.DataBind();
                }
            }

        }
        #endregion

        #region BtnEnviar
        protected void Button1_Click(object sender, EventArgs e)
        {
            string retIdInteressado, EMailOrigem, ParaMail, Assunto, Anexo, comCopia;

            bool podeIncluir;
            podeIncluir = false;

            retIdInteressado = "";
            EMailOrigem = "";
            ParaMail = "";
            Assunto = "Strong - Confirmaçao de Interesse";
            Anexo = "";
            comCopia = "";


            //app_code.UmInteressado.setIdCurso(ddlCurso.SelectedValue.ToString());
            //app_code.UmInteressado.setIdRegiao(ddlRegiao.SelectedValue.ToString());
            app_code.UmInteressado.setSexo(sexo.SelectedValue.ToString());
            app_code.UmInteressado.setNome(realname.Text.ToString());
            app_code.UmInteressado.setDdd(DDD.Text.ToString());
            app_code.UmInteressado.setTel(TEL.Text.ToString());
            app_code.UmInteressado.setIdComoSoube(dllCOMOSOUBE.SelectedValue.ToString());
            app_code.UmInteressado.setNmComoSoube(dllCOMOSOUBE.SelectedItem.ToString());
            app_code.UmInteressado.setEmail(EMail.Text.ToString());
            app_code.UmInteressado.setPeriodo(Periodo.SelectedValue.ToString());
            app_code.UmInteressado.setDtNascimanto(Data_Nascimento.Text.ToString());
            app_code.UmInteressado.setIdResposta(rdbRespostas.SelectedValue.ToString());

            if (Session["insertRealizadoPor"] == null) // 1a. entrada - pode incluir
            {
                Session["insertRealizadoPor"] = "interesse_" + app_code.UmInteressado.getIdCurso() + "_" + app_code.UmInteressado.getIdRegiao() + "_" + app_code.UmInteressado.getNome();
                podeIncluir = true;
            }
            else
                if (Session["insertRealizadoPor"].ToString() != "interesse_" + app_code.UmInteressado.getIdCurso() + "_" + app_code.UmInteressado.getIdRegiao() + "_" + app_code.UmInteressado.getNome()) // não é 1a. entrada mas mudou algo - pode incluir
                {
                    Session["insertRealizadoPor"] = "interesse_" + app_code.UmInteressado.getIdCurso() + "_" + app_code.UmInteressado.getIdRegiao() + "_" + app_code.UmInteressado.getNome();
                    podeIncluir = true;
                }

            if (ValidaCampos())
            {

                //Verifica se pode incluir
                if (podeIncluir)
                {
                    retIdInteressado = app_code.Aplicacao.InsertDadosInteressado();

                    DataTable dt = app_code.Aplicacao.RetornaParametroEmail(app_code.UmInteressado.getIdCurso(), app_code.UmInteressado.getIdRegiao());

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        EMailOrigem = dr["EMAilFrom"].ToString();
                        ParaMail = dr["EMailName"].ToString();
                    }

                    bool enviado;
                    enviado = false;

                    enviado = app_code.Funcoes.EnviarEMail(app_code.UmInteressado.getEmail(), Assunto, app_code.Aplicacao.RetornaTextoHtmlEmail(app_code.UmInteressado.getIdCurso(), app_code.UmInteressado.getIdRegiao()), Anexo, comCopia);


                    if (enviado)
                    {
                        //deu tudo certo
                        //Response.Redirect(HttpUtility.UrlEncode("~/confirma.aspx?curso=" + app_code.UmInteressado.getIdCurso() + "&regiao=" + app_code.UmInteressado.getIdRegiao() + "&idInte=" + retIdInteressado) , true);
                        Response.Redirect("~/confirma.aspx?acao=interesse&nome=" + app_code.UmInteressado.getNome() + "&curso=" + app_code.UmInteressado.getIdCurso() + "&regiao=" + app_code.UmInteressado.getIdRegiao() + "&idInte=" + retIdInteressado.ToString() + "", false);
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

        #region validaCampos
        public bool ValidaCampos()
        {
            string erros = "";
            lMensagem.Text = "";

            //if (ddlCatCur.SelectedValue.ToString() == "-1")
            //{
            //    erros += "Por favor, selecione o Tipo de Curso desejado ..." + "<br />";
            //}
            //else
            //    if (ddlCurso.SelectedValue.ToString() == "-1")
            //    {
            //        erros += "Por favor, selecione o Curso desejado ..." + "<br />";
            //    }
            //    else
            //        if (ddlRegiao.SelectedValue.ToString() == "-1")
            //        {
            //            erros += "Por favor, indique a Região ..." + "<br />";
            //        }
            //        else

            if (realname.Text == "")
            {
                erros += "*Por favor, preencha seu Nome ..." + "<br />";
            }
            else
                if (EMail.Text == "")
                {
                    erros += "*Por favor, preencha seu E-MAIL ..." + "<br />";
                }

                else
                    if (DDD.Text == "")
                    {
                        erros += "*Por favor, indique o DDD ..." + "<br />";
                    }
                    else
                        if (TEL.Text == "")
                        {
                            erros += "*Por favor, indique o Telefone corretamente ..." + "<br />";
                        }
                        else

                            if (sexo.SelectedValue == "Selecione")
                            {
                                erros += "*Por favor, selecione o sexo ..." + "<br />";
                            }
                            else

                                if (Data_Nascimento.Text == "")
                                {
                                    erros += "*Por favor, informe sua data de nascimento ..." + "<br />";
                                }
                                else
                                    if (dllCOMOSOUBE.SelectedValue.ToString() == "-1")
                                    {
                                        erros += "*Por favor, informe como soube dos nossos cursos ..." + "<br />";
                                    }
                                    else
                                        if (Periodo.SelectedValue.ToString() == "--Selecione--")
                                        {
                                            erros += "*Por favor, indique o Periodo de interesse" + "<br />";
                                        }
                                        else
                                            if (rdbRespostas.SelectedIndex.ToString() == "-1")
                                            {
                                                erros += "*Por favor, informe sua resposta ..." + "<br />";
                                            }


            if (erros == "")
            {
                return true;
            }
            else
            {
                lMensagem.Text = erros;
                lblErro.Style.Add("display", "block");
                return false;
            }

        }
        #endregion
    }//
}//