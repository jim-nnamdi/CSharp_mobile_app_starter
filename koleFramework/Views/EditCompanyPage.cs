using System;
using System.IO;
using koleFramework.Models;
using SQLite;
using Xamarin.Forms;

namespace koleFramework.Views
{
    public class EditCompanyPage : ContentPage
    {
        // Specify class variables

        private ListView _listview;

        private Entry _idEntry;

        private Entry _nameEntry;

        private Entry _addressEntry;

        private Button _button;

        Company _company = new Company();


        // Database initialization for the editing of elements

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditCompanyPage()
        {

            // specify the title of the page

            this.Title = "Edit kole companies";


            // start a secure database connection

            var db = new SQLiteConnection(_dbPath);

             
            // create the layouts for the items to be edited

            StackLayout stacklayout = new StackLayout();

            _listview = new ListView();

            _listview.ItemsSource = db.Table<Company>().OrderBy(x => x.Id).ToList();

            _listview.ItemSelected += _listview_ItemSelected;

            stacklayout.Children.Add(_listview );



            // set the edit element for  id

            _idEntry = new Entry();

            _idEntry.Placeholder = "Company Name";

            _idEntry.IsVisible = false;

            stacklayout.Children.Add(_idEntry);



            // set the edit element for  name

            _nameEntry = new Entry();

            _nameEntry.Keyboard = Keyboard.Text;

            _nameEntry.Placeholder = "Company Name";

            stacklayout.Children.Add(_nameEntry);



            // set the address element for  address

            _addressEntry = new Entry();

            _addressEntry.Keyboard = Keyboard.Text;

            _addressEntry.Placeholder = "Company Address";

            stacklayout.Children.Add(_addressEntry);


            // set the button for saving elements

            _button = new Button();

            _button.Text = "Update company details";

            _button.Clicked += _button_Clicked;

            stacklayout.Children.Add(_button);

            Content = stacklayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            Company company = new Company()
            {
                Id = Convert.ToInt32(_idEntry.Text),

                Name = _nameEntry.Text,

                Address = _addressEntry.Text
            };

            db.Update(company);

            await DisplayAlert(null, company.Name + "Updated", "ok");

            await Navigation.PopAsync();
        }

        private void _listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem;

            _nameEntry.Text = _company.Name;

            _addressEntry.Text = _company.Address;

        }
    }
}

