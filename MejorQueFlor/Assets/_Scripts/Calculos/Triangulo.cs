using UnityEngine;

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

    public void Set(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        _vertices = new Vector3[3] { v1, v2, v3 };
    }

    public void Set(Vector3[] vertices)
    {
        Set(vertices[0], vertices[1], vertices[2]);
    }
}
