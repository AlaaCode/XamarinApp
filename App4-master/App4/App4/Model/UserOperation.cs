using System;
using System.Collections.Generic;
using System.Text;
namespace App4.Model
{
    class UserOperation
    {
        SQLite.SQLiteConnection database;
        LoginPage p;
        public UserOperation(LoginPage _p,SQLite.SQLiteConnection _database)
        {
            database = _database;
            p = _p;
        }
        //public UserOperation() { }

        public User FindUserByEmailAndPassword(String email,String password)
        {
            User s = (User)database.Find<User>(email);
            if (s != null && s.Password.Equals(password))
            {
                return s;
            }
            else
            {
                return null;
            }
        }

        public void AddUser(User s)
        {
            try
            {
                database.Insert(s);
            }
            catch(Exception e)
            {
                p.DisplayAlert("ERREUR", e.Message, "ok"); 
            }
        }
    }
}
