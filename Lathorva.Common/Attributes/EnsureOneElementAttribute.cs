using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Lathorva.Common.Attributes
{
    public class EnsureOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            return list?.Count > 0;
        }
    }
}
