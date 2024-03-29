﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static WEBAPI.DTO.LoginFields;

namespace WEBAPI
{
    public class JwtAuthenticationManager
    {

        private readonly string key;

        //private readonly IDictionary<string, string> users = new Dictionary<string, string>()
        //{ {"test", "password"}, {"test1", "pwd"}};



        public JwtAuthenticationManager(string key) 
        { 
        this.key = key; 
        
        }


        public string Authenticate(UserFields request)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();


            var tokenKey = Encoding.ASCII.GetBytes(key);


            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                { 
                    new Claim(ClaimTypes.Name, request.firstname + " " + request.middlename + " " + request.lastname),
                    new Claim(ClaimTypes.Email, request.email!),
                    new Claim(ClaimTypes.NameIdentifier, request.userid.ToString()),
                }
                ),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


    }
}
