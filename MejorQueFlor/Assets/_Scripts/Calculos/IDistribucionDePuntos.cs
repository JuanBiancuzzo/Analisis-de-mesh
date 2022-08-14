using System.Collections.Generic;

public interface IDistribucionDePuntos
{
    public IEnumerable<float> Puntos(float extremoInferior, float extremoSuperior);
}
