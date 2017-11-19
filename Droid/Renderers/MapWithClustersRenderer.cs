using System;
using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Com.Google.Maps.Android.Clustering;
using RemarkableTreeApp.CustomViews;
using RemarkableTreeApp.Droid.Renderers;
using RemarkableTreeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(MapWithClusters), typeof(MapWithClustersRenderer))]
namespace RemarkableTreeApp.Droid.Renderers
{
    public class MapWithClustersRenderer : MapRenderer
    {
        private List<RemarkableTreeRoot> _trees;

        private ClusterManager _clusterManager;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var formsMap = (MapWithClusters)e.NewElement;
                _trees = formsMap.Trees;
                Control.GetMapAsync(this);

            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            _clusterManager = new ClusterManager(this.Context, map);
            //map.SetOnCameraChangeListener(_clusterManager);
            map.SetOnMarkerClickListener(_clusterManager);

            foreach (var tree in _trees)
            {
                var clusterItem = new TreeClusterItem(tree);
                _clusterManager.AddItem(clusterItem);
                //var point = new MarkerOptions();
                //point.SetPosition(new LatLng(tree.geometry.coordinates[1], tree.geometry.coordinates[0]));

                //map.AddMarker(point);
            }
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.ic_pin));
            return marker;
        }
    }
}
