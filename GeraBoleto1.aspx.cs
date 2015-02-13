using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_Interessado
{
    public partial class GeraBoleto1 : System.Web.UI.Page
    {
        #region variaveis
        protected PlaceHolder areaListagem, areaBoleto;

        protected string vStaBaiTes, vStaBaiAca, vStaRemess, vNumMatri, vTextoDaReferencia, sDataDoBoleto,
            sNumBoletoNaFicha, sTextoCodAgeCed, sCodigoDeBarras, sLinhaDigitada, vMoraCalculada, vBancoCodigo,
            vNomeDoCedente, vTextoDoBoleto1, vTextoDoBoleto2, vTextoDoBoleto3, vUsoBanco, vBancoCarteira,
            vCodMatrEvento, vrealname, vBairro, vCidade, vEstado, vCEP, vcpf, vNUMERO, vCOMPLEMENTO,
            vRG, vRGEm, vValorParaCalculo, vValorInscricao, vDataDeVencimento, vEveOri, vCodRgr, vDtEmissaoBoleto, vNumInscri;


        protected string TextoInicialDoBoleto, sOrgBanBol, sFanBanBol, sNumBanBol, vFichaCpf, vFichaCep,
            TextoVencimento, TextoHtml, espacoIMG, vTextoDaInscricao1, vNome, vCpf, vRg, vCep, vEndereco,
            sDataHoje, vNomeDoCurso, vNomeDaRegiao;

        protected string vBancoAgencia, vNumeroUltimoBoleto, sNumBoleto, vBancoIde,
            vBancoCodAgeCed, sValorInscricao, Prov, vTipoDeVencimento, vDeltaDeVencimento, NumeroAmpliadoGeral,
            sTabVencimento, sTextInicBarra, Comprimento, vPeriodo, sPeriodo, vNumBoletot;
        protected int Fator1, Fator2, Multiplicacao, vNumBoleto, vNumeroUltimaInscricao;

        protected string[] aAcesso;
        #endregion

        #region load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
            }

            string erro = "";


            if ((Request.QueryString["cu"].ToString() != "" && Request.QueryString["re"].ToString() != "" && Request.QueryString["int"].ToString() != ""))
            {
                erro = showBoletoLocal(Request.QueryString["cu"].ToString(), Request.QueryString["re"].ToString(), Request.QueryString["int"].ToString());
            }
            else
            {
                erro = "Parâmetros inválidos. Favor consultar o administrador do portal.";
            }

            if (erro != "")
            {
                areaListagem.Controls.Clear();
                areaListagem.Controls.Add(new LiteralControl(erro));
            }

        }
        #endregion load

        #region FUNÇÕES
        protected string showBoletoLocal(string vCurso, string vRegiao, string IdInteressado)
        {
            string sql = "", sqlv = "", sqlb = "", erro = "",//bolMensagemEspecifica = "";
                 sLinDigit1 = "", sLinDigit2 = "", sLinDigit3 = "",
                 sLinDigit4 = "", sLinDigit5 = "";
                

            int TxtLength = 0, DeterminaImpar = 0, CheckCodBarras = 0, CheckDigit = 0;

            //ref a data do processamento do boleto
            sDataHoje = DateTime.Now.ToString("d");

            DataTable dt = null;
            DataTable dtr = null;
            DataTable dtt = null;
            DataRow dr = null;

            if (IdInteressado != "")
            {
                sqlb = "Select realname, cpf, rg, CEP, endereco, Bairro," +
                        "Cidade, rgem, NUMERO, COMPLEMENTO, Estado, Periodo from site_inscricao where id=" + IdInteressado;

                dtt = app_code.Contexto.getdataTable(sqlb);
            }
            if (dtt.Rows.Count > 0)
            {
                dr = dtt.Rows[0];

                vNome = dr["realname"].ToString();
                vCpf = dr["cpf"].ToString();
                vRg = dr["rg"].ToString();
                vCep = dr["CEP"].ToString();
                vEndereco = dr["Endereco"].ToString();
                vBairro = dr["Bairro"].ToString();
                vCidade = dr["Cidade"].ToString();
                vRGEm = dr["rgem"].ToString();
                vNUMERO = dr["NUMERO"].ToString();
                vCOMPLEMENTO = dr["COMPLEMENTO"].ToString();
                vEstado = dr["Estado"].ToString();
                vPeriodo = dr["Periodo"].ToString();
            }

            switch (vPeriodo)
            {
                case "1":
                    sPeriodo = "TODOS";
                    break;
                case "2":
                    sPeriodo = "DIURNO|SÁBADOS";
                    break;
                default:
                    sPeriodo = "NOTURNO";
                    break;
            }

            if (vCurso != "" || vRegiao != "")
            {
                sqlv = "SELECT Site_Curso_Regiao.CodCurso, Site_Curso_Regiao.CodRegiao," +
                    " Site_Curso_Regiao.TxtHtml1, Site_Curso_Regiao.TxtHtml2," +
                    " Site_Curso_Regiao.TxtHtml3, Site_Curso_Regiao.CobraInscricao," +
                    " Site_Curso_Regiao.ValorInscricao, Site_Curso_Regiao.TipoDeVencimento," +
                    " Site_Curso_Regiao.DataDeVencimento, Site_Curso_Regiao.DeltaDeVencimento," +
                    " Site_Curso.Descricao AS NomeDoCurso, REGIAO.DESCRICAO AS NomeDaRegiao" +
                    " FROM Site_Curso_Regiao" +
                    " LEFT OUTER JOIN Site_Curso ON Site_Curso_Regiao.CodCurso = Site_Curso.CodCurso" +
                    " LEFT OUTER JOIN REGIAO ON Site_Curso_Regiao.CodRegiao = REGIAO.CODREGIAO" +
                    " WHERE (Site_Curso_Regiao.CodCurso = " + vCurso + ") AND (Site_Curso_Regiao.CodRegiao = " + vRegiao + ")";

                dtr = app_code.Contexto.getdataTable(sqlv);
            }
            if (dtr.Rows.Count > 0)
            {
                dr = dtr.Rows[0];

                //vCobraInscricao = dr["CobraInscricao"].ToString();	
                vValorInscricao = dr["ValorInscricao"].ToString();
                vNomeDoCurso = dr["NomeDoCurso"].ToString();
                vNomeDaRegiao = dr["NomeDaRegiao"].ToString();                
                //vTipoDeVencimento = dr["TipoDeVencimento"].ToString();
                vDataDeVencimento = dr["DataDeVencimento"].ToString();
                // vDeltaDeVencimento = dr["DeltaDeVencimento"].ToString();
            }

            //verificar se cobra a inscrição
            sql = "SELECT PARAMETROINSCRITO.NumeroUltimaInscricao, ContasBancarias.NomeDoCedente," +
                " PARAMETROINSCRITO.TextoDoBoleto1, PARAMETROINSCRITO.TextoDoBoleto2, PARAMETROINSCRITO.TextoDoBoleto3," +
                " PARAMETROINSCRITO.TextoDaInscricao1, PARAMETROINSCRITO.TextoDaInscricao2, PARAMETROINSCRITO.BcoIde," +
                " ContasBancarias.BancoCodigo, ContasBancarias.BancoAgencia, ContasBancarias.UsoDoBanco," +
                " ContasBancarias.BancoConta, ContasBancarias.BancoCodAgeCed," +
                " ContasBancarias.BancoCarteira,  ContasBancarias.NumeroUltimoBoleto" +
                " FROM ContasBancarias" +
                " RIGHT OUTER JOIN PARAMETROINSCRITO ON ContasBancarias.Id = PARAMETROINSCRITO.BcoIde";

            dt = app_code.Contexto.getdataTable(sql);

            if (dt.Rows.Count > 0)
            {

                dr = dt.Rows[0];

                vBancoIde=dr["BcoIde"].ToString();
                //sCodigoDeBarras = dr["CodigoDeBarras"].ToString();
                vBancoCodigo = dr["BancoCodigo"].ToString();
                vBancoAgencia = dr["BancoAgencia"].ToString();
                vNumeroUltimoBoleto = dr["NumeroUltimoBoleto"].ToString();
                vNumBoleto = Convert.ToInt32(vNumeroUltimoBoleto);
                vBancoCodAgeCed = dr["BancoCodAgeCed"].ToString();
                //vTipoDeVencimento = dr["TipoDeVencimento"].ToString();
                vNumeroUltimoBoleto = dr["NumeroUltimoBoleto"].ToString();
                vNomeDoCedente=dr["NomeDoCedente"].ToString();	
                vTextoDoBoleto1=dr["TextoDoBoleto1"].ToString();
                vTextoDoBoleto2=dr["TextoDoBoleto2"].ToString();		
                vTextoDoBoleto3=dr["TextoDoBoleto3"].ToString();
                vTextoDaInscricao1 = dr["TextoDaInscricao1"].ToString();
                vNumeroUltimaInscricao = Convert.ToInt32(dr["NumeroUltimaInscricao"].ToString());
                vBancoCarteira = dr["BancoCarteira"].ToString();
                vUsoBanco = dr["UsoDoBanco"].ToString();
            }

            //alteracao do numerador de boleto            
            vNumBoleto = app_code.FuncoesGeraBoleto.NumBoleto(vNumeroUltimoBoleto);           

            vNumInscri = (vNumeroUltimaInscricao + 1).ToString();

            //inicio da parte especifica do banco
            //***********************************
            if (vBancoCodigo == "33")
            {
                string sBancoAgencia = "", sBancoCodAgeCed = "";

                sOrgBanBol = "Banco do Estado de São Paulo S.A.";
                sFanBanBol = "Santander";
                sNumBanBol = "033-7";

                //trata numero da agencia
                sBancoAgencia = app_code.FuncoesGeraBoleto.GetBancoAgencia(vBancoAgencia);

                //Trata numero do boleto
                vNumBoletot = app_code.FuncoesGeraBoleto.TrataNBoleto(vNumeroUltimoBoleto.ToString());

                //Extrai espacos do CodAgeCedente - deve ficar com 11 caracteres
                sBancoCodAgeCed = app_code.FuncoesGeraBoleto.TrataCodAgeCedente(vBancoCodAgeCed);

                //Calcula CalculaCheckDigit1
                CheckDigit = app_code.FuncoesGeraBoleto.CalculaCheckDigit1(
                    sBancoCodAgeCed, vNumBoletot.ToString());

                //Calcula CalculaCheckDigit2
                NumeroAmpliadoGeral = app_code.FuncoesGeraBoleto.CalculaCheckDigit2(
                    sBancoCodAgeCed + vNumBoletot + "00033" + CheckDigit, vNumBoletot, sBancoCodAgeCed, CheckDigit);
                sTextoCodAgeCed = vBancoCodAgeCed;
                sTextInicBarra = "0339";

                sNumBoletoNaFicha = app_code.FuncoesGeraBoleto.CalculaCheckDisit3(sBancoAgencia, vNumBoletot);
            }
            //Termino da parte do banco testado até aqui esta retornando ok
            //*************************


            string sValorInscricao = "";


            //Formatacao do valor 
            sValorInscricao = vValorInscricao;
            Prov = sValorInscricao.Substring(0, (sValorInscricao.Length) - 3) + sValorInscricao.Substring(sValorInscricao.Length - 2, 2);
            if (Prov.Length < 10)
            {
                string Acrescimo = "";
                for (int i = 1; i < (10 - Prov.Length); i++)
                {
                    Acrescimo = Acrescimo + "0";
                }

                Prov = Acrescimo + Prov;
            }
            sValorInscricao = Prov;

            Prov = "";

            //Determinacao do vencimento
            
            //if (Convert.ToInt32(vTipoDeVencimento) == 0)
            //    Prov = Convert.ToDateTime(vDataDeVencimento).date1;
            //else
            //    Prov = vDataDeVencimento;

            int tDatVencim = 6497;

            //tDatVencim = Convert.ToInt32((Convert.ToDateTime(Prov).Subtract(Convert.ToDateTime("07/10/1997"))).ToString().Substring(0, 4));

            //Formatacao do vencimento
            if (tDatVencim > 9999)
            {
                DateTime date = new DateTime(1997, 10, 07);
                TimeSpan t = new TimeSpan(9999, 0, 0, 0);

                date = date.Add(t);

                string data;

                data = date.ToString();
                data = data.Substring(0, 10);


                Prov = Convert.ToDateTime("07/10/1997").ToString();
                tDatVencim = 9999;
                TextoVencimento = "-";
                sTabVencimento = data;
            }
            else
            {
                if (Convert.ToInt32(vTipoDeVencimento) == 0)
                    TextoVencimento = "-";
                else
                    TextoVencimento = Prov;


                sTabVencimento = "'" + Prov + "'";
            }


            //Codigo de barras
            //sCodigoDeBarras = sTextInicBarra + tDatVencim + sValorInscricao + NumeroAmpliadoGeral;
            sCodigoDeBarras = sTextInicBarra + "64970" + sValorInscricao + NumeroAmpliadoGeral;
            
            Comprimento = sCodigoDeBarras.Length.ToString();

            CheckCodBarras = app_code.FuncoesGeraBoleto.CheckDigitoBoleto(sCodigoDeBarras);


            //Codigo de barras completo
            sCodigoDeBarras = sCodigoDeBarras.Substring(0, 4) + CheckCodBarras + sCodigoDeBarras.Substring((sCodigoDeBarras.Length - 39), 39);

            //linha digitada - parte 1
            sLinDigit1 = sCodigoDeBarras.Substring(0, 4) + sCodigoDeBarras.Substring(19, 5);

            //checkdigit dessa parte
            TxtLength = sLinDigit1.Length;
            DeterminaImpar = TxtLength % 2;

            CheckDigit = app_code.FuncoesGeraBoleto.CheckDigito(DeterminaImpar, TxtLength, sLinDigit1);

            sLinDigit1 = sLinDigit1 + CheckDigit;
            sLinDigit1 = sLinDigit1.Substring(0, 5) + "." + sLinDigit1.Substring(sLinDigit1.Length - 5, 5);

            //linha digitada - parte 2
            sLinDigit2 = sCodigoDeBarras.Substring(24, 10);

            //checkdigit dessa parte
            TxtLength = sLinDigit2.Length;
            DeterminaImpar = TxtLength % 2;

            //
            CheckDigit = app_code.FuncoesGeraBoleto.CheckDigito(DeterminaImpar, TxtLength, sLinDigit2);
                                 

            sLinDigit2 = sLinDigit2 + CheckDigit;
            sLinDigit2 = sLinDigit2.Substring(0, 5) + "." + sLinDigit2.Substring(sLinDigit2.Length - 6, 6);

            //linha digitada - parte 3
            sLinDigit3 = sCodigoDeBarras.Substring(34, 10);

            //checkdigit dessa parte
            TxtLength = sLinDigit3.Length;
            DeterminaImpar = TxtLength % 2;

            CheckDigit = app_code.FuncoesGeraBoleto.CheckDigito(DeterminaImpar, TxtLength, sLinDigit3);

            sLinDigit3 = sLinDigit3 + CheckDigit;
            sLinDigit3 = sLinDigit3.Substring(0, 5) + "." + sLinDigit3.Substring(sLinDigit3.Length - 6, 6);

            //linha digitada - parte4         
            sLinDigit4 = sCodigoDeBarras.Substring(4, 1);

            //linha digitada - parte 5           
            sLinDigit5 = sCodigoDeBarras.Substring(5, 14);

            sLinhaDigitada = sLinDigit1 + " " + sLinDigit2 + " " + sLinDigit3 + " " + sLinDigit4 + " " + sLinDigit5;


            if (erro == "")
            { // Geracao da figura do código de barras
                string caracIni = "NNNNNN";
                string caracFim = "WNN";

                string[] tipCarac = new string[10];
                tipCarac[0] = "NNWWN";
                tipCarac[1] = "WNNNW";
                tipCarac[2] = "NWNNW";
                tipCarac[3] = "WWNNN";
                tipCarac[4] = "NNWNW";
                tipCarac[5] = "WNWNN";
                tipCarac[6] = "NWWNN";
                tipCarac[7] = "NNNWW";
                tipCarac[8] = "WNNWN";
                tipCarac[9] = "NWNWN";

                string NumeroDeEntrada = sCodigoDeBarras;
                string NumeroCodificado = "";

                for (int x = 0; x < NumeroDeEntrada.Length; x += 2)
                {
                    string sDigito1 = tipCarac[(int)NumeroDeEntrada[x] - 48];
                    string sDigito2 = tipCarac[(int)NumeroDeEntrada[x + 1] - 48];
                    string sUnidade = "";

                    for (int y = 0; y < 5; y++)
                    {
                        sUnidade += sDigito1[y].ToString() + sDigito2[y].ToString();
                    }
                    NumeroCodificado += sUnidade;
                }

                string NumeroBase = caracIni + NumeroCodificado + caracFim;

                TextoHtml = "";
                bool bBar = true;
                string ImagemGif = "";

                for (int x = 0; x < NumeroBase.Length; x++)
                {
                    if (bBar)
                    {
                        ImagemGif = NumeroBase[x] + "b.gif";
                    }
                    else
                    {
                        ImagemGif = NumeroBase[x] + "s.gif";
                    }
                    TextoHtml += "<img src=../imagens/" + ImagemGif + ">";

                    bBar = !bBar;
                }
                espacoIMG = "../imagens/espaco.gif";
            }


            //updates

            app_code.FuncoesGeraBoleto.SetUpdateNumInscri(vNumInscri);

            app_code.FuncoesGeraBoleto.SetUpdateNumUltimoBoleto(vNumInscri, vBancoIde);


            if (erro == "")
            {
                areaBoleto.Visible = true;
            }

            return erro;
        }
        //----------------------------------------------------------------------
        #endregion

    }//
}//