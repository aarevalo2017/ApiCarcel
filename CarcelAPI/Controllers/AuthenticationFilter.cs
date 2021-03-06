﻿using CarcelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CarcelAPI.Controllers
{
    public class AuthenticationFilter : AuthorizeAttribute
    {
        private CarcelDBContext context = new CarcelDBContext();
        /*
         * 
         * Este metodo se ejecutará antes de las peticiones a la api y verificara si el token existe y si es valido
         */
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string AccessTokenFromRequest = "";
            if (actionContext.Request.Headers.Authorization != null)
            {
                //obtenemos el token de acceso
                AccessTokenFromRequest = actionContext.Request.Headers.Authorization.Parameter;
                //verificamos que el token enviado este en la base de datos
                if (context.Usuarios.Where(u => u.Token == AccessTokenFromRequest).Count() > 0)
                {
                    // si existe el token retornamos true, y la peticion podrá continuar
                    return true;
                }
            }
            //si el token no existe se denegara el acceso a la apliacion
            return false;
        }
    }
}