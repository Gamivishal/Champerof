namespace CommonForReact.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Address { get; set; }

        // File
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
        public byte[]? FileData { get; set; }
        public List<PropertyImage>? Images { get; set; }
    }
    public class PropertyImage
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public byte[]? ImageData { get; set; }

        public string? FileName { get; set; }

        public string? ContentType { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
