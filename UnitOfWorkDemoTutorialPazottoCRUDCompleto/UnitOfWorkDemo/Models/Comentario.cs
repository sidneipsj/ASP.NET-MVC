using System;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkDemo.Models
{
	public class Comentario
	{
		public int ComentarioId { get; set; }

		[DataType(DataType.MultilineText)]
		public string Conteudo { get; set; }

		[ScaffoldColumn(false)]
		public DateTime DataCriacao { get; set; }
		public int PostId { get; set; }
		public virtual Post Post { get; set; }
	}
}