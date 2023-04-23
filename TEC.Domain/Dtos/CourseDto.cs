
namespace TEC.Domain.Dtos
{
    /// <summary>
    /// Course dto
    /// </summary>
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
    }
}
