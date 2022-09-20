using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsAchievmentsTracker.Services;
using StudentsAchievmentsTracker.Services.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace StudentsAchievmentsTracker.Pages.Students
{
    public class IndexModel : AbpPageModel
    {
        private readonly StudentService _studentService;

        public List<StudentDto> Students { get; set; }

        public IndexModel(StudentService studentService)
        {
            this._studentService = studentService;
        }
        public async Task OnGet()
        {
            Students = await _studentService.GetListAsync();
        }
    }
}
