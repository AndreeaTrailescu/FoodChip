using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Inference
{
    public class Fact
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Fact(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherFact = (Fact)obj;
            return Name == otherFact.Name && Value == otherFact.Value;
        }
    }
}
