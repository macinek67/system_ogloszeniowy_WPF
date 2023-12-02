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
        public Task<List<User_language>> GetUser_language()
        {
            return _database.QueryAsync<User_language>("SELECT * FROM User_language");
        }
        public Task<List<User_language>> GetUser_language(int user_id)
        {
            return _database.QueryAsync<User_language>("SELECT * FROM User_language WHERE User_id=?", user_id);
        }
        public Task<int> InsertUser_language(User_language language)
        {
            return _database.InsertAsync(language);
        }
        public Task<List<User_data>> GetUser_data(int user_id)
        {
            return _database.QueryAsync<User_data>("SELECT * FROM User_data WHERE User_id=?", user_id);
        }
        public Task<int> InsertUser_data(User_data user_data)
        {
            return _database.InsertAsync(user_data);
        }
        public Task<int> DeleteUser_language(User_language language)
        {
            return _database.DeleteAsync(language);
        }
        public Task<int> UpdateUser_data(User_data user_data)
        {
            return _database.UpdateAsync(user_data);
        }
        public Task<int> InsertUser_education(User_education education)
        {
            return _database.InsertAsync(education);
        }
        public Task<int> DeleteUser_education(User_education education)
        {
            return _database.DeleteAsync(education);
        }
        public Task<int> UpdateUser_education(User_education education)
        {
            return _database.UpdateAsync(education);
        }
        public Task<List<User_education>> GetUser_education(int user_id)
        {
            return _database.QueryAsync<User_education>("SELECT * FROM User_education WHERE User_id=?", user_id);
        }
        public int CountAnnouncements()
        {
            return _database.Table<Announcement>().CountAsync().Result;
        }
        public Task<int> InsertAnnouncement(Announcement announcement)
        {
            return _database.InsertAsync(announcement);
        }
        public Task<int> InsertCompany(Company company)
        {
            return _database.InsertAsync(company);
        }
        public Task<List<Announcement>> GetAnnouncement(int announcement_id)
        {
            return _database.QueryAsync<Announcement>("SELECT * FROM Announcement WHERE Announcement_id=?", announcement_id);
        }
        public Task<List<Announcement>> GetAllAnnouncements()
        {
            return _database.QueryAsync<Announcement>("SELECT * FROM Announcement");
        }
        public Task<List<Announcement>> GetAllAnnouncementsByNewestLimitTen()
        {
            return _database.QueryAsync<Announcement>("SELECT * FROM Announcement ORDER BY Announcement_id DESC LIMIT 10");
        }

        public Task<int> DeleteAnnouncement(Announcement announcement)
        {
            return _database.DeleteAsync(announcement);
        }
        public Task<List<Company>> GetCompany(int company_id)
        {
            return _database.QueryAsync<Company>("SELECT * FROM Company WHERE Company_id=?", company_id);
        }
        public Task<List<Announcement_category>> GetAllCategories()
        {
            return _database.QueryAsync<Announcement_category>("SELECT * FROM Announcement_category");
        }
        public Task<List<Announcement_category>> GetAllCategoriesByPopularityLimitTen()
        {
            return _database.QueryAsync<Announcement_category>("SELECT * FROM Announcement_category LIMIT 10");
        }
        public Task<int> InsertCategory(Announcement_category category)
        {
            return _database.InsertAsync(category);
        }
    }
}
