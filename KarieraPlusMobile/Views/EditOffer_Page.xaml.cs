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
	public partial class EditOffer_Page : ContentPage
	{
		Database db = new Database();
        public EditOffer_Page ()
		{
			InitializeComponent ();
		}

        public EditOffer_Page(Offers offer)
		{
            InitializeComponent();

            OfferIdLabel.Text = offer.Offer_id.ToString();
            CompanyNameEntry.Text = offer.Company_name;
            ContractTypeEntry.Text = offer.Type_of_contract;
            JobTypeEntry.Text = offer.Type_of_job;
            SalaryEntry.Text = offer.Salary;
            CategoryEntry.Text = offer.Category;
            DutiesEditor.Text = offer.Duties;
            RequirementsEditor.Text = offer.Requirements;
		}

        private void EditOffer_Clicked(object sender, EventArgs e)
        {
			Offers offer = new Offers()
			{
				Offer_id = int.Parse(OfferIdLabel.Text),
                Company_name = CompanyNameEntry.Text,
				Type_of_contract = ContractTypeEntry.Text,
				Type_of_job = JobTypeEntry.Text,
				Salary = SalaryEntry.Text,
				Category = CategoryEntry.Text,
				Duties = DutiesEditor.Text,
				Requirements = RequirementsEditor.Text
            };

			db.Offer_EditData(offer);

			DisplayAlert("Info", "Oferta została zedytowana", "OK");
			Navigation.PopAsync();
        }
    }
}