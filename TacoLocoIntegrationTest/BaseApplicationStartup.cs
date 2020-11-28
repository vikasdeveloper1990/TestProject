using Alba;
using TacoLoco;

namespace TacoLocoIntegrationTest
{
    public class BaseApplicationStartup
    {
        public BaseApplicationStartup()
        {
            string[] args = new string[0];
            //args[0] = "--config-file-path";
            //args[1] = "";
            //args[2] = "--web-file-name";
            //args[3] = "appsettings-web.json";
            var host = Program.CreateHostBuilder(args);
            WebApp = new SystemUnderTest(host);
        }


        public SystemUnderTest WebApp { get; }
    }
}
