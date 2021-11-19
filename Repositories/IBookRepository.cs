using CodeFirstEFWithFluentApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFWithFluentApi.Repositories
{
    internal interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(int id);
    }
}
