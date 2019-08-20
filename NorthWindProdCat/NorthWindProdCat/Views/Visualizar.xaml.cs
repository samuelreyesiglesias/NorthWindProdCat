using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NorthWindProdCat.Models;
using NorthWindProdCat.Views;
using System.Collections.ObjectModel;
namespace NorthWindProdCat.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Visualizar : ContentPage
	{
        Db BASE_DATOS = new Db();
        public Visualizar ()
		{
			InitializeComponent ();
           
            List<Category> categorias = new List<Category>();  ;
            categorias = BASE_DATOS.ReadCategories();
            Category__.ItemsSource = categorias;


        }

        private void Category___ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Category categoriaelegida = new Category();
            categoriaelegida = (Category)e.SelectedItem;
            int idcategoria = categoriaelegida.IdCategory;
            //DisplayAlert("", idcategoria.ToString(), "ok");
            List<Products> productosAMostrar =new List<Products>();
            productosAMostrar= BASE_DATOS.ReadProductsByIdCategory(idcategoria);


            Productos_ListView.ItemsSource = productosAMostrar;

            Category__.IsVisible = false;
            Productos_ListView.IsVisible = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Category__.IsVisible = true;
            Productos_ListView.IsVisible = false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }
    }
}