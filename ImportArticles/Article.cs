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
        public string CodigoSat { get; set; }
        public string UnidadMedida { get; set;}
        public string Inventariable { get; set; }

        public Article(string ID, string Description, string Marca, decimal PrecioVenta, decimal PrecioLista, decimal Descuento, string Proyecto, string CodigoSat, string UnidadMedida, string Inventariable)
        {
            this.ID = ID;
            this.Description = Description;
            this.Marca = Marca;
            this.PrecioVenta = PrecioVenta;
            this.PrecioLista = PrecioLista;
            this.Descuento = Descuento;
            this.Proyecto = Proyecto;
            this.CodigoSat = CodigoSat;
            this.UnidadMedida = UnidadMedida;
            this.Inventariable = Inventariable;
        }
    }
}
