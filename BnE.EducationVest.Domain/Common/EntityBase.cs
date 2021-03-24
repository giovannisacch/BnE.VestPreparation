using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Common
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public override bool Equals(object obj)
        {
            EntityBase other = obj as EntityBase;

            if (other == null || this.GetType() != other.GetType())
            {
                return false;
            }

            return other.Id == this.Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
