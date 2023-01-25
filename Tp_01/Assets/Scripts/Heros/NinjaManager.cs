using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaManager : PlayerManager
{
    private Collider collider;
    // Start is called before the first frame update
    private new void Start()
    {
        maxHealth = 45;
        cooldown1 = 1f;
        cooldown2 = 20f;
        cooldown3 = 5f;

        collider = GetComponent<Collider>();
        base.Start();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }

    protected override void Action1() //KatanaSlice
    {
        animator.SetBool("Katana", true);
        Invoke("EndKatanaAnimation", 1.5f);
    }

    void EndKatanaAnimation()
    {
        animator.SetBool("Katana", false);
    }

    protected override void Action2() //Smokescreen
    {
        throw new System.NotImplementedException();
    }

    private void DisableCollider()
    {
        collider.enabled = false;
    }
    
    private void EnableCollider()
    {
        collider.enabled = true;
    }

    protected override void Action3() //KunaiSpin
    {
        throw new System.NotImplementedException();
    }
}
