using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace My_Notes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Actualizarlista();
        }

        public void Actualizarlista()
        {
            UserRegisterViewModel userRegisterViewModel = new UserRegisterViewModel(App.DBPath);
            var listaUser = userRegisterViewModel.ListarUsers().Select(x => x.Nome);
            var cores = new List<Color> { Color.Red, Color.Green, Color.Blue, Color.Purple, Color.Yellow };
            Random random = new Random();
            var stackLayout = new StackLayout();

            foreach (var nome in listaUser)
            {


                var corAleatoria = cores[random.Next(cores.Count)];
                var frame = new Frame()
                {
                    BackgroundColor = corAleatoria,
                    CornerRadius = 10,
                    Padding = new Thickness(10),
                    Margin = new Thickness(10, 5),
                    HasShadow=true,
                    VerticalOptions = LayoutOptions.Start

                };

                var label = new Label()
                {
                    Text = nome,
                    TextColor = Color.Black,
                    FontSize = 20
                };

                frame.Content = label;

                
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnFrameTapped;
                frame.GestureRecognizers.Add(tapGestureRecognizer);



                stackLayout.Children.Add(frame);
            }

            absolute.Children.Add(stackLayout,
                new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
        }

        //Evento para click dos frames
        private async void OnFrameTapped(object sender, EventArgs e)
        {
            var frame = (Frame)sender;
            var nome = ((Label)frame.Content).Text;

            await Shell.Current.GoToAsync($"//login/mainPage/userDetails?nome={nome}");
        }

        private void btnCriarNota_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(state: "//login/mainPage/createNote");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}
