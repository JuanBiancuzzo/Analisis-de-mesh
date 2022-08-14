using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Evento/Evento mesh", fileName = "Evento mesh")]
public class EventoMeshesSO : ScriptableObject
{
    public Action<Mesh[]> Evento;

    public void Invoke(Mesh[] meshes) => Evento?.Invoke(meshes);
}
