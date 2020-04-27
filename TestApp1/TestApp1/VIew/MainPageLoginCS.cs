using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp1.VIew
{
    public class MainPageLoginCS : ContentPage
    {
        public MainPageLoginCS()
        {
            var toolbarItem = new ToolbarItem
            {
                Text = "Logout"
            };

            toolbarItem.Clicked += OnLogoutButtonClicked;
            ToolbarItems.Add(toolbarItem);

            Title = "Main Page";
            Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text="Main content goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };

            async void OnLogoutButtonClicked(object sender, EventArgs e)
            {
                App.IsUserLoggedIn = false;
                Navigation.InsertPageBefore(new MainPageLoginCS(), this);
                await Navigation.PopAsync();
            }
        }

    }
}
