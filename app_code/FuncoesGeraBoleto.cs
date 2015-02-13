using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_Interessado.app_code
{
    public class FuncoesGeraBoleto
    {

        #region inicio da parte do banco 033

        // Retorna o valor da variavel VnumBoleto
        public static int NumBoleto(string sPrvStr) 
        {
            string DirPrv = "", EsqPrv = "";
            int vNumBoleto=0;

            if (sPrvStr.Length > 8)
            {
                DirPrv = sPrvStr.Substring(sPrvStr.Length - 8, 8);
                EsqPrv = sPrvStr.Substring(0, sPrvStr.Length - 8);

                DirPrv = DirPrv + 1;

                if (DirPrv.Length < 8)
                {
                    string Acrescimo = "";

                    for (int i = 1; i < (8 - DirPrv.Length); i++)
                    {
                        Acrescimo = Acrescimo + "0";
                    }
                    DirPrv = Acrescimo + DirPrv;
                }
                sPrvStr = EsqPrv + DirPrv;
                vNumBoleto = Convert.ToInt32(sPrvStr);
                 
            }
            else
            {
                vNumBoleto = Convert.ToInt32(sPrvStr) + 1;
            }
            return vNumBoleto;
        }

        //Trata Numero da agencia 
        public static string GetBancoAgencia(string vBancoAgencia)
        {
            string sBancoAgencia = "";
            int ComprBancoAgencia = 0;

            if (Convert.ToInt32(vBancoAgencia.Length) >= 3)
            {
                sBancoAgencia = vBancoAgencia.Substring(0, 3);
                //Console.Write("O numero da agencia do Banespa deve ter tres digitos");
            }
            else
            {
                if (Convert.ToInt32(vBancoAgencia.Length) < 3)
                {
                    ComprBancoAgencia = Convert.ToInt32(vBancoAgencia.Length.ToString());

                    string Acrescimo = "";

                    for (int i = 1; i < (3 - ComprBancoAgencia); i++)
                    {
                        Acrescimo = Acrescimo + "0";
                    }
                    sBancoAgencia = Acrescimo + vBancoAgencia;
                }
            }
            return sBancoAgencia;
        }

        //Trata o numero do boleto 
        public static string TrataNBoleto(string vNumBoleto)
        {
            string sNumBoleto = "", ComprNumBoleto="";
            if (vNumBoleto.ToString().Length > 7)
            {

                sNumBoleto = vNumBoleto.ToString().Substring(0, 7);
                Console.Write("O numero do boleto do Banespa deve ter sete digitos");
            }
            else
            {
                if (vNumBoleto.ToString().Length < 7)
                {
                    ComprNumBoleto = vNumBoleto;
                    string Acrescimo = "";

                    for (int i = 1; i <= (7 - ComprNumBoleto.ToString().Length); i++)
                    {

                        Acrescimo = Acrescimo + "0";
                    }
                    sNumBoleto = Acrescimo + vNumBoleto;
                }
                else
                {
                    sNumBoleto = vNumBoleto.ToString();
                }
            }

            return sNumBoleto;
    
        }

        //Estrai  espaço do codAgeCedente
        public static string TrataCodAgeCedente(string vBancoCodAgeCed)
        {
            string Caracter = "", Prov="";

            for (int i = 1; i <= Convert.ToInt32(vBancoCodAgeCed.Length); i++)
            {
                Caracter = vBancoCodAgeCed.Substring(i - 1, 1);

                if (Caracter != " ")
                    Prov = Prov + Caracter;
            }

            return Prov;
            
        }

        // Trata checkdigt
        public static int CalculaCheckDigit1(string sBancoCodAgeCed, string sNumBoleto)
        {
            string Prov = "", TxtMulti="";
            int DeterminaImpar = 0, TxtLength = 0, NumAlt = 0,
                Fator1 = 0, Fator2 = 0, Multiplicacao = 0, ValSoma = 0, ValResto = 0, CheckDigit = 0;


            Prov = sBancoCodAgeCed + sNumBoleto + "00033";

            TxtLength = Convert.ToInt32(Prov.Length.ToString());

            DeterminaImpar = TxtLength % 2;

            if (DeterminaImpar == 1)
                NumAlt = 2;
            else
                NumAlt = 1;


            for (int i = 1; i <= TxtLength; i++)
            {
                TxtMulti = TxtMulti.ToString() + NumAlt.ToString();
                NumAlt = NumAlt + 1;
                if (NumAlt == 3)
                    NumAlt = 1;
            }

            for (int i = 1; i <= Convert.ToInt32(Prov.Length.ToString()); i++)
            {
                Fator1 = Convert.ToInt32(TxtMulti.Substring(i - 1, 1));
                Fator2 = Convert.ToInt32(Prov.Substring(i - 1, 1));
                Multiplicacao = Fator1 * Fator2;

                if (Multiplicacao > 9)
                    Multiplicacao = Multiplicacao - 9;

                ValSoma = ValSoma + Multiplicacao;
            }

            ValResto = ValSoma % 10;

            if (ValResto == 0)
                CheckDigit = ValResto;
            else
                CheckDigit = 10 - ValResto;

            return CheckDigit;
        
        }

        // Trata checkdigt
        public static string CalculaCheckDigit2(string Prov, string sNumBoleto, string sBancoCodAgeCed, int CheckDigit)
        {
            string TxtMulti = "";
            int Fator1 = 0, Fator2 = 0, ContadorDeRecursao = 99, ValSoma = 0,
                Multiplicacao = 0, ValResto = 0, CheckDigitComplementar=0;

            do
            {
                ContadorDeRecursao = ContadorDeRecursao - 1;
                TxtMulti = "765432765432765432765432";

                for (int i = 1; i <= Convert.ToInt32(Prov.Length.ToString()); i++)
                {
                    Fator1 = Convert.ToInt32(TxtMulti.Substring(i - 1, 1));
                    Fator2 = Convert.ToInt32(Prov.Substring(i - 1, 1));

                    Multiplicacao = Fator1 * Fator2;

                    ValSoma = ValSoma + Multiplicacao;
                }

                ValResto = ValSoma % 11;

                //"NAO Teve recursao"
                if (ValResto == 0)
                {    
                    CheckDigitComplementar = 0;
                    ContadorDeRecursao = 0;
                }
                //"NAO Teve recursao"
                if (ValResto > 1)
                {   
                    CheckDigitComplementar = 11 - ValResto;
                    ContadorDeRecursao = 0;
                }

                //Teve recursao"
                if (ValResto == 1)
                {   
                    CheckDigitComplementar = 1;
                    CheckDigit = CheckDigit + 1;
                    if (Convert.ToInt32(CheckDigit) > 9)
                        CheckDigit = 0;
                }

            } while (ContadorDeRecursao > 0);

            return sBancoCodAgeCed + sNumBoleto + "00033" + CheckDigit + CheckDigitComplementar;
            
        }

        // Trata checkdigt
        public static string CalculaCheckDisit3(string sBancoAgencia, string sNumBoleto)
        {
            string Prov = "", TxtMulti="";
            int TxtLength = 0, Fator1 = 0, Fator2 = 0, Multiplicacao = 0,
                ValSoma = 0, ValResto = 0, CheckDigit=0;

            //Calcula CheckDigit
            Prov = sBancoAgencia + sNumBoleto;
            TxtLength = Convert.ToInt32(Prov.Length.ToString());
            TxtMulti = "7319731973";
            //int ValSoma = 0;

            for (int i = 1; i <= Convert.ToInt32(Prov.Length.ToString()); i++)
            {
                Fator1 = Convert.ToInt32(TxtMulti.Substring(i - 1, 1));
                Fator2 = Convert.ToInt32(Prov.Substring(i - 1, 1));

                Multiplicacao = Fator1 * Fator2;
                ValSoma = ValSoma + Multiplicacao;
            }

            ValResto = ValSoma % 10;
            if (ValResto == 0)
                CheckDigit = ValResto;
            else
                CheckDigit = 10 - ValResto;

            return sBancoAgencia + " " + sNumBoleto + " " + CheckDigit;
            
        }

        #endregion Termina da parte do banco 

        #region Inicio Parte comum para todos os boletos 

        public static int CheckDigito(int DeterminaImpar,int TxtLength,string sLinDigit1)
        {
            string TxtMulti = "";
            int NumAlt = 0, Fator1 = 0, Fator2 = 0, Multiplicacao = 0, ValSoma = 0, ValResto=0;

            if (DeterminaImpar == 1)
                NumAlt = 2;
            else
                NumAlt = 1;

            for (int i = 1; i <= TxtLength; i++)
            {
                TxtMulti = TxtMulti + NumAlt;
                NumAlt = NumAlt + 1;
                if (NumAlt == 3)
                    NumAlt = 1;
            }


            for (int i = 1; i <= Convert.ToInt32(sLinDigit1.Length.ToString()); i++)
            {
                Fator1 = Convert.ToInt32(TxtMulti.Substring(i-1, 1));
                Fator2 = Convert.ToInt32(sLinDigit1.Substring(i-1, 1));
                Multiplicacao = Fator1 * Fator2;
                if (Multiplicacao > 9)
                    Multiplicacao = Multiplicacao - 9;

                ValSoma = ValSoma + Multiplicacao;
            }


            ValResto = ValSoma % 10;
            if (ValResto == 0)
                return ValResto;
            else
                return 10 - ValResto;
        
             
        }

        public static int CheckDigitoBoleto(string sCodigoDeBarras)
        {
            string TxtMulti="";
            int Fator1 = 0, Fator2 = 0, Multiplicacao = 0, ValSoma = 0, ValResto=0;

            //CheckDigit do codigo de barras
            TxtMulti = "4329876543298765432987654329876543298765432";

            for (int i = 1; i <= Convert.ToInt32(sCodigoDeBarras.Length.ToString()); i++)
            {
                Fator1 = Convert.ToInt32(TxtMulti.Substring(i - 1, 1));
                Fator2 = Convert.ToInt32(sCodigoDeBarras.Substring(i - 1, 1));
                Multiplicacao = Fator1 * Fator2;
                ValSoma = ValSoma + Multiplicacao;
            }

            ValResto = ValSoma % 11;

            if (ValResto == 0 || ValResto == 1 || ValResto == 10)
                return 1;
            else
                return 11 - ValResto;


        }

        #endregion 

        #region update 

        public static void SetUpdateNumInscri(string vNumInscri)
        {
            var sql="";
            sql = "UPDATE PARAMETROINSCRITO SET NumeroUltimaInscricao = '" + vNumInscri + "'";
        }

        public static void SetUpdateNumUltimoBoleto(string vNumBoleto, string vBancoIde)
        {
            var sql="";
            sql = "UPDATE ContasBancarias SET NumeroUltimoBoleto = '" + vNumBoleto + "' WHERE (Id = " + vBancoIde + ")";
        }
        	
        #endregion

    }//
}//