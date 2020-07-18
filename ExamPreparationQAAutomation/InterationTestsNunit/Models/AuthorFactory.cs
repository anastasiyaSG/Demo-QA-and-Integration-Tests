using InterationTestsNunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.Factories
{
    public static class AuthorFactory
    {
        public static Author CreateAuthor()
        {
            return new Author
            {
                FirstName = "Ani",
                LastName = "Best",
                Genre = "Female"
            };
        }
    }
}
