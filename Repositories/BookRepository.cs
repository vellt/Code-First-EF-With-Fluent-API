using CodeFirstEFWithFluentApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFWithFluentApi.Repositories
{
    internal class BookRepository : IBookRepository
    {
        public async Task Create(Book book)
        {
            using (var context= new BookContext())
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (var context = new BookContext())
            {
                var bookToDelete = await context.Books.FindAsync(id);
                if (bookToDelete != null)
                {
                    context.Books.Remove(bookToDelete);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Book>> Get()
        {
            using (var context= new BookContext())
            {
                return await context.Books.ToListAsync();
            }
        }

        public async Task<Book> Get(int id)
        {
            using (var context= new BookContext())
            {
                return await context.Books.FindAsync(id);
            }
        }

        public async Task Update(Book book)
        {
            using (var context = new BookContext())
            {
                context.Books.Update(book);
                await context.SaveChangesAsync();
            }
        }
    }
}
