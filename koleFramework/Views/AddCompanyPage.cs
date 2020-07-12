using System;
using SQLite;
using System.IO;
using koleFramework.Models;
using Xamarin.Forms;

namespace koleFramework.Views
{
    public class AddCompanyPage : ContentPage
    {
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Button _saveButton;

        // setup the sqlite database connection

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        // set up the class constructor

        public AddCompanyPage()
        {
            this.Title = "Set kole options";

            // set up the stacklayout for boxing

            StackLayout stacklayout = new StackLayout();

            // the name entry field for the app

            _nameEntry = new Entry();

            _nameEntry.Keyboard = Keyboard.Text;

            _nameEntry.Placeholder = "Company Name here";

            stacklayout.Children.Add(_nameEntry);


            // the address entry field for the app

            _addressEntry = new Entry();

            _addressEntry.Keyboard = Keyboard.Text;

            _addressEntry.Placeholder = "Company Address";

            stacklayout.Children.Add(_addressEntry);


            // the save button field for the app

            _saveButton = new Button();

            _saveButton.Text = "Save Company Data";

            _saveButton.Clicked += _saveButton_Clicked;

            stacklayout.Children.Add(_saveButton);


            // Enclose all items inside the ContentPage

            Content = stacklayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            // create a table to hold data

            db.CreateTable<Company>();

            // set the primary key of the id

            var maxPk = db.Table<Company>().OrderByDescending(c => c.Id).FirstOrDefault();

            // send the data to the model

            Company company = new Company()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),

                Name = _nameEntry.Text,

                Address = _addressEntry.Text
            };

            // insert the data into the table and database

            db.Insert(company);

            await DisplayAlert(null, company.Name + " saved " , "ok" );

            // save and return event loop

            await Navigation.PopAsync();
        }
    }
}

