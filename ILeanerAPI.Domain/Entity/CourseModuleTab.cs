using System.ComponentModel.DataAnnotations.Schema;

namespace ILeanerAPI.Domain.Entity
{
    public class CourseModuleTab
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public List<string> Topics { get; set; } = new();

        public int CourseId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ModulePrice { get; set; }
        public string Description { get; set; } = default!;
        public Course Course { get; set; } = default!;
    }
}