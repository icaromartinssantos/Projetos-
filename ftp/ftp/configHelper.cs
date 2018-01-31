using System.Configuration;

namespace ftp
{
    public class configHelper
    {
        public static string LocalUploadPending
        {
            get
            {   //ConfigurationManager.AppSettings obtém a configuração de um objeto AppSettingsSection definido no App.config
                return ConfigurationManager.AppSettings["LocalUploadPeding"].ToString();
            }
        }

        public static string LocalUploadOk
        {
            get
            {
                return ConfigurationManager.AppSettings["LocalUploadOk"].ToString();
            }
        }

    }
}
