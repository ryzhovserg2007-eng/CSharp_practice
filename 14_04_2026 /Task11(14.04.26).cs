using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    public class Task11 : Red
    {
        private int _output;
        public int Output => _output;
        public Task11(string input) : base(input) // массив должен быть null
        {
            _output = 0;
        }
        public override void Review()
        {
            // Обработать текст в Input, решая задание
            // (Текст в Input НЕ ДОЛЖЕН изменяться)
            // По результатам выполнения метода
            int count = 0;
            count++;

            _output = count;
            // Output должен возвращать правильный ответ для текста в Input

        }
        public override string ToString()
        {
            return $"{_input}{Environment.NewLine}{_output}"; // перенос на след строку
        }
    }
}
