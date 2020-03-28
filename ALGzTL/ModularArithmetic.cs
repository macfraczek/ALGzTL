using System;

namespace ALGzTL
{

    public class ModularArithmetic
    {
        bool _countInfo;
        public ModularArithmetic(bool countInfo = false)
        {
            _countInfo = countInfo;
        }

        /// <summary>
        /// solve congurence equations. ax = b (mod n)
        /// </summary>
        /// <param name="input">exaple '2x = 1 (mod 22)'</param>
        /// <returns></returns>
        public int ComputeCongruenceMinimalResult(string input)
        {
            var congurence = ParseCongruenceInput(input);

            int x = -1;
            int moduloCounter = 0;
            int moduloLeftside;

            do
            {
                x++;

                long leftside = (long)congurence.a * x;

                if (leftside >= (1 + moduloCounter) * congurence.n)
                    moduloCounter++;
                moduloLeftside = (int)(leftside - moduloCounter * congurence.n);
            } while (moduloLeftside != congurence.b);

            if(_countInfo)
                Console.WriteLine($"modulo was subtracted {moduloCounter} times");
            
            return x;
        }

        private CongurenceValues ParseCongruenceInput(string input)
        {
            if (!input.Contains('=')) throw new Exception($"Not found '=' in '${input}'");
            var partsByEqualitySign = input.Split('=');

            if (!partsByEqualitySign[0].Contains('x')) throw new Exception($"Not found 'x' in '${input}'");
            var a = partsByEqualitySign[0].Replace("x", "").Replace("*", "").Replace(" ", "");

            if (!partsByEqualitySign[1].Contains("m")) throw new Exception($"Not found 'm' in '${input}'");
            var partsByMod = partsByEqualitySign[1].Trim().Split("m");

            var b = partsByMod[0].Replace("(", "").Trim();
            var n = partsByMod[1].Replace(")", "").Replace("od", "").Trim();

            var result = new CongurenceValues(a, b, n);

            if (_countInfo) Console.WriteLine($"Input parsed to {result}.");

            return result;
        }
    }

    struct CongurenceValues
    {
        public int a;
        public int b;
        public int n;

        public CongurenceValues(string a, string b, string n)
        {
            this.a = string.IsNullOrWhiteSpace(a) ? 1 : int.Parse(a);
            this.b = int.Parse(b);
            this.n = int.Parse(n);
        }

        public override string ToString()
        {
            return $"{a}x = {b} (mod {n})";
        }
    }
}
