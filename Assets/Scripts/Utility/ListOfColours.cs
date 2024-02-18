using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ListOfColours : MonoBehaviour
{
    #region Unity Editor
    //if UNITY_EDITOR e endif servem para o código funcionar somente no editor, pois se for compilar a build com eles, irá dar erro, então esse código o exclui.
        #if UNITY_EDITOR

        //As funções abaixo servem para criar funções no menu de ferramenta do editor da Unity
        [UnityEditor.MenuItem("Instantiate/Cube/Cyan Cube %w")]
        private static void CubeCian()
        {
            InstantiateCube(Color.cyan);
        }
        [UnityEditor.MenuItem("Instantiate/Cube/Black Cube %e")]
        private static void CubeBlack()
        {
            InstantiateCube(Color.black);
        }
        [UnityEditor.MenuItem("Instantiate/Cube/Red Cube %r")]
        private static void CubeRed()
        {
            InstantiateCube(Color.red);
        }

#endif
    #endregion
    public List<Color> coloursList;
    public GameObject objectToColor;
    public static GameObject instantianteObject;
    public static Vector3 instantiateCubePosition = new Vector3(-1, 1);

    //No Start, a lista coloursList irá chamar o método GetRandom para retornar um de seus valores, adicionando um index com uma dessas cores.
    //Após isso, o ColorObject irá colorir um Game Object com tal cor.
    private void Start()
    {
        AddIndex();
        instantianteObject = objectToColor;
    }

    [Button]
    private void AddIndex()
    {
        coloursList.Add(UtilityScripts.GetRandom(coloursList));
        Invoke("ColorObject", 1f);
    }

    //A ideia é pegar o último index, que foi adicionado a cor e pintar o GameObject com tal cor.
    private void ColorObject()
    {
        objectToColor.GetComponent<Renderer>().material.color = coloursList[coloursList.Count - 1];
    }

    public static void InstantiateCube(Color color)
    {
        var a = instantianteObject;
        a.GetComponent<Renderer>().material.color = color;
        Instantiate(a);
        a.transform.position = instantiateCubePosition;
    }
}



