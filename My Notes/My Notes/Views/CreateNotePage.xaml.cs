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
    public partial class CreateNotePage : ContentPage
    {
        public CreateNotePage()
        {
            InitializeComponent();
        }

        //Tocando no frame que contem o entry, ira dar foco no respectivo entry, nao se limitando no clique do proprio entry
        //--------------{
        private void frameTitulo_Tapped(object sender, EventArgs e) { txtTitulo.Focus(); }
        private void frameDescricao_Tapped(object sender, EventArgs e) { txtDescricao.Focus(); }
        private void frameTag_Tapped(object sender, EventArgs e) { txtTag.Focus(); }
        private void frameLink_Tapped(object sender, EventArgs e) { txtLink.Focus(); }
        //-------------------- }

        //Guardar as notas do usuario e voltar automaticamente a pagina princial
        private async void btnGuardarNota_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Guardada", txtTitulo.Text, "Ok");
            //Navigation.PushAsync()


        }
    }
}   