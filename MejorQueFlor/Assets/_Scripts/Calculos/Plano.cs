using UnityEngine;

public struct Plano
{
    public Vector3 Direccion;
    public float Distancia;

    public Plano(Vector3 direccion, float distancia)
    {
        Direccion = direccion;
        Distancia = distancia;
    }
}
