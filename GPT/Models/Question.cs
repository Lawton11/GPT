namespace GPT.Models
{
    public class Question
    {

        public int Id { get; set; }

        public string role { get; set; }

        public string context { get; set; }

        public string  message { get; set; }

        public string response { get; set; }
    }
}
