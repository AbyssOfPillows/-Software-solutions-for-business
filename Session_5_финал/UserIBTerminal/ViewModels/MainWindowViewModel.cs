using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserIBTerminal.Models;
using UserIBTerminal.Views;

namespace UserIBTerminal.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() { }
        public List<Type>? ListTypesUser { get; set; }
        public string? Login { get; set; } = "YUrin68";
        public string? Password { get; set; } = "hibljzslmv";
        public string? SecretWord { get; set; } = "Спутник";
        public MainWindow? Owner { get; set; }
        public Type? SelectedType { get; set; }
        public MainWindowViewModel(MainWindow mainWindow)
        {
            Owner = mainWindow;
            Session4Context session4Context = new();
            session4Context.Users.Load();
            ListTypesUser = session4Context.Types.ToList();
        }
        public void Button_Auth()
        {
            Session4Context session4Context = new();
            session4Context.Posts.Load();
            User? user = session4Context.Users.FirstOrDefault(u => u.Login == Login);
            if (user != null && user.Password == Password && user.TypeId == SelectedType?.Id && user.SecretWord == SecretWord && user?.Post?.Name == "Специалист по ИБ")
            {
                ManageSecurityTerminal manageSecurityTerminal = new ManageSecurityTerminal();
                manageSecurityTerminal.DataContext = new ManageSecurityTerminalViewModel(manageSecurityTerminal, user);
                manageSecurityTerminal.Show();
                Owner.Close();

            }
            else Owner!.WarningText.IsVisible = true;
        }
    }
}