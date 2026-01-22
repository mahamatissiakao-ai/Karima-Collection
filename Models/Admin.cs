using KarimaCollection.Data;
using KarimaCollection.Services; // ✅ <-- Add this one
using System.ComponentModel.DataAnnotations;

namespace KarimaCollection.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
