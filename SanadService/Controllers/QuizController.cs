using Core_Layer.DTOs;
using Core_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanadService.Authorization;

namespace SanadService.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost("generate-ai")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuizDTOs.SendQuizAnswersDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<QuizDTOs.SendQuizAnswersDTO>> GenerateQuiz([FromBody] QuizDTOs.QuizInfoDTO quizInfoDTO)
        {
            var result = await _quizService.GenerateQuizByAsyncByAI(quizInfoDTO);
            if(result == null)
            {
                return BadRequest("Failed to generate quiz. Please try again.");
            }

            return Ok(result);
        }
    }
}
