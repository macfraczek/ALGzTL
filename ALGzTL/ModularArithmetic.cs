using ALGzTL.Logger;
using System;

namespace ALGzTL
{
    public class ModularArithmetic
    {
        ILogger Logger;

        public ModularArithmetic(ILogger logger = null)
        {
            Logger = logger ?? new VoidLogger();
        }

        /// <summary>
        /// solve congurence equations. ax = b (mod n)
        /// </summary>
        /// <param name="input">exaple 'x = 1 (mod 22)'</param>
        /// <returns></returns>
        public int ComputeCongruenceMinimalResult(string input)
        {
            var congr = ParseCongruenceInput(input);

            int x = -1;
            int moduloCounter = 0;
            int moduloLeftside;

            do
            {
                x++;

                long leftside = (long)congr.a * x;

                if (leftside >= (1 + moduloCounter) * congr.modulo)
                    moduloCounter++;
                moduloLeftside = (int)(leftside - moduloCounter * congr.modulo);
            } while (moduloLeftside != congr.b || x == congr.modulo);

            Logger.Info($"Modulo was subtracted {moduloCounter} times.");
            
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

            Logger.Info($"Input parsed to '{result}'.");

            return result;
        }
    }

    struct CongurenceValues
    {
        public int a;
        public int b;
        public int modulo;

        public CongurenceValues(string a, string b, string n)
        {
            this.a = string.IsNullOrWhiteSpace(a) ? 1 : int.Parse(a);
            this.b = int.Parse(b);
            this.modulo = int.Parse(n);
        }

        public override string ToString()
        {
            return $"{a}x = {b} (mod {modulo})";
        }
    }
}
