using KarieraPlusMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarieraPlusMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register_Page : ContentPage
    {
        public Register_Page()
        {
            InitializeComponent();
        }

        Database db = new Database();

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string firstname = FirstNameEntry.Text;
            string surname = SurnameEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string namePattern = @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s-]+$";

            if (Regex.IsMatch(EmailEntry.Text, emailPattern) && Regex.IsMatch(FirstNameEntry.Text, namePattern) && Regex.IsMatch(SurnameEntry.Text, namePattern))
            {

                if (!Database.IsLoginValid(email, password))
                {
                    User newUser = new User
                    {
                        Firstname = firstname,
                        Surname = surname,
                        Email = email,
                        Phone_number = "",
                        Address = "",
                        Password = password

                    };
                    db.User_AddData(newUser);

                    DisplayAlert("Sukces", "Rejestracja powiodła się!", "OK");

                    Navigation.PushAsync(new Login_Page());
                }
                else
                {
                    ErrorLabel.Text = "Użytkownik o podanym emailu już istnieje";
                }
            }
            else
            {
                DisplayAlert("Info", "Nieprawdłowe dane", "OK");
            }
        }
    }
}