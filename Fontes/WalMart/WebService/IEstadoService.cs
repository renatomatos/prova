using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WebService
{
    [ServiceContract]
    public interface IEstadoService
    {
        [OperationContract]
        bool Add(Model.EstadoModel data);

        [OperationContract]
        bool Update(Model.EstadoModel data);

        [OperationContract]
        bool Delete(int codigo);

        [OperationContract]
        List<Model.EstadoModel> List(int codigo);
    }
}
