using JWT.API.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Web;

namespace JWT.API.Client.JWTAPICall
{
    public class EmployeeManager
    {
        public static List<Employee> GetAllEmp(string pstrTokenUser, ref string pistrerror, ref Employee employee)
        {
            pistrerror = string.Empty;
            List<Employee> employees = new List<Employee>();
            try
            {
                HttpClient client = new HttpClient();
                SslProtocols Tls12 = (SslProtocols)0x00000C00;
                SecurityProtocolType Tls11 = (SecurityProtocolType)Tls12;
                ServicePointManager.SecurityProtocol = Tls11;

                client.BaseAddress = new Uri(Constants.GetJWTToken_BaseUrl());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType_App_Json));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Scheme_Bearer, pstrTokenUser);

                var json = JsonConvert.SerializeObject(null);
                var content = new StringContent(json, System.Text.Encoding.UTF8, Constants.MediaType_App_Json);

                var res = client.PostAsync("api/Employee/GetAllEmp", content).Result;

                if (res.IsSuccessStatusCode & res.StatusCode == HttpStatusCode.OK)
                {
                    return employees = JsonConvert.DeserializeObject<List<Employee>>(res.Content.ReadAsStringAsync().Result);
                }
                if (!res.IsSuccessStatusCode)
                {
                    pistrerror = res.ReasonPhrase;
                    employee.employeeResponseError = new EmployeeResponseError()
                    {
                        ErrorMessage = res.ReasonPhrase
                    };
                }
            }
            catch (Exception ex)
            {
                pistrerror = ex.Message;
            }
            return employees;
        }

        public static Employee GetEmpBy(ref string pistrerror, Employee pemployee, string pstrTokenUser)
        {
            pistrerror = string.Empty;
            Employee employee = new Employee();
            try
            {
                HttpClient client = new HttpClient();
                SslProtocols Tls12 = (SslProtocols)0x00000C00;
                SecurityProtocolType Tls11 = (SecurityProtocolType)Tls12;
                ServicePointManager.SecurityProtocol = Tls11;

                client.BaseAddress = new Uri(Constants.GetJWTToken_BaseUrl());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType_App_Json));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Scheme_Bearer, pstrTokenUser);

                var json = JsonConvert.SerializeObject(pemployee);
                var content = new StringContent(json, System.Text.Encoding.UTF8, Constants.MediaType_App_Json);

                var res = client.PostAsync("api/Employee/GetEmpBy", content).Result;

                if (res.IsSuccessStatusCode)
                {
                    employee = JsonConvert.DeserializeObject<Employee>(res.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                pistrerror = ex.Message;
            }
            return employee;
        }

        public static int InsEmp(ref string pistrerror, Employee pemployee, string pstrTokenUser)
        {
            int result = 0;
            try
            {
                HttpClient client = new HttpClient();
                SslProtocols Tls12 = (SslProtocols)0x00000C00;
                SecurityProtocolType Tls11 = (SecurityProtocolType)Tls12;
                ServicePointManager.SecurityProtocol = Tls11;

                client.BaseAddress = new Uri(Constants.GetJWTToken_BaseUrl());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType_App_Json));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Scheme_Bearer, pstrTokenUser);

                var json = JsonConvert.SerializeObject(pemployee);
                var content = new StringContent(json, System.Text.Encoding.UTF8, Constants.MediaType_App_Json);

                var res = client.PostAsync("api/Employee/InsEmp", content).Result;

                if (res.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<int>(res.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                pistrerror = ex.Message;
            }
            return result;
        }

        public static int UpdEmp(ref string pistrerror, Employee pemployee, string pstrTokenUser)
        {
            int result = 0;
            try
            {
                HttpClient client = new HttpClient();
                SslProtocols Tls12 = (SslProtocols)0x00000C00;
                SecurityProtocolType Tls11 = (SecurityProtocolType)Tls12;
                ServicePointManager.SecurityProtocol = Tls11;

                client.BaseAddress = new Uri(Constants.GetJWTToken_BaseUrl());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType_App_Json));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Scheme_Bearer, pstrTokenUser);

                var json = JsonConvert.SerializeObject(pemployee);
                var content = new StringContent(json, System.Text.Encoding.UTF8, Constants.MediaType_App_Json);

                var res = client.PutAsync("api/Employee/UpdEmp", content).Result;

                if (res.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<int>(res.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                pistrerror = ex.Message;
            }
            return result;
        }

        public static int DelEmp(ref string pistrerror, int pintEmpId, string pstrTokenUser)
        {
            int result = 0;
            try
            {
                HttpClient client = new HttpClient();
                SslProtocols Tls12 = (SslProtocols)0x00000C00;
                SecurityProtocolType Tls11 = (SecurityProtocolType)Tls12;
                ServicePointManager.SecurityProtocol = Tls11;

                client.BaseAddress = new Uri(Constants.GetJWTToken_BaseUrl());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaType_App_Json));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Scheme_Bearer, pstrTokenUser);

                var json = JsonConvert.SerializeObject(null);
                var content = new StringContent(json, System.Text.Encoding.UTF8, Constants.MediaType_App_Json);

                var res = client.DeleteAsync("api/Employee/DelEmp?EmpId=" + pintEmpId).Result;

                if (res.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<int>(res.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                pistrerror = ex.Message;
            }
            return result;
        }
    }
}