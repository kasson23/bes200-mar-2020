using LibraryApi.Models;
using System.Threading.Tasks;

namespace LibraryApi
{
    public interface IMapBooks
    {
        Task<GetABookResponse> GetBookById(int id);
        Task<GetBooksResponse> GetAllBooks(string genre);
        Task<GetABookResponse> AddABook(PostBooksRequest bookToAdd);
        Task <bool> UpdateNumberOfPagesAtId(int id, int newPages);
        Task Remove(int id);
    }
}