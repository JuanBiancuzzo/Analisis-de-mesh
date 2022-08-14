using UnityEngine;
using Parabox.Stl;

[CreateAssetMenu(menuName = "Procesar/Procesar mesh", fileName = "Procesar mesh")]
public class ProcesarArchivo : ScriptableObject
{
    [SerializeField] private EventoStringSO _eventoPath;
    [SerializeField] private EventoMeshesSO _eventoMeshes;

    private void OnEnable()
    {
        if (_eventoPath != null)
            _eventoPath.Evento += MandarMesh;
    }

    private void OnDisable()
    {
        if (_eventoPath != null)
            _eventoPath.Evento -= MandarMesh;
    }

    private void MandarMesh(string path)
    {
        Mesh[] meshes = Importer.Import(path);
        _eventoMeshes?.Invoke(meshes);
    }
}
