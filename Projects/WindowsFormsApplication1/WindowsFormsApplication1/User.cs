using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class User
    {
        private String _firstName;
        public String FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private String _lastName;
        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private String _emailAddress;
        public String EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        private String _password;
        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public override string ToString()
        {
            return FirstName + " " + LastName + " " + EmailAddress + " " + Password;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;
            User user = obj as User;

            if (this.FirstName.Equals(user.FirstName) && this.LastName.Equals(user.LastName))
                return true;
            return false;
        }

    }
}
