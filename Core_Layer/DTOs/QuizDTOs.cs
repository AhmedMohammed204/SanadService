using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs
{
    public class QuizDTOs
    {
        public class QuizQuestionDTO
        {
            public int questionId { get; set; }
            public string questionText { get; set; }
            public List<string> answers { get; set; }
            public int correctAnswerIndex { get; set; }

        }

        public class QuizInfoDTO
        {
            public string Topic { get; set; }
            public int NumberOfQuestions { get; set; }
            public string DifficultyLevel { get; set; }
        }

    }
}
