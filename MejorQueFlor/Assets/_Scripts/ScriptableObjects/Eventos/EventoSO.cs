using System;
using UnityEngine;

public class EventoSO<TTipo> : ScriptableObject
{
    public Action<TTipo> Evento;

    public void Invoke(TTipo tipo) => Evento?.Invoke(tipo);
}