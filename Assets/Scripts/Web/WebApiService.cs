using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace MakeAShape.Web
{
    public class WebApiService 
    {
        public async Task<string> GetAsync(string url)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                await request.SendWebRequest();
                if (request.isHttpError || request.isNetworkError)
                {
                    // Obviously not production ready error handling
                    return "";
                }
                return request.downloadHandler.text;
            }
        }

        public async Task<Texture2D> GetTextureAsync(string url)
        {
            using (var request = UnityWebRequestTexture.GetTexture(url))
            {
                await request.SendWebRequest();
                if (request.isHttpError || request.isNetworkError)
                {
                    // Obviously not production ready error handling
                    return null;
                }
                return DownloadHandlerTexture.GetContent(request);
            }
        }
    }
}