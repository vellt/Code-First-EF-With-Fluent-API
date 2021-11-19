using CodeFirstEFWithFluentApi.Repositories;
using CodeFirstEFWithFluentApi.Model;
using System;
using System.Linq;

namespace CodeFirstEFWithFluentApi
{
    enum Mode
    {
        Get,
        Update,
        Delete,
        Create,
        GetByID
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            start(bookRepository);
        }

        private static void start(BookRepository bookRepository)
        {
            Console.WriteLine("Press a key to continue..");
            while (Console.ReadKey().Key!=ConsoleKey.Delete)
            {
                Console.Clear();
                Console.Write("(0-Get | 1-Update | 2-Delete | 3-Create | 4-GetByID)\nMode: ");
                Mode mode = (Mode)Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine(nameof(mode.GetName));
                switch (mode)
                {
                    case Mode.Get:
                        get(bookRepository);
                        break;
                    case Mode.Update:
                        update(bookRepository);
                        break;
                    case Mode.Delete:
                        delete(bookRepository);
                        break;
                    case Mode.Create:
                        create(bookRepository);
                        break;
                    case Mode.GetByID:
                        getByID(bookRepository);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("done");
            }
        }

        private static async void getByID(BookRepository bookRepository)
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Book book = await bookRepository.Get(id);
            Console.WriteLine($"{book.ID}\t{book.Actor}\t{book.Title}");
        }

        private static async void create(BookRepository bookRepository)
        {
            Book book = new Book();
            Console.Write("Actor: ");
            book.Actor = Console.ReadLine();
            Console.Write("Title: ");
            book.Title = Console.ReadLine();
            Console.Write("Description: ");
            book.Description = Console.ReadLine();
            await bookRepository.Create(book);
        }

        private static async void delete(BookRepository bookRepository)
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            await bookRepository.Delete(id);
        }

        private static async void update(BookRepository bookRepository)
        {
            Book book = new Book();
            Console.Write("ID: ");
            book.ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Actor: ");
            book.Actor = Console.ReadLine();
            Console.Write("Title: ");
            book.Title = Console.ReadLine();
            Console.Write("Description: ");
            book.Description = Console.ReadLine();
            await bookRepository.Update(book);
        }

        private static void get(BookRepository bookRepository)
        {
            bookRepository
                .Get()
                .Result
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.ID}\t{x.Actor}\t{x.Title}"));
        }
    }
}
