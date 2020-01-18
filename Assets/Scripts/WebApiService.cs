using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace MakeAShape
{
    public class WebApiService 
    {
        public async Task<string> GetAsync(string url)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                await request.SendWebRequest();
                return request.downloadHandler.text;
            }
        }

        public async Task<Texture2D> GetTextureAsync(string url)
        {
            using (var request = UnityWebRequestTexture.GetTexture(url))
            {
                await request.SendWebRequest();
                return DownloadHandlerTexture.GetContent(request);
            }
        }
    }
}