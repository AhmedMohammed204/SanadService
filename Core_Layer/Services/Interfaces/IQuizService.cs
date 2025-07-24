using Core_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core_Layer.DTOs.QuizDTOs;

namespace Core_Layer.Services.Interfaces
{
    public interface IQuizService
    {
        Task<string?> GenerateQuizByAsyncByAI(QuizInfoDTO quizInfoDTO);
        Task<QuizDTOs.SendQuizAnswersDTO> GetSubjectQuiz(string subject);

    }
}
