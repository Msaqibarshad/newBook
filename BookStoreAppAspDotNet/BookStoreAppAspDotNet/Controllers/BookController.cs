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

        public BookController(BookRespository bookRespository)
        {
            _bookRespository = bookRespository;
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

        public ViewResult AddNewBook(bool isSuccess = false , int bookId = 0 )
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel)
        {
         int id =    _bookRespository.AddNewBook(bookModel);
            if (id > 0 )
            {
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true ,bookId = id});
            }
            return View();
        }
    }
}
