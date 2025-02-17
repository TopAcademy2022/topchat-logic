using TopChat.Domain.Entities;

namespace TopChat.Infrastruction.Data.Entities
{
    public class GroupMember
    {
        public int Id { get; set; }

        public Group Group { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
