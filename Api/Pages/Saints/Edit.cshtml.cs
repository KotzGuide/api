using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Saints
{
    public class EditModel : PageModel
    {
        private readonly ISaintRepository repository;

        public EditModel(ISaintRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public SaintModel Saint { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var idQueryS = HttpContext.Request.Query["id"].ToString();
            if(!string.IsNullOrEmpty(idQueryS))
            {
                int idQuery;
                if(int.TryParse(idQueryS, out idQuery))
                    Saint = await repository.Get(idQuery);
            }

            return Page();
        }
    }
}
