﻿namespace RankStay_API.Entities
{
    public class UserObj
    {
        public int UserId { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string UserLastName1 { get; set; } = string.Empty;
        public string UserLastName2 { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public int UserRole { get; set; } = 0;
        public string? RoleName { get; set; }
    }
}