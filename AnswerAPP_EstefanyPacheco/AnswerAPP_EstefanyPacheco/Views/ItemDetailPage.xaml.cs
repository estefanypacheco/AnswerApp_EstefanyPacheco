using AnswerAPP_EstefanyPacheco.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AnswerAPP_EstefanyPacheco.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}