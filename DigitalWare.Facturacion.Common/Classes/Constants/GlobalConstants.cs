using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.Constants
{
    public class GlobalConstants
    {
        #region Messages

        public const string ERROR_BASE_MODEL_ONLY_ONE_KEY = "El objeto tiene mas de 1 llave primaria. Lo cual no permite la automatización de BaseModel en el Update";

        public const string ERROR_BASE_MODEL_PRIMARY_KEY = "El objeto no tiene llave primaria. Lo cual no permite la automatización de BaseModel en el Update";

        public const string OPERATION_PROCESS_OK = "Operación Elaborada Con Éxito";

        #endregion
    }
}
