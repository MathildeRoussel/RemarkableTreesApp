using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace RemarkableTreeApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();

            RemarkableTreeApp.LoadInitialJsonSourcesService.Instance = new LoadInitialJsonSourcesService();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
