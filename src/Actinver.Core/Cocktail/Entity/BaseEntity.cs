namespace Actinver.Core.Cocktail.Entity
{
    using System;
    public abstract class BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
