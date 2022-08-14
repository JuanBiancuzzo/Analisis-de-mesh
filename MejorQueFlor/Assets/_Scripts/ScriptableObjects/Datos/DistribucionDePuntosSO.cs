using System.Collections.Generic;
using UnityEngine;

public abstract class DistribucionDePuntosSO : ScriptableObject, IDistribucionDePuntos
{
    [SerializeField] protected uint _cantidadDePuntos;

    public IEnumerable<float> Puntos(float extremoInferior, float extremoSuperior)
    {
        for (int i = 0; i <= _cantidadDePuntos; i++)
        {
            float instanteActual = ((float)i) / ((float)_cantidadDePuntos);

            float valorAlterado = FuncionDe0A1(instanteActual);

            yield return Mathf.Lerp(extremoInferior, extremoSuperior, valorAlterado);
        }
    }

    public abstract float FuncionDe0A1(float x);
}
