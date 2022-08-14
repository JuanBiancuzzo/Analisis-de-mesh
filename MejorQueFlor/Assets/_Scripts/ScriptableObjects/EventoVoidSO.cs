using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Evento/Evento void", fileName = "Evento void")]
public class EventoVoidSO : ScriptableObject
{
    public Action Evento;

    public void Invoke() => Evento?.Invoke();
}