using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnswerAPP_EstefanyPacheco.ViewModels;

namespace AnswerAPP_EstefanyPacheco.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyQuestionsPage : ContentPage
    {
        AskViewModel askViewModel;


        public MyQuestionsPage()
        {
            InitializeComponent();

            BindingContext = askViewModel = new AskViewModel();
            //to do hasta no tener usuario global vamos a tener que quemar el id de usaurio
            //en mi caso es el id 1002

            askViewModel.MyQuestion.UserId = 1002;

            LoadList();


        }


        private async void LoadList()
        {
            LstMyQuestions.ItemsSource = await askViewModel.GetQList();
        }
    }
}