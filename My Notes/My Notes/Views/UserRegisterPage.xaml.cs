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

            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        
        }
    }
}