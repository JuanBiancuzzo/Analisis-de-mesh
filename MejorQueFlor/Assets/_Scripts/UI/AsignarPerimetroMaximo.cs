using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class AsignarPerimetroMaximo : MonoBehaviour
{
    [SerializeField] private string _textoAcompañante = "Perimetro maximo: ";

    [SerializeField] private EventoFloatSO _eventoVamorPerimetroMaximo;

    private TMP_Text _texto;

    private void Awake()
    {
        _texto = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (_eventoVamorPerimetroMaximo != null)
            _eventoVamorPerimetroMaximo.Evento += ActualizarPerimetroMaximo;
    }

    private void OnDisable()
    {
        if (_eventoVamorPerimetroMaximo != null)
            _eventoVamorPerimetroMaximo.Evento -= ActualizarPerimetroMaximo;
    }

    private void ActualizarPerimetroMaximo(float perimetroMaximo)
    {
        _texto.text = _textoAcompañante + perimetroMaximo.ToString();
    }
}
