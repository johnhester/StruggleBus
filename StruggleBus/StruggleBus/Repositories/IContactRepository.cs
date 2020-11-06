using StruggleBus.Models;
using System.Collections.Generic;

namespace StruggleBus.Repositories
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        void Delete(int contactId);
        void Edit(Contact contact);
        Contact GetById(int contactId);
        List<Contact> GetByUserId(int userId);
    }
}