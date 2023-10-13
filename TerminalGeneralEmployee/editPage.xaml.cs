using Application = API.Models.Application;

namespace TerminalGeneralEmployee;

public partial class editPage : ContentPage
{
    Application application;

    public editPage(Application application)
    {
        InitializeComponent();
        this.application = application;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool status;
        string data = Data.Text;
        string time = Time.Text;
        int id = application.Id;
        if ((string)Status.SelectedItem == "1")
            status = true;
        else status = false;
        HttpClient client = new HttpClient();
        string apiUrl = $"http://localhost:5299/Application/Application/PostApproved?status={status}&data={data}&time={time}&Id={id}";
        HttpResponseMessage response = await client.GetAsync(apiUrl);
        if (response != null)
        {
            if (response.IsSuccessStatusCode)
            {
                await Navigation.PopModalAsync();
            }
        }

    }
}