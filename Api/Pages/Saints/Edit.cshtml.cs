using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Dtos.Saint;
using Data.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NikCore;

namespace Api.Pages.Saints
{
    public class EditModel : PageModel
    {
        private readonly ISaintRepository repository;
        private readonly ErrorContext errorContext;

        public EditModel(ISaintRepository repository, ErrorContext errorContext)
        {
            this.repository = repository;
            this.errorContext = errorContext;
            Dto = new UpdateSaintDto();
            errorContext.SetOverrideResponse(false);
        }
        public SaintModel Saint { get; set; }

        [BindProperty]
        public UpdateSaintDto Dto { get; set; }

        [BindProperty]
        public string RankStr { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var idQueryS = HttpContext.Request.Query["id"].ToString();
            if(!string.IsNullOrEmpty(idQueryS))
            {
                int idQuery;
                if(int.TryParse(idQueryS, out idQuery))
                    Saint = await repository.Get(idQuery);

                if(Saint != null)
                {
                    Dto.Name = Saint.Name;
                    Dto.Constellation = Saint.Constellation;
                    Dto.Description = Saint.Description;
                    Dto.Rank = (int)Saint.Rank;
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var saintToUpdate = await repository.Get(id);
            Dto.Id = id;
            if (RankStr != null)
                Dto.Rank = (int)((Rank)Enum.Parse(typeof(Rank), RankStr));
            if (saintToUpdate == null)
            {
                return NotFound();
            }
            var res = await repository.Update(Dto);
            if (res)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public ErrorContext Erro() => errorContext;
    }
}
