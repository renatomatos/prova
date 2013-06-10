using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public interface IBaseModel
    {
        /// <summary>
        /// Todas as classes deverão implementar este método de Bind.
        /// Após a execução do reader a leitura do banco será feita mediante chamada
        /// a este método.
        /// </summary>
        /// <param name="reader"></param>
        void Bind(System.Data.SqlClient.SqlDataReader reader);
    }
}