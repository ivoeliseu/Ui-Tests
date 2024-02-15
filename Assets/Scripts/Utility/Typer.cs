using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters = 0.05f;
    public string phrase;

    private void Awake()
    {
        textMesh.text = "";
    }

    /* Corrotina que recebe o parametro "s".
     * Para cada caracter (representado por "l") dentro de "s" (parametro recebido na corrotina)
     * o valor de "l" é igual a variável "textMesh" (convertida para texto com .text)
     * E aguarda o valor de "timeBetweenLetters" como delay para exibir a próxima letra.
     */

    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach(char l in s.ToCharArray())
        {
            textMesh.text += l;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
    [Button]
    public void StartType()
    {
        StartCoroutine(Type(phrase));
    }
}
