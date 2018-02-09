namespace Common.Math
{
    /// <summary>
    /// Оптимизированный прогрессбар
    /// </summary>
    public class Progress
    {
        readonly int _step;
        readonly int _count;
        int _pos;
        readonly int[] _posArr;
        readonly Handler.Handlers.IntHandler _handler;

        /// <param name="step">Количество засечек (больше 0)</param>
        /// <param name="count">Всего перебираемых данных (больше step)</param>
        /// <param name="handler">делегат, который вызывается при срабатывании после каждой отсечки</param>
        public Progress(int step, int count, Handler.Handlers.IntHandler handler)
        {
            _step = step;
            _count = count;
            _pos = 0;
            _posArr = new int[_step + 1];
            _handler = handler;

            for (int i = 1; i <= _step; i++)
            {
                _posArr[i - 1] = (count - 1) * i / _step;
                if (_posArr[i - 1] == -1) _posArr[i - 1] = 0;
            }

            _posArr[_step] = _count;

            _handler(0);
        }
        /// <summary>
        /// Значение должно быть от 0 до count
        /// </summary>
        public int Position
        {
            set
            {
                if (_count >= _step && value != _posArr[_pos]) return;

                _pos++;

                if (_count == 0)
                    value = 100;
                else
                    value = (int)((double)value / _count * 100.0);

                _handler(value);
            }
        }
    }
}
