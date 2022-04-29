using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnswerAPP_EstefanyPacheco.Models;

namespace AnswerAPP_EstefanyPacheco.ViewModels
{
    public class UserViewModel: BaseViewModel
    {
        public User MyUser { get; set; }
        public Tools.Crypto MyCrypto { get; set; }  


        public UserViewModel()
        {
            MyUser = new User();

            MyCrypto = new Tools.Crypto();

           

            //TODO: Implementar los command posteriormente


        }

        //agregamos una funciona para AGREGAR el usuario
        public async Task<bool> AddUser
            ( string pUserName, 
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

              
                MyUser.UserName = pUserName;
                MyUser.FirstName = pFirstName;
                MyUser.LastName = pLastName;
                MyUser.PhoneNumber = pPhoneNumber;

                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pUserPassword);

                MyUser.UserPassword = EncriptedPassword;
                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.JobDescription = pJobDescription;
                MyUser.UserStatusId = pUserStatusId;
                MyUser.CountryId = pCountryId;
                MyUser.UserRoleId = pUserRoleId;

                MyUser.StrikeCount = 0;

                bool R = await MyUser.AddNewUser();

                return R;
            }
            catch (Exception)
            {
                return false;

               
            }
            finally
            { IsBusy = false;  }


        }

        //funcion para validar el permiso de acceso del usuario

        public async Task<bool> ValidateUserAccess(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);

                MyUser.UserName = pEmail;
                MyUser.UserPassword = EncriptedPassword;

                bool R = await MyUser.ValidateUserAccess();

                return R;
            }
            catch (Exception )
            {
                return false;
                
            }
            finally
            {
                IsBusy = false;
            }
        }


        public async Task<List<UserRole>> GetQList()
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    List<UserRole> list = new List<UserRole>();

                    list = await MyUser.UserRole.GetUserRolesList();

                    if (list == null)
                    {
                        return null;
                    }
                    else
                    {
                        return list;
                    }



                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    throw;
                }
            }


        }



       



    }
}
