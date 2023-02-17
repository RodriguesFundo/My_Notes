using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace My_Notes.Droid
{
    //Classe para saber onde esta armazenada a BD no celular
    public class MyNotesDBFile
    {
        public static string GetLocalFilePath(string filename) {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename); //Retorna o local onde esta armazenado a BD
        }
    }
}