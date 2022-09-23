using MySupermarket.Common.Configurations;
using MySupermarket.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Modules.ModuleName.Service.Music
{
    public class MusicInfoService : BaseService<MusicInfoDto>, IMusicInfoService
    {
        private readonly HttpRestClient client;
        private readonly string serviceName;

        public MusicInfoService(HttpRestClient client, string serviceName = "MusicInfo") : base(client, serviceName)
        {
            this.client = client;
            this.serviceName = serviceName;
        }

        public async Task<ApiResponse<MusicInfoDto>> GetFirstOfDefaultAsync(string songName)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/GetSingle?name={songName}";

            return await client.ExecuteAsync<MusicInfoDto>(request);
        }
    }
}
