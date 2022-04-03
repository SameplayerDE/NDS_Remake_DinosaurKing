using System.IO;
using HxTiled.Json;
using Newtonsoft.Json;

namespace NDS_Remake_DinosaurKing.Data
{
    public static class SimulationAreaLoader
    {
        
        /*public static SimulationArea LoadFromJson(string path, out int[] data, out int width, out int height)
        {
            data = null;
            width = 0;
            height = 0;
            if (!File.Exists(path)) return;
            using var file = File.OpenText(path);
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            using var reader = new JsonTextReader(file);

            var jsonObject000 = (JObject)JToken.ReadFrom(reader);

            var jsonLayers = jsonObject000["layers"];
            if (jsonLayers != null)
            {
                for (var layerIndex = 0; layerIndex < jsonLayers.Count(); layerIndex++)
                {
                    var jsonLayer = jsonLayers[layerIndex];
                    var layerWidth = (int)jsonLayer?["width"];
                    var layerHeight = (int)jsonLayer?["height"];
                    var layerData = jsonLayer?["data"];

                    width = layerWidth;
                    height = layerHeight;

                    if (layerData == null) return;

                    var layerDataArray = layerData.Values<int>().ToArray();
                    data = layerDataArray;
                }
            }

            reader.Close();
            file.Dispose();
        }*/
        
        public static TileMapFile LoadFromJson(string path)
        {
            var result = JsonConvert.DeserializeObject<TileMapFile>(File.ReadAllText(path));
            if (result == null) return null;
            result.Path = path;

            foreach (var tileSetFile in result.Tilesets)
            {
                tileSetFile.Path = result.Path;
            }
            
            return result;
        }
    }
}