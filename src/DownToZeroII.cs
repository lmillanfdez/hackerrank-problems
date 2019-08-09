using System;
using System.Collections.Generic;

namespace hackerrank_problems
{
    class DownToZeroII
    {
        private Dictionary<int, int> _memory = new Dictionary<int, int>();

        public int downToZero(int n)
        {
            if(n == 0)
                return 0;

            int _result;

            if(_memory.TryGetValue(n, out _result))
                return _result;

            var _maximumDivider = GetMaximunDividerOf(n);
            _result = downToZero(n - 1);

            if(_maximumDivider > 1)
            {
                _maximumDivider = n / _maximumDivider;
                _result = Math.Min(downToZero(_maximumDivider), _result);
            }

            _memory.Add(n, ++_result);
            return _result;
        }

        private int GetMaximunDividerOf(int n)
        {
            if(n == 1 || n == 2 || n == 3)
                return 1;

            var _maximumDivider = 1;
            var _incrementalStep = 1;

            if(n % 2 == 0)
                _maximumDivider = 2;
            else
                _incrementalStep = 2;

            var _tempDivider = _maximumDivider + _incrementalStep;

            while(_tempDivider <= Math.Floor(Math.Sqrt(n)))
            {
                if(n % _tempDivider == 0)
                    _maximumDivider = _tempDivider;

                _tempDivider += _incrementalStep;
            }

            return _maximumDivider;
        }
    }
}