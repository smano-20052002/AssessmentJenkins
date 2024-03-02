using AssessmentJenkins.Model;

namespace AssessmentJenkins.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private List<Question> Questions = new List<Question>();
        private int _nextId = 1;
        public QuestionRepository()
        {
            Add(new Question {  QuestionId= 1, QuestionText= "What is Mobile",QuestionCategory= "General",Option1= "Device", Option2= "Software",Option3= "Hardware",RightAnswer= "Device" });
            Add(new Question { QuestionId = 2,QuestionText="How are you?",QuestionCategory="General",Option1="Good",Option2="Ok",Option3="Well & Good",RightAnswer="Well & Good" });

        }
        public IEnumerable<Question> GetAll()
        {
            return Questions;
        }

        public Question GetById(int id)
        {
            return Questions.Find(p => p.QuestionId == id);
        }

        public Question Add(Question Question)
        {
            if (Question == null)
            {
                throw new ArgumentNullException("item");
            }
            Question.QuestionId = _nextId++;
            Questions.Add(Question);
            return Question;
        }

        public void Remove(int id)
        {
            Questions.RemoveAll(p => p.QuestionId == id);
        }
        public bool Update(Question Question)
        {
            if (Question == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Questions.FindIndex(p => p.QuestionId == Question.QuestionId);
            if (index == -1)
            {
                return false;
            }
            Questions.RemoveAt(index);
            Questions.Add(Question);
            return true;
        }

    }
}
