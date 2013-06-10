using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    [ServiceContract]
    public interface ICidadeService
    {
        [OperationContract]
        bool Add(Model.CidadeModel data);

        [OperationContract]
        bool Update(Model.CidadeModel data);

        [OperationContract]
        bool Delete(int codigo);

        [OperationContract]
        List<Model.CidadeModel> List(int codigo);
    }
}
