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
                Console.WriteLine($"Вы находитесь на сайте: {GetNameWebsite()}");
                Console.WriteLine("Выберите вариант действия: ");
                Console.WriteLine($"1 - Добавить автора.");
                Console.WriteLine($"2 - Написать и опубликовать статью.");
                Console.WriteLine($"3 - Просмотреть список авторов.");
                Console.WriteLine($"4 - Просмотреть опубликованные статьи.");
                Console.WriteLine($"5 - Выход.");
                Console.Write("Введите номер действия: ");
                string userChoisNumberText = Console.ReadLine()?.Trim();

                bool userChoisNumberValid = int.TryParse(userChoisNumberText, out int userChoisNumber);

                Console.WriteLine();

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

                            Console.WriteLine("Статья опубликована!");
                        }
                        else
                        {
                            Console.WriteLine("Произошла какая-то ошибка! Статья не опубликована!");
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

                Console.WriteLine();
            }

            Console.WriteLine("Вы покинули сайт!");
        }

        private string RequestNameWriter()
        {
            Console.Write("Введите полное имя автора: ");
            string name = Console.ReadLine()?.Trim();

            Console.WriteLine();

            return name;
        }

        private string RequestTitleArticle()
        {
            Console.Write("Введите название статьи: ");
            string title = Console.ReadLine()?.Trim();

            Console.WriteLine();

            return title;
        }

        private string RequestDescriptionArticle()
        {
            Console.Write("Введите содержимое статьи ");
            string description = Console.ReadLine()?.Trim();

            Console.WriteLine();

            return description;
        }

        private void ShowWriters()
        {
            if (_writers.Count > 0)
            {
                Console.WriteLine("Список писателей зарегистрированных на сайте: ");

                foreach (Writer writer in _writers)
                {
                    Console.WriteLine(writer.GetName());
                }
            }
            else
            { 
                Console.WriteLine("На сайте нет зарегистрированных писателей!");
            }
        }

        private void ShowArticles()
        {
            int totalArticles = 0;

            foreach (Writer writer in _writers)
            {
                totalArticles = writer.GetArticles().Count;
            }

            if (totalArticles > 0)
            {
                foreach (Writer writer in _writers)
                {
                    foreach (Article article in writer.GetArticles())
                    {
                        Console.WriteLine($"Автор: {writer.GetName()}.");
                        Console.WriteLine($"Название статьи: {article.GetTitle()}");
                        Console.WriteLine($"Содержание статьи: {article.GetDescription()}");

                    }
                }
            }
            else
            {
                Console.WriteLine("На сайте нет опубликованных статей!");
            }
        }
    }
}