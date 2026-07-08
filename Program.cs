using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Website website = new Website();

            Writer writer1 = new Writer("Иван Иванов");
            Writer writer2 = new Writer("Петя Петров");

            writer1.WriteArticle("Статья 1");
            writer1.WriteArticle("Статья 2");

            writer2.WriteArticle("Статья 1.1");
            writer2.WriteArticle("Статья 2.2");

            website.SetWriter(writer1);
            website.SetWriter(writer2);

            website.PublishArticle();
        }
    }
}