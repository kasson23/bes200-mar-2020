using LibraryApi;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApiIntegrationTests
{
    public class ResourceSmokeTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient Client;

        public ResourceSmokeTest(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/books")]
        [InlineData("/books/1")]
        public async Task GetResourceAndSeeIfTheyAreAlive(string resource)
        {
            var response = await Client.GetAsync(resource);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetBookOne()
        {
            var book1 = await Client.GetAsync("/books/1");
            var content = await book1.Content.ReadAsAsync<GetABookResponse>();

            Assert.Equal(HttpStatusCode.OK, book1.StatusCode);
            Assert.Equal("application/json", book1.Content.Headers.ContentType.MediaType);

            Assert.Equal("Walden", content.title);
            //Check all the properties
        }

        [Fact]
        public async Task CanAddABook()
        {
            // create a book to send
            var bookToAdd = new PostBookRequest
            {
                author = "Smith",
                title = "Effecient use of virual machines in the cloud",
                genre = "fiction",
                numberOfPages = 3
            };

            // send to our api
            var response = await Client.PostAsJsonAsync("/books", bookToAdd);
            // test response that it got created
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // in response check the path for where the one book can be found
            var location = response.Headers.Location.LocalPath;

            // get the book by the path revieved and set it to Type Book Response
            var getItResponse = await Client.GetAsync(location);
            var responseData = await getItResponse.Content.ReadAsAsync<GetABookResponse>();
            // test that the data sent was the data recieved from the GET
            Assert.Equal(bookToAdd.title, responseData.title);
            Assert.Equal(bookToAdd.author, responseData.author);
        }
    }
    public class GetABookResponse
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int numberOfPages { get; set; }
    }


    public class PostBookRequest
    {
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int numberOfPages { get; set; }
    }
}
