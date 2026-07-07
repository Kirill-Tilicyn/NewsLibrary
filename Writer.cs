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

        public List<Article> GetArticles()
        {
            return _articles;
        }

        public Article WriteArticle(string title)
        {
            if (title == null)
            {
                return null;
            }

            Article article = new Article(title);
            _articles.Add(article);
            return article;
        }
    }
}