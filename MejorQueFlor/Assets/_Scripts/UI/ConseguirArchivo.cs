using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConseguirArchivo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _nombreVentana;
    [SerializeField] private string _directorio;
    [SerializeField] private string _formato;

    [Space]

    [SerializeField] private EventoStringSO _eventoPath;

    public void OnPointerClick(PointerEventData eventData)
    {
        string path = EditorUtility.OpenFilePanel(_nombreVentana, _directorio, _formato);
        if (path != null)
            _eventoPath?.Invoke(path);
    }
}
