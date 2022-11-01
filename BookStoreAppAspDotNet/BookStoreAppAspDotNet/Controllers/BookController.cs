using BookStoreAppAspDotNet.Models;
using BookStoreAppAspDotNet.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppAspDotNet.Controllers
{
    public class BookController : Controller    
    {

        private readonly BookRespository _bookRespository = null;

        public BookController()
        {
            _bookRespository = new BookRespository();
        }



        public List<BookModel> GetAllBooks()
        {
            return _bookRespository.GetAllBooks();
        }
        public BookModel GetBook(int id )
        {
            return _bookRespository.GetBookId(id);
        }
        public List<BookModel> SearchBook(string BookName, string AuthorName)
        {
            return _bookRespository.SearchBook(BookName, AuthorName);
        }
    }
}
