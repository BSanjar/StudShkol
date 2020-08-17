using System;
using System.Collections.Generic;

namespace Domain
{
    public class LevelTest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid groupTestId { get; set;}
        public GroupTest groupTest { get; set; }
        public string TimeToTest { get; set; }
        public List<Test> Test {get;set;}
        public List<StudentTest> StudentTest {get;set;}
        
    }
}