using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_dot_net.Model
{
    public class RechercheViewModel
    {
        public string Recherche { get; set; }
        public List<Academies> ListAcademieRechercher { get; set; }
    }
}