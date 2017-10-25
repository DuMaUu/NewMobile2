using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour {

	const string baseUrl = "http://localhost:57842/API";

	void Start () {
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
	}

}
