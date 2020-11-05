using StruggleBus.Models;
using System.Collections.Generic;

namespace StruggleBus.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByFirebaseUserId(string firebaseUserId);
        User GetByPhoneNumber(string phoneNumber);
        List<User> GetAllButCurrent(int userId);
        void Edit(User user);
        void Remove(int id);

    }
}