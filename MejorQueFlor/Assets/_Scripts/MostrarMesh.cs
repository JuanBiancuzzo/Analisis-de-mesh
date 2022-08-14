using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MostrarMesh : MonoBehaviour
{
    [SerializeField] private EventoMeshSO _eventoMesh;

    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    private void OnEnable()
    {
        if (_eventoMesh != null)
            _eventoMesh.Evento += ActualizarMesh;
    }

    private void OnDisable()
    {
        if (_eventoMesh != null)
            _eventoMesh.Evento -= ActualizarMesh;
    }

    private void ActualizarMesh(Mesh mesh)
    {
        _meshFilter.sharedMesh = mesh;
    }
}
