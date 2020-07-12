using System;
using Xamarin.Forms;

namespace koleFramework.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Kolecompany options";

            // set stackLayout for display and boxing

            StackLayout stacklayout = new StackLayout();

            // set button that would handle navigations

            Button button = new Button();

            // set button properties

            button.Text = "Add Company";

            button.Clicked += Button_Clicked;

            // set the stacklayout for button inboxing

            stacklayout.Children.Add(button);


            //add the button to retrieve item

            button = new Button();

            button.Text = "Get companies";

            button.Clicked += Button_Get_Clicked;

            stacklayout.Children.Add(button);

            // add the button to edit content

            button = new Button();

            button.Text = "Edit Companies";

            button.Clicked += Button_Edit_Clicked;

            stacklayout.Children.Add(button);

            // close the stacklayout by attribution

            Content = stacklayout;
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompanyPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCompanyPage());
        }

        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllCompaniesPage());
        }
    }

}