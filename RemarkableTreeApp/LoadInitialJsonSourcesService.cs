using System;
using System.IO;
using Newtonsoft.Json;

namespace RemarkableTreeApp
{
    public abstract class LoadInitialJsonSourcesService
    {
        public static LoadInitialJsonSourcesService Instance { get; set; }

        public abstract T Init<T>(string fileName);
    }
}
