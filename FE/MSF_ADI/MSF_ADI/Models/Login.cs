﻿namespace MSF_ADI.Models
{
    public class Login
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
