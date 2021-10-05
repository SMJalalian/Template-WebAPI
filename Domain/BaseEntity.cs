using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Domain
{
    public abstract class BaseEntity<TKey> : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {

    }

    public interface IEntity
    {

    }
}
