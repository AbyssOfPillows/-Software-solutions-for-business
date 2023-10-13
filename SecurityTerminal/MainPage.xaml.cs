using System.Text.Json;
using Application = API.Models.Application;

namespace SecurityTerminal
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Entry_Completed(object sender, EventArgs e)
        {
            string myText = ((Entry)sender).Text;

            HttpClient client = new();
            string apiUrl = $"http://localhost:5299/Application/Application/GetEmployeeСodeСomparison?empCode={myText}&departamentNumber=6";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent != null)
            {
                Application[] applications = JsonSerializer.Deserialize<Application[]>(responseContent);
                await Navigation.PushAsync(new applicationsPage(applications));
            }
            else LabelError.Text = "Такого сотрудника нет";
        }
    }
}