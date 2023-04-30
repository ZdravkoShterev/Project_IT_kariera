namespace Project_IT_kariera.Models
{
    public class UpdateEvent
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime Date { get; set; }
    }
}
