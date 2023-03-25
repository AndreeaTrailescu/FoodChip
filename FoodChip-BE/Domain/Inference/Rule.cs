using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Inference
{
    public class Rule
    {
        public List<Fact> Conditions { get; set; }
        public Fact Action { get; set; }

        public Rule(List<Fact> conditions, Fact action)
        {
            Conditions = conditions;
            Action = action;
        }
    }
}
