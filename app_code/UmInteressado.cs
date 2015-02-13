using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_Interessado.app_code
{
    public static class UmInteressado
    {
        //Tipo 
        private static String IdCurso;
        private static String IdRegiao;
        private static String Sexo;
        private static String Nome;
        private static String Ddd;
        private static String Tel;
        private static String IdComoSoube;
        private static String NmComoSoube;
        private static String QualJornal;
        private static String QualRevista;
        private static String QualOutros;
        private static String Email;
        private static String Periodo;
        private static String DtNascimanto;
        private static String IdPergunta;
        private static String IdResposta;
        private static Boolean TemResp;


        //set
        public static void setIdCurso(String _IdCurso) { IdCurso = _IdCurso; }
        public static void setIdRegiao(String _IdRegiao) { IdRegiao = _IdRegiao; }
        public static void setSexo(String _Sexo) { Sexo = _Sexo; }
        public static void setNome(String _Nome) { Nome = _Nome; }
        public static void setDdd(String _Ddd) { Ddd = _Ddd; }
        public static void setTel(String _Tel) { Tel = _Tel; }
        public static void setIdComoSoube(String _IdComoSoube) { IdComoSoube = _IdComoSoube; }
        public static void setNmComoSoube(String _NmComoSoube) { NmComoSoube = _NmComoSoube; }
        public static void setQualJornal(String _QualJornal) { QualJornal = _QualJornal; }
        public static void setQualRevista(String _QualRevista) { QualRevista = _QualRevista; }
        public static void setQualOutros(String _QualOutros) { QualOutros = _QualOutros; }
        public static void setEmail(String _Email) { Email = _Email; }
        public static void setPeriodo(String _Periodo) { Periodo = _Periodo; }
        public static void setDtNascimanto(String _DtNascimanto) { DtNascimanto = _DtNascimanto; }
        public static void setIdPergunta(String _IdPergunta) { IdPergunta = _IdPergunta; }
        public static void setIdResposta(String _IdResposta) { IdResposta = _IdResposta; }
        public static void setTemResp(Boolean _TemResp) { TemResp = _TemResp; }


        //get
        public static String getIdCurso() { return IdCurso; }
        public static String getIdRegiao() { return IdRegiao; }
        public static String getSexo() { return Sexo; }
        public static String getNome() { return Nome; }
        public static String getDdd() { return Ddd; }
        public static String getTel() { return Tel; }
        public static String getIdComoSoube() { return IdComoSoube; }
        public static String getNmComoSoube() { return NmComoSoube; }
        public static String getQualJornal() { return QualJornal; }
        public static String getQualRevista() { return QualRevista; }
        public static String getQualOutros() { return QualOutros; }
        public static String getEmail() { return Email; }
        public static String getPeriodo() { return Periodo; }
        public static String getDtNascimanto() { return DtNascimanto; }
        public static String getIdPergunta() { return IdPergunta; }
        public static String getIdResposta() { return IdResposta; }
        public static Boolean getTemResp() { return TemResp; }
    }//
}//