using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjEstanteLivros
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Reading { get; set; }

        public Book(string t, string a, string isbn, string reading)
        {
            this.Title = t;
            this.Author = a;
            this.ISBN = isbn;
            this.Reading = reading;
        }

        public string EditTitle()
        {
            Console.Write("Título:");
            this.Title = Console.ReadLine();

            return this.Title;
        }
        public string EditAuthor()
        {
            Console.Write("Autor:");
            this.Author = Console.ReadLine();

            return this.Author;
        }
        public string EditISBN()
        {
            Console.Write("ISBN:");
            this.ISBN = Console.ReadLine();

            return this.ISBN;
        }

        public string EditReading()
        {
            do
            {
                Console.WriteLine("\nEste livro está: \n(0)-Sendo lido \n(1)-A ler \n(2)-Já lido");
                Reading = Console.ReadLine();
            } while (Reading != "0" && Reading != "1" && Reading != "2");

            return this.Reading;
        }

        //public string  showBook()
        //{
        //    return $"Título: {this.Title}  *  Autor: {this.Author}  *  ISBN: {this.ISBN}  *  Estado: {this.Reading} ";

        //}

        public string ToStringSegundo()
        {
            return $" Título: {this.Title} * Autor: {this.Author}  *  ISBN: {this.ISBN}  *  Estado de leitura: {this.Reading}";
        }
        public override string ToString()
        {
            return $"{this.Title} * {this.Author}  *  {this.ISBN}  *  {this.Reading}";
        }

        
    }
}
