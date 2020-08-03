using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Tenor.Schema;
using Xunit;

namespace Tenor.Tests
{
    public class Search_Tests
    {
        private readonly TenorClient client;

        public Search_Tests()
        {
            client = new TenorClient("LIVDSRZULELA"); // example key from their documentation page
        }

        [Fact]
        public async Task Should_Get_Correct_Count()
        {
            var limit = 10;
            var results = await client.SearchAsync("potato", limit: limit);

            Assert.Equal(limit, results.Results.Count());
        }

        [Fact]
        public async Task Should_Use_Correct_Culture()
        {
            var culture = CultureInfo.GetCultureInfo("es");
            var results = await client.SearchAsync("Zanahoria", locale: culture);

            Assert.NotEmpty(results.Results);
        }

        [Fact]
        public async Task Should_Handle_Special_Characters()
        {
            var results = await client.SearchAsync("mom/dad's homemade pie!");

            Assert.NotEmpty(results.Results);
        }

        [Fact]
        public async Task Should_Apply_Filter()
        {
            var results = await client.SearchAsync("ass", contentFilter: ContentFilter.Off);

            Assert.NotEmpty(results.Results);
        }
    }
}
