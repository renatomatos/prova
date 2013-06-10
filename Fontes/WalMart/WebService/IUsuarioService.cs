using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        bool Add(Model.UsuarioModel data);

        [OperationContract]
        bool Update(Model.UsuarioModel data);

        [OperationContract]
        bool Delete(int codigo);

        [OperationContract]
        List<Model.UsuarioModel> List(int codigo);

        [OperationContract]
        List<Model.UsuarioModel> Find(string login);
    }
}
