using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NinjaManager : PlayerManager
{
    public UnityEvent OnStartInvisibility = new UnityEvent();
    public UnityEvent OnEndInvisibility = new UnityEvent();
    
    [SerializeField] private GameObject smokescreen;
    private float smokescreenDuration = 3f;
    
    //Needed to temporarily disable player-enemy collisions:
    private int playerLayer;
    private int enemyLayer;
    
    // Start is called before the first frame update
    private new void Start()
    {
        maxHealth = 45;
        cooldown1 = 1f;
        cooldown2 = 5f;
        cooldown3 = 20f;

        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Ennemy");
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
    }

    protected override void EndAction1()
    {
        EndKatanaAnimation();
    }

    void EndKatanaAnimation()
    {
        animator.SetBool("Katana", false);
    }

    protected override void Action2() //KunaiSpin
    {
        throw new System.NotImplementedException();
    }
    
    protected override void Action3() //Smokescreen
    {
        animator.SetBool("Smoke", true);
        StartCoroutine(InvisibilityManager());
    }

    //Using Animation Events, disable player-enemy collisions so Ninja can roll away from enemies, then enable collisions:
    private void DisableCollisions()
    {
        Physics.IgnoreLayerCollision(playerLayer, enemyLayer, true);
    }
    
    private void EnableCollisions()
    {
        Physics.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        animator.SetBool("Smoke", false);
    }

    private IEnumerator InvisibilityManager()
    {
        OnStartInvisibility?.Invoke();
        smokescreen.SetActive(true);
        yield return new WaitForSeconds(smokescreenDuration);
        smokescreen.SetActive(false);
        OnEndInvisibility?.Invoke();
    }
}
