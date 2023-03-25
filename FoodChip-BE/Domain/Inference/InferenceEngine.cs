using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Domain.Inference
{
    public class InferenceEngine
    {
        private readonly List<Fact> _facts;
        private readonly List<Rule> _rules;

        public InferenceEngine()
        {
            _facts = new List<Fact>();
            _rules = new List<Rule>();
        }

        public void AddFact(Fact fact)
        {
            _facts.Add(fact);
        }

        public void AddRule(List<Rule> rules)
        {
            _rules.AddRange(rules);
        }

        public IList<Fact> Run()
        {
            
            var newlyDerivedFacts = new List<Fact>();
            var derivedFacts = new List<Fact>();
            using (StreamReader r = new StreamReader("..\\Domain\\Inference\\rules.json"))
            {
                string json = r.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<Rule>>(json);
                AddRule(list);
            }

            do
            {
                newlyDerivedFacts.Clear();

                foreach (var rule in _rules)
                {
                    var conditions = rule.Conditions;

                    bool isMatch = true;
                    foreach (var i in _facts)
                    {
                        if(!conditions.Contains(i))
                        {
                            isMatch = false;
                        }

                    }
                    if(isMatch)
                    {
                        if (!derivedFacts.Contains(rule.Action))
                        {
                            newlyDerivedFacts.Add(rule.Action);
                        }
                    }

                }

                foreach (var fact in newlyDerivedFacts)
                {
                    _facts.Add(fact);
                    var index = derivedFacts.FindIndex(f => f.Value == fact.Value);
                    if (index < 0)
                    {
                        derivedFacts.Add(fact);
                    }
                }


            } while (newlyDerivedFacts.Any());

            return derivedFacts;
        }

    }
}
