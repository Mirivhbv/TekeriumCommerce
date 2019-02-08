﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Extensions;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Localization.Areas.Localization.Controllers
{
    [Area("Localization")]
    public class LocalizationController : Controller
    {
        private readonly IRepositoryWithTypedId<User, long> _userRepository;
        private readonly IWorkContext _workContext;

        public LocalizationController(IRepositoryWithTypedId<User, long> userRepository, IWorkContext workContext)
        {
            _userRepository = userRepository;
            _workContext = workContext;
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var currentUser = _userRepository.Query()
                .Single(u => u.Email == _workContext.GetCurrentUser().Result.Email);
            currentUser.Culture = culture;
            _userRepository.SaveChanges();

            return LocalRedirect(returnUrl);
        }
    }
}