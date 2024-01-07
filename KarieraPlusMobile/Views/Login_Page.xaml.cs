using KarieraPlusMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarieraPlusMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_Page : ContentPage
    {
        public Login_Page()
        {
            InitializeComponent();

            Database.InitializeDatabase();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (Database.IsLoginValid(email, password))
            {
                Application.Current.Properties["user_email"] = email;
                App.Current.MainPage = new FlyoutPage1();
            }
            else
            {
                ErrorLabel.Text = "Nieprawidłowy email lub hasło";
            }
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register_Page());
        }
    }
}