using System.Security.Cryptography;
using System.Text;
using KarimaCollection.Data;
using Microsoft.EntityFrameworkCore;

namespace KarimaCollection.Services
{
    public class AdminAuthService
    {
        private readonly AppDbContext _db;
        public AdminAuthService(AppDbContext db)
        {
            _db = db;
        }

        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var admin = await _db.Admins.FirstOrDefaultAsync(a => a.Username == username);
            if (admin == null) return false;

            return VerifyPassword(password, admin.PasswordHash);
        }


        public async Task ResetAdminAsync(
    string oldUsername,
    string newUsername,
    string newPassword)
        {
            var admin = await _db.Admins
                .FirstOrDefaultAsync(a => a.Username == oldUsername);

            if (admin == null)
                throw new Exception("Admin not found");

            admin.Username = newUsername;
            admin.PasswordHash = HashPassword(newPassword);

            await _db.SaveChangesAsync();

        }

    }
}
