using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConseguirMesh : MonoBehaviour
{
    [SerializeField] private string _nombreVentana;
    [SerializeField] private string _directorio;
    [SerializeField] private string _formato;

    public string CaminoParaArchivo()
    {
        return EditorUtility.OpenFilePanel(_nombreVentana, _directorio, _formato);
    }
}
