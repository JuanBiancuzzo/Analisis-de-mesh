using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ReconfigurarMesh : MonoBehaviour
{
    [SerializeField] private OrientacionSO _orientacion;

    [Space]

    [SerializeField] private bool _reposicionar;
    [SerializeField] private bool _reescalar;

    [Space]

    [SerializeField] private EventoMeshesSO _eventoActualizarMesh;

    private void OnEnable()
    {
        if (_eventoActualizarMesh != null)
            _eventoActualizarMesh.Evento += ReconfigurarConRespectoAMesh;
    }

    private void OnDisable()
    {
        if (_eventoActualizarMesh != null)
            _eventoActualizarMesh.Evento -= ReconfigurarConRespectoAMesh;
    }

    private void ReconfigurarConRespectoAMesh(Mesh[] meshes)
    {
        if (_reposicionar)
            ModificarCentro(meshes);

        if (_reescalar)
            ModificarEscala(meshes);
    }

    private void ModificarEscala(Mesh[] meshes)
    {
        if (_orientacion == null)
            return;

        var extremos = ProcesarMesh.ExtremosEnUnaDireccion(meshes, _orientacion.Direccion);

        float longitud = extremos.Item2 - extremos.Item1;

        Debug.Log("Incio: " + extremos.Item1 + ", Final: " + extremos.Item2);
        Debug.Log("Longitud: " + longitud);
    }

    private void ModificarCentro(Mesh[] meshes)
    {
        Vector3 centroMesh = ProcesarMesh.CentroDeUnaMesh(meshes);

        Debug.Log("Centro: " + centroMesh);
    }
}
