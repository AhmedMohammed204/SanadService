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
            prompt.AppendLine("{ \"questionText\": \"\", \"answers\": [\"\", \"\", \"\", \"\"], \"correctAnswerIndex\": 0 }");
            return prompt.ToString();
        }
    }
}
