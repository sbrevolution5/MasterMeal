using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using MasterMealBlazor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using MasterMealBlazor.Services.Interfaces;
using MasterMealBlazor.Services;
using Microsoft.EntityFrameworkCore;
using MasterMealBlazor.Data;

namespace MasterMealBlazor.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Chef> _signInManager;
        private readonly UserManager<Chef> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IFileService _fileService;
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public RegisterModel(
            UserManager<Chef> userManager,
            SignInManager<Chef> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, IFileService fileService, Microsoft.EntityFrameworkCore.IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _fileService = fileService;
            _contextFactory = contextFactory;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Screen Name")]
            public string ScreenName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public bool ShowFullName { get; set; }
            [Display(Name = "Profile Picture")]
            public IFormFile ImageFile { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            using var context = _contextFactory.CreateDbContext();
            if (ModelState.IsValid)
            {
                int imageId;
                if (Input.ImageFile is not null)
                {
                    var image = new DBImage()
                    {
                        ImageData = await _fileService.ConvertFileToByteArrayAsync(Input.ImageFile),
                        ContentType = Input.ImageFile.ContentType
                    };
                    context.Add(image);
                    //DONT SAVE YET IN CASE USER REGISTRATION FAILS!
                    //await context.SaveChangesAsync();
                    imageId = image.Id;
                }
                else //default user image
                {
                    imageId = 2;
                }
                var user = new Chef {
                    UserName = Input.Email,
                    ScreenName = Input.ScreenName,
                    Email = Input.Email,
                    DisplayName = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    ShowFullName = Input.ShowFullName,
                    ImageId = imageId,
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //SAVE IMAGE
                    await context.SaveChangesAsync();
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
