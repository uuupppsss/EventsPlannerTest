using EventsPlannerTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventsPlannerTest.Controllers
{
    public class AuthController
    {
        private List<User> users;

        public AuthController(List<User> _users)
        {
            users= _users;
        }

        //Users/GetUsersList - Запрос для получения списка пользователей. Ничего не принимает, параметр ответа: List<User>
        public List<User> GetUsersList()
        {
            List<User> result = [.. users];
            return result;
        }

        //Users/SignIn - Запрос Post для авторизации. Принимает параметр: объект User, параметр ответа: обьект User
        public User SignIn(User user)
        {
            User found_user=users.FirstOrDefault(u=>u.Email==user.Email);
            if (found_user != null && found_user.Password == user.Password) return found_user;
            else return null;
        }

        //Users/SignUp - Запрос Post для регистрации. Принимает параметр: объект User, параметр ответа: 200
        public void SignUp(User user)
        {
            user.Role = "user";
            users.Add(user);
        }

        //Users/DeleteUser - Запрос Delete для удаления пользователя. Принимает параметр: int id, параметр ответа: 200
        public void DeleteUser(int id)
        {
            var user= users.FirstOrDefault(u=>u.Id==id);
            if(user!=null) users.Remove(user);
        }
    }
}
