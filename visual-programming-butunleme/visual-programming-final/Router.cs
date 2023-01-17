using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visual_programming_final
{
    public static class Router
    {
        public static AnaForm anaForm = new AnaForm();
        public static FilmAra filmAra = new FilmAra();
        public static FilmEkle filmEkle = new FilmEkle();
        public static FilmSil filmSil = new FilmSil();
        public static FilmGuncelle filmGuncelle = new FilmGuncelle();
        public static TumFilmler tumFilmler = new TumFilmler();
    }
}
