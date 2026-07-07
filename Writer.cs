using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    public class Writer
    {
        private string _name;
        private List<Article> _articles;

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

            _articles = new List<Article>();
        }

        public string GetName()
        {
            return _name;
        }
    }
}