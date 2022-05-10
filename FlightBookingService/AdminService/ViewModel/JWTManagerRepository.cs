﻿using AdminService.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.ViewModel
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        FlightBookingContext _flightBookingContext = new FlightBookingContext();

        private readonly IConfiguration configuartion;

        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            configuartion = iconfiguration;
        }

        public Tokens Authenticate(User users)
        {
            if (!_flightBookingContext.UserMasters.Any(x => x.Email == users.Email &&
            x.Password == users.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,users.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
