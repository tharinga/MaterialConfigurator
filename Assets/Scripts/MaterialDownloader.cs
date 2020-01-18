﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace MakeAShape
{
    public class MaterialDownloader : MonoBehaviour
    {
        private WebApiService _webApiService;
        private TextureButtonLoader _buttonLoader;
        private MaterialController _materialController;

        [Inject]
        public void Construct(
            WebApiService webApiService, 
            TextureButtonLoader buttonLoader,
            MaterialController materialController)
        {
            _webApiService = webApiService;
            _buttonLoader = buttonLoader;
            _materialController = materialController;
        }
        
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
            
            _buttonLoader.LoadButtons(materials);
            _materialController.LoadMaterials(materials);
        }
    }
}