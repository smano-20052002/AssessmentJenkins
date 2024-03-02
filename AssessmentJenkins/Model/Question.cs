namespace AssessmentJenkins.Model
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? QuestionCategory { get; set; }
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? RightAnswer { get; set; }
       
    }
}
