using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;
using system_ogloszeniowy.Tables;

namespace system_ogloszeniowy
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Announcement>().Wait();
            _database.CreateTableAsync<Announcement_category>().Wait();
            _database.CreateTableAsync<Announcement_subcategory>().Wait();
            _database.CreateTableAsync<Announcement_working_days>().Wait();
            _database.CreateTableAsync<Company>().Wait();
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<User_application>().Wait();
            _database.CreateTableAsync<User_course>().Wait();
            _database.CreateTableAsync<User_data>().Wait();
            _database.CreateTableAsync<User_education>().Wait();
            _database.CreateTableAsync<User_experience>().Wait();
            _database.CreateTableAsync<User_language>().Wait();
            _database.CreateTableAsync<User_link>().Wait();
            _database.CreateTableAsync<User_role>().Wait();
            _database.CreateTableAsync<User_saved>().Wait();
            _database.CreateTableAsync<User_skill>().Wait();
        }

        public Task<List<User>> GetUsers()
        {
            return _database.QueryAsync<User>("SELECT * FROM User");
        }

        public Task<List<User>> GetUsers(string email)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Email=?", email);
        }

        public Task<List<User>> GetUsers(string email, string password)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Email=? AND Password=?", email, password);
        }

        public Task<int> InsertUser(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<int> InsertRole(User_role role)
        {
            return _database.InsertAsync(role);
        }
        public Task<List<User_role>> GetRoles()
        {
            return _database.QueryAsync<User_role>("SELECT * FROM User_role");
        }
    }
}
