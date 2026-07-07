using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    internal class Writer
    {
        private string _name;
        private List<string> _articles;

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

            _articles = new List<string>();
        }

        public string GetName()
        {
            return _name;
        }
    }
}