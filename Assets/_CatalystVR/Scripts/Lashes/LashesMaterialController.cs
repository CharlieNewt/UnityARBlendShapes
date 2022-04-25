using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LashesMaterialController : MonoBehaviour
{
    [SerializeField] private Material lashesMaterial;

    int currentTex = 1;


    // private void LateUpdate()
    // {
    //     lashesMaterial.SetFloat("_D1", lashData.texStrength_D1);
    //     lashesMaterial.SetFloat("_D3", lashData.texStrength_D3);
    //     lashesMaterial.SetFloat("_D5", lashData.texStrength_D5);
    // }

    public void NextLashTexture()
    {        
        currentTex = ++currentTex % 3;

       lashesMaterial.SetFloat("_D1", currentTex == 0 ? 1 : 0);
       lashesMaterial.SetFloat("_D3", currentTex == 1 ? 1 : 0);
       lashesMaterial.SetFloat("_D5", currentTex == 2 ? 1 : 0);
    }
}
