namespace Domain
{
    public class TestResult
    {
        public int id { get; set; }
        public StudentTest studentTest { get; set; }
        public Test test { get; set; }
        public Answer answer { get; set; } 
        public string Comment { get; set; }
    }
}