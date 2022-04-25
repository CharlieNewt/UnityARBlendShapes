using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class LashManipulator : MonoBehaviour
{
    [SerializeField] LashData lashData;
    [SerializeField] SkinnedMeshRenderer meshRenderer;


    //  UPDATE
    //  assign mapping data to lash blend shapes
    private void Update() {
        meshRenderer.SetBlendShapeWeight(0, lashData.blinkBlendShape.value);
        meshRenderer.SetBlendShapeWeight(1, lashData.wideBlendShape.value);
        meshRenderer.SetBlendShapeWeight(2, lashData.curl);
        meshRenderer.SetBlendShapeWeight(3, lashData.length);
        meshRenderer.SetBlendShapeWeight(4, lashData.width);
    }
}
