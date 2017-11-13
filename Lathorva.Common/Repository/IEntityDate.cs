﻿using System;

namespace Lathorva.Common.Repository
{
    /// <summary>
    /// For main entities, needs dates when created / edited last.
    /// </summary>
    public interface IEntityDate : IEntity
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset UpdatedDate { get; set; }
    }
}
