using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace MakeAShape
{
    public class MaterialDownloader : MonoBehaviour
    {
        private WebApiService _webApiService = new WebApiService();

        async void Start()
        {
            await FetchDataAsync();
        }

        async Task FetchDataAsync()
        {
            var json = await _webApiService.GetAsync(ApiConstants.MaterialDataUrl);
            var data = JsonConvert.DeserializeObject<List<MaterialDto>>(json);

            await DownloadTexturesAsync(data);
        }

        async Task DownloadTexturesAsync(List<MaterialDto> data)
        {
            var materials = new List<MaterialProperties>();

            foreach (var materialData in data)
            {
                var albedoTexture = await _webApiService.GetTextureAsync(materialData.AlbedoUrl);
                var normalTexture = await _webApiService.GetTextureAsync(materialData.NormalUrl);

                materials.Add(new MaterialProperties(materialData, albedoTexture, normalTexture));
            }
        }
    }
}