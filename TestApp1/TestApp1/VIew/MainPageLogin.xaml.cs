using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp1.VIew
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class MainPageLogin : ContentPage
	{
		public MainPageLogin ()
		{
			InitializeComponent ();
		}

        async void OnLogoutButton_Clicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

 
    }
}