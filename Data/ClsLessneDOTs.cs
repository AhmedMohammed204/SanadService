using System.ComponentModel.DataAnnotations;

namespace Core_Layer
{ 

    public class ClsLessenDOTs
    {
        public required string Name { get; set; }
        public required string Topic { get; set; }
        public required string Description { get; set; }
        public required string Url { get; set; }
        public required string Time { get; set; }
    }
   

}
