using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurante
{
    public class CategoriasBL
    {
        Contexto _contexto;

        public BindingList<Categoria> ListaCategorias { get; set;}

        public CategoriasBL()
        {
            _contexto = new Contexto();
            ListaCategorias = new BindingList<Categoria>();
        }

        public BindingList<Categoria> ObtenerCategorias()
        {
            _contexto.Categorias.Load();
            ListaCategorias = _contexto.Categorias.Local.ToBindingList();

            return ListaCategorias;
        }

    }

    public class Categoria
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}
