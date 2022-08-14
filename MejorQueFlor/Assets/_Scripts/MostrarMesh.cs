using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MostrarMesh : MonoBehaviour
{
    [SerializeField] private EventoMeshSO _eventoMesh;
    [SerializeField] private EventoVoidSO _eventoActualizoMesh;

    private MeshFilter _meshFilter;
    private Mesh _mesh
    {
        get
        {
            if (_meshFilter == null)
                _meshFilter = GetComponent<MeshFilter>();
            return _meshFilter.sharedMesh;
        }

        set
        {
            if (_meshFilter == null)
                _meshFilter = GetComponent<MeshFilter>();
            _meshFilter.sharedMesh = value;
        }
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
        _mesh = mesh;
        _eventoActualizoMesh?.Invoke();
    }

    [ContextMenu("Mandar mesh actual")]
    private void MandarMeshActual() => _eventoMesh?.Invoke(_mesh);
}
