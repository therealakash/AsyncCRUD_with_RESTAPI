using AsyncCRUD.Models;
using AsyncCRUD.Repositry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections;

namespace AsyncCRUD.Services
{
    public class Serv : IbookService
    {
        private readonly Appdbcontext cnt;

        public Serv(Appdbcontext cnt)
        {
            this.cnt = cnt;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await cnt.AddAsync(book);
            await cnt.SaveChangesAsync();
            return book;
        }

        

        public async Task<Book?> DeleteBook(int id)
        {

            var bk1 = await cnt.Books.FindAsync(id);
            if (bk1 == null)
            {
                return null;
            }
            cnt.Books.Remove(bk1);
            await cnt.SaveChangesAsync();
            return bk1;
        }

        public async Task<List<Book>> GetAllAsync()
        {
           return await cnt.Books.ToListAsync();
        }

        public async Task<IEnumerable> GetAllAuthor()
        {
            var dat= await cnt.Authors.FromSqlRaw("Select * from Authors").ToListAsync();
            return dat;
        }

        public async Task<IEnumerable> GetAllBooksWithAuthor()
        {
            var bwa = await (from b in cnt.Books join a in cnt.Authors 
                             on b.AuthorId equals a.AuthorId
                             select new{
                Book = b.Title,
                Author=a.Firstname
            }).ToListAsync();
            return bwa;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await cnt.Books.SingleOrDefaultAsync(x=> x.BookId == id);
        }

        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            if (id != book.BookId)
            {
                return null;
            }
            var  bk = await cnt.Books.SingleOrDefaultAsync(q=>q.BookId == id);
            if (bk == null) 
            {
                return null;
                   
            }
           cnt.Entry(bk).CurrentValues.SetValues(book);
            await cnt.SaveChangesAsync();
            return bk;
        }

    
    }
}
