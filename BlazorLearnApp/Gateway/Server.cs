namespace BlazorLearnApp.Gateway
{
    public class Server
    {
        public static string server = ".";
        public static string database = "Sample";
        public static string user = "sa";
        public static string password = "a";
        public static string sharePath = "";

        public static void ReadSharePath()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + @"Data\Share.ini";

            string[] lines = System.IO.File.ReadAllLines(file);

            sharePath = lines[0];
        }

        public static void ReadServerInfo()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + @"Data\SqlSvr.ini";

            string[] lines = System.IO.File.ReadAllLines(file);

            server = lines[0];
            database = lines[1];
            password = lines[2];
        }
    }
}
