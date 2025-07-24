using AI_Layer.Interfaces;
using Core_Layer.DTOs;
using Core_Layer.Services.Concrete.General;
using Core_Layer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Services.Concrete.Services
{
    public class QuizService : IQuizService
    {
        private readonly IGenerativeAI _generativeAI;

        public QuizService(IGenerativeAI generativeAI)
        {
            _generativeAI = generativeAI;
        }

        public async Task<string?> GenerateQuizByAsyncByAI(QuizDTOs.QuizInfoDTO quizInfoDTO)
        {
            string prompt = Prompts.GenrateQuiz(quizInfoDTO.Topic, quizInfoDTO.NumberOfQuestions, quizInfoDTO.DifficultyLevel);
            var res = await _generativeAI.TextGenerate(prompt);
            
            if (string.IsNullOrEmpty(res))
            {
                throw new Exception("Failed to generate quiz. Please try again.");
            }

            return res.Substring(4);
        }
        
        public async Task<QuizDTOs.SendQuizAnswersDTO> GetSubjectQuiz(string subject)
        {
            throw new NotImplementedException();
        }
    }
}
