using My_Notes.Models;
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
    public partial class UserRegisterPage : ContentPage
    {
        public UserRegisterPage()
        {
            InitializeComponent();
        }

        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync(state: "//login");

            try
            {
                User user = new User();
                user.Nome = txtNome.Text;
                user.Email = txtEmail.Text;
                user.Password = txtSenha.Text;
                user.DataDeCriacao = DateTime.Now;
                user.DataDeActualizacao = DateTime.Now;

                UserRegisterViewModel userRegisterViewModel = new UserRegisterViewModel(App.DBPath);
                if (await userRegisterViewModel.EmailJaExiste(user.Email))
                {
                    await DisplayAlert("", "Email ja existe", "OK");
                }
                else
                {
                    await userRegisterViewModel.InserirUser(user);
                    await DisplayAlert(user.Nome, user.Email, "OK");
                    await Shell.Current.Navigation.PopAsync();
                }



            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        
        }

        //Tocando no frame que contem o entry, ira dar foco no respectivo entry, nao se limitando no clique do proprio entry
        //--------------{
        private void frameNome_Tapped(object sender, EventArgs e){ txtNome.Focus(); }
        private void frameEmail_Tapped(object sender, EventArgs e){ txtEmail.Focus(); }

        private void frameSenha_Tapped(object sender, EventArgs e){ txtSenha.Focus(); }
        //-------------------}
       
    }
}