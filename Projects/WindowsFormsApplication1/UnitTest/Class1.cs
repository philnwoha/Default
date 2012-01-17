using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WindowsFormsApplication1;

namespace UnitTest
{
    [TestFixture]
    public class Class1
    {
        String filepath = @"C:\temp\unittest.txt";
        private Controller controller;
        [SetUp]
        public void initialize()
        {
            controller = new Controller();
        }

        [Test]
        public void testSavingNewUser()
        {
            controller.setFilePath(filepath);
            String message = controller.save("firstname", "lastName", "emailAddress", "password");
            Assert.AreEqual(message, "User saved successfully!");

            System.IO.File.Delete(filepath);
        }

        [Test]
        public void testSavingExistingUser()
        {
            controller.setFilePath(filepath);
            controller.save("firstname", "lastName", "emailAddress", "password");

            //try saving the same user again
            String message = controller.save("firstname", "lastName", "emailAddress", "password");
            Assert.AreEqual(message, "User already exists!");

            System.IO.File.Delete(filepath);
        }
    }
}
