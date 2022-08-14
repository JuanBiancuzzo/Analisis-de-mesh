using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalcularPerimetroMaximo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private OrientacionSO _orientacion;
    [SerializeField] private DistribucionDePuntosSO _distribucionDePuntos;

    [Space]

    [SerializeField] private EventoMeshesSO _eventoMeshes;
    [SerializeField] private EventoFloatSO _eventoActualizarPerimetroMaximo;

    private Mesh[] _meshesActuales;

    private void OnEnable()
    {
        if (_eventoMeshes != null)
            _eventoMeshes.Evento += GuardarMeshes;
    }

    private void OnDisable()
    {
        if (_eventoMeshes != null)
            _eventoMeshes.Evento -= GuardarMeshes;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float perimetroMaximo = ProcesarMesh.PerimetroMaximo(_meshesActuales, _orientacion.Direccion, _distribucionDePuntos);
        _eventoActualizarPerimetroMaximo?.Invoke(perimetroMaximo);
    }

    private void GuardarMeshes(Mesh[] meshes)
    {
        _meshesActuales = meshes;
    }
}
