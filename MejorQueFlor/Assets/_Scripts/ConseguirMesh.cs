using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConseguirMesh : MonoBehaviour
{
    [SerializeField] private string _nombreVentana;
    [SerializeField] private string _directorio;
    [SerializeField] private string _formato;

    [Space]

    [SerializeField] private string _pathFinal;

    public void CaminoParaArchivo()
    {
        _pathFinal = EditorUtility.OpenFilePanel(_nombreVentana, _directorio, _formato);
    }
}
