using Xamarin.Forms;

namespace launchtest
{
    public partial class launchtestPage : ContentPage
    {
        public launchtestPage()
        {
            InitializeComponent();

			App.PostSuccessFacebookAction = token =>
			{
                fbLoginButton.Text = token;
			};
        }
    }
}
