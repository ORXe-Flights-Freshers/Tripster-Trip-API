using Newtonsoft.Json;
using System.IO;
namespace Tavisca.Tripster.Contracts.Entity
{
    public static class DatabaseSettings
    {
        public static string ConnectionString { get; private set; }
        public static string DatabaseName { get; private set; }

        public static void Configure()
        {
            using (StreamReader file = File.OpenText("appsettings.json"))
            {
                dynamic settings = JsonConvert.DeserializeObject(file.ReadToEnd());
                ConnectionString = settings["ConnectionString"];
                DatabaseName = settings["DatabaseName"];
            }
        }
    }
}
