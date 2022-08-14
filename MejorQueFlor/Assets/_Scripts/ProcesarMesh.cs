using System;
using System.Collections;
using System.Collections.Generic;
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

public struct Triangulo
{
    private Vector3[] _vertices;

    public Triangulo(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        _vertices = new Vector3[3] { v1, v2, v3 };
    }

    public Triangulo(Vector3[] vertices)
        : this(vertices[0], vertices[1], vertices[2])
    {
    }

    public Vector3 this[int i] { get { return _vertices[i]; } }
}

public interface IDistribucionDePuntos
{
    public IEnumerable<float> Puntos(float extremoInferior, float extremoSuperior);
}

public static class ProcesarMesh
{
    public static float Diametro(List<Triangulo> triangulos, Plano plano)
    {
        float diametro = 0f;
        
        foreach (Triangulo triangulo in triangulos)
        {
            if (!TrianguloIntersectaPlano(triangulo, plano))
                continue;
            diametro += InterseccionTrianguloPlano(triangulo, plano);
        }

        return diametro;
    }

    private static bool TrianguloIntersectaPlano(Triangulo triangulo, Plano plano)
    {
        
        
        return false;
    }

    private static float InterseccionTrianguloPlano(Triangulo triangulo, Plano plano)
    {
        return 0f;
    }

    public static float DiametroMaximo(Mesh mesh, Vector3 direccion, IDistribucionDePuntos distribucion)
    {
        float diametroMaximo = -1f;
        List<Triangulo> triangulos = TriangulosDeUnaMesh(mesh);
        Tuple<float, float> extremos = ExtremosEnUnaDireccion(mesh, direccion);

        foreach (float distancia in distribucion.Puntos(extremos.Item1, extremos.Item2))
        {
            Plano plano = new Plano(direccion, distancia);
            float diametro = Diametro(triangulos, plano);
            diametroMaximo = Mathf.Max(diametroMaximo, diametro);
        }

        return diametroMaximo;
    }

    private static List<Triangulo> TriangulosDeUnaMesh(Mesh mesh)
    {
        List<Triangulo> triangulos = new List<Triangulo>();
        Vector3[] vertices = mesh.vertices;
        int[] indices = mesh.GetIndices(0);

        for (int i = 0; i < indices.Length; i += 3)
        {
            Vector3[] triangulo = new Vector3[3];
            for (int j = 0; j < 3; j++)
                triangulo[j] = vertices[indices[i + j]];
            triangulos.Add(new Triangulo(triangulo));
        }

        return triangulos;
    }

    private static Tuple<float, float> ExtremosEnUnaDireccion(Mesh mesh, Vector3 direccion)
    {
        float inicio = 0f, final = 0f;
        Vector3[] vertices = mesh.vertices;
        Vector3 centro = CentroDeVertices(vertices);

        foreach (Vector3 vertice in vertices)
        {
            Vector3 verticeProyectado = ProyectarEnRecta(centro, direccion, vertice);

            Vector3 diferencia = verticeProyectado - centro;
            float distancia = diferencia.magnitude;

            if (Vector3.Dot(diferencia, direccion) > 0)
                final = Mathf.Max(final, distancia);
            else
                inicio = Mathf.Min(inicio, -distancia);
        }

        return new Tuple<float, float>(inicio, final);
    }

    private static Vector3 CentroDeVertices(Vector3[] vertices)
    {
        Vector3 centro = Vector3.zero;
        foreach (Vector3 vertice in vertices)
            centro += vertice;
        centro /= vertices.Length;
        return centro;
    }

    private static Vector3 ProyectarEnRecta(Vector3 puntoEnRecta, Vector3 direccion, Vector3 punto)
    {
        Vector3 proyeccionEnDireccion = (Vector3.Dot(direccion, punto) / Vector3.Dot(direccion, direccion)) * direccion;
        return puntoEnRecta + proyeccionEnDireccion;
    }
}
