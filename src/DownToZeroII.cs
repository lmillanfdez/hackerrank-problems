using System;
using System.Collections.Generic;

namespace hackerrank_problems
{
    class DownToZeroII
    {
        private static Dictionary<int, int> _memory = new Dictionary<int, int>();

        public static int downToZero(int n)
        {
            Console.Write("{0} -> ", n);

            if(n == 0)
                return 0;

            int _result;

            if(_memory.TryGetValue(n, out _result))
                return _result;

            var _maximumDivider = GetMaximunDividerOf(n);
            _result = _maximumDivider > 1 ? downToZero(_maximumDivider) : downToZero(n - 1);

            _memory.Add(n, ++_result);
            return _result;
        }

        private static int GetMaximunDividerOf(int n)
        {
            if(n == 1 || n == 2 || n == 3)
                return 1;

            var _incrementalStep = 1;
            var _squareRoot = Math.Sqrt(n);
            int _firstNumber;
            
            if(_squareRoot > (_firstNumber = Convert.ToInt32(_squareRoot)))
                _firstNumber++;

            if(n % 2 > 0)
            {
                if(_firstNumber % 2 == 0)
                    _firstNumber++;
                    
                _incrementalStep++;
            }

            var _tempDivider = _firstNumber;
            var halfOfN = Convert.ToInt32(n / 2);

            while(_tempDivider <= halfOfN)
            {
                if(n % _tempDivider == 0)
                    break;

                _tempDivider += _incrementalStep;
            }

            return _tempDivider <= halfOfN ? _tempDivider : 1;
        }
    }
}