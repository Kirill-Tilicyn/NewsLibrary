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

        public bool WriteArticle(Writer name, string title, string description)
        {
            if (!_writers.Contains(name))
            {
                return false;
            }

            name.WriteArticle(title, description);
            return true;
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
                        string nameWriter = RequestNameWriter();

                        bool isThereWriter = false;

                        if (nameWriter != null)
                        {
                            foreach (Writer writer in _writers)
                            {
                                if (writer.GetName() == nameWriter)
                                {
                                    isThereWriter = true;
                                    Console.WriteLine("Такой автор уже существует на данном сайте!");
                                }
                            }

                            if (isThereWriter == false)
                            {
                                _writers.Add(new Writer(nameWriter));

                                Console.WriteLine("Писатель добавлен на сайте!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели некорректное имя!");
                        }

                    }
                    else if (userChoisNumber == (int)MenuAction.AddArticle)
                    {
                        string nameWriter = RequestNameWriter();

                        Writer activeWriter = null;

                        bool isThereWriter = false;

                        if (nameWriter != null)
                        {
                            foreach (Writer writer in _writers)
                            {
                                if (writer.GetName() == nameWriter)
                                {
                                    activeWriter = writer;
                                    isThereWriter = true;
                                }
                            }
                        }

                        if (isThereWriter)
                        {
                            string title = RequestTitleArticle();
                            string description = RequestDescriptionArticle();

                            WriteArticle(activeWriter, title, description);
                        }
                    }
                    else if (userChoisNumber == (int)MenuAction.ShowWriters)
                    {
                        ShowWriters();
                    }
                    else if (userChoisNumber == (int)MenuAction.ShowArticles)
                    {
                        ShowArticles();
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

        private string RequestNameWriter()
        {
            Console.Write("Введите полное имя автора: ");
            string name = Console.ReadLine()?.Trim();
            return name;
        }

        private string RequestTitleArticle()
        {
            Console.Write("Введите название статьи: ");
            string title = Console.ReadLine()?.Trim();
            return title;
        }

        private string RequestDescriptionArticle()
        {
            Console.Write("Введите содержимое статьи ");
            string description = Console.ReadLine()?.Trim();
            return description;
        }

        private void ShowWriters()
        {
            Console.WriteLine("Список писателей зарегистрированных на сайте: ");

            foreach (Writer writer in _writers)
            {
                Console.WriteLine(writer.GetName());
            }
        }

        private void ShowArticles()
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