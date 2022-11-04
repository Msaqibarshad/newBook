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



        public ViewResult GetAllBooks()
        {
            var data =  _bookRespository.GetAllBooks();
            return View(data);
        }
        public ViewResult GetBook(int id )
        {
            var data =  _bookRespository.GetBookId(id);
            return View(data);
        }
        public List<BookModel> SearchBook(string BookName, string AuthorName)
        {
            return _bookRespository.SearchBook(BookName, AuthorName);
        }

        public ViewResult AddNewBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddNewBook(BookModel bookModel)
        {
            return View();
        }
    }
}
