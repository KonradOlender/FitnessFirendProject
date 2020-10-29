using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication.Models;

namespace WebApplication.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Uzytkownik class
    public class Uzytkownik : IdentityUser<int>
    {
        //public int id_uzytkownika { get; set; }
        public string imie { get; set; }
        public string login { get; set; }

        public virtual ICollection<RolaUzytkownika> role { get; set; }
        public virtual ICollection<Trening> treningi { get; set; }
        public virtual ICollection<Posilek> posilki { get; set; }
        public virtual ICollection<HistoriaUzytkownika> historiaUzytkownika { get; set; }

    }
}
