using UnityEngine;

[CreateAssetMenu(menuName = "Datos/Distribucion de puntos lineal", fileName = "Distribucion de puntos lineal")]
public class DistribucionDePuntosLinealSO : DistribucionDePuntosSO
{
    public override float FuncionDe0A1(float x)
    {
        return x;
    }
}