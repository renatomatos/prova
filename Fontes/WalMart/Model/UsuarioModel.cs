using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Security;

namespace Model
{
    [Serializable]
    public class UsuarioModel : IBaseModel
    {
        #region Construtor

        public UsuarioModel()
        { 
        
        }

        public UsuarioModel(System.Data.SqlClient.SqlDataReader rd) : this()
        {
            Bind(rd);
        }

        #endregion Construtor

        #region Métodos

        public void Bind(System.Data.SqlClient.SqlDataReader reader)
        {
            try
            {
                this.Id = Utils.HelperDataReader.GetInteger(reader, "US_ID");
                this.Login = Utils.HelperDataReader.GetString(reader, "US_LOGIN");
                this.Nome = Utils.HelperDataReader.GetString(reader, "US_NOME");
                this.Senha = Utils.HelperDataReader.GetString(reader, "US_SENHA");
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioModel.Bind");
            }
        }

        #endregion Métidos

        #region Propriedades

        [DisplayName("Código")]
        public int Id { get; set; }

        [Required(ErrorMessage="Informe um login")]
        [DisplayName("Login")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "O nome deverá conter entre 6 e 60 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe um nome")]
        [DisplayName("Nome")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "O nome deverá conter entre 6 e 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Informe uma senha")]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "A senha deverá conter exatamente 8 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Favor confirmar a senha")]
        [DisplayName("Confirmar senha")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "A senha deverá conter exatamente 8 caracteres")]
        public string SenhaConfirmacao { get; set; }

        #endregion Propriedades
    }

    [Serializable]
    public class LoginModel
    {
        [Required(ErrorMessage="O campo usuário deverá ser informado")]
        [DisplayName("Usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage="O campo senha deverá ser informado")]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }

    #region Autenticação
    public interface ICustomFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class CustomFormsAuthenticationService : ICustomFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Informe um usuário.", "userName");

            SessionContextModel.UserName = userName;

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            SessionContextModel.Clear();
            FormsAuthentication.SignOut();
        }
    }
    #endregion Autenticação

}