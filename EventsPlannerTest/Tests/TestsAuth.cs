using EventsPlannerTest.Controllers;
using EventsPlannerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlannerTest.Tests
{
    public class TestsAuth
    {
        AuthController Model;
        [SetUp]
        public void SetUp()
        {
            Model = new AuthController(new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name="admin",
                    Email="admin@admin.com",
                    Password="admin",
                    Role="admin"
                },

                new User()
                {
                    Id = 2,
                    Name="user",
                    Email="user@user.com",
                    Password="user",
                    Role="user"
                },
            });
        }
        [Test]
        public void GetUsersListTest()
        {
            var users=Model.GetUsersList();
            Assert.AreEqual(2, users.Count);
        }

        [Test]
        public void SignInTest()
        {
            var user = new User()
            {
                Email = "admin@admin.com",
                Password = "admin",
            };

            var found_user=Model.SignIn(user);

            var users = Model.GetUsersList();
            Assert.AreEqual(users.FirstOrDefault(u=>u.Email == "admin@admin.com"), found_user);
        }

        [Test]
        public void SignUpTest()
        {
            var user = new User()
            {
                Id = 3,
                Name = "me",
                Email = "me@mymail.com",
                Password = "123",
            };

            Model.SignUp(user);
            
            var users= Model.GetUsersList();
            var created_user=users.FirstOrDefault(u=>u.Email==user.Email);

            Assert.That(created_user.Name == user.Name && created_user.Email == user.Email &&
                created_user.Password == user.Password && created_user.Role == "user");
        }
    }
}
