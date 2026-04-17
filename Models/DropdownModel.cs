namespace Champerof.Models
{
    public class Dropdownname
    {
        public long Id { get; set; }
        public string? Name { get; set; }

    }
    public class Lov_Master
    {
        public string? Code { get; set; }
        public string? Name { get; set; }

    }

    public class ServiceName
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal? DefaultPrice { get; set; }

    }
}
