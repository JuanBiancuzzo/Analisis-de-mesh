using System;
using System.Collections.Generic;
using UnityEngine;

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
        float[] valores = ValoresDeTriangulo(triangulo, plano);
        return !((valores[0] > 0 && valores[1] > 0 && valores[2] > 0) || (valores[0] < 0 && valores[1] < 0 && valores[2] < 0));
    }

    private static float InterseccionTrianguloPlano(Triangulo triangulo, Plano plano)
    {
        float[] valores = ValoresDeTriangulo(triangulo, plano);
        Vector3[] mismoLado = new Vector3[2];
        Vector3 ladoOpuesto;

        if (valores[0] * valores[1] > 0)
        {
            mismoLado[0] = triangulo[0];
            mismoLado[1] = triangulo[1];
            ladoOpuesto = triangulo[2];
        } 
        else if (valores[1] * valores[2] > 0)
        {
            mismoLado[0] = triangulo[1];
            mismoLado[1] = triangulo[2];
            ladoOpuesto = triangulo[0];
        } 
        else
        {
            mismoLado[0] = triangulo[0];
            mismoLado[1] = triangulo[2];
            ladoOpuesto = triangulo[1];
        }

        Vector3[] proyeccionEnElPlano = new Vector3[2];

        for (int i = 0; i < 2; i++)
        {
            Vector3 direccion = mismoLado[i] - ladoOpuesto;
            proyeccionEnElPlano[i] = ladoOpuesto + direccion * PuntoInterseccionPlanoYDosPuntos(plano, ladoOpuesto, direccion);
        }

        return Vector3.Distance(proyeccionEnElPlano[0], proyeccionEnElPlano[1]);
    }

    private static float PuntoInterseccionPlanoYDosPuntos(Plano plano, Vector3 inicio, Vector3 direccion)
    {
        Vector3 direccionPlano = plano.Direccion;
        float distancia = plano.Distancia;

        return (Vector3.Dot(direccionPlano, direccionPlano) * distancia - Vector3.Dot(direccionPlano, inicio)) / Vector3.Dot(direccionPlano, direccion);
    }

    private static float[] ValoresDeTriangulo(Triangulo triangulo, Plano plano)
    {
        Vector3 puntoEnPlano = plano.Distancia * plano.Direccion;
        float[] valores = new float[3];

        for (int i = 0; i < 3; i++)
        {
            Vector3 verticeTransladado = triangulo[i] - puntoEnPlano;
            valores[i] = Vector3.Dot(verticeTransladado, plano.Direccion);
        }
        return valores;
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

    public static Vector3 CentroDeUnaMesh(Mesh mesh)
    {
        return CentroDeVertices(mesh.vertices);
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
