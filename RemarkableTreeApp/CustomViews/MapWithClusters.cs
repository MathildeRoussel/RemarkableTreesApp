using System;
using System.Collections.Generic;
using RemarkableTreeApp.Models;
using Xamarin.Forms.Maps;

namespace RemarkableTreeApp.CustomViews
{
    public class MapWithClusters : Map
    {
        public List<RemarkableTreeRoot> Trees { get; set; }

        public MapWithClusters()
        {
        }
    }
}
