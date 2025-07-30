using Core_Layer;
using Data.Models;
using System.ComponentModel.DataAnnotations;
namespace Data
{
    public class ClsLessons_CoursesData
    {
        // Data Simulation for Courses and Lessons
        private static List<ClsLessenDOTs> lstofLessons = new List<ClsLessenDOTs>()
        {
            new ClsLessenDOTs () {
                Name = "الأحياء" ,
                Topic = "النظام البيئي" ,
                Description = "مادة الأحياء لطلاب الصف الثالث الشهادة السودانية",
                Time = "00:13:20" , Url = "https://www.youtube.com/watch?v=vrn6M0Igqjo" } ,
            new ClsLessenDOTs{Name = "الرياضيات" ,Topic = "النهايات"  , Description = "النهايات هي أحد المفاهيم الأساسية في حساب التفاضل والتكامل",
                Time = "0:55:24" , Url = "https://www.youtube.com/watch?v=VaByhDxedDU" },
            new ClsLessenDOTs {Name = "التربيةالإسلامية" , Topic = "التجويد-المدود" ,
                Description = "مادة التربية الإسلامية لطلاب الصف الثالث الشهادة السودانية " ,
                Time = "00:12:37" , Url = "https://www.youtube.com/watch?v=YhckVHIiQHw&t=755s" }
        };
        private static List<ClsCoruseDTOs> lstOfCourses = new List<ClsCoruseDTOs>()
        {
            new ClsCoruseDTOs () {Title = "رياضيات", 
                Instructor = "الأستاذ عبدالله محمد",
                Duration = "3:32:00", Price = 2500},
            new ClsCoruseDTOs () {Title = "الفيزياء", 
                Instructor = "الأستاذ محمد",
                Duration = "5:00:00" , Price = 3000},
            new ClsCoruseDTOs () {Title = "الكيمياء", 
                Instructor = "الأستاذاحمد", 
                Duration = "6:42:00", 
                Price = 4500},
        };

        // Retrive all Courses and Lessons Data
        public static List<ClsLessenDOTs> GetAllLessons()
        {
            return lstofLessons; 
        }
        public static List<ClsCoruseDTOs> GetAllCourses() { 
           return lstOfCourses;
        }

    }
}
