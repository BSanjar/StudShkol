namespace Domain
{
    public class Answer
    {
        public int id { get; set; }
        public int answer { get; set; }
        public Test tests { get; set; }
        public int score { get; set; }
    }
}