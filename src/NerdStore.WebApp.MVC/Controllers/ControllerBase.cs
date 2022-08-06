using Microsoft.AspNetCore.Mvc;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Guid ClienteId = Guid.Parse("573B2556-8808-4A47-B036-4DC5C32B6C93");
    }
}
