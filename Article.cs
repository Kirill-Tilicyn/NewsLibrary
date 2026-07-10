using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    public class Article
    {
        private Dictionary<string, string> _articles;

        public Article(string title, string description)
        {
            new Dictionary<string, string>();

            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(description))
            {
                _articles.Add("Без названия", "Пустая статья");
            }
            else
            {
                _articles.Add(title, description);
            }
        }
    }
}