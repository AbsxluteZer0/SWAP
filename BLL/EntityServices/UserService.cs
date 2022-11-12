using SWAP.DAL.Data;
using SWAP.DAL.Data.Interfaces;

namespace SWAP.BLL.EntityServices
{
    internal class UserService
    {
        private readonly IApplicationContext context;
        public User? User { get; private set; }

        public UserService(IApplicationContext context)
        {
            this.context = context;
        }

        public void Register(string email, string userName, string password)
        {
            if (context.Users.Any(u => u.Email.Equals(email)))
            {
                throw new ApplicationException("Користувач з такою ел. поштою вже зареєстрований");
            }

            User newUser = new User { Email = email, UserName = userName, Password = password };

            context.Users.Add(newUser);

            context.SaveData();

            User = newUser;
        }

        public void Login(string email, string password)
        {
            User? user = context.Users.FirstOrDefault(u => u.Email.Equals(email));

            if (user == null)
            {
                throw new ApplicationException("Користувача з такою ел. поштою не знайдено");
            }

            if (!user.Password.Equals(password))
            {
                throw new ApplicationException("Невірний пароль");
            }

            User = user;
        }

        public string GetProfile()
        {
            if (User == null)
            {
                throw new UnauthorizedAccessException("користувач неавторизований");
            }

            return "Ел. пошта: " + User.Email + "\tІм'я користувача: " + User.UserName;
        }

        public void EditUserName(string newUserName)
        {
            if (User == null)
            {
                throw new UnauthorizedAccessException("користувач неавторизований");
            }


            User.UserName = newUserName;
            context.Users.Update(User);

            context.SaveData();
        }

        public void EditPassword(string password, string newPassword)
        {
            if (User == null)
            {
                throw new UnauthorizedAccessException("користувач неавторизований");
            }

            if (!User.Password.Equals(password))
            {
                throw new ApplicationException("введено невірний старий пароль");
            }

            User.Password = newPassword;
            context.Users.Update(User);

            context.SaveData();
        }
    }
}
