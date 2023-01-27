using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiSpawner : MonoBehaviour
{
    private NinjaManager ninjaMgr;
    [SerializeField] private GameObject kunai;
    
    // Start is called before the first frame update
    void Start()
    {
        ninjaMgr = GameObject.FindWithTag("Player").GetComponent<NinjaManager>();
        ninjaMgr.OnThrowKunai.AddListener(ThrowKunai);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ThrowKunai()
    {
        Instantiate(kunai, transform.position, Quaternion.identity);
    }
}
