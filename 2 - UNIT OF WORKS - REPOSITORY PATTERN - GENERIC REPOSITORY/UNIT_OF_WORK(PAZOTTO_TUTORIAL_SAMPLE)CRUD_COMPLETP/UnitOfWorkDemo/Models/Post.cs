using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkDemo.Models
{
	public class Post
	{
		public int PostId { get; set; }
		public string Titulo { get; set; }

		[DataType(DataType.MultilineText)]
		public string Conteudo { get; set; }

		[ScaffoldColumn(false)]
		public DateTime DataCriacao { get; set; }
		public virtual ICollection<Comentario> Comentarios { get; set; }
	}
}
