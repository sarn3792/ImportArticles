using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArticles
{
    public class Article
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Marca { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioLista { get; set; }
        public decimal Descuento { get; set; }
        public string Proyecto { get; set; }

        public Article(string ID, string Description, string Marca, decimal PrecioVenta, decimal PrecioLista, decimal Descuento, string Proyecto)
        {
            this.ID = ID;
            this.Description = Description;
            this.Marca = Marca;
            this.PrecioVenta = PrecioVenta;
            this.PrecioLista = PrecioLista;
            this.Descuento = Descuento;
            this.Proyecto = Proyecto;
        }
    }
}
