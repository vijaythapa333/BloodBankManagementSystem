using System;
using BloodBankManagementSystem.BLL;
using NUnit.Framework;

namespace BloodBankManagementSystem.Tests
{
    public class BllTests
    {
        [Test]
        public void loginBll_CanCreate_Get_Set()
        {
            var login = new loginBLL
            {
                username = "mahirbathija@gmail.com",
                password = "my_password", 
            };
            
            Assert.NotNull(login);
            Assert.AreEqual("mahirbathija@gmail.com", login.username);
            Assert.AreEqual("my_password", login.password);
        }
    }
}