using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace AnswerAPP_EstefanyPacheco.Models
{
    public partial class User
    {
        public RestRequest request { get; set; }

        string mimetype = "application/json";
        string contentType = "Content-Type";

        public User()
        {
            

            Answers = new HashSet<Answer>();
            Asks = new HashSet<Ask>();
            ChatReceivers = new HashSet<Chat>();
            ChatSenders = new HashSet<Chat>();
            Likes = new HashSet<Like>();
            UserRole = new UserRole();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public int StrikeCount { get; set; }
        public string BackUpEmail { get; set; }
        public string JobDescription { get; set; }
        public int UserStatusId { get; set; }
        public int CountryId { get; set; }
        public int UserRoleId { get; set; }

        public virtual Country Country { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Ask> Asks { get; set; }
        public virtual ICollection<Chat> ChatReceivers { get; set; }
        public virtual ICollection<Chat> ChatSenders { get; set; }
        public virtual ICollection<Like> Likes { get; set; }


        public async Task<bool> AddNewUser()
        {
            bool R = false;

            try
            {
                string FinalApiRoute = CnnToAPI.ProductiorRoute + "users";

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Post);

                string mimetype = "application/json";

                //agregar la info de seguridad, en este caso api key
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //serializar esta clase para pasala en el body
                string SerializedClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerializedClass, mimetype);
                
                //esto envia la consulta al api y recibe una respuesta que debemos leer
                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;



                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;
                }

            }   
            catch (Exception ex)
            {
                string wsg = ex.Message;
                throw;
            }

            return R;




        }

        public async Task<bool> ValidateUserAccess()
        {
            bool R = false;

            try
            {

                //Como esta ruta es un poco as compleja de consumr ya que lleva una funcion con nombre
                //ydemas dos parametso lo mas conveniente es formateralr a or aparte y luego adjuntarla a base URL
                //(CnnToAPI.ProductorRoute) para obtener la ruta completa
           
                string routeSufix = string.Format("Users/ValidateUserLogin?pEmail={0}&pPassword={1}",
                    this.UserName, this.UserPassword);
                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                //agregar la ingo de seguridad en este caso api key
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    R = true;

                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

            return R;

        }


    }
}
