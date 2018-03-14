using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.Repository.Models
{
    /// <summary>
    /// Interface for models that has children and parent of same type (nested levels of data)
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IParentChildModel<TEntity>
    {
        TEntity Parent { get; set; }
        ICollection<TEntity> Children { get; set; }
    }
}
