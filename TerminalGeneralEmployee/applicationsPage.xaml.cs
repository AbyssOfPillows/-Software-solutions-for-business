using API.Models;
using System.Text.RegularExpressions;
using Application = API.Models.Application;
using Group = API.Models.Group;

namespace TerminalGeneralEmployee;

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
        Label header = new Label { Text = "������ �������������", FontSize = 18 };
        // ���������� �������� ������
        applicationListView.ItemsSource = resultApplications.ToList<Application>();
        // ���������� ������ ������
        applicationListView.ItemTemplate = new DataTemplate(() =>
        {
            // �������� � �������� Name
            Label FioLabel = new Label { FontSize = 16 };
            FioLabel.SetBinding(Label.TextProperty, "Fio");

            // �������� � �������� Age
            Label PhoneNumberLabel = new Label { FontSize = 14 };
            PhoneNumberLabel.SetBinding(Label.TextProperty, "PhoneNumber");

            Label EMailLabel = new Label { FontSize = 16 };
            EMailLabel.SetBinding(Label.TextProperty, "EMail");

            // �������� � �������� Age
            Label DateOfBirthLabel = new Label { FontSize = 14 };
            DateOfBirthLabel.SetBinding(Label.TextProperty, "DateOfBirth");

            Label PasportDetailsLabel = new Label { FontSize = 16 };
            PasportDetailsLabel.SetBinding(Label.TextProperty, "PasportDetails");

            // �������� � �������� Age
            Label LoginLabel = new Label { FontSize = 14 };
            LoginLabel.SetBinding(Label.TextProperty, "Login");

            Label PasswordLabel = new Label { FontSize = 16 };
            PasswordLabel.SetBinding(Label.TextProperty, "Password");

            // �������� � �������� Age
            Label ApprovedLabel = new Label { FontSize = 14 };
            ApprovedLabel.SetBinding(Label.TextProperty, "Approved");

            Label ReasonLabel = new Label { FontSize = 16 };
            ReasonLabel.SetBinding(Label.TextProperty, "Reason");

            // �������� � �������� Age
            Label TypeApplicationLabel = new Label { FontSize = 14 };
            TypeApplicationLabel.SetBinding(Label.TextProperty, "TypeApplication");

            Label TheDesiredStartOfTheActionOfTheApplicationLabel = new Label { FontSize = 16 };
            TheDesiredStartOfTheActionOfTheApplicationLabel.SetBinding(Label.TextProperty, "TheDesiredStartOfTheActionOfTheApplication");

            // �������� � �������� Age
            Label TheDesiredEndOfTheActionOfTheApplicationLabel = new Label { FontSize = 14 };
            TheDesiredEndOfTheActionOfTheApplicationLabel.SetBinding(Label.TextProperty, "TheDesiredEndOfTheActionOfTheApplication");

            Label NoteLabel = new Label { FontSize = 16 };
            NoteLabel.SetBinding(Label.TextProperty, "Note");

            // �������� � �������� Age
            Label OrganizationLabel = new Label { FontSize = 14 };
            OrganizationLabel.SetBinding(Label.TextProperty, "Organization");


            // ������� ������ ViewCell.
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
        string status = (string)StatusPicker.SelectedItem;
        bool statusBool;
        if (status == "1")
        {
            statusBool = true;
        }
        else statusBool = false;
        foreach (Application ap in dupliateApplications.ToArray())
        {
            if ((ap.TypeApplication != type) && (ap.Approved != statusBool))
            {
                var result = resultApplications.First(a => a.Id == ap.Id);
                resultApplications.Remove(result);
            }
        }
        string departament = (string)DepartamentPicker.SelectedItem;
        foreach (Application ap in resultApplications)
        {
            CompanyContext db = new CompanyContext();
            Group? refGroup = db.Groups.Where(t => t.Id == ap.GroupId).Select(t => t).FirstOrDefault();
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
            if (ap.Approved != statusBool)
            {
                resultApplications.Remove(ap);
            }
        }
        InitializePage();

    }
}