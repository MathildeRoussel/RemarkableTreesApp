using System.Collections.Generic;
using RemarkableTreeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RemarkableTreeApp
{
    public partial class RemarkableTreeAppPage : ContentPage
    {
        public List<RemarkableTreeRoot> Trees { get; private set; }

        public RemarkableTreeAppPage()
        {
            InitializeComponent();

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(48.8566, 2.3522), Distance.FromMiles(5)));

            Trees = LoadInitialJsonSourcesService.Instance.Init<List<RemarkableTreeRoot>>("arbresremarquablesparis2011.json");

            MyMap.Trees = Trees;
        }
    }
}
