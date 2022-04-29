using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace AnswerAPP_EstefanyPacheco.Models
{
    public partial class UserRole
    {
        public RestRequest request { get; set; }

        string mimetype = "application/json";
        string contentType = "Content-Type";

        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string UserRole1 { get; set; }

        //aparenta no usarlo
        //public bool IsUserSelectable {get; set;}

        public virtual ICollection<User> Users { get; set; }

        public async Task<List<UserRole>> GetUserRolesList()
        {
            try
            {
                string routeSufix = string.Format("UserRoles/GetUserRolesList");
                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var Qlist = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);

                if (statusCode == HttpStatusCode.OK)
                {
                    return Qlist;
                }
                else
                {
                    return null;
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
