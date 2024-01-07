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
	public partial class AddOffer_Page : ContentPage
	{
        Database db = new Database();
		public AddOffer_Page ()
		{
			InitializeComponent ();

            offersListView.ItemsSource = db.Offers_GetData();
		}

        private void AddOffer_Clicked(object sender, EventArgs e)
        {
            string companyName = CompanyNameEntry.Text;
            string contractType = ContractTypeEntry.Text;
            string jobType = JobTypeEntry.Text;
            string salary = SalaryEntry.Text;
            string category = CategoryEntry.Text;
            string duties = DutiesEditor.Text;
            string requirements = RequirementsEditor.Text;

            Offers offer = new Offers
            {
                Company_name = companyName,
                Type_of_contract = contractType,
                Type_of_job = jobType,
                Salary = salary,
                Category = category,
                Duties = duties,
                Requirements = requirements
            };

            db.Offer_AddData(offer);
            DisplayAlert("Info", "Oferta została dodana pomyślnie!", "OK");
        }

        private void DeleteOffer_Clicked(object sender, EventArgs e)
        {
            db.Offer_DeleteData(offersListView.SelectedItem as Offers);
            DisplayAlert("Info", "Oferta usunięta pomyślnie!", "OK");
        }

        private void EditOffer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditOffer_Page(offersListView.SelectedItem as Offers));
        }
    }
}