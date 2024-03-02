using AssessmentJenkins.Model;

namespace AssessmentJenkins.Repository
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
        Question GetById(int id);
        Question Add(Question question);
        void Remove(int id);
        bool Update(Question question);
    }
}
