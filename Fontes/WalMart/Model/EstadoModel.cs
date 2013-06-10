using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    [DataContract(Namespace="")]
    public class EstadoModel : IBaseModel
    {
        #region Construtor

        public EstadoModel(){}

        public EstadoModel(System.Data.SqlClient.SqlDataReader rd)
            : this()
        {
            Bind(rd);
        }

        #endregion Construtor

        #region Métodos

        public void Bind(System.Data.SqlClient.SqlDataReader reader)
        {
            try
            {
                this.Codigo = Utils.HelperDataReader.GetInteger(reader, "UF_CODIGO");
                this.Pais = Utils.HelperDataReader.GetString(reader, "UF_PAIS");
                this.Nome = Utils.HelperDataReader.GetString(reader, "UF_NOME");
                this.Sigla = Utils.HelperDataReader.GetString(reader, "UF_SIGLA");
                this.Regiao = Utils.HelperDataReader.GetString(reader, "UF_REGIAO");
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoModel.Bind");
            }
        }

        #endregion Métodos

        #region Propriedades

        [DisplayName("Código")]
        [DataMember]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Informe uma país")]
        [DisplayName("País")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "O campo deverá conter entre 1 e 60 caracteres")]
        [DataMember]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Informe um nome")]
        [DisplayName("Nome")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "O campo deverá conter entre 1 e 60 caracteres")]
        [DataMember]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe uma sigla")]
        [DisplayName("Sigla")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo deverá conter exatamente 2 caracteres")]
        [DataMember]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Informe uma Região")]
        [DisplayName("Região")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "O campo deverá conter entre 1 e 60 caracteres")]
        [DataMember]
        public string Regiao { get; set; }

        #endregion Propriedades
    }
}