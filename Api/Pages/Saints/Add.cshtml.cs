using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Dtos.Saint;
using Data.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NikCore;
using NikCore.Models;

namespace Api.Pages.Saints
{
    public class AddModel : PageModel
    {
        private readonly ISaintRepository repository;
        private readonly ErrorContext errorContext;

        public AddModel(ISaintRepository repository, ErrorContext errorContext)
        {
            this.repository = repository;
            this.errorContext = errorContext;

            errorContext.SetOverrideResponse(false);
        }
        [BindProperty]
        public InsertSaintDto InsertSaint { get; set; }
        [BindProperty]
        public string RankStr { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();
      
            if (RankStr != null)
                 InsertSaint.Rank = (int)((Rank)Enum.Parse(typeof(Rank), RankStr));

            var result = await repository.Insert(InsertSaint);

            if (result <= 0)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }

        public ErrorContext Erro() => errorContext;
    }
}
