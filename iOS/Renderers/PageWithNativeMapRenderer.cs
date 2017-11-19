using System;
using System.Collections.Generic;
using System.Linq;
using MapKit;
using RemarkableTreeApp;
using RemarkableTreeApp.iOS.Annotations;
using RemarkableTreeApp.iOS.Helpers;
using RemarkableTreeApp.iOS.MapClassesExtensions;
using RemarkableTreeApp.iOS.Renderers;
using RemarkableTreeApp.Models;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RemarkableTreeAppPage), typeof(PageWithNativeMapRenderer))]
namespace RemarkableTreeApp.iOS.Renderers
{
    public class PageWithNativeMapRenderer : PageRenderer
    {
        private List<RemarkableTreeRoot> _trees;

        private MKMapView MapView => ViewHelper.FindInHierarchy<MKMapView>(NativeView);

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var customViewForms = (RemarkableTreeAppPage)e.NewElement;

                _trees = customViewForms.Trees;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var mapView = MapView;

            if (mapView == null)
                return;

            mapView.GetViewForAnnotation = GetViewForAnnotation;

            mapView.Register(typeof(RemarkableTreeView), "marker");
            mapView.Register(typeof(ClusterView), "cluster");

            mapView.AddAnnotations(FromTreesModelsToAnnotationsTrees(_trees));

            var button = MKUserTrackingButton.FromMapView(mapView);
            button.Layer.BackgroundColor = UIColor.FromRGBA(255, 255, 255, 80).CGColor;
            button.Layer.BorderColor = UIColor.White.CGColor;
            button.Layer.BorderWidth = 1;
            button.Layer.CornerRadius = 5;
            button.TranslatesAutoresizingMaskIntoConstraints = false;
            mapView.AddSubview(button);
        }

        private MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            if (annotation is RemarkableTree)
            {
                var marker = annotation as RemarkableTree;

                var view = mapView.DequeueReusableAnnotation(MKMapViewDefault.AnnotationViewReuseIdentifier) as RemarkableTreeView;
                if (view == null)
                {
                    view = new RemarkableTreeView(marker, MKMapViewDefault.AnnotationViewReuseIdentifier);
                }
                return view;
            }
            else if (annotation is MKClusterAnnotation)
            {
                var cluster = annotation as MKClusterAnnotation;

                var view = mapView.DequeueReusableAnnotation(MKMapViewDefault.ClusterAnnotationViewReuseIdentifier) as ClusterView;
                if (view == null)
                {
                    view = new ClusterView(cluster, MKMapViewDefault.ClusterAnnotationViewReuseIdentifier);
                }
                return view;
            }
            else if (annotation != null)
            {
                var unwrappedAnnotation = MKAnnotationWrapperExtensions.UnwrapClusterAnnotation(annotation);

                return GetViewForAnnotation(mapView, unwrappedAnnotation);
            }
            return null;
        }

        private RemarkableTree[] FromTreesModelsToAnnotationsTrees(List<RemarkableTreeRoot> trees)
        {
            return trees.Select(u => new RemarkableTree(u)).ToArray();
        }
    }
}
