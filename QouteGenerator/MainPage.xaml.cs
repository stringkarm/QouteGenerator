namespace QouteGenerator
{
    public partial class MainPage : ContentPage
    {
 

        public MainPage()
        {
            InitializeComponent();
        }



        private void btnGenerate_Clicked(object sender, EventArgs e)
        {
            int index = Random.Next(quotes.Count);
            lblQuote.Text = quotes[index];
        }
    }

}
