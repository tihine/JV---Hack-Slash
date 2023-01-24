using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaManager : PlayerManager
{
    // Start is called before the first frame update
    private new void Start()
    {
        maxHealth = 45;
        cooldown1 = 1f;
        cooldown2 = 20f;
        cooldown3 = 5f;
        base.Start();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }

    protected override void Action1() //KatanaSlice
    {
        throw new System.NotImplementedException();
    }

    protected override void Action2() //Smokescreen
    {
        throw new System.NotImplementedException();
    }

    protected override void Action3() //KunaiSpin
    {
        throw new System.NotImplementedException();
    }
}
