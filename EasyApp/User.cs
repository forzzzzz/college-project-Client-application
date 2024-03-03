﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyApp
{
    class User
    {
        public int Id { get; set; }
        private string login, email, pass;


        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }


        public User() { }

        public User (string login, string email, string pass)
        {
            this.login = login;
            this.email = email;
            this.pass = pass;
        }

        //public override string ToString()
        //{
        //    return "Користувач: " + Login + ". Email: " + Email;
        //}
    }
}
