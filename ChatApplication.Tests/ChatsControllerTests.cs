using Xunit;
using ChatApplication.Controllers;
using ChatApplication.Data;
using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApplication.Tests
{
    public class ChatsControllerTests
    {
        private readonly ChatsController _controller;
        private readonly ChatContext _context;

        public ChatsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ChatContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ChatContext(options);
            _controller = new ChatsController(_context);
        }

        [Fact]
        public async Task GetChats_ReturnsEmptyList_WhenNoChats()
        {
            var result = await _controller.GetChats();
            Assert.IsType<ActionResult<IEnumerable<Chat>>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var chats = Assert.IsType<List<Chat>>(actionResult.Value);
            Assert.Empty(chats);
        }

        // Добавьте больше тестов для других методов
        [Fact]
        public async Task PostChat_CreatesChat()
        {
            var newChat = new Chat { Name = "Test Chat" };
            var result = await _controller.PostChat(newChat);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdChat = Assert.IsType<Chat>(actionResult.Value);
            Assert.Equal("Test Chat", createdChat.Name);
            Assert.NotEqual(0, createdChat.Id);
        }
    }
}
