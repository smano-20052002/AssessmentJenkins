using AssessmentJenkins.Controllers;
using AssessmentJenkins.Model;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentJenkinsTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Post_with_0_id_returns_OkResult()
        {
            QuestionsController questionController = new QuestionsController();

            Question question = new Question()
            {
                QuestionId = 0,
                QuestionText = "What is MSBUILD",
                QuestionCategory = "MSBUILD",
                Option1 = "Build Tool",
                Option2 = "Integration Tool",
                Option3 = "Testing Tool",
                RightAnswer = "Build Tool"
            };

            var result = questionController.PostQuestion(question);

            Assert.IsInstanceOf<OkResult>(result);
        }
        [Test]
        public void Update_with_correct_type_returns_correctResult()
        {

            QuestionsController questionController = new QuestionsController();

            Question Question = new Question()
            {
                QuestionId = 1,
                QuestionText = "What is CI/CD?",
                QuestionCategory = "CI/CD",
                Option1 = "Continous Integration",
                Option2 = "Continous Integration",
                Option3 = "Continous Integration/Continous Integration",
                RightAnswer = "Continous Integration/Continous Integration"
            };

            var result = questionController.UpdateQuestion(Question.QuestionId, Question).Result;

            Assert.IsInstanceOf<OkResult>(result);

        }
        [Test]
        public void Delete_returns_OkRequest_validId()
        {
            QuestionsController questionController = new QuestionsController();
            var result = questionController.DeleteQuestion(1).Result;
            Assert.IsInstanceOf<OkResult>(result);

        }


        [Test]
        public void GetById_returns_correctResult()
        {
            QuestionsController questionController = new QuestionsController();
            var result = questionController.GetQuestionsById(2);

            var value = result.QuestionId;
            Assert.AreEqual(2, value);

        }
        [Test]
        public void GetByCategory_returns_correctResult()
        {
            QuestionsController questionController = new QuestionsController();
            var result = questionController.GetByQuestionCategory("General");

            var value = result.First();
            Assert.AreEqual("General", value.QuestionCategory);

        }

        [Test]
        public void Get_returnsAllResults_give_correct_type()
        {
            QuestionsController questionController = new QuestionsController();
            var result = questionController.GetAllQuestions();
            Assert.IsInstanceOf<List<Question>>(result);

        }



    }
}