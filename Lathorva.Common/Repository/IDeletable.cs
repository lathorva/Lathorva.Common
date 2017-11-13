﻿using System;

namespace Lathorva.Common.Repository
{
    /// <summary>
    /// Marked as deleted by customer, but really not deleted, just deactivated.
    /// </summary>
    public interface IDeletable : IEntity
    {
        bool IsDeleted { get; set; }
    }
}
