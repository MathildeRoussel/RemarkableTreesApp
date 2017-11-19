using System;
using System.IO;
using Newtonsoft.Json;

namespace RemarkableTreeApp.iOS
{
    public class LoadInitialJsonSourcesService : RemarkableTreeApp.LoadInitialJsonSourcesService
    {
        public override T Init<T>(string fileName)
        {
            var json = File.ReadAllText("Assets/" + fileName);

            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }
    }
}
