using UnityEngine;

public class Trash : MonoBehaviour
{
    protected MeshRenderer meshRenderer;

    [SerializeField]
    protected SampahInformation sampahInformation;

    public SampahInformation SampahInformation
    {
        get => sampahInformation;
        set => sampahInformation = value;
    }

    protected Rigidbody rigidBody;

    protected void Start() 
    {
        // meshRenderer = GetComponent<MeshRenderer>();
        // meshRenderer.sharedMaterial = sampahInformation.materialSampah;
        rigidBody = GetComponent<Rigidbody>();
    }
}