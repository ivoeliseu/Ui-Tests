using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Essa classe precisa ser "static".
public static class UtilityScripts
{

    #region Unity Editor
    //if UNITY_EDITOR e endif servem para o c�digo funcionar somente no editor, pois se for compilar a build com eles, ir� dar erro, ent�o esse c�digo o exclui.
        #if UNITY_EDITOR

        //As fun��es abaixo servem para criar fun��es no menu de ferramenta do editor da Unity
        [UnityEditor.MenuItem("DebugText/Test %q")]
        private static void DebugText()
        {
        Debug.Log("Test");
        }

        #endif
    #endregion

    //Recebe um transform que vai aumentar de tamanho e valor da mudan�a
    //O "this" indica que vai pegar o transform que est� chamando a fun��o
    public static void ScaleTransform(this Transform objectjToScale, float size = 1.2f)
    {
        objectjToScale.localScale = Vector3.one * size;
    }
    public static void ScaleGameObject (this GameObject objectjToScale, float size = 1.2f)
    {
        objectjToScale.transform.localScale = Vector3.one * size;
    }
    public static void ScaleVector3(this Vector3 objectjToScale, float size = 1.2f)
    {
        objectjToScale = Vector3.one * size;
    }

    // T -> Porque a fun��o retorna um valor
    // Essa fun��o pega uma lista e retorna ela randomizada
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    } 

}
