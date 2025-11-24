using AsyncCRUD.Models;
using System.Collections;
using System.Collections.Generic;

namespace AsyncCRUD.Services
{
    public interface IbookService
    {
        Task<Book>AddAsync(Book book);
        Task<Book?>GetByIdAsync(int id);
        Task<List<Book>> GetAllAsync();

        Task<Book?>UpdateAsync(int id , Book book);

        Task<Book?>DeleteBook(int id);

        Task<IEnumerable> GetAllBooksWithAuthor();

        Task<IEnumerable> GetAllAuthor();

        Task<IEnumerable> GetAuthorbook();
    }
}
