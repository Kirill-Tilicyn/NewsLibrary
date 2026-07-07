using System;

namespace NewsLibrary
{
    internal class Writer
    {
        private string _name;

        public Writer(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _name = "Неизвестный автор";
            }
            else
            {
                _name = name;
            }
        }
    }
}