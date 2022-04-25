using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Eye {
    None,
    LeftEye,
    RightEye
}

public class LashManipulator : MonoBehaviour
{
    [SerializeField] string eye;
    [SerializeField] BlendShapeMappings mappings;
    [SerializeField] SkinnedMeshRenderer meshRenderer;
   
    //  START
    //  1. parse eye identifier
    //  2. setup reference to mapping data (generic?)
    private void Start() {
        
    }

    //  UPDATE
    //  assign mapping data to lash blend shapes
    private void Update() {
        // meshRenderer.SetBlendShapeWeight(0, mappings.Mappings.First());
    }
}
