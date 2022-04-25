using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARFace))]
public class ARKitLashBlendShapeConverter : MonoBehaviour
{
    [SerializeField]
    private LashData lashDataLeft = null;

    [SerializeField]
    private LashData lashDataRight = null;

    private ARKitFaceSubsystem arKitFaceSubsystem;


    private Dictionary<ARKitBlendShapeLocation, LashData>
        faceArkitBlendShapeLashDataMap =
            new Dictionary<ARKitBlendShapeLocation, LashData>();

    private ARFace face;

    void Awake()
    {
        face = GetComponent<ARFace>();
        CreateFeatureBlendMapping();
    }

    void CreateFeatureBlendMapping()
    {

        faceArkitBlendShapeLashDataMap[lashDataLeft
            .blinkBlendShape
            .blendShapeLocation] = lashDataLeft;
        faceArkitBlendShapeLashDataMap[lashDataLeft
            .wideBlendShape
            .blendShapeLocation] = lashDataLeft;
        faceArkitBlendShapeLashDataMap[lashDataRight
            .blinkBlendShape
            .blendShapeLocation] = lashDataRight;
        faceArkitBlendShapeLashDataMap[lashDataRight
            .wideBlendShape
            .blendShapeLocation] = lashDataRight;
    }

    void UpdateVisibility()
    {
        var visible =
            enabled &&
            (face.trackingState == TrackingState.Tracking) &&
            (ARSession.state > ARSessionState.Ready);
    }

    void OnEnable()
    {
        var faceManager = FindObjectOfType<ARFaceManager>();

        if (faceManager != null && faceManager?.subsystem != null)
        {
            arKitFaceSubsystem = (ARKitFaceSubsystem)faceManager?.subsystem;
        }

        UpdateVisibility();

        face.updated += OnUpdated;
        ARSession.stateChanged += OnSystemStateChanged;
    }

    void OnDisable()
    {
        face.updated -= OnUpdated;
        ARSession.stateChanged -= OnSystemStateChanged;
    }

    void OnSystemStateChanged(ARSessionStateChangedEventArgs eventArgs)
    {
        UpdateVisibility();
    }

    void OnUpdated(ARFaceUpdatedEventArgs eventArgs)
    {
        UpdateVisibility();
        UpdateFaceFeatures();
    }

    void UpdateFaceFeatures()
    {
        using (
            var blendShapes =
                arKitFaceSubsystem
                    .GetBlendShapeCoefficients(face.trackableId, Allocator.Temp)
        )
        {

            
            foreach (var featureCoefficient in blendShapes)
            {
                LashData tempLashData;
                if (faceArkitBlendShapeLashDataMap.TryGetValue(featureCoefficient.blendShapeLocation, out tempLashData))
                {
                    tempLashData.UpdateBlendShapeValueByLocation(featureCoefficient.blendShapeLocation, featureCoefficient.coefficient * tempLashData.blendshapeCoefficientScale);
                }
            }
        }
    }
}
