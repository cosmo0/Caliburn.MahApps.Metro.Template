namespace CaliburnTemplate
{
    using System.Windows;
    using Caliburn.Micro;
    using Caliburn.Micro.Logging.NLog;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes static members of the <see cref="App"/> class
        /// </summary>
        public static App()
        {
            LogManager.GetLog = type => new NLogLogger(type);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            var log = LogManager.GetLog(this.GetType());

            log.Info("##### Application starting");
        }
    }
}