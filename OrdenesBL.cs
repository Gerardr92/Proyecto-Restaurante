using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurante
{
   public class OrdenesBL
    {
        Contexto _contexto;
       public BindingList<Orden> ListaOrdenes { get; set; }


        public OrdenesBL()
        {
            _contexto = new Contexto();
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
            _contexto.SaveChanges();
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

            if(orden == null)
            {
                Resultado.Mensaje = "Ingrese una orden";
                Resultado.Exitoso = false;

                return Resultado;
            }


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

            if (orden.CategoriaID == 0)
            {
                Resultado.Mensaje = "Ingrese una categoria";
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
        public int CategoriaID { get; set; }
        public Categoria categoria { get; set; }
        public byte[] foto { get; set; }
        public bool activo { get; set; }
        public string observaciones { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
