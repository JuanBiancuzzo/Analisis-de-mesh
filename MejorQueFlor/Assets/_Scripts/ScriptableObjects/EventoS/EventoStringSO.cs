using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Evento/Evento string", fileName = "Evento string")]
public class EventoStringSO : ScriptableObject
{
    public Action<string> Evento;

    public void Invoke(string texto) => Evento?.Invoke(texto);
}
