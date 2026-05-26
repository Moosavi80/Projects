using System.ComponentModel.DataAnnotations;
using WebApi_FirstProject_EF.Entity;

namespace WebApi_FirstProject_EF.Response
{
    public class SchoolCreateParams
    {
        public required string Tittle { get; set; }

        public IEnumerable<ClassEntity>? Classes { get; set; }
    }
}
