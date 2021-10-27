using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurante
{
   public class AgOrdenesBL
    {
        Contexto _contexto;
       public BindingList<Orden> ListaOrdenes { get; set; }


        public AgOrdenesBL()
        {
            _contexto = new Restaurante.Contexto();
            ListaOrdenes = new BindingList<Orden>();

            
        }

        public BindingList<Orden> ObtenerOrdenes()
        {
            _contexto.Ordenes.Load();
            ListaOrdenes = _contexto.Ordenes.Local.ToBindingList();
            return ListaOrdenes;
        }

        public Resultado GuardarOrden(Orden orden)
        {

            var resultado = Validar(orden);
                if(resultado.Exitoso == false)
            {
                return resultado;
            }
            if (orden.id == 0)
            {
                orden.id = ListaOrdenes.Max(item => item.id) + 1;
            }
            resultado.Exitoso = true;
            return resultado;
        }

        public void agregarOrden()
        {
            var nuevaOrden = new Orden();

            ListaOrdenes.Add(nuevaOrden);
        }
        
        public bool eliminarOrden(int id)
        {
            foreach (var item in ListaOrdenes)
            {
                if(item.id == id)
                {
                    ListaOrdenes.Remove(item);
                    return true;
                }
            }
            return false;

        }

        private Resultado Validar(Orden orden)
        {
            var Resultado = new Resultado();
            Resultado.Exitoso = true;

            if (string.IsNullOrEmpty(orden.descripcion) == true)
            {
                Resultado.Mensaje = "Ingrese una descripcion";
                Resultado.Exitoso = false;
            }

            if (orden.existencia < 0)
            {
                Resultado.Mensaje = "La existencia debe ser mayor a cero";
                Resultado.Exitoso = false;
            }

            if (orden.precio < 0)
            {
                Resultado.Mensaje = "El precio debe ser mayor a cero";
                Resultado.Exitoso = false;
            }


            return Resultado;

        }
    }

    public class Orden
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int existencia { get; set; }
        public bool activo { get; set; }
        public string observaciones { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
