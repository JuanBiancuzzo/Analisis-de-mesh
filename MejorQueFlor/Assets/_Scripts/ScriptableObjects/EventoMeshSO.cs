using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Evento/Evento mesh", fileName = "Evento mesh")]
public class EventoMeshSO : ScriptableObject
{
    public Action<Mesh> Evento;

    public void Invoke(Mesh mesh) => Evento?.Invoke(mesh);
}
