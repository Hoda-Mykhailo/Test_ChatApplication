using Microsoft.EntityFrameworkCore;
using ChatApplication.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ChatApplication.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Chat)
                .HasForeignKey(m => m.ChatId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
