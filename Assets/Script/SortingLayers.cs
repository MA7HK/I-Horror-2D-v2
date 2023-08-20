using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;

[InitializeOnLoad]
class SortingLayers
{
    static SortingLayers()
    {
        Initialize();
    }
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
        GraphicsSettings.transparencySortAxis = new Vector3(0.0f, 1.0f, 1.0f);
    }
}