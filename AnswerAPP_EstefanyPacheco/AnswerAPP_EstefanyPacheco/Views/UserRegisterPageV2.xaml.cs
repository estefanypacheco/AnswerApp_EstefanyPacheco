using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswerAPP_EstefanyPacheco.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswerAPP_EstefanyPacheco.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisterPageV2 : ContentPage
    {
        public UserRegisterPageV2()
        {
            InitializeComponent();

            BindingContext = new UserViewModelV2();


        }
    }
}