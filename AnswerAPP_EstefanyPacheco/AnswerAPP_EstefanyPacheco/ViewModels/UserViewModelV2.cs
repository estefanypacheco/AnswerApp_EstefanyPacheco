using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using AnswerAPP_EstefanyPacheco.Models;
using AnswerAPP_EstefanyPacheco.Tools;

namespace AnswerAPP_EstefanyPacheco.ViewModels
{
    public class UserViewModelV2 : BaseViewModel
    {
        //a diferencia del primer view model v1 para usaurio, este será adecuado para
        //realizar el binding a cada control en la vista

        //con respecto a las propiedades debemos usar el formato FULL PROP
        //ya que debemos implementar OnPropertyChange (cuya funcionalidad se hereda
        //de BaseViewModel 

        //El binding entre los controles de la vista y las proiedades del viewmodel
        //ocurren en "tiempo real" al modificar los datos en la vista
        //para que esto ocurra debemos implementar OnPropChange en el get; o en el set;
        //de la propiedad.

        private string nombreDeUsuario;
        private string nombre;
        private string apellidos;
        private string numeroTelefonico;
        private string contrasena;
        private string segundoCorreo;
        private string descripcionEmpleo;
        // private int idEstadoUsuario;
        // private int idPais;
        private int idRolUsuario;
        //public User MyUser { get; set; }
        public Tools.Crypto MyCrypto { get; set; }


        public User MiUsuario { get; set; }



        public string NombreDeUsuario 
        {


            get { return nombreDeUsuario; }
            set {

                if (nombreDeUsuario == value)
                {

                    return;
                }
                
                nombreDeUsuario = value;

                OnPropertyChanged(nameof(NombreDeUsuario));
            
            
            }

        }
        //
        public string Nombre
        {


            get { return nombre; }
            set
            {

                if (nombre == value)
                {

                    return;
                }

                nombre = value;

                OnPropertyChanged(nameof(Nombre));


            }

        }

        public string Apellidos
        {


            get { return apellidos; }
            set
            {

                if (apellidos == value)
                {

                    return;
                }

                apellidos = value;

                OnPropertyChanged(nameof(Apellidos));


            }

        }

        public string NumeroTelefonico
        {


            get { return numeroTelefonico; }
            set
            {

                if (numeroTelefonico == value)
                {

                    return;
                }

                numeroTelefonico = value;

                OnPropertyChanged(nameof(NumeroTelefonico));


            }

        }

        public string Contrasena
        {


            get { return contrasena; }
            set
            {

                if (contrasena == value)
                {

                    return;
                }

                contrasena = value;

                OnPropertyChanged(nameof(Contrasena));


            }

        }

       

        public string SegundoCorreo
        {


            get { return segundoCorreo; }
            set
            {

                if (segundoCorreo == value)
                {

                    return;
                }

                segundoCorreo = value;

                OnPropertyChanged(nameof(SegundoCorreo));


            }

        }

        public string DescripcionEmpleo
        {


            get { return descripcionEmpleo; }
            set
            {

                if (descripcionEmpleo == value)
                {

                    return;
                }

                descripcionEmpleo = value;

                OnPropertyChanged(nameof(DescripcionEmpleo));


            }

        }

        public int IdRolUsuario
        {


            get { return IdRolUsuario; }
            set
            {

                if (idRolUsuario == value)
                {

                    return;
                }

                IdRolUsuario = value;

                OnPropertyChanged(nameof(IdRolUsuario));


            }

        }

        

        Crypto MiEnccriptador { get; set; }

        //A diferencia del vw original, acá definimos las acciones por medio de command(s)
        //Si la funcionalidad es muy compleja y requiere de un manejo más detallado
        //igual se puede usar cmo lo vimos en el vm original
        public Command AgregarUsuarioCommand { get; }

        public UserViewModelV2()
        {
            MiUsuario = new User();
            MiEnccriptador = new Tools.Crypto();

            //implementacion de los Command
            AgregarUsuarioCommand = new Command(async () => await AgregarUsuario(NombreDeUsuario, Nombre,
                Apellidos, NumeroTelefonico, Contrasena, SegundoCorreo, DescripcionEmpleo, 1, 1, 1) );



        }

    //escribimos las funciones de forma similar (sino identifica)
    public async Task<bool> AgregarUsuario
        (string pUserName,
        string pFirstName,
        string pLastName,
        string pPhoneNumber,
        string pUserPassword,
        string pBackUpEmail,
        string pJobDescription,
        int pUserStatusId = 1,
        int pCountryId = 1,
        int pUserRoleId = 1)
    {

        if (IsBusy) return false;
        IsBusy = true;

            try
            {


                MiUsuario.UserName = pUserName;
                MiUsuario.FirstName = pFirstName;
                MiUsuario.LastName = pLastName;
                MiUsuario.PhoneNumber = pPhoneNumber;

                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pUserPassword);

                MiUsuario.UserPassword = EncriptedPassword;
                MiUsuario.BackUpEmail = pBackUpEmail;
                MiUsuario.JobDescription = pJobDescription;
                MiUsuario.UserStatusId = pUserStatusId;
                MiUsuario.CountryId = pCountryId;
                MiUsuario.UserRoleId = pUserRoleId;


                //este obt compuesto es funcional para la carga 
                MiUsuario.UserRole = null;

                //miusuario.userrole.userrodeid = puserroleid
                //opcional
                //musuario.userrole.userrole1 = "role"

            MiUsuario.StrikeCount = 0;

            bool R = await MiUsuario.AddNewUser();

            return R;
        }
        catch (Exception)
        {
            return false;


        }
        finally
        { IsBusy = false; }


    }





}
}
