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
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(route: "registration", typeof(UserRegisterPage));
            Routing.RegisterRoute(route: "mainPage", typeof(MainPage));
            Routing.RegisterRoute(route: "createNote", typeof(CreateNotePage));
            Routing.RegisterRoute(route: "noteDetailPage", typeof(NoteDetailPage));
        }
    }
}