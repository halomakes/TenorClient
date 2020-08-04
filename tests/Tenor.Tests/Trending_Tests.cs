using System.Threading.Tasks;
using Xunit;

namespace Tenor.Tests
{
    public class Trending_Tests
    {
        private readonly TenorClient client;

        public Trending_Tests()
        {
            client = new TenorClient(Utils.ApiKey);
        }

        [Fact]
        public async Task Should_Get_Trending_Posts()
        {
            var trending = await client.GetTrendingPostsAsync();
            Assert.NotEmpty(trending.Results);
        }

        [Fact]
        public async Task Should_Get_Trending_Terms()
        {
            var trending = await client.GetTrendingTermsAsync();
            Assert.NotEmpty(trending);
        }
    }
}
