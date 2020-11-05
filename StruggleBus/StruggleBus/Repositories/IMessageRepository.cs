using StruggleBus.Models;
using System.Collections.Generic;

namespace StruggleBus.Repositories
{
    public interface IMessageRepository
    {
        void Add(UserMessage message);
        List<UserMessage> getUserMessages(int userId);
    }
}