using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace E_Ticaret_Proje.Entity
{
    public class Author
    {
        public int Id { get; set; }

        [DisplayName("Yazar")]
        public string Name { get; set; }

        [DisplayName("Yazar Hakkında")]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}