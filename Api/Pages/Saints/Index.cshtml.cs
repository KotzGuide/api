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
    public class IndexModel : PageModel
    {
        private readonly ISaintRepository repository;

        public IndexModel(ISaintRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public List<SaintModel> Saints { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Saints = await repository.GetAll();
            return Page();
        }
    }
}
