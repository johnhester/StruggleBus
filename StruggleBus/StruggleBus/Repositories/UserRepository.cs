using Microsoft.Extensions.Configuration;
using StruggleBus.Models;
using StruggleBus.Utils;
using System.Collections.Generic;

namespace StruggleBus.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public User GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, FirebaseUserId, UserName, Email, FirstName, LastName, UserPhone
                          FROM [User] 
                         WHERE FirebaseUserId = @FirebaseUserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            UserName = DbUtils.GetString(reader, "UserName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            UserPhone = DbUtils.GetString(reader, "UserPhone")
                        };
                    }
                    reader.Close();

                    return user;
                }
            }
        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, FirebaseUserId, UserName, Email, FirstName, LastName, UserPhone
                          FROM [User] 
                         WHERE UserPhone = @phoneNumber";

                    DbUtils.AddParameter(cmd, "@phoneNumber", phoneNumber);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            UserName = DbUtils.GetString(reader, "UserName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            UserPhone = DbUtils.GetString(reader, "UserPhone")
                        };
                    }
                    reader.Close();

                    return user;
                }
            }
        }

        public List<User> GetAllButCurrent(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, FirebaseUserId, UserName, Email, FirstName, LastName, UserPhone
                          FROM [User] 
                         WHERE Id != @userId";

                    DbUtils.AddParameter(cmd, "@userId", userId);

                    

                    var users = new List<User>();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            UserName = DbUtils.GetString(reader, "UserName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            UserPhone = DbUtils.GetString(reader, "UserPhone")
                        };

                        users.Add(user);
                    }
                    reader.Close();

                    return users;
                }
            }
        }

        public void Add(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [User] (FirebaseUserId, UserName, Email, FirstName, LastName, UserPhone)
                                        OUTPUT INSERTED.ID
                                        VALUES (@FirebaseUserId, @UserName, @Email, @FirstName, @LastName, @UserPhone)";
                    DbUtils.AddParameter(cmd, "@FirebaseUserId", user.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@UserName", user.UserName);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@FirstName", user.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", user.LastName);
                    DbUtils.AddParameter(cmd, "@UserPhone", user.UserPhone);

                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        } 

        public void Edit(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                       UPDATE [User]
                       SET
                        FirebaseUserId = @FirebaseUserId,
                        UserName = @UserName,
                        Email = @Email,
                        FirstName = @FirstName,
                        LastName = @LastName,
                        UserPhone = @UserPhone
                       WHERE
                        Id = @Id
                    ";

                    DbUtils.AddParameter(cmd, "@Id", user.Id);
                    DbUtils.AddParameter(cmd, "@FirebaseUserId", user.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@UserName", user.UserName);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@FirstName", user.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", user.LastName);
                    DbUtils.AddParameter(cmd, "@UserPhone", user.UserPhone);             


                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public void Remove(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            Delete from FriendJoin Where User1Id = @id OR User2Id = @id
                            Delete from DefaultActive Where UserId = @id
                            Delete from Contact Where UserId = @id
                            Delete from UserMessages Where UserId = @id
                            Delete from User Where id = @id
                            ";
                    DbUtils.AddParameter(cmd, "@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
