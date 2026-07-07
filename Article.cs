using System;

namespace NewsLibrary
{
    public class Article
    {
        private string _title;

        public Article(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                _title = "Без названия";
            }
            else
            {
                _title = title;
            }
        }

        public string GetTitle()
        {
            return _title;
        }
    }
}