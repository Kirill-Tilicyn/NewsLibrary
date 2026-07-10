using System;

namespace NewsLibrary
{
    public class Article
    {
        private string _title;
        private string _description;

        public Article(string title, string description)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(description))
            {
                _title = "Без названия";
                _description = "Пустая статья";
            }
            else
            {
                _title = title;
                _description = description;
            }

            _description = description;
        }

        public string GetTitle()
        {
            return _title;
        }
    }
}