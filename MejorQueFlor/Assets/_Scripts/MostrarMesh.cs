using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarMesh : MonoBehaviour
{
    [SerializeField] private Material _material;

    [Space]

    [SerializeField] private EventoMeshesSO _eventoMesh;
    [SerializeField] private EventoVoidSO _eventoActualizoMesh;

    private List<GameObject> _renderMeshes = new List<GameObject>();

    private void Awake()
    {
        _renderMeshes = new List<GameObject>();
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

    private void ActualizarMesh(Mesh[] meshes)
    {
        LiberarMeshesAnteriores();

        foreach (Mesh mesh in meshes)
        {
            GameObject renderMesh = CrearObjetoParaMostrarMesh(mesh);
            _renderMeshes.Add(renderMesh);
        }

        _eventoActualizoMesh?.Invoke();
    }

    private void LiberarMeshesAnteriores()
    {
        foreach (GameObject renderMesh in _renderMeshes)
            Destroy(renderMesh);
        _renderMeshes.Clear();
    }

    private GameObject CrearObjetoParaMostrarMesh(Mesh mesh)
    {
        GameObject renderMesh = new GameObject("Render");
        renderMesh.transform.parent = transform;

        MeshFilter meshFilter = renderMesh.AddComponent<MeshFilter>();
        meshFilter.sharedMesh = mesh;

        MeshRenderer meshRenderer = renderMesh.AddComponent<MeshRenderer>();
        if (_material != null)
            meshRenderer.sharedMaterial = _material;

        return renderMesh;
    }

    [ContextMenu("Mandar renderMesh actual")]
    private void MandarMeshActual() => _eventoActualizoMesh?.Invoke();
}
