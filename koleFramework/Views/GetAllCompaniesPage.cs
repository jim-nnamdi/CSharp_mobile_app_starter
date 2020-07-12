using System;
using System.IO;
using koleFramework.Models;
using SQLite;
using Xamarin.Forms;

namespace koleFramework.Views
{
    public class GetAllCompaniesPage : ContentPage
    {

        // declare a list view

        private ListView _listview;

        // initialize the database connections

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public GetAllCompaniesPage()
        {
            this.Title = "Get companies";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stacklayout = new StackLayout();

            _listview = new ListView();

            _listview.ItemsSource = db.Table<Company>().OrderBy(x => x.Id).ToList();

            stacklayout.Children.Add(_listview);

            Content = stacklayout;

        }
    }
}

