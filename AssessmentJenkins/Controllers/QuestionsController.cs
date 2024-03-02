using AssessmentJenkins.Model;
using AssessmentJenkins.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentJenkins.Controllers
{
    [Route("/onlinequizrest/api/question")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        static readonly IQuestionRepository repository = new QuestionRepository();

        [HttpGet]
        public IEnumerable<Question> GetAllQuestions()
        {
            return repository.GetAll();
        }
        [HttpGet("id")]
        public Question GetQuestionsById(int id)
        {
            Question Question = repository.GetById(id);
            if (Question == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return null;

            }
            return Question;
        }

        [HttpGet("Category")]
        public IEnumerable<Question> GetByQuestionCategory(string Category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.QuestionCategory, Category, StringComparison.OrdinalIgnoreCase));
        }
        [HttpPost]
        public ActionResult PostQuestion(Question item)
        {
            repository.Add(item);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuestion(int id, Question Question)
        {
            if (id != Question.QuestionId)
                return BadRequest();
            else
                repository.Update(Question);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {

            repository.Remove(id);
            return Ok();
        }



    }
}
