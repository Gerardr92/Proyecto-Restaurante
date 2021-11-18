using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurante
{
    public class SeguridadBL
    {
        public bool login(string usuario, string contrasena)
        {
            if (usuario == "admin1" && contrasena == "1234")
            {
                return true;
            }
            else
            if (usuario == "admin2" && contrasena == "1234")
            {
                return true;
            }
            return false;
        }

        public object login(object usuario, object contrasena)
        {
            throw new NotImplementedException();
        }
    }
}
