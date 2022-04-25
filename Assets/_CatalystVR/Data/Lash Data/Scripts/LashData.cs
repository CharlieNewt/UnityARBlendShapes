using System;
using UnityEngine;
using UnityEngine.XR.ARKit; 

[Serializable]
public class LashBlendShape {
    public ARKitBlendShapeLocation blendShapeLocation;
    [ReadOnly] public float value;
}

[CreateAssetMenu(fileName = "Lash Data", menuName = "Custom Data/Lash Data")]
public class LashData : ScriptableObject
{
    public LashBlendShape blinkBlendShape;
    public LashBlendShape wideBlendShape;
    public float curl;
    public float width;
    public float length;

    public float blendshapeCoefficientScale = 100;
    // public float texStrength_D1;
    // public float texStrength_D3;
    // public float texStrength_D5;

    public void UpdateBlendShapeValueByLocation(ARKitBlendShapeLocation location, float value)
    {
        if (location == blinkBlendShape.blendShapeLocation)
        {
            blinkBlendShape.value = value;
            return;
        }
        if (location == wideBlendShape.blendShapeLocation)
        {
            wideBlendShape.value = value;
            return;
        }

        Debug.LogError("No blendshape '" + location.ToString() + "' exists on in LashData");
    }

}
