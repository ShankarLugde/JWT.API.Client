using JWT.API.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Web;
using System.Web.Configuration;

namespace JWT.API.Client.JWTAPICall
{
    public class TokenManager
    {
        public static Login GenerateTokenByUser(Login login)
        {
            Login Response = new Login();
            try
            {
                HttpClient client = new HttpClient();

                SslProtocols Tls12 = (SslProtocols)0x00000C00;
                SecurityProtocolType Tls11 = (SecurityProtocolType)Tls12;
                ServicePointManager.SecurityProtocol = Tls11;

                client.BaseAddress = new Uri(Constants.GetJWTToken_BaseUrl());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType_App_Json));

                var json = JsonConvert.SerializeObject(login);
                var content = new StringContent(json, System.Text.Encoding.UTF8, Constants.MediaType_App_Json);

                var res = client.PostAsync("api/Login/GenerateTokenByUser", content).Result;

                if (res.IsSuccessStatusCode)
                {
                    Response = JsonConvert.DeserializeObject<Login>(res.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Response;
        }
    }
}