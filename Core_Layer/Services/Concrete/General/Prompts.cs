using System.Text;

namespace Core_Layer.Services.Concrete.General
{
    public static class Prompts
    {
       public static string GenrateQuiz(string topic, int numberOfQuestions, string difficultyLevel)
        {
            StringBuilder prompt = new StringBuilder();
            prompt.Append("In Arabic");
            prompt.AppendLine($"Generate a quiz on the topic of {topic}.");
            prompt.AppendLine($"The quiz should contain {numberOfQuestions} questions.");
            prompt.AppendLine($"The difficulty level should be {difficultyLevel}.");
            prompt.AppendLine("Each question should have 4 possible answers, with one correct answer.");
            prompt.AppendLine("Provide the questions in a JSON format with the following structure:");
            prompt.AppendLine("{\"questionId\": \"\", \"questionText\": \"\", \"answers\": [\"\", \"\", \"\", \"\"], \"correctAnswerIndex\": 0 }");
            prompt.AppendLine("Known that:\n-it is 0-indexed");
            prompt.AppendLine("question id and correct answer index should be integers so don't make them between double quotes");
            prompt.AppendLine("The questions target Sudanese students who are in 3rd grade of high school and prepare for the final exams, so make sure that the questions are relevant and created from their subjects.");
            return prompt.ToString();
        }
    }
}
