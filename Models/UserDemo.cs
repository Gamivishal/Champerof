using CommonForReact.Infra;

namespace CommonForReact.Models
{
    public class UserDemo : EntityBase
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        // ✅ File fields
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
        public byte[]? FileData { get; set; }
        public List<UserDemoFile>? Files { get; set; }

    }

    public class UserDemoFormDto
    {
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }

        public long? CreatedBy { get; set; }
        public long? LastModifiedBy { get; set; }
    }
    public class UserDemoFile
    {
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
        public byte[]? FileData { get; set; }
    }
    public class UserDemoGetModel
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }

        // File fields
        public long? FileId { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
        public byte[]? FileData { get; set; }
    }
}
