using LibraryApi.Domain;
using LibraryApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
	public class BooksMongoController : Controller
	{
		private readonly BookServiceMongoDb _bookService;

		public BooksMongoController(BookServiceMongoDb bookService)
		{
			_bookService = bookService;
		}


		[HttpGet("/mongo/books")]
		public ActionResult<List<BookMongo>> Get()
		{
			return Ok(_bookService.Get());
		}
	}
}
