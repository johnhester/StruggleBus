using StruggleBus.Models;

namespace StruggleBus.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByFirebaseUserId(string firebaseUserId);
        void Edit(User user);
        void Remove(int id);

    }
}