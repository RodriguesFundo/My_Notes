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
            
            var cores = new List<Color> { Color.FromHex("#FF9E9E"), Color.FromHex("#91F48F"), Color.FromHex("#FFF599"), Color.FromHex("#9EFFFF"), Color.FromHex("#B69CFF") };
            Random random = new Random();
            
            var stackLayout = new StackLayout();

            foreach (var nome in listaUser)
            {

                var corAleatoria = cores[random.Next(cores.Count)];
                var frame = new Frame()
                {
                    BackgroundColor = corAleatoria,
                    CornerRadius = 10,
                    Padding = new Thickness(27),
                    Margin = new Thickness(10, 7),
                    HasShadow=true,
                    VerticalOptions = LayoutOptions.Start

                };

                var label = new Label()
                {
                    Text = nome,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 25
                };

                frame.Content = label;

                //Click dos frames
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnFrameTapped;
                frame.GestureRecognizers.Add(tapGestureRecognizer);



                stackLayout.Children.Add(frame);
            }
            Button button = new Button()
            {

                Text = "+",
                BackgroundColor=Color.FromHex("#736D6D"),
                WidthRequest = 50,
                HeightRequest = 50,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 50,
                Margin = 50
            };
            button.Clicked += button_Clicked;
            //            stackLayout.Children.Add(button);

            var scrollView = new ScrollView();
            scrollView.Content = stackLayout;

            absolute.Children.Add(scrollView,
                new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(1, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


            absolute.Children.Add(button);
        }

        //Clique do botao para abrir pagiba para adicinar notas
        private void button_Clicked(object sender, EventArgs e) { Shell.Current.GoToAsync(state: "//login/mainPage/createNote"); }


        //Evento para click dos frames que contem as notas
        private async void OnFrameTapped(object sender, EventArgs e)
        {
            var frame = (Frame)sender;
            var nome = ((Label)frame.Content).Text;

            //Abrir uma nova pagina com os dados do titulo clicado
            await Shell.Current.GoToAsync($"//login/mainPage/noteDetailPage?nome={nome}");
        }

            
        


    }
}
