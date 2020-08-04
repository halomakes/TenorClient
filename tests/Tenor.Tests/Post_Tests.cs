using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tenor.Tests
{
    public class Post_Tests
    {
        private readonly TenorClient client;

        public Post_Tests()
        {
            client = new TenorClient(Utils.ApiKey);
        }

        [Fact]
        public async Task Should_Get_Post()
        {
            var id = "17972084";
            var post = await client.GetPostAsync(id);
            Assert.NotNull(post);
            Assert.Equal(id, post.Id);
        }

        [Fact]
        public async Task Should_Get_Posts()
        {
            var ids = new List<string> { "17972084", "17970954", "4862446" };
            var posts = await client.GetPostsAsync(ids);
            Assert.NotEmpty(posts.Results);
            foreach (var id in ids)
            {
                Assert.NotNull(posts.Results.FirstOrDefault(p => p.Id == id));
            }
        }
    }
}
