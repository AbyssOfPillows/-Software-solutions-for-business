using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserIBTerminal.Models;
using UserIBTerminal.Views;
using static Google.Protobuf.Reflection.FieldOptions.Types;

namespace UserIBTerminal.ViewModels
{
    public class ManageSecurityTerminalViewModel
    {
        public User CurrentUser { get; set; }
        public List<UserIBTerminal.Models.Type> TypesUser { get; set; }
        public List<User> Users { get; set; }
        public ManageSecurityTerminal Owner { get; set; }
        Session4Context Session4Context { get; set; }
        public ManageSecurityTerminalViewModel(ManageSecurityTerminal owner, User currentUser) 
        {
            CurrentUser = currentUser;
            Owner = owner;
            Session4Context = new Session4Context();
            TypesUser = Session4Context.Types.ToList();
            Session4Context.Posts.Load();
            Users = Session4Context.Users.Where(u => u.True == false).ToList();
            for(int i = 0; i < Users.Count; i++)
            {
                Users[i].UserTypes = TypesUser;
            }
        }
        public void Save_Button()
        {
            foreach(var user in Users)
            {
                if(user.True == false)
                {
                    Session4Context.Remove(user);
                }
            }
            Session4Context.SaveChanges();
            
        }

    }
}
