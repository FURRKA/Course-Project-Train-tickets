namespace GUI_Layer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            string path = @"Data Source=..\..\..\..\DataLayer\DB_CourseWork.db";
            ApplicationConfiguration.Initialize();
            Application.Run(new Authorization(path));
            //Application.Run(new StatisticForm());
        }
    }
}