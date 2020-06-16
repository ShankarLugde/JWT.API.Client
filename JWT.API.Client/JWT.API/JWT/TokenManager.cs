using JWT.API.ADOHelper;
using JWT.API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace JWT.API.JWT
{
    public class TokenManager
    {
        private static string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        public static Login GenerateToken(Login login, ref string pistrError)
        {
            pistrError = string.Empty;
            Login Response = new Login();

            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, login.UserName)}),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            Response.Token = handler.WriteToken(token);
            Response.UserName = login.UserName;
            try
            {
                var Userdata = new LoginHelper().Validate_User(login);

                if (Userdata.Rows.Count > 0)
                {
                    Response.FirstName = !DBNull.Value.Equals(Userdata.Rows[0]["FirstName"]) ? Userdata.Rows[0]["FirstName"].ToString() : "";
                    Response.LastName = !DBNull.Value.Equals(Userdata.Rows[0]["LastName"]) ? Userdata.Rows[0]["LastName"].ToString() : "";
                    Response.RoleName = !DBNull.Value.Equals(Userdata.Rows[0]["RoleName"]) ? Userdata.Rows[0]["RoleName"].ToString() : "";
                    Response.FullName = Response.FirstName + " " + Response.LastName;
                    Response.LoginError = new LoginResponseError();
                }
                else
                {
                    pistrError = "User Not Found !!!";
                    Response.LoginError = new LoginResponseError()
                    {
                        ErrorCode = "100",
                        ErrorMessage = "User Not Found !!!",
                    };
                }
            }
            catch (Exception ex)
            {
                pistrError = ex.Message;
                Response.LoginError = new LoginResponseError()
                {
                    ErrorCode = "100",
                    ErrorMessage = " Error occured at the the time of validate user !!!",
                };
            }
            Response.Password = null;
            return Response;
        }
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch (Exception ex)
            {
                var xx = ex;
                return null;
            }
        }
        public static string ValidateToken(string token)
        {
            string username = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim.Value;
            return username;
        }
    }

}
