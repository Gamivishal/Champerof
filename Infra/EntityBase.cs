using System.ComponentModel.DataAnnotations.Schema;

namespace CommonForReact.Infra
{
    public class EntityBase
    {

        [NotMapped]
        public long? CreatedBy { get; set; }
        [NotMapped]
       
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        
        public long? LastModifiedBy { get; set; }

        [NotMapped]
      
        public DateTime? LastModifiedDate { get; set; }


    }
}
