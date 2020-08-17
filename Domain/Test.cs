using System;
using System.Collections.Generic;

namespace Domain
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Question {get;set;}
        public Guid levelTestId{get;set;}
        public  LevelTest levelTest { get; set; }
        public List<Answer> Answer {get;set;}
        public List<ImageTest> ImageTest {get;set;}
        public List<TestResult> TestResult {get;set;}
        
        
    }
}