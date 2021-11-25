using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurante
{
    public class Datosdeinicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {

            var usuarioAdmin = new SeguridadBL.usuario();
            usuarioAdmin.Nombre = "admin1";
            usuarioAdmin.Contrasena = "1234";

            contexto.Usuarios.Add(usuarioAdmin);


            var categoria1 = new Categoria();
            categoria1.Descripcion = "Entradas";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Plato fuerte";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Snacks";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Bebidas";
            contexto.Categorias.Add(categoria4);

            var categoria5 = new Categoria();
            categoria5.Descripcion = "Postres";
            contexto.Categorias.Add(categoria5);

            base.Seed(contexto);
        }
    }
}
