using Firebase.Auth;
using FireSharp;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using MinimalApiSample.Models;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Packaging.Licenses;
using Swashbuckle.AspNetCore.SwaggerGen;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MinimalApiSample.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireBaseAuthController : ControllerBase
    {
        FirebaseAuthProvider auth;
        IFirebaseConfig config;
        IFirebaseClient client;
        // IFirebaseConfig config = new FirebaseConfig();
        private  string urlData = "https://aspcorefirebase-8ffd4-default-rtdb.firebaseio.com/";
        private readonly string KeyData = "jBVHtF9OcMjGiZOeBnL8mvYHoPT7rbXPcn0wQCDo";
        public FireBaseAuthController()
        {
            auth = new FirebaseAuthProvider(
                            new FirebaseConfig("AIzaSyAycq852cyeW_NLhfLOuSe7ligMzWH_px0"));

            config  = new FireSharp.Config.FirebaseConfig
            {
                BasePath= urlData,
                AuthSecret= KeyData

            };

            client = new FireSharp.FirebaseClient(config);

        }
        [HttpPost]
        [Route("RegisterByEmailPassworld")]
        public async Task<ActionResult<FireBaseModel>> RegisterByEmailPass(FireBaseModel loginModel)
        {
            try
            {
                //create the user
                await auth.CreateUserWithEmailAndPasswordAsync(loginModel.UserEmail, loginModel.Password);
                //log in the new user
                var fbAuthLink = await auth
                                .SignInWithEmailAndPasswordAsync(loginModel.UserEmail, loginModel.Password);

                string token = fbAuthLink.FirebaseToken;
                //saving the token in a session variable
                if (token != null)
                {
                    // HttpContext.Session.SetString("_UserToken", token);

                    return new FireBaseModel 
                    {
                        UserEmail = loginModel.UserEmail,
                        TokenFire = token,
                    };
                }
            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseError>(ex.ResponseData);
                ModelState.AddModelError(string.Empty, firebaseEx.error.message);
                return loginModel;

            }
            return loginModel;


        }

        [HttpPost]
        [Route("LoginByEmailPassworld")]
        public async Task<ActionResult<FireBaseModel>> LoginByEmailPass(FireBaseModel loginModel)
        {
            try
            {
                
                //log in the new user
                var fbAuthLink = await auth
                                .SignInWithEmailAndPasswordAsync(loginModel.UserEmail, loginModel.Password);

                string token = fbAuthLink.FirebaseToken;
                //saving the token in a session variable
                if (token != null)
                {
                    // HttpContext.Session.SetString("_UserToken", token);

                    return new FireBaseModel
                    {
                        UserEmail=  loginModel.UserEmail,
                        TokenFire = token,
                    };
                }
            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseError>(ex.ResponseData);
                ModelState.AddModelError(string.Empty, firebaseEx.error.message);
                return loginModel;

            }
            return loginModel;


        }

        [HttpGet]
        [Route("GetFireBaseData")]
        public async Task<ActionResult<List<DataFireBase>>> GEetDataFireBase()
        {
            return await GetData();

        }


        [HttpGet]
        [Route("GetFireBaseDataById")]
        public async Task<ActionResult<DataFireBase>> GetFireBaseDataById(Guid id)
        {

           var  List =  await GetData();

            if (List != null) {
                var dato = List.Value.Where(x => x.Id == id).First();
                return dato;

            }
            
            return new DataFireBase(){ };
        }

        [HttpPost]
        [Route("AddDataFireBase")]
        public async Task<ActionResult<DataFireBase>> AddDataFireBase(DataFireBase loginModel)
        {
            loginModel.Id = Guid.NewGuid();
            var response = await client.PushAsync("JsonUsers/", loginModel);
            return loginModel;

        }
        private async Task<ActionResult<List<DataFireBase>>>  GetData() {
            // var response = await client.GetAsync("JsonUsers/");
            FirebaseResponse response = await client.GetAsync("JsonUsers/");
            Dictionary<string, DataFireBase> mList = new Dictionary<string, DataFireBase>();
            List<DataFireBase> list = new List<DataFireBase>();
            mList = JsonConvert.DeserializeObject<Dictionary<string, DataFireBase>>(response.Body);

            foreach (KeyValuePair<string, DataFireBase> entry in mList)
            {
                list.Add(new DataFireBase()
                {
                    Id = entry.Value.Id,
                    Username = entry.Value.Username,
                    Email = entry.Value.Email,
                });
            }
            return list;
        }

        [HttpDelete]
        [Route("DeleteFireBaseData")]
        public async Task<ActionResult<DataFireBase>> DeleteFireBaseData(Guid id)
        {
            DataFireBase dato = new DataFireBase();



            var response = await client.DeleteAsync("JsonUser/" + id.ToString());

            return dato;
        }

    }
}
