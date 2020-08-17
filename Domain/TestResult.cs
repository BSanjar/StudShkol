using System;

namespace Domain
{
    public class TestResult
    {
        public Guid Id { get; set; }
        public Guid studentTestId { get; set; }
        public StudentTest studentTest { get; set; }
        public Guid testId {get;set;}
        public Test test { get; set; }
        public Guid answerId{get;set;}
        public Answer answer { get; set; } 
        public string Comment { get; set; }
    }
}