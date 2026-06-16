namespace Window_Forms
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
            ApplicationConfiguration.Initialize();
            GeminiService.ApiKey = "AQ.Ab8RN6La8rSruu4bR_jBQ-GNvnfaJjIfE18ySi07uCSOLH8jNg";
            Application.Run(new Loading());
        }
    }
}

