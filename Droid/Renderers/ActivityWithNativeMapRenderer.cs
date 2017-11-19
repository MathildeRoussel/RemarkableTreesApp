using System;
using System.Collections.Generic;
using Android.App;
using Android.Gms.Maps;
using RemarkableTreeApp;
using RemarkableTreeApp.Droid.Renderers;
using RemarkableTreeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace RemarkableTreeApp.Droid.Renderers
{
    public class ActivityWithNativeMapRenderer : PageRenderer, IOnMapReadyCallback
    {
        //private GoogleMap MapView => ViewHelper.FindInHierarchy<GoogleMap>(ViewGroup);

        private List<RemarkableTreeRoot> _trees;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var customViewForms = (RemarkableTreeAppPage)e.NewElement;

                _trees = customViewForms.Trees;
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var count = ChildCount;

            var child = GetChildAt(0);


            base.OnLayout(changed, l, t, r, b);
        }


        public void OnMapReady(GoogleMap googleMap)
        {
            var activity = this.Context as Activity;

            var view = this.FindFocus();
            for (int i = 0; i < ViewGroup.ChildCount; i++)
            {

                var child = ViewGroup.GetChildAt(i);
            }
            //_clusterManager = new ClusterManager(this, _map);
            //_map.SetOnCameraChangeListener(_clusterManager);
            //_map.SetOnMarkerClickListener(_clusterManager);
        }
    }
}
