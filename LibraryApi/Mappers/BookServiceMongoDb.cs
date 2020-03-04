using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Domain;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LibraryApi.Mappers
{
	public class BookServiceMongoDb
	{
		private readonly IMongoCollection<Book> _books;

		public BookServiceMongoDb(IBookstoreDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_books = database.GetCollection<Book>(settings.BooksCollectionName);
		}

		
		public List<Book> Get()
		{
			return _books.Find(book => book.InInventory == true).ToList();
		}
	}
}
