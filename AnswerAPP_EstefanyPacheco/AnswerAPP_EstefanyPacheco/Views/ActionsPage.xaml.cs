using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswerAPP_EstefanyPacheco.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionsPage : ContentPage
    {
        public ActionsPage()
        {
            InitializeComponent();
        }

        private async void BtnViewMyQuestions_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyQuestionsPage());

        }
    }
}