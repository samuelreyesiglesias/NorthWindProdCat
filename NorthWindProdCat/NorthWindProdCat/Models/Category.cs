using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace NorthWindProdCat.Models
{

    [Table(nameof(Category))]
    public class Category
    {
        [PrimaryKey,AutoIncrement]
        public int IdCategory { get; set; }
        public string NameCategory { get; set; }
        public string DescriptionCategory { get; set; }
    }
}
