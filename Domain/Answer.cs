using System;
using System.Collections.Generic;

namespace Domain
{
    public class Answer
    {
        public Guid Id { get; set; }
        public int answer { get; set; }
        public Guid testsId { get; set; }
        public Test tests { get; set; }
        public int score { get; set; }
        public List<ImageAnswer> ImageAnswer{get;set;}
        public List<TestResult> TestResult{get;set;}
        
    }
}