using KarieraPlusMobile.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace KarieraPlusMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfile_Page : ContentPage
	{
        Database db = new Database();
        public UserProfile_Page ()
		{
			InitializeComponent ();

            if ((bool)Application.Current.Properties.ContainsKey("user_email") && Application.Current.Properties["user_email"] != null)
            {
                
            }
            else
            {
                App.Current.MainPage = new FlyoutPage1();
            }

            List<User> tmp = db.Users_GetData();

            string email = Application.Current.Properties["user_email"] as string;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].Email == email)
                {
                    FirstNameEntry.Text = tmp[i].Firstname;
                    SurnameEntry.Text = tmp[i].Surname;
                    EmailEntry.Text = tmp[i].Email;
                    PhoneNumberEntry.Text = tmp[i].Phone_number;
                    AddressEntry.Text = tmp[i].Address;
                    UserIdLabel.Text = tmp[i].User_id.ToString();
                    PasswordEntry.Text = tmp[i].Password;
                }
            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string namePattern = @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s-]+$";
            string phonePattern = @"^\+?[1-9]\d{1,14}$";
            string addressPattern = @"^[a-zA-Z0-9ąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s,.-]+$";
            
            if (Regex.IsMatch(EmailEntry.Text, emailPattern) && Regex.IsMatch(FirstNameEntry.Text, namePattern) && Regex.IsMatch(SurnameEntry.Text, namePattern) && Regex.IsMatch(PhoneNumberEntry.Text, phonePattern) && Regex.IsMatch(AddressEntry.Text, addressPattern))
            {
                if (Database.IsLoginValid(EmailEntry.Text, PasswordEntry.Text))
                {
                    User user = new User()
                    {
                        User_id = int.Parse(UserIdLabel.Text),
                        Firstname = FirstNameEntry.Text,
                        Surname = SurnameEntry.Text,
                        Email = EmailEntry.Text,
                        Phone_number = PhoneNumberEntry.Text,
                        Address = AddressEntry.Text,
                        Password = PasswordEntry.Text
                    };

                    db.User_EditData(user);
                    DisplayAlert("Info", "Twoje dane zostały zedytowane", "OK");
                }
                else
                {
                    DisplayAlert("Info", "Nieprawidłowy adres email", "OK");
                }
            }
            else
            {
                DisplayAlert("Info", "Nieprawidłowe dane", "OK");
            }
        }
    }
}