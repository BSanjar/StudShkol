using System;

namespace Domain
{
    public class StudentTest
    {
        public int id { get; set; }
        public Student student { get; set; }
        public GroupTest groupTest { get; set; }
        public string status { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime DateStartTest { get; set; }
        public DateTime DateFinishTest { get; set; }
        public string CountTime { get; set; }
    }
}