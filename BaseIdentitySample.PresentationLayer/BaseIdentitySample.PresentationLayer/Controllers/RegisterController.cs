using BaseIdentitySample.EntityLayer.Concrete;
using BaseIdentitySample.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseIdentitySample.PresentationLayer.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterModel p)
		{
			if (ModelState.IsValid) //else yazmaya gerek yok. ModelState modelin boş gelip gelmemesini yakalayacak.
			{ 
				//BUNUN İÇİNDE KONTROLLERİ YAPICAZ:
				AppUser appUser= new AppUser() //AppUser.ı örnekledik ve model p.den gelenleri appusera atıyoruz:
				{
					Name = p.Name,
					Surname=p.Surname,
					Email = p.Mail,
					UserName = p.Username
				};
				//MAİL CONFİRM
				if(p.Password==p.ConfirmPassword)
				{
					var result = await _userManager.CreateAsync(appUser, p.Password);  

					if(result.Succeeded)
					{
						return RedirectToAction("Index", "Login");
					}
					else //identity şifre standartına takılabilir, kullanıcı adı same olabilir, girilen ifadeler db atamasına uymayabilir vs.
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError("", item.Description); //identity.den gelen desc
						}
					}
				}
                else
                {
                    ModelState.AddModelError("", "Şifreler Uyuşmuyor.");
                }
            }
			return View();
		}
	}
}
