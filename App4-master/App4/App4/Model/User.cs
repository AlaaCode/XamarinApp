using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace App4.Model
{
    class User
    {
        public User() { }

        String nom;
        String prenom;
        String password;
        String email;

        [PrimaryKey]
        public string Email { get => email; set => email = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Password { get => password; set => password = value; }
        
    }
}
