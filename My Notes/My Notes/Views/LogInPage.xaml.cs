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
        
        }

        //Click da label para cadastro
        

        private async void btnEntrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                LoginViewModel loginViewModel = new LoginViewModel();
                //loginViewModel.ValidarLogin(txtEmail.Text, txtSenhas.Text);

                await Shell.Current.GoToAsync(state: "//login/mainPage");

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