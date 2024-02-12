using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Quando o objeto detecta o mouse em cima ou saindo dele, passa o valor para esse script.
public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Button Animation")]
    public float finalScale = 1.2f;
    public float scaleDuration = .1f;

    private Vector3 _originalScale; //Salva a escala original do botão.
    private Tween _currentTween; //Salva qual animação está sendo feito, para caso o mouse saia antes dela ser concluida, matar.

    private void Awake()
    {
        _originalScale = transform.localScale; //Salva a escala original.
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        //Se detectar o mouse em cima do objeto, irá fazer uma animação de escala.
        _currentTween = transform.DOScale(_originalScale * finalScale, scaleDuration);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        _currentTween.Kill(); //Se detectar que o mouse saiu, mata a animação.
        transform.localScale = _originalScale; //Volta a escala original.
    }
}
