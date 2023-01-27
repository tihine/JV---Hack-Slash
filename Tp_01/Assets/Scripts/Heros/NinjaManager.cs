using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class NinjaManager : PlayerManager
{
    public UnityEvent OnThrowKunai = new UnityEvent();
    public UnityEvent OnStartInvisibility = new UnityEvent();
    public UnityEvent OnEndInvisibility = new UnityEvent();

    private float katanaRange = 5f;
    private int katanaDamage = 10;
    private float kunaiSpinDuration = 2f;
    private float kunaiThrowInterval = 0.25f;
    private float kunaiSpinSpeed = 45f;
    [SerializeField] private GameObject smokescreen;
    private float smokescreenDuration = 3f;

    //Needed to temporarily disable player-enemy collisions:
    private int playerLayer;
    private int enemyLayer;

    //Set to true to disable Ninja automatic player orientation;
    private bool kunaiSpinning;
    
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

    protected override void Orient() //Override so Ninja can KunaiSpin
    {
        if (kunaiSpinning) return;
        transform.LookAt(orientRefPt);
        attackDir = (orientRefPt - transform.position).normalized;
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

    void KatanaStrike()
    {
        if (Physics.Raycast(transform.position, attackDir, out RaycastHit hit, katanaRange))
        {
            hit.collider.SendMessage("AddDamage", katanaDamage);
        }
    }

    protected override void Action2() //KunaiSpin
    {
        animator.SetBool("Kunai", true);
        Debug.Log("KunaiSpin started");
        StartCoroutine(KunaiSpin());
    }

    private IEnumerator KunaiSpin()
    {
        kunaiSpinning = true;
        float throwingTime = 0f;
        while (throwingTime < kunaiSpinDuration)
        {
            OnThrowKunai?.Invoke();
            yield return new WaitForSeconds(kunaiThrowInterval);
            throwingTime += kunaiThrowInterval;
            transform.RotateAround(transform.position, Vector3.up, kunaiSpinSpeed);
        }
        kunaiSpinning = false;
        yield return null;
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
