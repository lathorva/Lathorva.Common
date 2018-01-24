using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Lathorva.Common.Attributes
{
    /// <summary>
    /// Used on class only. Contains at least two properties where at least one is required.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AtLeastOnePropertyAttribute : ValidationAttribute
    {
        private readonly string[] _propertyList;

        public AtLeastOnePropertyAttribute(params string[] propertyList)
        {
            _propertyList = propertyList;
        }

        //See http://stackoverflow.com/a/1365669
        public override object TypeId => this;

        public override bool IsValid(object value)
        {
            foreach (string propertyName in _propertyList)
            {
                var propertyInfo = value.GetType().GetProperty(propertyName);

                if (propertyInfo != null && propertyInfo.GetValue(value, null) != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
