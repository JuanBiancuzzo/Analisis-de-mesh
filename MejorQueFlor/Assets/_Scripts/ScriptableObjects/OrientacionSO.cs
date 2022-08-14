using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datos/Orientacion", fileName = "Orientacion")]
public class OrientacionSO : ScriptableObject
{
    [SerializeField] private Vector3 _direccion;

    public Vector3 Direccion { get => _direccion.normalized; set => _direccion = value; }
}
