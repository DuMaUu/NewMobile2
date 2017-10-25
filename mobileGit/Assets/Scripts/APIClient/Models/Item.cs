[System.Serializable]
public class Item {
	public int ItemID;

	public string Nome;

	public string Descricao;

	public int DanoMaximo;

	public int Raridade;

	// Relacionamento Item --> TipoItem
	public int TipoItemID;
}
