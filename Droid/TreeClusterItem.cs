using System;
using Android.Gms.Maps.Model;
using Com.Google.Maps.Android.Clustering;
using RemarkableTreeApp.Models;

namespace RemarkableTreeApp.Droid
{
    public class TreeClusterItem : Java.Lang.Object, IClusterItem
    {
        public TreeClusterItem(RemarkableTreeRoot tree)
        {
            Position = new LatLng(tree.geometry.coordinates[1], tree.geometry.coordinates[0]);
            Title = tree.fields.libellefrancais;
        }

        public TreeClusterItem(IntPtr handle, Android.Runtime.JniHandleOwnership transfer)
        : base(handle, transfer)
        {

        }

        public LatLng Position { get; private set; }

        public string Snippet { get; set; }

        public string Title { get; set; }
    }
}
