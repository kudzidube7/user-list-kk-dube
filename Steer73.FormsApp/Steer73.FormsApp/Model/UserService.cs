using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steer73.FormsApp.Model
{
    public class UserService : IUserService
    {
        private static readonly IEnumerable<User> Users = new[]
        {
            new User { FirstName = "Alexandru", LastName = "Vint", Initials = "A V" },
            new User { FirstName = "Jon", LastName = "Bennett" , Initials = "J B"},
            new User { FirstName = "Alex", LastName = "Welding" , Initials = "A W"},
            new User { FirstName = "Nick", LastName = "Waites" , Initials = "N W"},
              new User { FirstName = "Kudzai", LastName = "Dube" , Initials = "K D"},
        };

        public async Task<IEnumerable<User>> GetUsers()
        {
            await Task.Delay(1500);

            return await Task.FromResult(Users);
        }
    }

    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    }
}