using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NorthWindProdCat.Models;
using System.Collections;
using System.Collections.ObjectModel;

namespace NorthWindProdCat.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Insertar : ContentPage
	{
		public Insertar ()
		{
			InitializeComponent ();
		}
        ObservableCollection<Products> productos_ = new ObservableCollection<Products>();
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            Products Agregar = new Products();
            Agregar.NameProduct = ProductoEntry.Text;
            ProductoEntry.Text = "";
            productos_.Add(Agregar);
            Productos.ItemsSource = productos_;
            
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

            Db BASE_DATOS = new Db();

            Category NewCategory = new Category();
            NewCategory.NameCategory = CategoryEntry.Text;
            NewCategory.DescriptionCategory = DescripcionEntry.Text;
            
            int IdCategoria = BASE_DATOS.InsertCategory(NewCategory);
            if (IdCategoria != -1)
            {
                foreach(Products ProductoAInsertar in productos_)
                {
                    ProductoAInsertar.IdCategory = NewCategory.IdCategory;
                     BASE_DATOS.InsertProduct(ProductoAInsertar);
                    
                }

                Navigation.PushAsync(new Visualizar());
            }
            else{
                DisplayAlert("Error", "No insertado", "ok");
            }


        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Visualizar());
        }
    }
}