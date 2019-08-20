using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using NorthWindProdCat.Models;
namespace NorthWindProdCat.Models
{
    public class Db
    { 
        public SQLiteConnection BaseDatos;
        public Db()
        {
            string Conexion = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "northwind.db3");
            BaseDatos = new SQLiteConnection(Conexion);
            BaseDatos.CreateTable<Category>();
            BaseDatos.CreateTable<Products>();
        }

        ///INSERTAR
        public int InsertCategory(Category Category_)
        {
            return BaseDatos.Insert(Category_);
        }
        public int InsertProduct(Products Product_)
        {
            return BaseDatos.Insert(Product_);
        }

        ///LEER 1

        public Category ReadCategory(int IdCategory)
        {
            return BaseDatos.Table<Category>().Where(n => n.IdCategory == IdCategory).FirstOrDefault();
        }

        ///LEER TODOS

        public List<Category> ReadCategories()
        {
            return BaseDatos.Table<Category>().ToList();
        }

        ///LEER 1

        public Products ReadProduct(int IdProduct)
        {
            return BaseDatos.Table<Products>().Where(n => n.IdProduct == IdProduct).FirstOrDefault();
        }

        ///LEER TODOS

        public List<Products> ReadProducts()
        {
            return BaseDatos.Table<Products>().ToList();
        }

        public List<Products> ReadProductsByIdCategory(int idcategoria)
        {
            //            return BaseDatos.Table<Products>().ToList();
            return BaseDatos.Table<Products>().Where(n => n.IdCategory == idcategoria).ToList();
        }

        



    }
}
