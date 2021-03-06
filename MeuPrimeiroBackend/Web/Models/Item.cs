﻿namespace Web.Models
{
	public class Item
	{
		public int ItemID { get; set; }

		public string Nome { get; set; }

		public string Descricao { get; set; }

		public int DanoMaximo { get; set; }

		public int Raridade { get; set; }

		// Relacionamento Item --> TipoItem
		public int TipoItemID { get; set; }

		public virtual TipoItem _Tipoitem { get; set; }
	}
}