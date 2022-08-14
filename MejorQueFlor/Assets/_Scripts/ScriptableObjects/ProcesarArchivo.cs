using UnityEngine;
using Parabox.Stl;

[CreateAssetMenu(menuName = "Procesar/Procesar mesh", fileName = "Procesar mesh")]
public class ProcesarArchivo : ScriptableObject
{
    [SerializeField] private EventoStringSO _eventoPath;
    [SerializeField] private EventoMeshSO _eventoMesh;

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
        Mesh meshParaEnviar = null;

        foreach (Mesh mesh in meshes)
            if (mesh.vertexCount > 0)
            {
                meshParaEnviar = mesh;
                break;
            }

        if (meshParaEnviar != null)
            _eventoMesh?.Invoke(meshParaEnviar);
        else
            Debug.Log("No se pudo importar ningun archivo");
    }
}
