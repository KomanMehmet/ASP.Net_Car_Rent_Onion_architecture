using System.ComponentModel.DataAnnotations;

namespace CarRent.Domain.Entities
{
    public class TagCloud
    {
        [Key]
        public int TagClodID { get; set; }

        public string Title { get; set; }

        public int BlogID { get; set; }

        public Blog Blog { get; set; }
    }
}
