using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp6Starter.DTO;
using WebApp6Starter.Models;

namespace WebApp6Starter.Pages.Students
{
    public class ViewStudentsModel : PageModel
    {
        public List<StudentReadOnlyDTO> StudentsReadOnlyDTOs { get; set; } = [
            MapStudentToDTO(new Student() {Id = 1, Firstname = "�������", Lastname = "�������"}),
            MapStudentToDTO(new Student() {Id = 1, Firstname = "������", Lastname = "����������"}),
            MapStudentToDTO(new Student() {Id = 1, Firstname = "����", Lastname = "�����������"})
        ];



        public IActionResult OnGet()
        {
            if (Request.Query.TryGetValue("lastname", out var lastname))
            {
                StudentsReadOnlyDTOs = StudentsReadOnlyDTOs.Where(s  => s.Lastname == lastname).ToList();
                return Page();
            }
            return Page();
        }

        private static StudentReadOnlyDTO MapStudentToDTO(Student student)
        {
            return new StudentReadOnlyDTO()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
        }
    }

    
}
