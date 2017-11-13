using System;

namespace Lathorva.Common.Repository
{
    public interface IEntity<TKey>  where TKey : IConvertible
    {
        /// <summary>
        /// Replace this with generic property if needed
        /// </summary>
        TKey Id { get; set; }
    }
}
