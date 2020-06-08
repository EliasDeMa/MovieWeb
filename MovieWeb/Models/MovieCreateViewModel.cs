using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Models
{
    public class MovieCreateViewModel
    {
        [DisplayName("Titel")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Titel verplicht!")]
        [MaxLength(30, ErrorMessage = "Maximum 30 karakters!")]
        public string Title { get; set; }

        [DisplayName("Omschrijving")]
        [MaxLength(250, ErrorMessage = "Maximum 250 karakters!")]
        public string Description { get; set; }

        [DisplayName("Genre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Genre verplicht!")]
        [MaxLength(30, ErrorMessage = "Maximum 30 karakters!")]
        public string Genre { get; set; }

        [DisplayName("Release Datum")]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2070")]
        public DateTime? ReleaseDate
        {
            get
            {
                return this.ReleaseDate.HasValue
                    ? this.ReleaseDate.Value
                    : DateTime.Now;
            }
            set
            {
                this.ReleaseDate = value;
            }
        }
    }
}
