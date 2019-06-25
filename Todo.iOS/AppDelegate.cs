﻿using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Shiny;


namespace Todo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            iOSShinyHost.Init(new ShinyStartup());
            Forms.Init();
            this.LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }


        [Export("application:performFetchWithCompletionHandler:")]
        public void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        {
            Shiny.Jobs.JobManager.OnBackgroundFetch(completionHandler);
        }
    }
}
