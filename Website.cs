using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    public class Website
    {
        private List<Writer> _writers;

        public Website()
        {
            _writers = new List<Writer>();
        }

        public bool SetWriter(Writer writer)
        {
            if (writer == null)
            {
                return false;
            }

            _writers.Add(writer);
            return true;
        }

        public bool WriteArticle(Writer name, string title, string description)
        {
            if (!_writers.Contains(name))
            {
                return false;
            }

            name.WriteArticle(title, description);
            return true;
        }

        public void PublishArticle()
        {
            foreach (Writer writer in _writers)
            {
                List<Article> articles = writer.GetArticles();

                foreach (Article article in articles)
                {
                    Console.WriteLine($"Автор: {writer.GetName()}.");
                    Console.WriteLine($"Название статьи: {article.GetTitle()}");
                    Console.WriteLine($"Содержание статьи: {article.GetDescription()}");
                }
            }
        }
    }
}