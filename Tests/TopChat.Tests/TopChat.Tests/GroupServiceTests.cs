using TopChat.Services;

namespace TopChat.Tests
{
    public class GroupServiceTests
    {
        private readonly GroupService _groupService;

        public GroupServiceTests()
        {
            _groupService = new GroupService();
        }

        [Fact]
        public void AddGroupTest()
        {
            // Arrange
            string groupName = "Test Group";

            // Act && Assert
            Assert.True(_groupService.AddGroup(groupName));
        }

        [Fact]
        public void AddUserToGroupTest()
        {
            // Arrange
            string groupName = "Test Group";
            _groupService.AddGroup(groupName);

            UserServes userServes = new UserServes(new SqliteConnection());
            userServes.Registration("admin", "admin");

            // Act
            //bool result = _groupService.AddUserToGroup(fromBD, fromBD);

            // Assert
            Assert.True(true);
        }

    }
}
