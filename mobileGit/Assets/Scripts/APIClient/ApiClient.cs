using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ApiClient : MonoBehaviour {
	//Variaveis inventario 1
	[Header("Variaveis2")]
	public Text Nome1;
	public Text Desc1;
	public Text DanoMax1;
	public Text Raridade1;
	public Text TipoItemId1;
	//2
	[Header("Variaveis2")]
	public Text Nome2;
	public Text Desc2;
	public Text DanoMax2;
	public Text Raridade2;
	public Text TipoItemId2;

	private int TypeOfItem;


	const string baseUrl = "http://localhost:57842/API";

	void Start () {
		TypeOfItem = 0;
		StartCoroutine(GetItems());
	}
	
	IEnumerator GetItems()
	{
		UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Items");
		yield return request.Send();

		if(request.isNetworkError || request.isHttpError)
		{
			Debug.Log(request.error);
		}
		else
		{
			string response = request.downloadHandler.text;
			Debug.Log(response);
			byte[] bytes = request.downloadHandler.data;

			Item[] Items = JsonHelper.getJsonArray<Item>(response);

			foreach(Item i in Items)
			{
				ImprimirItem(i);
			}
		}
	}
	private void ImprimirItem(Item i)
	{
		Debug.Log("====== Dados Objeto =====");
		Debug.Log("Nome: " + i.Nome);
		Debug.Log("Descrição: " + i.Descricao);
		Debug.Log("Dano Máximo: " + i.DanoMaximo);
		Debug.Log("Raridade: " + i.Raridade);
		Debug.Log("TipoItemID: " + i.TipoItemID);
		if (TypeOfItem == 0)
		{
			Nome1.text = "Nome: " + i.Nome;
			Desc1.text = "Descrição: " + i.Descricao;
			DanoMax1.text = "Dano Máximo: " + i.DanoMaximo.ToString();
			Raridade1.text = "Raridade: " + i.Raridade.ToString();
			TipoItemId1.text = "TipoItemID: " + i.TipoItemID.ToString();
		}
		else if(TypeOfItem == 1)
		{
			Nome2.text = "Nome: " + i.Nome;
			Desc2.text = "Descrição: " + i.Descricao;
			DanoMax2.text = "Dano Máximo: " + i.DanoMaximo.ToString();
			Raridade2.text = "Raridade: " + i.Raridade.ToString();
			TipoItemId2.text = "TipoItemID: " + i.TipoItemID.ToString();
		}

		TypeOfItem++;
	}


}
