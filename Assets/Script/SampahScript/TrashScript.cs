using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrashScript : MonoBehaviour
{
    public SampahInformation sampahInformation;
    Renderer rend;
    private void Start() {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;
        rend.sharedMaterial = sampahInformation.materialSampah;
    } 

}
