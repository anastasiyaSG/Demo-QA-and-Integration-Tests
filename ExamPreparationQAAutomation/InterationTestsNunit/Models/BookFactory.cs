using InterationTestsNunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.Factories
{
    public static class BookFactory
    {
        public static Book CreateBook()
        {
            return new Book
            {
                Title = "Get Exam",
                Description = "Maximum"
            };
        }
    }
}
