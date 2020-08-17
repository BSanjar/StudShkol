using System;

namespace Domain
{
    public class ImageAnswer
    {
        public Guid Id { get; set; }
        public Guid answerId{get;set;}
        public Answer answer { get; set; }
        public string file { get; set; }
    }
}