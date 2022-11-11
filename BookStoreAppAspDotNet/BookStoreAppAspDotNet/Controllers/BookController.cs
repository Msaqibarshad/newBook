using BookStoreAppAspDotNet.Models;
using BookStoreAppAspDotNet.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppAspDotNet.Controllers
{
    public class BookController : Controller     
    {

        private readonly BookRespository _bookRespository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public BookController(BookRespository bookRespository , IWebHostEnvironment webHostEnvironment)
        {
            _bookRespository = bookRespository;
            _webHostEnvironment = webHostEnvironment;
        }



        public async Task<ViewResult>   GetAllBooks()
        {
            var data =await  _bookRespository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id )
        {
            var data = await _bookRespository.GetBookId(id);
            return View(data);
        }
        
        public ViewResult AddNewBook(bool isSuccess = false , int bookId = 0 )
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  AddNewBook(BookModel bookModel)
        {

            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "Books/CoverImage/";
                    folder += Guid.NewGuid().ToString() + "_" + bookModel.CoverPhoto.FileName ;
                    bookModel.CoverImageUrl = "/"+folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                 await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                }

                int id = await _bookRespository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
         
            return View();
        }
    }
}
