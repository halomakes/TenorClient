using System;
using System.Threading.Tasks;
using Tenor.Schema;
using Tenor.Utils;

namespace Tenor
{
    public partial class TenorClient
    {
        public async Task<CategoryResult> GetCategoriesAsync()
        {
            var @params = GetParameters();

            var requestPath = new Uri($"{BaseUrl}v1/categories").ApplyQueryParams(@params);

            return await client.GetAsync<CategoryResult>(requestPath.ToString());
        }
    }
}
