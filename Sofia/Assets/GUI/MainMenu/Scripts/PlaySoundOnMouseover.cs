using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySoundOnMouseover : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audioSource;

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.Play();
    }
}
