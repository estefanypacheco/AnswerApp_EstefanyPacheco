using AnswerAPP_EstefanyPacheco.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        UserViewModel Vm;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = Vm = new UserViewModel();
            

        }

        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            if (SwSeePassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void CmdUserRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegisterPageV2());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool R = await Vm.ValidateUserAccess(TxtUserName.Text.Trim(), TxtPassword.Text.Trim());

            if (R)
            {
                //quitar este mensaje
                await DisplayAlert(":)", "Usuario correcto", "OK");

               await Navigation.PushAsync(new ActionsPage());


            }
            else
            {
                await DisplayAlert(":(", "Usuario o contraseña incorrectos", "OK");
                TxtPassword.Focus();
            }


        }
    }
}