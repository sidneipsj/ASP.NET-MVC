using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sidnei.DemoEF_Blog.Models
{
    public class Artigo
    {
        public Artigo()
        {
            Tags = new List<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public Autor Autor { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}