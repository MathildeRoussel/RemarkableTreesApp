using System;
using CoreLocation;
using Foundation;
using MapKit;
using RemarkableTreeApp.Models;

namespace RemarkableTreeApp.iOS.Annotations
{
    public class RemarkableTree : MKPointAnnotation
    {
        public RemarkableTreeRoot TreeItem { get; }

        public RemarkableTree()
        {
        }

        public RemarkableTree(RemarkableTreeRoot tree)
        {
            Coordinate = new CLLocationCoordinate2D(((NSNumber)tree.geometry.coordinates[1]).NFloatValue, ((NSNumber)tree.geometry.coordinates[0]).NFloatValue);

            TreeItem = tree;

            this.Title = tree.fields?.libellefrancais;
            this.Subtitle = tree.fields?.espece;
        }
    }
}
