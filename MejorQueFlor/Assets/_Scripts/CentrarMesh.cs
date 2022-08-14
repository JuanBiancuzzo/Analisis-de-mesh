using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrarMesh : MonoBehaviour
{
    [SerializeField] private Vector3 _posicionObjetivo;

    [Space]

    [SerializeField] private EventoMeshSO _eventoMesh;

    private void OnEnable()
    {
        if (_eventoMesh != null)
            _eventoMesh.Evento += CentrarConRespectoAMesh;
    }

    private void OnDisable()
    {
        if (_eventoMesh != null)
            _eventoMesh.Evento -= CentrarConRespectoAMesh;
    }

    private void CentrarConRespectoAMesh(Mesh mesh)
    {
        Vector3 centroMesh = ProcesarMesh.CentroDeUnaMesh(mesh);
        transform.position = _posicionObjetivo - centroMesh;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_posicionObjetivo, 0.5f);
    }
}
