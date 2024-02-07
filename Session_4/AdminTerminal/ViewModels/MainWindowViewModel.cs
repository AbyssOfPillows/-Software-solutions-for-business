using AdminTerminal.Models;
using AdminTerminal.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdminTerminal.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() { }
        public List<Type> Types { get; set; }
        public string? Login { get; set; } = "Agripina17";
        public string? Password { get; set; } = "obdxbosmqa";
        public string? secretWord { get; set; } = "Сова";
        public MainWindow? Owner { get; set; }
        public Type SelectedType { get; set; }
        public MainWindowViewModel(MainWindow mainWindow)
        {
            Owner = mainWindow;
            Session4Context Session4Context = new Session4Context();
            List<Type> types = Session4Context.Types.ToList();
            Types = types;
        }
        public void Button_Auth()
        {
            Session4Context Session4Context = new Session4Context();
            User? user = Session4Context.Users.FirstOrDefault(u => u.Login == Login);
            Session4Context.Posts.Load();
            if (user != null && user.Password == Password && user.TypeId == SelectedType.Id && user.SecretWord == secretWord && user.Post.Name == "Администратор доступа")
            {
                WindowManaging windowManagingAvailable = new WindowManaging();
                windowManagingAvailable.DataContext = new ManagingWindowViewModel(windowManagingAvailable, user);
                windowManagingAvailable.Show();
                Owner?.Close();
            }
            else Owner.WarningText.IsVisible = true;
        }
    }
}
