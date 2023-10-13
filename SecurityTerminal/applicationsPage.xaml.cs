using API.Models;
using System.Text.RegularExpressions;
using Application = API.Models.Application;
namespace SecurityTerminal;

public partial class applicationsPage : ContentPage
{
    public List<Application> resultApplications;
    public List<Application> dupliateApplications;
    public applicationsPage(Application[] applications)
	{
		InitializeComponent();
        dupliateApplications = applications.ToList();
        resultApplications = dupliateApplications;
        InitializePage();
    }
    public void InitializePage()
    {
        Label header = new Label { Text = "Список пользователей", FontSize = 18 };
        // определяем источник данных
        applicationListView.ItemsSource = resultApplications.ToList<Application>();
        // определяем шаблон данных
        applicationListView.ItemTemplate = new DataTemplate(() =>
        {
            // привязка к свойству Name
            Label FioLabel = new Label { FontSize = 16 };
            FioLabel.SetBinding(Label.TextProperty, "Fio");

            // привязка к свойству Age
            Label PhoneNumberLabel = new Label { FontSize = 14 };
            PhoneNumberLabel.SetBinding(Label.TextProperty, "PhoneNumber");

            Label EMailLabel = new Label { FontSize = 16 };
            EMailLabel.SetBinding(Label.TextProperty, "EMail");

            // привязка к свойству Age
            Label DateOfBirthLabel = new Label { FontSize = 14 };
            DateOfBirthLabel.SetBinding(Label.TextProperty, "DateOfBirth");

            Label PasportDetailsLabel = new Label { FontSize = 16 };
            PasportDetailsLabel.SetBinding(Label.TextProperty, "PasportDetails");

            // привязка к свойству Age
            Label LoginLabel = new Label { FontSize = 14 };
            LoginLabel.SetBinding(Label.TextProperty, "Login");

            Label PasswordLabel = new Label { FontSize = 16 };
            PasswordLabel.SetBinding(Label.TextProperty, "Password");

            // привязка к свойству Age
            Label ApprovedLabel = new Label { FontSize = 14 };
            ApprovedLabel.SetBinding(Label.TextProperty, "Approved");

            Label ReasonLabel = new Label { FontSize = 16 };
            ReasonLabel.SetBinding(Label.TextProperty, "Reason");

            // привязка к свойству Age
            Label TypeApplicationLabel = new Label { FontSize = 14 };
            TypeApplicationLabel.SetBinding(Label.TextProperty, "TypeApplication");

            Label TheDesiredStartOfTheActionOfTheApplicationLabel = new Label { FontSize = 16 };
            TheDesiredStartOfTheActionOfTheApplicationLabel.SetBinding(Label.TextProperty, "TheDesiredStartOfTheActionOfTheApplication");

            // привязка к свойству Age
            Label TheDesiredEndOfTheActionOfTheApplicationLabel = new Label { FontSize = 14 };
            TheDesiredEndOfTheActionOfTheApplicationLabel.SetBinding(Label.TextProperty, "TheDesiredEndOfTheActionOfTheApplication");

            Label NoteLabel = new Label { FontSize = 16 };
            NoteLabel.SetBinding(Label.TextProperty, "Note");

            // привязка к свойству Age
            Label OrganizationLabel = new Label { FontSize = 14 };
            OrganizationLabel.SetBinding(Label.TextProperty, "Organization");


            // создаем объект ViewCell.
            return new ViewCell
            {
                View = new StackLayout
                {

                    Padding = new Thickness(0, 5),
                    Orientation = StackOrientation.Vertical,
                    Children = { FioLabel, PhoneNumberLabel, EMailLabel, DateOfBirthLabel, PasportDetailsLabel, LoginLabel, PasswordLabel, ApprovedLabel, ReasonLabel, TypeApplicationLabel }
                }
            };
        });
        applicationListView.ItemSelected += (sender, e) =>
        {
            if (e.SelectedItem == null)
                return;
            Application application = (Application)e.SelectedItem;
            editPage editWindow = new editPage(application);
            Navigation.PushModalAsync(editWindow);
            InitializePage();
        };
    }
    private void ConfirmBtn(object sender, EventArgs e)
    {
        string type = (string)TypePicker.SelectedItem;
        foreach (Application ap in dupliateApplications.ToArray())
        {
            if (ap.TypeApplication != type)
            {
                var result = resultApplications.First(a => a.Id == ap.Id);
                resultApplications.Remove(result);
            }
        }
        string data = DateEntry.Text;
        foreach (Application ap in resultApplications.ToArray())
        {
            CompanyContext db = new CompanyContext();
            API.Models.Group? refGroup = db.Groups.Where(t => t.Id == ap.GroupId).Select(t => t).FirstOrDefault();
            if (refGroup != null)
            {
                Appointment? app = db.Appointments.Where(t => t.Id == refGroup.Appointment).Select(t => t).FirstOrDefault();
                if (app != null)
                {
                    if (app.DateOfVisit != DateEntry.Text)
                    {
                        resultApplications.Remove(ap);
                    }
                }
            }
        }
        string departament = (string)DepartamentPicker.SelectedItem;
        foreach (Application ap in resultApplications)
        {
            CompanyContext db = new CompanyContext();
            API.Models.Group refGroup = db.Groups.Where(t => t.Id == ap.GroupId).Select(t => t).FirstOrDefault();
            if (refGroup != null)
            {
                Appointment? app = db.Appointments.Where(t => t.Id == refGroup.Appointment).Select(t => t).FirstOrDefault();
                if (app != null)
                {
                    string? date = app.DateOfVisit;
                    Employe? emp = db.Employes.Where(t => t.EmployeeCode == app.EmployeId).Select(t => t).FirstOrDefault();
                    if (emp != null)
                    {
                        Departament? department = db.Departaments.Where(t => t.Id == emp.Departament).Select(t => t).FirstOrDefault();
                        string? findDep = department?.Departament1;
                        if (findDep != (string)DepartamentPicker.SelectedItem)
                        {
                            resultApplications.Remove(ap);
                        }

                    }
                }
            }
        }
        InitializePage();

    }

    private void SearchBtn(object sender, EventArgs e)
    {
        string fio = FIO.Text;
        string searchNumPassport = NumPassport.Text;
        foreach (Application ap in dupliateApplications.ToArray())
        {
            string numPassport = ap.PasportDetails.ToString();
            numPassport = numPassport.Substring(4);
            if ((ap.Fio == fio) && (numPassport == searchNumPassport))
            {
                resultApplications.Clear();
                resultApplications.Add(ap);
                InitializePage();
            }
        }
    }
}