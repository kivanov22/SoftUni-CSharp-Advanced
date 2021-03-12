using System;
using System.Collections.Generic;
using System.Text;

namespace P03.GenericSwapMethodString
{
    public class Box<T>
        
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public override string ToString()
        {
            Type valueType = this.Value.GetType();
            string valueTypeFullname = valueType.FullName;

            return $"{valueTypeFullname}: {this.Value}";
        }
    }
}
