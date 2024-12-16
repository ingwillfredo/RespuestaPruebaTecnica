namespace ApiBackPruebaTec.Entities.Models.DTOs
{
    public class TaskDTO
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
