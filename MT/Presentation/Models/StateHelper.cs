﻿using Application.DTOs;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Presentation.Models
{
    public class StateHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        private GetUserDTO? _userData;

        public StateHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userData = User();
        }

        public GetUserDTO? User()
        {
            var userData = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.UserData);
            if (userData != null)
                return JsonConvert.DeserializeObject<GetUserDTO>(userData);
            else
                return null;
        }

        public int Id
        {
            get { return _userData?.Id ?? 0; }
        }

        //public string Name
        //{
        //    get { return _userData?.Name ?? string.Empty; }
        //}

        //public string Email
        //{
        //    get { return _userData?.Email ?? string.Empty; }
        //}

        //public string Password
        //{
        //    get { return _userData?.Password ?? string.Empty; }
        //}

        //public enRole Role
        //{
        //    get { return _userData?.Role ?? enRole.User; }
        //}
    }

}
