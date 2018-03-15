using System;

namespace Lathorva.Common.Repository.Models
{
    /// <summary>
    /// For main entities, needs dates when created / edited last.
    /// </summary>
    public interface IEntityDate : IEntity
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset UpdatedDate { get; set; }
    }

    public interface IEntityDate<TKey> : IEntity<TKey>
    where TKey : IConvertible
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset UpdatedDate { get; set; }
    }
}
