using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireballEvent : UnityEvent
{
}

public class MageManager : PlayerManager
{
    public FireballEvent OnMakeFireball = new FireballEvent();
    // Start is called before the first frame update
    private new void Start()
    {
        maxHealth = 40;
        base.Start();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }

    protected override void Action1()
    {
        OnMakeFireball?.Invoke();
    }

    protected override void Action2()
    {
        throw new System.NotImplementedException();
    }

    protected override void Action3()
    {
        throw new System.NotImplementedException();
    }
}
