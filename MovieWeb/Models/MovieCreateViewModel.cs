﻿using System;
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
        [MaxLength(20, ErrorMessage = "Maximum 20 karakters!")]
        public string Title { get; set; }

        [DisplayName("Omschrijving")]
        public string Description { get; set; }

        [DisplayName("Genre")]
        public string Genre { get; set; }

        [DisplayName("Release Datum")]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
    }
}
