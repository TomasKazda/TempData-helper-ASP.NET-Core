using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TempDataHelperExtension.Pages
{
    public class OtherPage2Model : PageModel
    {
        
        public void OnGet()
        {

        }

        public void OnGetMessage(string text)
        {
            TempData.AddMessage("infobox", TempDataExtension.MessageType.danger, text);
        }
    }
}