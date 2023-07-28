﻿namespace DataProcessingAPI.Models
{
    public class Name
    {
        public string? Common { get; set; }
        public string? Official { get; set; }
        public Dictionary<string, NativeName>? NativeName { get; set; }
    }
}