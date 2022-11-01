using BookStoreAppAspDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppAspDotNet.Repository
{
    public class BookRespository
    {

        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookId(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title , string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorname)).ToList();

        }

        private List<BookModel> DataSource()
        {

            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title = "MVC" , Author = "Saqib"},
                new BookModel() { Id = 2, Title = "JAVA", Author = "USAMA" },
                new BookModel() { Id = 3, Title = "PYHTON", Author = "ATTA" },
                new BookModel() { Id = 4, Title = "CSHARP", Author = "SAMI" },
                new BookModel() { Id = 5, Title = "REACT", Author = "Saqib" }
            };
        }

    }
}
