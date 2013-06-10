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
    public class CidadeModel : IBaseModel
    {
        #region Campos

        private EstadoModel _Estado = null;

        #endregion Campos

        #region Construtor

        public CidadeModel() { }

        public CidadeModel(System.Data.SqlClient.SqlDataReader rd)
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
                this.Codigo = Utils.HelperDataReader.GetInteger(reader, "CD_CODIGO");
                this.Nome = Utils.HelperDataReader.GetString(reader, "CD_NOME");
                this.Capital = Utils.HelperDataReader.GetString(reader, "CD_CAPITAL").Equals("S");
                this.Estado.Bind(reader);
                this.EstadoCodigo = this.Estado.Codigo;
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeModel.Bind");
            }
        }

        #endregion Métodos

        [DisplayName("Código")]
        public int Codigo { get; set; }

        public EstadoModel Estado 
        {
            get
            {
                if (_Estado == null)
                {
                    _Estado = new EstadoModel();
                }
                return _Estado;
            }
        }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Informe um Estado")]
        public int EstadoCodigo { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe o conteúdo para o campo Nome")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "O campo deverá conter entre 1 e 60 caracteres")]
        public string Nome { get; set; }

        [DisplayName("Capital")]
        public Boolean Capital { get; set; }

    }
}