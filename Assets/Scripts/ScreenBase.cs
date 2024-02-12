using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType //Lista contendo as telas do menu.
    {
        Panel,
        Info_Panel,
        Shop
    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listOfObjects;
        public bool startHided = false;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayBetweenObjects = .05f;

        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }
        [Button] //NaughtyAttributes;
        protected virtual void Show() //Chama a função ShowObjects
        {
            ShowObjects();
            Debug.Log("Show");
        }
        [Button] //NaughtyAttributes;
        protected virtual void Hide() //Chama a função HideObjects
        {
            HideObjects();
            Debug.Log("Hide");
        }

        private void ForceShowObjects() //Mostra os elementos visuais da lista SEM ANIMAÇÃO
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        } 
        private void ShowObjects() //Mostra os elementos visuais da lista COM ANIMAÇÃO
        {
            //Enquanto i for menor que a contagem da listagem máxima da lista:
            //obj será igual ao index representado por i
            //Ativa ele
            //Deixa ele com escala 0 e durante "animationDuration" segundos, ele vai para a escala original dele (classificado por From())
            //SetDalay faz uma pausa entre a próxima animação baseado no index i * a variável delayBetweenObjects;
            for (int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];
                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
        }
        private void HideObjects() //Esconde os elementos visuais da lista
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
        } 
    }
}
