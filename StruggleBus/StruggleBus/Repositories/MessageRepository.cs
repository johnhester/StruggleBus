using Microsoft.Extensions.Configuration;
using StruggleBus.Models;
using StruggleBus.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StruggleBus.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserMessage> getUserMessages(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, UserId, Message
                        FROM UserMessage 
                        WHERE UserId = @userId
                        ORDER BY Id Desc";

                    DbUtils.AddParameter(cmd, "@userId", userId);

                    List<UserMessage> messages = new List<UserMessage>();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var message = new UserMessage()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = userId,
                            Message = DbUtils.GetString(reader, "Message")
                        };

                        messages.Add(message);
                    }
                    reader.Close();

                    return messages;
                }
            }
        }

        public void Add(UserMessage message)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserMessage (UserId, Message)
                                        OUTPUT INSERTED.ID
                                        VALUES (@UserId, @Message)";
                    DbUtils.AddParameter(cmd, "@UserId", message.UserId);
                    DbUtils.AddParameter(cmd, "@Message", message.Message);

                    message.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
