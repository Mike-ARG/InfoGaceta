using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoGaceta.Data
{
    public class Noticia
    {
        //Esta clase almacenará los datos referidos a las noticias que se extraerán del sitio.
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Link { get; set; }

    }
}
