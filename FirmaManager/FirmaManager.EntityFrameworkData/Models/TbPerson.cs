using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaManager.EntityFrameworkData.Models
{
    public partial class TbPerson
    {
        public Guid Uid { get; set; }
        public string PersonNummer { get; set; }
        public string Vorname { get; set; }
        public string Name { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public bool Geschlecht { get; set; }
    }
}
