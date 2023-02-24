using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        
        public LogInPage()
        {
            InitializeComponent();
            //Limpar todas navegacoes anteriores, tornando assim uma nova pilha de navegacao
            if (Navigation.NavigationStack.Count > 0)
            {
                Navigation.RemovePage(Navigation.NavigationStack[0]);
            }

        }

        //Click da label para cadastro


        private async void btnEntrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                LoginViewModel loginViewModel = new LoginViewModel();
                bool loginValido = loginViewModel.ValidarLogin(txtEmail.Text, txtSenhas.Text);

                if (loginValido)
                {
                    await Shell.Current.GoToAsync(state: "//login/mainPage");
                }
                else
                {
                    await DisplayAlert("Erro", "E-mail ou senha inválidos.", "OK");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private async void OnLabelClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//login/registration");

            //UserRegisterPage userRegisterPage = new UserRegisterPage();
            ////LogInPage logInPage = new LogInPage();

            //App.Current.MainPage = userRegisterPage;
        }
    }
}