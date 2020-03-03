using AutoMapper;
using LibraryApi.Domain;
using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Profiles
{
    public class BooksProfile : Profile
    {
        // ctor - snippet to create a contructor 
        public BooksProfile()
        {
            // After, configure it in the Startup.cs
            CreateMap<Book, GetABookResponse>();
            CreateMap<Book, BookSummaryItem>();
            CreateMap<PostBooksRequest, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InInventory, opt => opt.MapFrom(_ => true)); // use _ when you h
        }
    }
}
