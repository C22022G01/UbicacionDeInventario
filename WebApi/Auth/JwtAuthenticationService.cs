using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// agregar la siguiente libreria
using UbicacionDeInventario.EntidadesDeNegocio;
//************************************

namespace UbicacionDeInventario.WebAPI.Auth
{
    public interface UwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}

