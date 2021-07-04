using BookStoreAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDTO>> GetAll();
        Task<BookDTO> Get(int id);
        Task<BookDTO> Create(BookDTO book);
        Task Update(BookDTO book);
        Task Delete(int id);
    }
}
