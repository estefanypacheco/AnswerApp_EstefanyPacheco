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
    public partial class UserRegisterPage : ContentPage
    {
        UserViewModel viewModel;

         

        public UserRegisterPage()
        {
            InitializeComponent();

            //estamos anclando la vista con el view model respectivo
            BindingContext = viewModel = new UserViewModel();

            LoadRoles();
        }

        private async void LoadRoles()
        {
            CboUserRole.ItemsSource = await viewModel.GetQList();
        }


        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            if (SwSeePassword.IsToggled)
            {
                TxtPass.IsPassword = false;
            }
            else
            {
                TxtPass.IsPassword = true;
            }
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {


            //todo: se deben validar datos minimos, estrucutra del email, complejidad de contraseña
            bool R = await viewModel.AddUser(TxtEmail.Text.Trim(),
                TxtName.Text.Trim(),
                TxtLastName.Text.Trim(),
                TxtPhone.Text.Trim(),
                TxtPass.Text.Trim(),
                TxtBackUpEmail.Text.Trim(),
                TxtJob.Text.Trim());

            if (R)
            {
                await DisplayAlert("!!", "The User was added", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong!", "OK");
              //  await Navigation.PopAsync();
            }


        }
    }
}