using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  public class FA1
  {
        State q0 = new State
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State q1 = new State
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State q2 = new State
        {
            Name = "q2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State q3 = new State
        {
            Name = "q3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public FA1()
        {
            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q0;
            q1.Transitions['0'] = q2;
            q1.Transitions['1'] = q3;
            q2.Transitions['0'] = q2;
            q2.Transitions['1'] = q2;
            q3.Transitions['0'] = q2;
            q3.Transitions['1'] = q3;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = q0;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;

                current = current.Transitions[c];
            }

            return current.IsAcceptState;
        }
    }

  public class FA2
  {
        State q0 = new State
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State q1 = new State
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State q2 = new State
        {
            Name = "q2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State q3 = new State
        {
            Name = "q3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public FA2()
        {
            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q2;
            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q3;
            q2.Transitions['0'] = q3;
            q2.Transitions['1'] = q0;
            q3.Transitions['0'] = q2;
            q3.Transitions['1'] = q1;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = q0;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;

                current = current.Transitions[c];
            }

            return current.IsAcceptState;
        }
    }
  
  public class FA3
  {
        State q0 = new State
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State q1 = new State
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State q2 = new State
        {
            Name = "q2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public FA3()
        {
            q0.Transitions['0'] = q0;
            q0.Transitions['1'] = q1;
            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q2;
            q2.Transitions['0'] = q2;
            q2.Transitions['1'] = q2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = q0;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;

                current = current.Transitions[c];
            }

            return current.IsAcceptState;
        }
    }

  class Program
  {
        static void Main(string[] args)
        {
            string s1 = "1101";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s1);
            Console.WriteLine($"FA1 - Result for '{s1}': {result1}");

            string s2 = "01010";
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s2);
            Console.WriteLine($"FA2 - Result for '{s2}': {result2}");

            string s3 = "010110";
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s3);
            Console.WriteLine($"FA3 - Result for '{s3}': {result3}");
        }
    }
}