using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurante
{
   public class FacturaBL
    {
        Contexto _contexto;
        
        public BindingList<factura> Listafactura { get; set; }

        public FacturaBL()
        {
            _contexto = new Contexto();
        }

        public BindingList<factura> Obtenerfacturas()
        {

            _contexto.Facturas.Include("Facturadetalle").Load();
            Listafactura = _contexto.Facturas.Local.ToBindingList();

            return Listafactura;
        }

        public void Agregarfactura()
        {
            var Nuevafactura = new factura();
            _contexto.Facturas.Add(Nuevafactura);
            
        }

        public void Agregarfacturadetalle(factura factura)
        {
            if(factura != null)
            {
                var Nuevodetalle = new Facturadetalle();
                factura.Facturadetalle.Add(Nuevodetalle);
            }
        }

        public void Removerfacturadetalle(factura Factura, Facturadetalle facturadetalle)
        {
            if(Factura != null && facturadetalle != null)
            {
                Factura.Facturadetalle.Remove(facturadetalle);
            }
        }


        public void Cancelarcambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }  

        public Resultado Guardarfactura(factura factura)
        {
            var Resultado = Validar(factura);
            if(Resultado.Exitoso == false)
            {
                return Resultado;
            }

            Calcularexistencia(factura);

                    _contexto.SaveChanges();
            Resultado.Exitoso = true;
            return Resultado;

        }

        private void Calcularexistencia(factura factura)
        {
            foreach (var Detalle in factura.Facturadetalle)
            {
                var Orden = _contexto.Ordenes.Find(Detalle.OrdenId);
                if (Orden != null)
                {
                    if(factura.Activo == true)
                    {
                        Orden.existencia = Orden.existencia - Detalle.Cantidad;
                    }
                    else
                    {
                        Orden.existencia = Orden.existencia + Detalle.Cantidad;
                    }
                    
                }
            }
        }

        private Resultado Validar(factura factura)
        {
            var Resultado = new Resultado();
            Resultado.Exitoso = true;

            if(factura == null)
            {
                Resultado.Mensaje = "Agregue una factura para guardarla";
                Resultado.Exitoso = false;

                return Resultado;
            }

            if (factura.Id != 0 && factura.Activo == true)
            {
                Resultado.Mensaje = "La factura esta registrada, no se pueden realizar cambios";
                Resultado.Exitoso = false;
            }

            if (factura.Activo == false)
            {
                Resultado.Mensaje = "La factura esta anulada y no se pueden realizar cambios en ella";
                Resultado.Exitoso = false;
            }

            if(factura.Facturadetalle.Count == 0)
            {
                Resultado.Mensaje = "Agrege Ordenes a la factura";
                Resultado.Exitoso = false;
            }

            foreach (var detalle in factura.Facturadetalle)
            {
            if(detalle.OrdenId == 0)
                {
                    Resultado.Mensaje = "Seleccione Ordenes Validas";
                    Resultado.Exitoso = false;
                }
            }

            return Resultado;

        }

        public void Calcularfactura(factura Factura)
        {
            if(Factura != null)
            {
                double Subtotal = 0;

                foreach (var Detalle in Factura.Facturadetalle)
                {
                    var Orden = _contexto.Ordenes.Find(Detalle.OrdenId);
                    if(Orden != null)
                    {
                        Detalle.Precio = Orden.precio;
                        Detalle.Total = Detalle.Cantidad * Orden.precio;

                        Subtotal += Detalle.Total;
                    }
                }
                Factura.Subtotal = Subtotal;
                Factura.Impuesto = Subtotal * 0.15;
                Factura.Total = Subtotal + Factura.Impuesto;

                {

                }
            }
        }

        public bool Anularfactura(int Id)
        {
            foreach (var factura in Listafactura)
            {
                if(factura.Id == Id)
                {
                    factura.Activo = false;

                    Calcularexistencia(factura);

                    _contexto.SaveChanges();
                    return true;
                }
            }


            return false;
        }

    }

    public class factura
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public BindingList<Facturadetalle> Facturadetalle { get; set; }
        public Double Subtotal { get; set; }
        public Double Impuesto { get; set; }
        public Double Total { get; set; }
        public bool Activo { get; set; }

        public factura()
        {
            Fecha = DateTime.Now;
            Facturadetalle = new BindingList<Facturadetalle>();
            Activo = true;

        }
    }

    public class Facturadetalle
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public Orden orden { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public Double Total { get; set; }

        public Facturadetalle()
        {
            Cantidad = 1;
        }
    }
}
