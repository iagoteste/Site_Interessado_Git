using Site_Interessado.app_code;
using System;

namespace Site_Interessado
{
    public partial class confirma : System.Web.UI.Page
    {
        protected string fulano;

        protected void Page_Load(object sender, EventArgs e)
        {
            fulano = Request.QueryString["nome"].ToString();

            if (Request.QueryString["acao"].ToString() == "interesse")
            {
                ImprimirBoleto.Visible = false;
            }
            else
            {
                Confirmado.Visible = false;
            }

        }

        protected void ImprimirBoleto_Click(object sender, EventArgs e)
        {
            
                string c = "", r = "", i = "";
                c = Request.QueryString["curso"].ToString();
                r = Request.QueryString["regiao"].ToString();
                i = Request.QueryString["idInte"].ToString();

                ////Tratamento de URLAamigavel
                //UrlAmigavel UrlAmigavel = new UrlAmigavel();
                //UrlAmigavel.AdicionarUrlAmigavel("Boleto", "~/GeraBoleto1.aspx?cu=" + c + "&re=" + r + "&int=" + i);

                //Response.Redirect("Boleto");
                Response.Redirect("~/GeraBoleto1.aspx?cu=" + c + "&re=" + r + "&int=" + i, false);


               // Response.Redirect("~/GeraBoleto1.aspx?cu=" + c + "&re=" + r + "&int=" + i + "", false);
            
        }

        protected void btnokconf_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.strong.com.br/Cursos", false);
        }
    }//
}//