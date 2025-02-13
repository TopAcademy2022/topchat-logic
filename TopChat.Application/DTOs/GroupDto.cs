using System.Collections.Generic;

namespace TopChat.Application.DTOs
{
    public class GroupDto
    {
        public string Name { get; set; } = null!;

        public List<UserDto> Users { get; set; } = null!;
    }
}
