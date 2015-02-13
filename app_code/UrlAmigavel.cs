using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;

namespace Site_Interessado.app_code
{
    public class UrlAmigavel
    {

        public void AdicionarUrlAmigavel(string UrlAmigavel, String NomePagina)
        {
            UrlMapping urlMap = null;
            // Abre o Web.config

            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            // Recupera a seção urlMappings, do web.config
            UrlMappingsSection urlMapSection = (UrlMappingsSection)config.GetSection("system.web/urlMappings");

            // Adiciona a URL Amigável a seção, que é salva no Web.Config
            urlMap = new UrlMapping("~/" + UrlAmigavel, NomePagina);

            urlMapSection.UrlMappings.Remove(urlMap);
            urlMapSection.UrlMappings.Add(urlMap);

            // Grava no web.config
            config.Save();
        }
        
    }
}