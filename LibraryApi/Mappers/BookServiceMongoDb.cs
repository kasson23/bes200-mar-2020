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
		private readonly IMongoCollection<BookMongo> _books;

		public BookServiceMongoDb(IBookstoreDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_books = database.GetCollection<BookMongo>(settings.BooksCollectionName);
		}

		
		public List<BookMongo> Get()
		{
			return _books.Find(book => book.InInventory == true).ToList();
		}
	}
}
