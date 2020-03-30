using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Helpers;

namespace TempDataHelperExtension.Pages
{
    public class OtherPageModel : PageModel
    {
        public void OnGet()
        {

        }

        //[TempData]
        //public string infobox { get; set; }

        public void OnGetMessage(string text)
        {
            //infobox = text;

            TempData.AddMessage("infobox", TempDataExtension.MessageType.success, text);
        }
    }
}