using System;
using System.Collections.Generic;
using System.Text;

namespace AnswerAPP_EstefanyPacheco
{
    public static class CnnToAPI
    {

        //en esta clase estatica avmos a almacenar la info de configuracion de consumo del API
        //En pruebas normalmente se usa una ruta distinta que en produccion

        public static string ProductiorRoute = "http://192.168.100.11:45455/api/";
        public static string TestingRoute = "http://192.168.100.11:45455/api/";

        //TODO: Agregar la funcionalidad para JWT.

        //El api key acá es util ya que el usuario antes de registrarse podría usarlo, ya una vez
        //registrado puede usar JWT.

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "qwerty1234ABC";

    }
}
