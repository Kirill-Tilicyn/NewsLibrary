using System;

namespace NewsLibrary
{
    public class Article
    {
        private string _title;
        private string _description;

        public Article(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                _title = "Без названия";
            }
            else
            {
                _title = title;
            }

            if (string.IsNullOrEmpty(description))
            {
                _description = "Пустая статья";
            }
            else
            {
                _description = description;
            }
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetDescription()
        {
            return _description;
        }
    }
}