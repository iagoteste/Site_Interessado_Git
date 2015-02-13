    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Site_Interessado.app_code
{
    public static class Aplicacao
    {
        //Inicio Interesse

        #region InsertDadosInteressado
        public static string InsertDadosInteressado()
        {
            string sSql;
            sSql = "";

            int t;
            t = 0;

            //pega a qtd de caracter da string 
            t = UmInteressado.getNmComoSoube().Length;

            // testa se o tamanho do texto é maior que o tamanho do campo que é 25
            if (t > 25)
                t = 24;
            else
                t = t - 1;
            

            

            sSql = "SET NOCOUNT ON insert into Site_Interessado (" +
                    "CodigoDoConselho, Curso, Regiao, Sexo, " +
                    "realname, DDD, TEL, " +
                    "CODCOMOSOUBE, Como_Soube, " +
                    "EMail, Periodo, Data_Nascimento ";

            //Se não tem resposta não inclui pergunta e resposta 
            if (UmInteressado.getTemResp())
                sSql = sSql + ",idPergunta , idResposta";

            

            sSql = sSql + ") Values (" +
                 "'26','" + UmInteressado.getIdCurso() + "','" + UmInteressado.getIdRegiao() +
                 "','" + UmInteressado.getSexo() + "'," + "'" + UmInteressado.getNome() +
                 "','" + UmInteressado.getDdd() + "','" + UmInteressado.getTel() + "'," +
                 "'" + UmInteressado.getIdComoSoube() + "','" + UmInteressado.getNmComoSoube().Substring(0,t) + "'," +
                 "'" + UmInteressado.getEmail() + "','" + UmInteressado.getPeriodo() + "','" + Funcoes.FormataDataBRtoUS(UmInteressado.getDtNascimanto()) + "'";

            //Se não tem resposta não inclui pergunta e resposta 
            if (UmInteressado.getTemResp())
                sSql = sSql + ",'" + UmInteressado.getIdPergunta() + "','" + UmInteressado.getIdResposta() + "')";

            return Contexto.insertGetIdentity(sSql);

        }
        #endregion

        #region retornoTipoCurso
        public static DataSet retornoTipoCurso(string cat)
        {
            string sSql;
            sSql = "";

            sSql = "SELECT CATEGORIACURSO.DESCRICAO AS NomCatCur, CATEGORIACURSO.CODCATEGORIACURSO As CodCatCur" +
                    " FROM Site_Curso" +
                    " INNER JOIN CURSO ON Site_Curso.CodSge = CURSO.CODCURSO" +
                    " INNER JOIN CATEGORIACURSO ON CURSO.CODCATEGORIACURSO = CATEGORIACURSO.CODCATEGORIACURSO" +
                    " WHERE (Site_Curso.Ativo <> 0)" +
                    " GROUP BY CATEGORIACURSO.DESCRICAO, CATEGORIACURSO.CODCATEGORIACURSO" +
                    " ORDER BY NomCatCur";


            return Contexto.getdata(sSql);
        }
        #endregion

        #region retornoTipoCursoDt
        public static DataTable retornoTipoCursoDt(string cat)
        {
            string sSql;
            sSql = "";

            sSql = "SELECT CATEGORIACURSO.DESCRICAO AS NomCatCur, CATEGORIACURSO.CODCATEGORIACURSO As CodCatCur" +
                    " FROM Site_Curso" +
                    " INNER JOIN CURSO ON Site_Curso.CodSge = CURSO.CODCURSO" +
                    " INNER JOIN CATEGORIACURSO ON CURSO.CODCATEGORIACURSO = CATEGORIACURSO.CODCATEGORIACURSO" +
                    " WHERE (Site_Curso.Ativo <> 0)" +
                    " GROUP BY CATEGORIACURSO.DESCRICAO, CATEGORIACURSO.CODCATEGORIACURSO" +
                    " ORDER BY NomCatCur";


            return Contexto.getdataTable(sSql);
        }
        #endregion


        #region RetornoCursodt
        public static DataTable RetornoCursoDt(string idCurso)
        {
            string aSql;
            aSql = "";

            aSql = "SELECT Site_Curso.CodCurso, Site_Curso.Descricao, Site_Curso.Ativo, CURSO.CODCATEGORIACURSO"+
                   " FROM CURSO INNER JOIN Site_Curso ON CURSO.CODCURSO = Site_Curso.CodSge"+
                   " WHERE (Site_Curso.Ativo <> 0) and Site_Curso.CodCurso = '" + idCurso + "'";



            return Contexto.getdataTable(aSql);
        }
        #endregion

        #region RetornoCurso
        public static DataSet RetornoCurso(string idCatCurso)
        {
            string aSql;
            aSql = "";

            aSql = "SELECT Site_Curso.CodCurso, Site_Curso.Descricao, Site_Curso.Ativo, CURSO.CODCATEGORIACURSO" +
                    " FROM CURSO INNER JOIN Site_Curso ON CURSO.CODCURSO = Site_Curso.CodSge" +
                    " WHERE (Site_Curso.Ativo <> 0) and curso.CODCATEGORIACURSO = '" + idCatCurso + "'" +
                    " ORDER BY CURSO.CODCATEGORIACURSO, Site_Curso.Descricao";


            return Contexto.getdata(aSql);
        }
        #endregion

        #region RetornoRegiao
        public static DataSet RetornoRegiao(string idCurso)
        {
            string bSql;
            bSql = "";

            bSql = " SELECT Site_Curso_Regiao.CodCurso, Site_Curso_Regiao.CodRegiao, REGIAO.DESCRICAO AS NomeRegiao" +
                    " FROM Site_Curso_Regiao" +
                    " LEFT OUTER JOIN Site_Curso ON Site_Curso_Regiao.CodCurso = Site_Curso.CodCurso" +
                    " LEFT OUTER JOIN REGIAO ON Site_Curso_Regiao.CodRegiao = REGIAO.CODREGIAO" +
                    " where Site_Curso_Regiao.CodCurso='" + idCurso + "'";

            return Contexto.getdata(bSql);
        }
        #endregion

        #region RetornoRegiao
        public static DataTable RetornoRegiaoDt(string idRegiao)
        {
            string bSql;
            bSql = "";

            bSql = " SELECT DESCRICAO,CodRegiao FROM REGIAO where CodRegiao='" + idRegiao + "'";

            return Contexto.getdataTable(bSql);
        }
        #endregion

        #region RetornoComoSoube
        public static DataSet RetornoComoSoube()
        {
            string cSql;
            cSql = "";

            cSql = "SELECT COMOSOUBE.CODCOMOSOUBE, COMOSOUBE.DESCRICAO, COMOSOUBE.ATIVO" +
                    " FROM COMOSOUBE" +
                    " WHERE (COMOSOUBE.ATIVO <> 0)" +
                    " ORDER BY COMOSOUBE.DESCRICAO";

            return Contexto.getdata(cSql);
        }
        #endregion

        #region RetornaPergunta
        public static DataTable RetornaPergunta(string idRegiao)
        {
            string dSql;
            dSql = "";

            dSql = " SELECT idPergunta, txtPergunta,ativo,idRegiao" +
                   " FROM Pergunta " +
                   " WHERE (ativo <> 0) " +
                   " And idRegiao = '" + idRegiao + "'" +
                   " ORDER BY idPergunta DESC";


            return Contexto.getdataTable(dSql);
        }
        #endregion

        #region RetornaResposta
        public static DataTable RetornaResposta(string idPergunta)
        {
            string eSql;
            eSql = "";

            eSql = "SELECT idResposta, idPergunta, txtResposta" +
                        " FROM Resposta" +
                        " WHERE idPergunta = '" + idPergunta + "'";


            return Contexto.getdataTable(eSql);
        }
        #endregion

        #region RetornaTextoHtmlEmail
        public static string RetornaTextoHtmlEmail(string idCurso, string idRegiao)
        {
            string fSql, TextoDoEMail;
            int Contador;
            Contador = 0;
            fSql = "";
            TextoDoEMail = "";

            fSql = "SELECT Id, CodCurso, CodRegiao, Sequencia, TxtHtml" +
             " FROM Site_Curso_Regiao_Html" +
             " WHERE (CodCurso = " + idCurso + ") AND (CodRegiao = " + idRegiao + ")" +
             " ORDER BY Sequencia";

            DataTable dt = Contexto.getdataTable(fSql);

            if (dt.Rows.Count > 0)
            {

                //DataRow dr = dt.Rows[0];

                foreach (DataRow dr in dt.Rows)
                {

                    if (Contador == 0)
                    {
                        TextoDoEMail = dr["TxtHtml"].ToString() + "<br> <br> Prezado(a) " + UmInteressado.getNome() + ", ";
                    }
                    else
                    {
                        TextoDoEMail = TextoDoEMail + dr["TxtHtml"].ToString();
                    }

                    Contador = Contador + 1;
                }
            }

            return TextoDoEMail;
        }
        #endregion

        #region RetornaParametroEmail
        public static DataTable RetornaParametroEmail(string idCurso, string idRegiao)
        {

            string gSql;
            gSql = "";

            gSql = "SELECT Site_Curso_Regiao.CodCurso, Site_Curso_Regiao.CodRegiao, Site_Curso.Descricao AS NomeCurso," +
                " REGIAO.DESCRICAO AS NomeRegiao, Site_Curso_Regiao.EMailFrom, Site_Curso_Regiao.EMailName" +
                " FROM Site_Curso_Regiao" +
                " LEFT OUTER JOIN REGIAO ON Site_Curso_Regiao.CodRegiao = REGIAO.CODREGIAO" +
                " LEFT OUTER JOIN Site_Curso ON Site_Curso_Regiao.CodCurso = Site_Curso.CodCurso" +
                " WHERE ( Site_Curso_Regiao.CodCurso = " + idCurso + ") AND ( Site_Curso_Regiao.CodRegiao = " + idRegiao + ")";

            return Contexto.getdataTable(gSql);
        }
        #endregion

        //Inicio Inscricao

        #region retornoTipoCursoInsc
        public static DataSet retornoTipoCursoInsc()
        {
            string sSql;
            sSql = "";

            sSql = "SELECT CATEGORIACURSO.DESCRICAO AS NomCatCur, CATEGORIACURSO.CODCATEGORIACURSO As CodCatCur" +
                    " FROM Site_Curso" +
                    " INNER JOIN CURSO ON Site_Curso.CodSge = CURSO.CODCURSO" +
                    " INNER JOIN CATEGORIACURSO ON CURSO.CODCATEGORIACURSO = CATEGORIACURSO.CODCATEGORIACURSO" +
                    " WHERE (Site_Curso.Ativo <> 0)" +
                    " GROUP BY CATEGORIACURSO.DESCRICAO, CATEGORIACURSO.CODCATEGORIACURSO" +
                    " ORDER BY NomCatCur";

            return Contexto.getdata(sSql);
        }
        #endregion

        #region RetornoCursoInsc
        public static DataSet RetornoCursoInsc(string idCatCurso)
        {
            string aSql;
            aSql = "";

            aSql = "SELECT Site_Curso.CodCurso, Site_Curso.Descricao, Site_Curso.Ativo, CURSO.CODCATEGORIACURSO" +
                    " FROM CURSO INNER JOIN Site_Curso ON CURSO.CODCURSO = Site_Curso.CodSge" +
                    " WHERE (Site_Curso.Ativo <> 0) and curso.CODCATEGORIACURSO = '" + idCatCurso + "'" +
                    " ORDER BY CURSO.CODCATEGORIACURSO, Site_Curso.Descricao";


            return Contexto.getdata(aSql);
        }
        #endregion

        #region RetornoRegiaoInsc
        public static DataSet RetornoRegiaoInsc(string idCurso)
        {
            string bSql;
            bSql = "";

            bSql = " SELECT Site_Curso_Regiao.CodCurso, Site_Curso_Regiao.CodRegiao, REGIAO.DESCRICAO AS NomeRegiao" +
                    " FROM Site_Curso_Regiao" +
                    " LEFT OUTER JOIN Site_Curso ON Site_Curso_Regiao.CodCurso = Site_Curso.CodCurso" +
                    " LEFT OUTER JOIN REGIAO ON Site_Curso_Regiao.CodRegiao = REGIAO.CODREGIAO" +
                    " where Site_Curso_Regiao.CodCurso='" + idCurso + "'";

            return Contexto.getdata(bSql);
        }
        #endregion

        #region RetornoComoSoubeInsc
        public static DataSet RetornoComoSoubeInsc()
        {
            string cSql;
            cSql = "";

            cSql = "SELECT COMOSOUBE.CODCOMOSOUBE, COMOSOUBE.DESCRICAO, COMOSOUBE.ATIVO" +
                    " FROM COMOSOUBE" +
                    " WHERE (COMOSOUBE.ATIVO <> 0)" +
                    " ORDER BY COMOSOUBE.DESCRICAO";

            return Contexto.getdata(cSql);
        }
        #endregion

        #region RetornoClasseInsc
        public static DataSet RetornoClasseInsc()
        {
            string cSql;
            cSql = "";

            cSql = "Select CodigoDoConselho,NomeDoConselho from Site_Conselho order by NomeDoConselho";

            return Contexto.getdata(cSql);
        }
        #endregion

        #region InsertDadosInteressadoInsc
        public static string InsertDadosInteressadoInsc()
        {
            string sSql;
            sSql = "";

            int t;
            int cargo = 0;
            t = 0;

            //pega a qtd de caracter da string 
            t = app_code.UmInscrito.getComoSoube().Length;

            // testa se o tamanho do texto é maior que o tamanho do campo que é 25
            if (t > 25)
                t = 24;
            else
                t = t - 1;



            if (app_code.UmInscrito.getCargo().Length > 1)
            {
                cargo = 0;
            }
            else
            {
                cargo = Convert.ToInt16(app_code.UmInscrito.getCargo());
            }

            sSql = "SET NOCOUNT ON insert into Site_Inscricao (" +
                    "CodigoDoConselho, Curso, Regiao, Sexo, " +
                    "realname, DDD, Telefone, " +
                    "CODCOMOSOUBE, Como_Soube, " +
                    "EMail, Periodo, Data_Nascimento, " +
                    "rg, cpf,Cidade_Nascimento, Estado_Nascimento, " +
                    "Endereco, Bairro, Cidade, Estado, CEP, DDD_Celular, " +
                    "Celular, Curso_Universitario,Ano_Conclusao, "+
                    "Curso_Universitario2,Ano_Conclusao2,Empresa,Perfil, "+
                    "Endereco_Profissional, Bairro_Profissional, "+
                    "Cidade_Profissional, Estado_Profissional, CEP_Profissional, "+
                    "DDD_Telefone_Profissional, Telefone_Profissional, "+
                    "DDD_Fax_Profissional, Fax_Profissional, rgem, EMail_Com, "+
                    "formacao,formacao2,NUMERO,COMPLEMENTO,CODCARGO,DTADMISSAO, "+
                    "CARGOCOMPLEMENTO,NUMERO_Profissional, COMPLEMENTO_Profissional, "+
                    "PAISNASC,ESTADOCIVIL";
            sSql = sSql + ") Values (" +
                 "'26','" + app_code.UmInscrito.getIdCurso() + "','" + app_code.UmInscrito.getIdRegiao() +
                 "','" + app_code.UmInscrito.getSexo() + "'," + "'" + app_code.UmInscrito.getNome() +
                 "','" + app_code.UmInscrito.getDDDTEL() + "','" + app_code.UmInscrito.getTEL() + "'," +
                 "'" + app_code.UmInscrito.getComoSoube() + "','" + app_code.UmInscrito.getnmComoSoube() + "'," +
                 "'" + app_code.UmInscrito.getemail() + "','" + app_code.UmInscrito.getIdPeriodo() + "'," + 
                 "'" + Funcoes.FormataDataBRtoUS(app_code.UmInscrito.getDtNascimento()) + "'," +
                 "'" + app_code.UmInscrito.getRG() + "','" + app_code.UmInscrito.getCPF() + "'," + 
                 "'" + app_code.UmInscrito.getCidadeNasc() + "','" + app_code.UmInscrito.getUFNasc() + "'," +
                 "'" + app_code.UmInscrito.getEndereco() + "','" + app_code.UmInscrito.getBairro() + "'," + 
                 "'" + app_code.UmInscrito.getCidade() + "','" + app_code.UmInscrito.getEstado() + "'," +
                 "'" + app_code.UmInscrito.getCEP() + "','" + app_code.UmInscrito.getDDDCEL() + "'," +
                 "'" + app_code.UmInscrito.getCEL() + "','" + app_code.UmInscrito.getCursoUniversitario() + "'," + 
                 "'" + app_code.UmInscrito.getAnoConclusao() + "','" + app_code.UmInscrito.getSegCursoUniversitario() + "'," + 
                 "'" + app_code.UmInscrito.getSegAnoConclusao() + "','" + app_code.UmInscrito.getEmpresa() + "'," + 
                 "'" + app_code.UmInscrito.getPerfilEmpresa() + "','" + app_code.UmInscrito.getEnderecoEmpresa() + "'," + 
                 "'" + app_code.UmInscrito.getBairroEmpresa() + "','" + app_code.UmInscrito.getCidadeEmpresa() + "'," +
                 "'" + app_code.UmInscrito.getEstadoEmpresa() + "','" + app_code.UmInscrito.getCEPEmpresa() + "'," + 
                 "'" + app_code.UmInscrito.getDDDTelEmpresa() + "','" + app_code.UmInscrito.getTELEmpresa() + "'," + 
                 "'" + app_code.UmInscrito.getDDDFaxEmpresa() + "','" + app_code.UmInscrito.getFAXEmpresa() + "'," + 
                 "'" + app_code.UmInscrito.getOrgaoEmissor() + "','" + app_code.UmInscrito.getemailComercial() + "'," + 
                 "'" + app_code.UmInscrito.getInstituicaoFormacao() + "','" + app_code.UmInscrito.getSegInstituicaoFormacao() + "'," + 
                 "'" + app_code.UmInscrito.getNumero() + "','" + app_code.UmInscrito.getComplemento() + "'," + 
                 "'" + cargo + "','" + Funcoes.FormataDataBRtoUS(app_code.UmInscrito.getDataAdmissao()) + "'," + 
                 "'" + app_code.UmInscrito.getCargoCompleto() + "'," +
                 "'" + app_code.UmInscrito.getNumeroEmpresa() + "','" + app_code.UmInscrito.getComplementoEmpresa() + "'," + 
                 "'" + app_code.UmInscrito.getPaisNasc() + "','" + app_code.UmInscrito.getEstadoCivil() + "')";


            return Contexto.insertGetIdentity(sSql);

        }
        #endregion
    }//
}//