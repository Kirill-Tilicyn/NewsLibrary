using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    public class Website
    {
        private string _nameWebsite;
        private List<Writer> _writers;

        public Website(string nameWebsite)
        {
            if (string.IsNullOrEmpty(nameWebsite))
            {
                _nameWebsite = "Неизвестный сайт";
            }
            else
            {
                _nameWebsite = nameWebsite;
            }

                _writers = new List<Writer>();
        }

        public string GetNameWebsite()
        {
            return _nameWebsite;
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

        public (bool,Writer) GetWriterByName(string nameWriter)
        {
            foreach (Writer writer in _writers)
            {
                if (writer.GetName() == nameWriter)
                {
                    return (true,writer);
                }
            }

            return (false, null);
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

        public void PublishArticles()
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