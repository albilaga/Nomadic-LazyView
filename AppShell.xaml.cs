﻿using Nomadic.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nomadic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        public static void RegisterRoutes()
        {
            Routing.RegisterRoute("webpage", typeof(WebPage));
            Routing.RegisterRoute("interestarticles", typeof(InterestArticles));
            Routing.RegisterRoute("signout", typeof(SignOut));
            Routing.RegisterRoute("savedarticles", typeof(SavedArticles));
        }
    }
}