using Microsoft.Extensions.Configuration;
using StruggleBus.Models;
using StruggleBus.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StruggleBus.Repositories
{
    public class ContactRepository : BaseRepository, IContactRepository
    {

        public ContactRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Contact contact)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Contact (UserId, Name, ContactPhone)
                                        OUTPUT INSERTED.ID
                                        VALUES (@UserId, @Name, @CotactPhone)";
                    DbUtils.AddParameter(cmd, "@UserId", contact.UserId);
                    DbUtils.AddParameter(cmd, "@Name", contact.Name);
                    DbUtils.AddParameter(cmd, "@ContactPhone", contact.ContactPhone);

                    contact.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public List<Contact> GetByUserId(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string getCommentsSql = @"
                            SELECT Id, UserId, Name, ContactPhone
                            FROM Contact
                            WHERE UserId = @userId
                        ";

                    cmd.CommandText = getCommentsSql;

                    DbUtils.AddParameter(cmd, "@userId", userId);

                    var reader = cmd.ExecuteReader();

                    List<Contact> contacts = new List<Contact>();

                    while (reader.Read())
                    {
                        Contact contact = new Contact()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = userId,
                            Name = DbUtils.GetString(reader, "Name"),
                            ContactPhone = DbUtils.GetString(reader, "ContactPhone")

                        };

                        contacts.Add(contact);
                    }

                    reader.Close();

                    return contacts;
                }
            }
        }

        public Contact GetById(int contactId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string getCommentsSql = @"
                            SELECT Id, UserId, Name, ContactPhone
                            FROM Contact
                            WHERE Id = @contactId
                        ";

                    cmd.CommandText = getCommentsSql;

                    DbUtils.AddParameter(cmd, "@contactId", contactId);

                    var reader = cmd.ExecuteReader();

                    Contact contact = null;

                    if (reader.Read())
                    {
                        contact = new Contact()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ContactPhone = DbUtils.GetString(reader, "ContactPhone")

                        };

                    }

                    reader.Close();

                    return contact;
                }
            }
        }

        public void Edit(Contact contact)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                       UPDATE Contact
                       SET
                        UserId = @userId,
                        Name = @name,
                        ContactPhone = @contactPhone
                       WHERE
                        Id = @id
                    ";

                    cmd.Parameters.AddWithValue("@Id", contact.Id);
                    cmd.Parameters.AddWithValue("@userId", contact.UserId);
                    cmd.Parameters.AddWithValue("@name", contact.Name);
                    cmd.Parameters.AddWithValue("@contactPhone", contact.ContactPhone);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int contactId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        DELETE FROM UserMessages Where ContactId = @contactId
                        DELETE FROM Contact WHERE Id = @contactId
                    ";

                    DbUtils.AddParameter(cmd, "@contactId", contactId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
