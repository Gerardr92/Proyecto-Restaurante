using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurante
{
   public class AgOrdenesBL
    {
       public BindingList<Orden> ListaOrdenes { get; set; }


        public AgOrdenesBL()
        {
            ListaOrdenes = new BindingList<Orden>();

            var Orden1 = new Orden();
            Orden1.id = 001;
            Orden1.descripcion = "Hamburguesa Clasica";
            Orden1.precio = 120.00;
            Orden1.existencia = 50;
            Orden1.activo = true;

            ListaOrdenes.Add(Orden1);

            var Orden2 = new Orden();
            Orden2.id = 002;
            Orden2.descripcion = "Alitas BBQ";
            Orden2.precio = 120.00;
            Orden2.existencia = 100;
            Orden2.activo = true;

            ListaOrdenes.Add(Orden2);

            var Orden3 = new Orden();
            Orden3.id = 003;
            Orden3.descripcion = "Arroz Frito ";
            Orden3.precio = 140.00;
            Orden3.existencia = 30;
            Orden3.activo = true;

            ListaOrdenes.Add(Orden3);

        }

        public BindingList<Orden> ObtenerOrdenes()
        {
            return ListaOrdenes;
        }
    }

    public class Orden
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int existencia { get; set; }
        public bool activo { get; set; }
    }
}
