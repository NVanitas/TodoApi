﻿namespace TodoApi.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Done { get; set; }
    }
}
