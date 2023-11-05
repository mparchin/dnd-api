namespace api.Models
{
    public interface IModel
    {
        public int Id { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}