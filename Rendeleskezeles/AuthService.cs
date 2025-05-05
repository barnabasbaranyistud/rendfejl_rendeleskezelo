using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendeleskezeles
{
    public class AuthService
    {
        private readonly string correctUsername;
        private readonly string correctPassword;

        public AuthService(string correctUsername, string correctPassword)
        {
            this.correctUsername = correctUsername;
            this.correctPassword = correctPassword;
        }

        public bool Authenticate(string username, string password)
        {
            return username == correctUsername && password == correctPassword;
        }
    }

}
