using System;
using System.Collections.Generic;

namespace Domain
{
    public class GroupTest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<LevelTest> LevelTest { get; set;}
    }
}