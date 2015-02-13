using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_Interessado.app_code
{
    public static class UmInscrito
    {
        //Tipo 
        private static String IdCatCurso;
        private static String IdCurso;
        private static String IdRegiao;
        private static String IdPeriodo;
        private static String Nome;
        private static String Sexo;
        private static String DtNascimento;
        private static String CidadeNasc;
        private static String UFNasc;
        private static String EstadoCivil;
        private static String CPF;
        private static String RG;
        private static String OrgaoEmissor;
        private static String PaisNasc;
        private static String email;
        private static String CEP;
        private static String Endereco;
        private static String Numero;
        private static String Complemento;
        private static String Bairro;
        private static String Cidade;
        private static String Estado;
        private static String DDDTEL;
        private static String TEL;
        private static String DDDCEL;
        private static String CEL;
        private static String CursoUniversitario;
        private static String AnoConclusao;
        private static String InstituicaoFormacao;
        private static String SegCursoUniversitario;
        private static String SegAnoConclusao;
        private static String SegInstituicaoFormacao;
        private static String Empresa;
        private static String CargoCompleto;
        private static String Cargo;
        private static String DataAdmissao;
        private static String emailComercial;
        private static String CEPEmpresa;
        private static String EnderecoEmpresa;
        private static String NumeroEmpresa;
        private static String ComplementoEmpresa;
        private static String BairroEmpresa;
        private static String CidadeEmpresa;
        private static String EstadoEmpresa;
        private static String PerfilEmpresa;
        private static String DDDTelEmpresa;
        private static String TELEmpresa;
        private static String DDDFaxEmpresa;
        private static String FAXEmpresa;
        private static String Folder;
        private static String Filiado;
        private static String ComoSoube;
        private static String nmComoSoube;
        private static Boolean TemResp;


        //set
        public static void setIdCatCurso(String _IdCatCurso) { IdCatCurso = _IdCatCurso; }
        public static void setIdCurso(String _IdCurso) { IdCurso = _IdCurso; }
        public static void setIdRegiao(String _IdRegiao) { IdRegiao = _IdRegiao; }
        public static void setIdPeriodo(String _IdPeriodo) { IdPeriodo = _IdPeriodo; }
        public static void setNome(String _Nome) { Nome = _Nome; }
        public static void setSexo(String _Sexo) { Sexo = _Sexo; }
        public static void setDtNascimento(String _DtNascimento) { DtNascimento = _DtNascimento; }
        public static void setCidadeNasc(String _CidadeNasc) { CidadeNasc = _CidadeNasc; }
        public static void setUFNasc(String _UFNasc) { UFNasc = _UFNasc; }
        public static void setEstadoCivil(String _EstadoCivil) { EstadoCivil = _EstadoCivil; }
        public static void setCPF(String _CPF) { CPF = _CPF; }
        public static void setRG(String _RG) { RG = _RG; }
        public static void setOrgaoEmissor(String _OrgaoEmissor) { OrgaoEmissor = _OrgaoEmissor; }
        public static void setPaisNasc(String _PaisNasc) { PaisNasc = _PaisNasc; }
        public static void setemail(String _email) { email = _email; }
        public static void setCEP(String _CEP) { CEP = _CEP; }
        public static void setEndereco(String _Endereco) { Endereco = _Endereco; }
        public static void setNumero(String _Numero) { Numero = _Numero; }
        public static void setComplemento(String _Complemento) { Complemento = _Complemento; }
        public static void setBairro(String _Bairro) { Bairro = _Bairro; }
        public static void setCidade(String _Cidade) { Cidade = _Cidade; }
        public static void setEstado(String _Estado) { Estado = _Estado; }
        public static void setDDDTEL(String _DDDTEL) { DDDTEL = _DDDTEL; }
        public static void setTEL(String _TEL) { TEL = _TEL; }
        public static void setDDDCEL(String _DDDCEL) { DDDCEL = _DDDCEL; }
        public static void setCEL(String _CEL) { CEL = _CEL; }
        public static void setCursoUniversitario(String _CursoUniversitario) { CursoUniversitario = _CursoUniversitario; }
        public static void setAnoConclusao(String _AnoConclusao) { AnoConclusao = _AnoConclusao; }
        public static void setInstituicaoFormacao(String _InstituicaoFormacao) { InstituicaoFormacao = _InstituicaoFormacao; }
        public static void setSegCursoUniversitario(String _SegCursoUniversitario) { SegCursoUniversitario = _SegCursoUniversitario; }
        public static void setSegAnoConclusao(String _SegAnoConclusao) { SegAnoConclusao = _SegAnoConclusao; }
        public static void setSegInstituicaoFormacao(String _SegInstituicaoFormacao) { SegInstituicaoFormacao = _SegInstituicaoFormacao; }
        public static void setEmpresa(String _Empresa) { Empresa = _Empresa; }
        public static void setCargoCompleto(String _CargoCompleto) { CargoCompleto = _CargoCompleto; }
        public static void setCargo(String _Cargo) { Cargo = _Cargo; }
        public static void setDataAdmissao(String _DataAdmissao) { DataAdmissao = _DataAdmissao; }
        public static void setemailComercial(String _emailComercial) { emailComercial = _emailComercial; }
        public static void setCEPEmpresa(String _CEPEmpresa) { CEPEmpresa = _CEPEmpresa; }
        public static void setEnderecoEmpresa(String _EnderecoEmpresa) { EnderecoEmpresa = _EnderecoEmpresa; }
        public static void setNumeroEmpresa(String _NumeroEmpresa) { NumeroEmpresa = _NumeroEmpresa; }
        public static void setComplementoEmpresa(String _ComplementoEmpresa) { ComplementoEmpresa = _ComplementoEmpresa; }
        public static void setBairroEmpresa(String _BairroEmpresa) { BairroEmpresa = _BairroEmpresa; }
        public static void setCidadeEmpresa(String _CidadeEmpresa) { CidadeEmpresa = _CidadeEmpresa; }
        public static void setEstadoEmpresa(String _EstadoEmpresa) { EstadoEmpresa = _EstadoEmpresa; }
        public static void setPerfilEmpresa(String _PerfilEmpresa) { PerfilEmpresa = _PerfilEmpresa; }
        public static void setDDDTelEmpresa(String _DDDTelEmpresa) { DDDTelEmpresa = _DDDTelEmpresa; }
        public static void setTELEmpresa(String _TELEmpresa) { TELEmpresa = _TELEmpresa; }
        public static void setDDDFaxEmpresa(String _DDDFaxEmpresa) { DDDFaxEmpresa = _DDDFaxEmpresa; }
        public static void setFAXEmpresa(String _FAXEmpresa) { FAXEmpresa = _FAXEmpresa; }
        public static void setFolder(String _Folder) { Folder = _Folder; }
        public static void setFiliado(String _Filiado) { Filiado = _Filiado; }
        public static void setComoSoube(String _ComoSoube) { ComoSoube = _ComoSoube; }
        public static void setnmComoSoube(String _nmComoSoube) { nmComoSoube = _nmComoSoube; }
        public static void setTemResp(Boolean _TemResp) { TemResp = _TemResp; }


        //get
        public static String getIdCatCurso() { return IdCatCurso; }
        public static String getIdCurso() { return IdCurso; }
        public static String getIdRegiao() { return IdRegiao; }
        public static String getIdPeriodo() { return IdPeriodo; }
        public static String getNome() { return Nome; }
        public static String getSexo() { return Sexo; }
        public static String getDtNascimento() { return DtNascimento; }
        public static String getCidadeNasc() { return CidadeNasc; }
        public static String getUFNasc() { return UFNasc; }
        public static String getEstadoCivil() { return EstadoCivil; }
        public static String getCPF() { return CPF; }
        public static String getRG() { return RG; }
        public static String getOrgaoEmissor() { return OrgaoEmissor; }
        public static String getPaisNasc() { return PaisNasc; }
        public static String getemail() { return email; }
        public static String getCEP() { return CEP; }
        public static String getEndereco() { return Endereco; }
        public static String getNumero() { return Numero; }
        public static String getComplemento() { return Complemento; }
        public static String getBairro() { return Bairro; }
        public static String getCidade() { return Cidade; }
        public static String getEstado() { return Estado; }
        public static String getDDDTEL() { return DDDTEL; }
        public static String getTEL() { return TEL; }
        public static String getDDDCEL() { return DDDCEL; }
        public static String getCEL() { return CEL; }
        public static String getCursoUniversitario() { return CursoUniversitario; }
        public static String getAnoConclusao() { return AnoConclusao; }
        public static String getInstituicaoFormacao() { return InstituicaoFormacao; }
        public static String getSegCursoUniversitario() { return SegCursoUniversitario; }
        public static String getSegAnoConclusao() { return SegAnoConclusao; }
        public static String getSegInstituicaoFormacao() { return SegInstituicaoFormacao; }
        public static String getEmpresa() { return Empresa; }
        public static String getCargoCompleto() { return CargoCompleto; }
        public static String getCargo() { return Cargo; }
        public static String getDataAdmissao() { return DataAdmissao; }
        public static String getemailComercial() { return emailComercial; }
        public static String getCEPEmpresa() { return CEPEmpresa; }
        public static String getEnderecoEmpresa() { return EnderecoEmpresa; }
        public static String getNumeroEmpresa() { return NumeroEmpresa; }
        public static String getComplementoEmpresa() { return ComplementoEmpresa; }
        public static String getBairroEmpresa() { return BairroEmpresa; }
        public static String getCidadeEmpresa() { return CidadeEmpresa; }
        public static String getEstadoEmpresa() { return EstadoEmpresa; }
        public static String getPerfilEmpresa() { return PerfilEmpresa; }
        public static String getDDDTelEmpresa() { return DDDTelEmpresa; }
        public static String getTELEmpresa() { return TELEmpresa; }
        public static String getDDDFaxEmpresa() { return DDDFaxEmpresa; }
        public static String getFAXEmpresa() { return FAXEmpresa; }
        public static String getFolder() { return Folder; }
        public static String getFiliado() { return Filiado; }
        public static String getComoSoube() { return ComoSoube; }
        public static String getnmComoSoube() { return nmComoSoube; }
        public static Boolean getTemResp() { return TemResp; }
    }
}