using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entities
{
    public class MyOpject : Base
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        

    }
}
