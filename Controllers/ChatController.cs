using Microsoft.AspNetCore.Mvc;

namespace uchat.Controllers
{
    public class ChatController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GroupChat(
            string roomid    
        )
        {
            ViewData["roomid"] = roomid;
            return View();
        }
    }

}
