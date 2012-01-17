using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication1
{
    public class Controller
    {
        List<User> listOfUsers;
        String filePath = @"C:\temp\listOfUsers.txt";
        public Controller()
        {
            listOfUsers = new List<User>();
            
        }
        public void setFilePath(String path)
        {
            filePath = path;
        }
        private void loadUsers()
        {
            StreamReader fileLoader = new StreamReader(filePath);

            String line;
            while (!fileLoader.EndOfStream)
            {
                line = fileLoader.ReadLine();
                String[] splitString = line.Split(new Char[] { ' ' });

                //here i assume that we got back four strings
                User user = new User();
                user.FirstName = splitString[0];
                user.LastName = splitString[1];
                user.EmailAddress = splitString[2];
                user.Password = splitString[3];

                listOfUsers.Add(user);
            }
        }
        private bool verifyUserExists(User user)
        {
            if (listOfUsers.Contains(user))
                return true;
            else
                return false;
        }
        public String save(String firstName, String lastName, String emailAddress, String password)
        {
            if (!System.IO.File.Exists(filePath))
                System.IO.File.Create(filePath);

            loadUsers();
            //create the user 
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.EmailAddress = emailAddress;
            user.Password = password;

            //first verify that this user does not exist
            if (verifyUserExists(user))
                return "User already exists!";

            //make sure this temp directory exists or change the location.
            StreamWriter fileWriter = new StreamWriter(filePath, true);
            //fileWriter.WriteLine(firstName + " " + lastName + " " + emailAddress + " " + password);
            fileWriter.WriteLine(user.ToString());
            fileWriter.Close();

            return "User saved successfully!";
        }
    }
}
