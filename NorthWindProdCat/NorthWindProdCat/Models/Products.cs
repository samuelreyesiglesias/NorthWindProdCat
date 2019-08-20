using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NorthWindProdCat.Models
{
   
        [Table(nameof(Products))]
        public class Products: ClaseBase
        {
        
        private int IdProduct_;
        [PrimaryKey, AutoIncrement]
        public int IdProduct { get { return IdProduct_; } set { IdProduct_ = value; OnPropertyChanged(); } }

        private string NameProduct_;

        public string NameProduct
        {
            get { return NameProduct_; }
            set { NameProduct_ = value; OnPropertyChanged(); }
        }


        private int IdCategory_;

        public int IdCategory
        {
            get { return IdCategory_; }
            set { IdCategory_ = value; OnPropertyChanged(); }
        }
        
        }

    
}
