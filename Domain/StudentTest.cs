using System;

namespace Domain
{
    public class StudentTest
    {
        public Guid Id { get; set; }
        public Guid studentId { get; set; }
        public Guid levelTestId { get; set; }
        public LevelTest levelTest { get; set; }
        public Guid codeId { get; set; }
        public Promocode code { get; set; }
    }
}