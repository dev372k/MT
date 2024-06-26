﻿namespace Application.DTOs
{
    public class GetGroupDTOs
    {
        public List<GetGroupDTO> Item { get; set; }
        public int TotalCount { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }

    public class GetGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;

    }
    public class AddGroupDTO
    {
        public string Name { get; set; } = string.Empty;
    }
    
    public class UpdateGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
