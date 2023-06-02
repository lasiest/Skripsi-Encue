using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sampah", menuName = "Sampah Information")]
public class SampahInformation : ScriptableObject
{
    public string namaSampah;
    public enum tipeSampahEnum{
        None,
        Organik,
        Anorganik, 
        Beracun
    };
    public tipeSampahEnum tipeSampah; 
    public int poinSampah;
    public Material materialSampah;

}
