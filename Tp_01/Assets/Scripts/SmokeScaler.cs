using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScaler : MonoBehaviour
{
    [SerializeField]
    [Range(0,20)]
    int scale = 10;
    // Start is called before the first frame update
    void Start()
    {
        var psys = GetComponentsInChildren<ParticleSystem>();
        foreach (var ps in psys)
        {
            var main = ps.main;
            main.scalingMode = ParticleSystemScalingMode.Local;
            ps.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
