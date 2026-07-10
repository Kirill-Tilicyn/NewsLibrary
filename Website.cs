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

        private enum MenuAction
        {
            AddWrite = 1,
            AddArticle = 2,
            ShowWriters = 3,
            ShowArticles = 4,
            Exit = 5
        }

        public void LaunchWebsiteMenu()
        {
            bool isWebsiteRunning = true;

            while (isWebsiteRunning)
            {
                Console.WriteLine("Выберите вариант действия: ");
                Console.WriteLine($"1 - Добавить автора.");
                Console.WriteLine($"2 - Написать и опубликовать статью.");
                Console.WriteLine($"3 - Просмотреть список авторов.");
                Console.WriteLine($"4 - Просмотреть опубликованные статьи.");
                Console.WriteLine($"5 - Выход.");
                Console.Write("Введите номер действия: ");
                string userChoisNumberText = Console.ReadLine()?.Trim();

                bool userChoisNumberValid = int.TryParse(userChoisNumberText, out int userChoisNumber);

                if (userChoisNumberValid)
                {
                    if (userChoisNumber == (int)MenuAction.AddWrite)
                    {

                    }
                    else if (userChoisNumber == (int)MenuAction.AddArticle)
                    {

                    }
                    else if (userChoisNumber == (int)MenuAction.ShowWriters)
                    {

                    }
                    else if (userChoisNumber == (int)MenuAction.ShowArticles)
                    {

                    }
                    else if (userChoisNumber == (int)MenuAction.Exit)
                    {
                        isWebsiteRunning = false;
                    }
                    else
                    {
                        Console.WriteLine("Действия под таким номером нет! Попробуйте еще раз!");
                    }
                }
                else
                {
                    Console.WriteLine("Номер действия не распознан!. Попробуйте еще раз!");
                }
            }
        }
    }
}