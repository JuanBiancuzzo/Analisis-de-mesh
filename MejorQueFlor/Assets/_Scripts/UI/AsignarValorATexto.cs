using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class AsignarValorATexto : MonoBehaviour
{
    [SerializeField] private string _textoAcompañante;
    [SerializeField] private EventoFloatSO _eventoActualizarValor;

    private TMP_Text _texto;

    private void Awake()
    {
        _texto = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (_eventoActualizarValor != null)
            _eventoActualizarValor.Evento += ActualizarValor;
    }

    private void OnDisable()
    {
        if (_eventoActualizarValor != null)
            _eventoActualizarValor.Evento -= ActualizarValor;
    }

    private void ActualizarValor(float valor)
    {
        _texto.text = _textoAcompañante + valor.ToString();
    }
}
