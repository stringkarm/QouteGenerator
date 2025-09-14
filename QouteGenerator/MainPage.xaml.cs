using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;
using Microsoft.Maui.Controls;

namespace QouteGenerator
{
    public partial class MainPage : ContentPage
    {

        private List<string> quotes;

        public MainPage()
        {
            InitializeComponent();
            LoadQuotes();
        }

        private async void LoadQuotes()
        {
            quotes = new List<string>();

            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("qoutes.txt");
                using var reader = new StreamReader(stream);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        quotes.Add(line.Trim());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load quotes: {ex.Message}", "OK");
            }
        }

        private void btnGenerate_Clicked(object sender, EventArgs e)
        {
            if (quotes.Count > 0)
            {
                int index = new Random().Next(quotes.Count);
                lblQuote.Text = quotes[index];
            }
            else
            {
                lblQuote.Text = "No quotes found.";
            }
        }
    }

}
