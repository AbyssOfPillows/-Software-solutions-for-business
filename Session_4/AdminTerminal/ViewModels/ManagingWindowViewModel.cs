using AdminTerminal.Models;
using DynamicData.Kernel;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdminTerminal.ViewModels
{
    internal class ManagingWindowViewModel
    {
        User user { get; set; }
        public WindowManaging Owner { get; set; }
        public string Fio {  get; set; }

        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? UserPatronymic { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string[] Sex { get; set; } = new string[2] { "М", "Ж"};
        public string SelectedSex { get; set; }
        public string? Post { get; set; }
        public ManagingWindowViewModel(WindowManaging window, User user)
        {
            this.user = user;
            UserName = user.Name;
            UserSurname = user.Surname;
            UserPatronymic = user.Patryonomic;
            Fio = UserName + " " + UserSurname + " " + UserPatronymic;
            Owner = window;
        }
        public void Button_Save()
        {
            Session4Context session4Context = new Session4Context();
            User newUser = new User();
            newUser.Name = Name;
            newUser.Surname = Surname;
            newUser.Patryonomic = Patronymic;
            newUser.Sex = SelectedSex;
            newUser.PostId = session4Context.Posts.First(p => p.Name == Post).Id;
            newUser.True = false;
            session4Context.Add(newUser);
            session4Context.SaveChanges();
        }
        public void Cancel_Save()
        {
            Name = " ";
            Surname = " ";
            Patronymic = " ";
            SelectedSex = " ";
            Post = " ";
        }
    }
}
