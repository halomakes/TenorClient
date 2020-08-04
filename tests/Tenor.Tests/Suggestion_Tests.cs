using System.Threading.Tasks;
using Xunit;

namespace Tenor.Tests
{
    public class Suggestion_Tests
    {
        private readonly TenorClient client;

        public Suggestion_Tests()
        {
            client = new TenorClient(Utils.ApiKey);
        }

        [Fact]
        public async Task Should_Get_Suggestions()
        {
            var suggestions = await client.GetSearchSuggestionsAsync("potato");
            Assert.NotEmpty(suggestions);
        }

        [Fact]
        public async Task Autocomplete_Should_Work()
        {
            var suggestions = await client.GetAutocompleteSuggestionsAsync("fu");
            Assert.NotEmpty(suggestions);
        }
    }
}
