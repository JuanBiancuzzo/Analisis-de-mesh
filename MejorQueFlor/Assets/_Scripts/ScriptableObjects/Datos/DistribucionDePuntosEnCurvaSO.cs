using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Datos/Distribucion de puntos en curva", fileName = "Distribucion de puntos en curva")]
public class DistribucionDePuntosEnCurvaSO : DistribucionDePuntosSO
{
    [SerializeField] private AnimationCurve _curva;

    public override float FuncionDe0A1(float x)
    {
        return _curva.Evaluate(x);
    }
}