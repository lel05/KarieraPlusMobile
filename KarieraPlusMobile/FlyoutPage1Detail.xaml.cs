using KarieraPlusMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KarieraPlusMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPage1Detail : ContentPage
    {
        Database db = new Database();
        public FlyoutPage1Detail()
        {
            InitializeComponent();

            Database.InitializeDatabase();

            offersListView.ItemsSource = db.Offers_GetData();

            if((bool)Application.Current.Properties.ContainsKey("user_email") && Application.Current.Properties["user_email"] != null)
            {
                ToolbarLoginBtn.Text = "Wyloguj";
                ToolbarLoginBtn.Clicked += LogoutBtn_Clicked;

                if(Application.Current.Properties["user_email"] as string == "admin@admin.admin")
                {
                    ToolbarAddOfferBtn.Text = "Admin";
                    ToolbarAddOfferBtn.Clicked += ToolbarAddOfferBtn_Clicked;
                }
            }
            else
            {
                ToolbarLoginBtn.Text = "Logowanie";
                ToolbarLoginBtn.Clicked += LoginBtn_Clicked;
            }
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Login_Page());
        }

        private void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["user_email"] = null;
            ToolbarAddOfferBtn.Text = "";
            ToolbarAddOfferBtn.Clicked -= null;
            App.Current.MainPage = new FlyoutPage1();
        }

        private void ToolbarAddOfferBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.AddOffer_Page());
        }
    }
}