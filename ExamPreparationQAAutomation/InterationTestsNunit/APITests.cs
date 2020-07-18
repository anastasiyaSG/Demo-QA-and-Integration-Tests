using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace InterationTestsNunit
{
    [TestFixture]
    public class APITests
    {
        private RestClient _restClient;
        private string _idAuthor;
        private string _bookId;

        [SetUp]
        public void SetUp()
        {
            _restClient = new RestClient();
            _restClient.Timeout = -1;
            _restClient.BaseUrl = new Uri("https://libraryjuly.azurewebsites.net");
            _restClient.AddDefaultHeader("Content-Type", "application/json");
            _restClient.AddDefaultHeader("Accept", "application/json");

            _idAuthor = CreateAuthor();
            _bookId = AddBookToAuthor();
        }
        public string CreateAuthor()
        {
            var newAuthor = AuthorFactory.CreateAuthor();

            var request = new RestRequest("/api/authors");
            request.AddJsonBody(newAuthor.ToJson(), "application/json");

            var response = _restClient.Post(request);

            var createdAuthor = Author.FromJson(response.Content);

            return createdAuthor.Id.ToString();
        }

        public string AddBookToAuthor()
        {
            var newBook = BookFactory.CreateBook();

            var request = new RestRequest($"/api/authors/{_idAuthor}/books");
            request.AddJsonBody(newBook.ToJson(), "application/json");

            var response = _restClient.Post(request);

            var addedBook = Book.FromJson(response.Content);

            return addedBook.Id.ToString();
        }

        [Test]
        public void PostAuthor()
        {
            var request = new RestRequest($"/api/authors");

            request.AddParameter("application/json", "{\n\t\"firstName\" : \"lala\",\n\t\"lastName\" : \"Test\",\n\t\"genre\": \"female\"\n}", ParameterType.RequestBody);
            var responsePost =_restClient.Post(request);
            
            Assert.AreEqual(HttpStatusCode.Created, responsePost.StatusCode);
        }

        [Test]
        public void PostInvalidAuthor()
        {
          var request = new RestRequest($"/api/authors");
          
            request.AddParameter("application/json", "{\n\t\"firstName\" : \"James\",\n\t\"lastName\" : \"Ellroy\",\n\t\"dateOfBirth\" : \"invalid value for DateTimeOffset\",\n\t\"genre\": \"Thriller\"\n}", ParameterType.RequestBody);
            var responsePost = _restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, responsePost.StatusCode);

        }
        [Test]
        public void PostBookForAuthor()
        {
            var request = new RestRequest($"/api/authors/{_idAuthor}/books");
            request.AddParameter("application/json", "{\n\t\"title\" : \"The Restaurant at the End of the Universe\",\n\t\"description\" : \"The sequel to The Hitchhiker's Guide to the Galaxy\"\n}", ParameterType.RequestBody);
           var responsePost = _restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.Created, responsePost.StatusCode);

        }
        [Test]
        public void PostBookForAuthorUnexistingAuthor()
        {
            var request = new RestRequest("/api/authors/0d75ab75-0028-40c3-8019-1188fe7e790a/books");
            request.AddParameter("application/json", "{\n\t\"title\" : \"The Restaurant at the End of the Universe\",\n\t\"description\" : \"The sequel to The Hitchhiker's Guide to the Galaxy\"\n}", ParameterType.RequestBody);
            IRestResponse responsePost =_restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.NotFound, responsePost.StatusCode);

        }
        [Test]
        public void PostAuthorWhitBooks()
        {
            var request = new RestRequest("/api/authors");
            request.AddParameter("application/json", "{\n\t\"firstName\" : \"James\",\n\t\"lastName\" : \"Ellroy\",\n\t\"dateOfBirth\" : \"1948-03-04T00:00:00\",\n\t\"genre\": \"Thriller\",\n\t\"books\": [\n\t\t{\n\t\t\t\"title\" : \"American Tabloid\",\n\t\t  \t\"description\" : \"First book in the Underworld USA trilogy\"\n\t\t},\n\t\t{\n\t\t\t\"title\": \"The Cold Six Thousand\",\n\t\t\t\"description\": \"Second book in the Underworld USA trilogy\"\n\t\t}\n\t\t]\n}", ParameterType.RequestBody);
            var responsePost = _restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.Created, responsePost.StatusCode);

        }
        [Test]
        public void PostAuthorCollection()
        {
            var request = new RestRequest("/api/authorcollections");
           request.AddParameter("application/json", "[{\n\t\"firstName\" : \"James\",\n\t\"lastName\" : \"Ellroy\",\n\t\"dateOfBirth\" : \"1948-03-04T00:00:00\",\n\t\"genre\": \"Thriller\"\n},\n{\n\t\"firstName\" : \"Jonathan\",\n\t\"lastName\" : \"Franzen\",\n\t\"dateOfBirth\" : \"1959-08-17T00:00:00\",\n\t\"genre\": \"Drama\"\n}]", ParameterType.RequestBody);
            IRestResponse response = _restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
        [Test]
        public void PostAuthorSingleUnexisting()
        {
            var request= new RestRequest("/api/authors/25141d83-4584-4487-a306-0441695d8e24");
            request.AddParameter("application/json", "{\n\t\"firstName\" : \"James\",\n\t\"lastName\" : \"Ellroy\",\n\t\"dateOfBirth\" : \"1948-03-04T00:00:00\",\n\t\"genre\": \"Thriller\"\n}", ParameterType.RequestBody);
            var response = _restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }
        [Test]
        public void PostAuthorSingleExisting()
        {
            var request = new RestRequest("/api/authors/f74d6899-9ed2-4137-9876-66b070553f8f");
            request.AddParameter("application/json", "{\n\t\"firstName\" : \"James\",\n\t\"lastName\" : \"Ellroy\",\n\t\"dateOfBirth\" : \"1948-03-04T00:00:00\",\n\t\"genre\": \"Thriller\"\n}", ParameterType.RequestBody);
            var response = _restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }

        [Test]
        public void PostAuthorXMLInput()
        {
            var request = new RestRequest("/api/authors");
            request.AddParameter("application/xml", "<AuthorForCreationDto xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/Library.API.Models\">\r\n        <DateOfBirth xmlns:d3p1=\"http://schemas.datacontract.org/2004/07/System\">\r\n            <d3p1:DateTime>1948-03-03T00:00:00Z</d3p1:DateTime>\r\n            <d3p1:OffsetMinutes>0</d3p1:OffsetMinutes>\r\n        </DateOfBirth>\r\n        <FirstName>James</FirstName>\r\n        <Genre>Thriller</Genre>\r\n        <LastName>Ellroy</LastName>\r\n</AuthorForCreationDto>\r\n", ParameterType.RequestBody);
            var response = _restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void PostAuthorXMLInputXMLOutput()
        {
            var request = new RestRequest("/api/authors");
            request.AddParameter("application/xml", "<AuthorForCreationDto xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/Library.API.Models\">\r\n        <DateOfBirth xmlns:d3p1=\"http://schemas.datacontract.org/2004/07/System\">\r\n            <d3p1:DateTime>1948-03-03T00:00:00Z</d3p1:DateTime>\r\n            <d3p1:OffsetMinutes>0</d3p1:OffsetMinutes>\r\n        </DateOfBirth>\r\n        <FirstName>James</FirstName>\r\n        <Genre>Thriller</Genre>\r\n        <LastName>Ellroy</LastName>\r\n</AuthorForCreationDto>", ParameterType.RequestBody);
            var response = _restClient.Post(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Test]
        public void DeleteBookForAuthor()
        {
            var request= new RestRequest($"/api/authors/{_idAuthor}/books/{_bookId}");
            request.AddHeader("Cookie", "ARRAffinity=270fc76c7a748acb7bb3a328ed3b3e85783de79ee41831feff7c3c2118b4802a");
           var response = _restClient.Delete(request);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Test]
        public void DeleteBookForAuthorUnexistingBook()
        {
            var request = new RestRequest("/api/authors/25320c5e-f58a-4b1f-b63a-8ee07a840bdf/books/3f946dbe-edf3-4c44-baef-b683bc355a0f");
            var response = _restClient.Execute(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void DeleteBookForAuthorUnexistingAuthor()
        {
            var request = new RestRequest("/api/authors/787f6625-6048-43d7-b64e-bf3d02f0132d/books/70a1f9b9-0a37-4c1a-99b1-c7709fc64167");
            request.AddHeader("Cookie", "ARRAffinity=270fc76c7a748acb7bb3a328ed3b3e85783de79ee41831feff7c3c2118b4802a");
            IRestResponse response = _restClient.Delete(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void DeleteAuthor()
        {
            var request
                = new RestRequest($"/api/authors/{_idAuthor}");
            request.AddHeader("Cookie", "ARRAffinity=270fc76c7a748acb7bb3a328ed3b3e85783de79ee41831feff7c3c2118b4802a");
            var response = _restClient.Delete(request);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Test]
        public void GetAuthorAcceptAplicationXML()
        {
            var request = new RestRequest("/api/authors/76053df4-6687-4353-8937-b45556748abe");
            var response = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void GetAuthorAcceptAplicationJson()
        {
            var request = new RestRequest("/api/authors/76053df4-6687-4353-8937-b45556748abe");
            var response = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public void GetAuthorUnexistingAuthor()
        {
            var request = new RestRequest("/api/authors/b29e03b5-ba28-4489-8834-689de28af370/books/bc4c35c3-3857-4250-9449-155fcf5109ec");
            var response = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Test]
        public void GetAuthorUnexistingBook()
        {
            var request = new RestRequest("/api/authors/76053df4-6687-4353-8937-b45556748abe/books/8afc4f43-3d02-429b-90c7-1cabe201bf7a");
            var response =_restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Test]
        public void GetBookForAuthor()
        {
            var request = new RestRequest($"/api/authors/{_idAuthor}/books/{_bookId}");
            var response = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public void GetBooskForAuthorUnexistingAuthor()
        {
            var request = new RestRequest("/api/authors/b29e03b5-ba28-4489-8834-689de28af370/books");
            var response = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void GetBooskForAuthor()
        {
            var request = new RestRequest($"/api/authors/{_idAuthor}/books");
            request.AddHeader("Cookie", "ARRAffinity=270fc76c7a748acb7bb3a328ed3b3e85783de79ee41831feff7c3c2118b4802a");
            var response = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public void GetAuthorUnexisting()
        {
            var request
                = new RestRequest("/api/authors/a8d15573-ec65-4f48-97d2-2e7c0a726c33");
            var response = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void GetAuthor()
        {
            var request = new RestRequest($"/api/authors/{_idAuthor}");
            var responseGet = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, responseGet.StatusCode);
        }

        [Test]
        public void GetAuthors()
        {
            var request = new RestRequest("/api/authors");
            var response = _restClient.Get(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
