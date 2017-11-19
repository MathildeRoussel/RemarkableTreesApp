using System;
using System.IO;
using Android.App;
using Newtonsoft.Json;

namespace RemarkableTreeApp.Droid
{
    public class LoadInitialJsonSourcesService : RemarkableTreeApp.LoadInitialJsonSourcesService
    {
        private readonly Activity _activity;

        public LoadInitialJsonSourcesService(Activity activity)
        {
            _activity = activity;
        }

        public override T Init<T>(string fileName)
        {
            StreamReader strm = new StreamReader(_activity.Assets.Open(fileName));
            var response = strm.ReadToEnd();

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
