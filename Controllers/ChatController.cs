using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatgptcall.Controllers
{
   
    [Route("[Controller]")]
    public class ChatController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> chat(string input)
        {
            var callgpt = new Chatgptrestcall("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");

            var generatedai=await callgpt.GetResponse(input);

            return Ok(generatedai.Choices[0].text.Replace("\n",""));
            
        }
    }
}
