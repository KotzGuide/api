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
            var name = HttpContext.Request.Query["name"].ToString();
            var constellation = HttpContext.Request.Query["constellation"].ToString();
            var rank = HttpContext.Request.Query["rank"].ToString();

            if (!string.IsNullOrEmpty(name))
            {
                bool nameQuery;
                if (bool.TryParse(name, out nameQuery))
                    Saints = await repository.GetAll(nameQuery, null, null);
            }
            else if (!string.IsNullOrEmpty(constellation))
            {
                bool constellationQuery;
                if (bool.TryParse(constellation, out constellationQuery))
                    Saints = await repository.GetAll(null, constellationQuery, null);
            }
            else if (!string.IsNullOrEmpty(rank))
            {
                bool rankQuery;
                if (bool.TryParse(rank, out rankQuery))
                    Saints = await repository.GetAll(null, null, rankQuery);
            }
            else
                Saints = await repository.GetAll(null, null, null);
            return Page();
        }
    }
}
