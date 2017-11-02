using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ApiClient : MonoBehaviour
{
    [Header("Variaveis2")]
    public Text Nome;
    public Text Desc;
    public Text Poligonos;


    const string baseUrl = "http://localhost:58845/API";

    // Use this for initialization
    void Start()
    {
        Debug.Log("START");
        StartCoroutine(GetItensApiAsync());
    }

    IEnumerator GetItensApiAsync()
    {
        Debug.Log("TESTE");

        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Dados");
        yield return request.Send();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            //Debug.Log(response);

            //byte[] bytes = request.downloadHandler.data;

            Dados[] dados = JsonHelper.getJsonArray<Dados>(response);

            foreach (Dados i in dados)
            {
                ImprimirItem(i);
            }

        }
    }

    private void ImprimirItem(Dados i)
    {
        Debug.Log("======= Dados Objeto ==========");

        Debug.Log("Id: " + i.DadosID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Descrição: " + i.Descricao);
        Debug.Log("Poligonos: " + i.Poligonos);


        Nome.text = "Nome: " + i.Nome;
        Desc.text = "Descrição: " + i.Descricao;
        Poligonos.text = "Poligonos: " + i.Poligonos.ToString();

    }
}