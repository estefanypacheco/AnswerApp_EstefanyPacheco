using AnswerAPP_EstefanyPacheco.ViewModels;
using AnswerAPP_EstefanyPacheco.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AnswerAPP_EstefanyPacheco
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
