﻿using BookStoreAppAspDotNet.Data;
using BookStoreAppAspDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppAspDotNet.Repository
{
    public class BookRespository
    {
        private readonly BookStoreContext _context = null;

        public BookRespository(BookStoreContext context)
        {
            _context = context;
        }

        public int AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {

                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                Pages = model.Pages,
                Language = model.Language


            };

            _context.Books.Add(newBook);
            _context.SaveChanges();

            return newBook.Id;

        }

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
                new BookModel() { Id = 1, Title = "MVC" , Author = "Saqib" , Description= "This book will cover all the details about Asp.Net Core MVC 5. This book is designed specially for freshers to pro knowledge. After reading this book you will be able to develop fully functional application using Asp.Net Core MVC 5." , Category = "Programming" , Language = "English" , Pages=1024},
                new BookModel() { Id = 2, Title = "JAVA", Author = "Usama" , Description= "JAVA was developed by James Gosling at Sun Microsystems Inc in the year 1995, later acquired by Oracle Corporation. It is a simple programming language. Java makes writing, compiling, and debugging programming easy. It helps to create reusable code and modular programs." , Category = "Low Level Programming" , Language = "Chinese" , Pages=884},
                new BookModel() { Id = 3, Title = "PYHTON", Author = "Atta" , Description= "Python is a widely used general-purpose, high level programming language. It was created by Guido van Rossum in 1991 and further developed by the Python Software Foundation." , Category = "AI Languase" , Language = "User Friendly" , Pages=1000},
                new BookModel() { Id = 4, Title = "C#", Author = "Sami" , Description= "C# is a general-purpose, modern and object-oriented programming language pronounced as “C sharp”. It was developed by Microsoft led by Anders Hejlsberg and his team within the .Net initiative and was approved by the European Computer Manufacturers Association (ECMA) and International Standards Organization (ISO)." , Category = "Development" , Language = "Italian" , Pages=2500},
                new BookModel() { Id = 5, Title = "REACT", Author = "Saqib" , Description= "React is a declarative, efficient, and flexible JavaScript library for building user interfaces. ‘V’ denotes the view in MVC. ReactJS is an open-source, component-based front end library responsible only for the view layer of the application. It is maintained by Facebook." , Category = "FrontEnd Library" , Language = "French" , Pages=777},
                new BookModel() { Id = 6, Title = "MATHS", Author = "Azher" , Description= "Mathematics is essential in the sciences, engineering, medicine, finance, computer science and the social sciences. The fundamental truths of mathematics are independent from any scientific experimentation, although mathematics is extensively used for modeling phenomena. Some areas of mathematics, such as statistics and game theory, are developed in close correlation with their applications and are often grouped under applied mathematics." , Category = "Learning" , Language = "English" , Pages=333}

            };
        }

    }
}
