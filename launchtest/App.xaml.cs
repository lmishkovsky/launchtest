using Xamarin.Forms;

namespace launchtest
{
    public partial class App : Application
    {
        public static System.Action<string> PostSuccessFacebookAction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:launchtest.App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new launchtestPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
