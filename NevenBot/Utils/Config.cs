using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevenBot.Utils
{
    internal class Config
    {
        static public string GetToken()
        {
            try
            {
                var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                IConfiguration config = builder.Build();

                string token = config["ApiToken"];

                return token;

            }
            catch
            {
                return "Error: Token not found";

            }
        }

        static public int GetDebugID()
        {
            try
            {
                var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                IConfiguration config = builder.Build();

                int DebugId = int.Parse(config["DebugID"]);

                return DebugId;

            }
            catch
            {
                return 0;

            }

        }
    }

}
}
