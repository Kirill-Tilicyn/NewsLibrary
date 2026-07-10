using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    internal class Program
    {
        private enum MenuAction
        {
            AddWebsite = 1,
            ViewingWebsite = 2,
            WorkingWebsite = 3,
            Exit = 4
        }

        public static void Main(string[] args)
        {
            bool isProgramRunning = true;

            List<Website> websites = new List<Website>();

            while (isProgramRunning)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine($"{(int)MenuAction.AddWebsite} - Добавить сайт.");
                Console.WriteLine($"{(int)MenuAction.ViewingWebsite} - Просмотр списка сайтов.");
                Console.WriteLine($"{(int)MenuAction.WorkingWebsite} - Работать с сайтом.");
                Console.WriteLine($"{(int)MenuAction.Exit} - Закончить работу.");
                Console.Write("Введите номер выбранного действия: ");
                string userActionNumberText = Console.ReadLine()?.Trim();

                bool userActionNumberValid = int.TryParse(userActionNumberText, out int userActionNumber);

                if (userActionNumberValid)
                {
                    if (userActionNumber == (int)MenuAction.AddWebsite)
                    {
                        bool hasAdditionCompleted = AddWebSite(websites);

                        if (hasAdditionCompleted)
                        {
                            Console.WriteLine("Сайт создан!");
                        }
                        else
                        {
                            Console.WriteLine("Не получилось создать такой сайт! Попробуйте еще раз!");
                        }
                    }
                    else if (userActionNumber == (int)MenuAction.ViewingWebsite)
                    {
                        Console.WriteLine("Список доступных сайтов: ");

                        foreach (Website website in websites)
                        {
                            Console.WriteLine(website.GetNameWebsite());
                        }
                    }
                    else if (userActionNumber == (int)MenuAction.WorkingWebsite)
                    {
                        Website foundSite = null;

                        string nameWebsite = RequestNameWebsite();

                        if (nameWebsite != null)
                        {
                            foreach (Website website in websites)
                            {
                                if (website.GetNameWebsite() == nameWebsite)
                                {
                                    foundSite = website;
                                }
                            }
                        }

                        if (foundSite == null)
                        {
                            Console.WriteLine("Сайт не найден!");
                        }
                        else
                        {
                            foundSite.LaunchWebsiteMenu();
                        }
                    }
                    else if (userActionNumber == (int)MenuAction.Exit)
                    {
                        isProgramRunning = false;
                    }
                    else
                    {
                        Console.WriteLine("Действия под таким номером нет!");
                    }
                }
                else
                {
                    Console.WriteLine("Ваш выбор некорректен! Попробуйте еще раз!");
                }
            }
        }
        
        public static string RequestNameWebsite()
        {
            Console.Write("Введите название сайта: ");
            string nameWebsite = Console.ReadLine()?.Trim();
            return nameWebsite;
        }

        public static bool AddWebSite(List<Website> websites)
        {
            string nameWebsite = RequestNameWebsite();

            if (string.IsNullOrEmpty(nameWebsite))
            {
                return false;
            }
            else
            {
                foreach (Website website in websites)
                {
                    if (website.GetNameWebsite() == nameWebsite)
                    {
                        return false;
                    }
                }
            }

            websites.Add(new Website(nameWebsite));
            return true;
        }
    }
}