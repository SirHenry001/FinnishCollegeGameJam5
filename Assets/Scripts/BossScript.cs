using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform target;

    [Header("GameObject Variables")]
    public GameObject shortAttackWeapon;
    public GameObject longAttackCheckObj;
    public GameObject longAttackWeapon_One;
    public GameObject longAttackWeapon_Two;

    [Header("GameObject Spawnpoints")]
    public GameObject shortAttackSpawnPos;
    public GameObject[] longAttactSpawnPoint;

    [Header("Booleans")]
    public bool attackLoopOn;
    public bool longAttackProgress;
    public bool longAttackStart;
    public bool shortAttackprogress;
    public bool checkPositionLock;

    [Header("Timers for attacks")]
    //longattack timer variables
    public float longAttackIntervalTime;
    public float longAttackCoolDownTime;
    // time when check object follows target
    public float isCounting;
    public float isCountingStatic;

    public float longAttacktimeDefault;
    public float isCountingDefault;
    public float isCountingStaticDefault;

    //distance to short attack
    public float f2fDist;

    private void Awake()
    {
        longAttackCheckObj.GetComponent<Renderer>().enabled = false;
        attackLoopOn = true;
        longAttackIntervalTime = longAttacktimeDefault;
        isCounting = isCountingDefault;
        isCountingStatic = isCountingStaticDefault;


    }

    private void Update()
    {
     
        float distToPlayer = Vector3.Distance(transform.position, target.transform.position);
        if (distToPlayer < f2fDist && !shortAttackprogress && longAttackIntervalTime > 0)
        {
            shortAttackprogress = true;
            StartCoroutine(AttackShort());
        }

        if(!longAttackProgress)
        {
            longAttackCheckObj.GetComponent<Renderer>().enabled = false;
            longAttackIntervalTime -= Time.deltaTime;
        }

        if (longAttackIntervalTime <= 0)
        {
            longAttackCheckObj.GetComponent<Renderer>().enabled = true;
            longAttackIntervalTime = 0;
            longAttackProgress = true;
            AttackLongCheck();
        }

        longAttackCheckObj.transform.position = new Vector3(target.transform.position.x, target.position.y + 10f, target.transform.position.z);


    }

    public void AttackLongCheck()
    {
        //tähän sitten apufunkitioihin meno jos halua varioida kahden+ eri hyökkäyksen välillä
        // if lauseke tsek = 
        // funktio 1
        // funktio 2


        longAttackCheckObj.GetComponent<Renderer>().material.color = Color.yellow;
        isCounting -= Time.deltaTime;
        
        if (isCounting <= 0)
        {
            checkPositionLock = true;
            isCounting = 0;
            longAttackCheckObj.GetComponent<Renderer>().material.color = Color.red;
            isCountingStatic -= Time.deltaTime;
            if(isCountingStatic <= 0 && !longAttackStart)
            {
                isCountingStatic = 0;
                longAttackStart = true;
                StartCoroutine(LongAttack());
            }

        }
    }

    IEnumerator LongAttack()
    {
        longAttackCheckObj.GetComponent<Renderer>().enabled = false;
        //Hyökkäys tähän
        Instantiate(longAttackWeapon_One, longAttactSpawnPoint[0].transform.position, longAttactSpawnPoint[0].transform.rotation);
        Instantiate(longAttackWeapon_One, longAttactSpawnPoint[1].transform.position, longAttactSpawnPoint[1].transform.rotation);
        Instantiate(longAttackWeapon_One, longAttactSpawnPoint[2].transform.position, longAttactSpawnPoint[2].transform.rotation);

        yield return new WaitForSeconds(2f);
        longAttackIntervalTime = longAttacktimeDefault;
        isCounting = isCountingDefault;
        isCountingStatic = isCountingStaticDefault;
        longAttackProgress = false;
        longAttackStart = false;
        checkPositionLock = false;
    }
    IEnumerator AttackShort()
    {
        Debug.Log("Short Attack start");
        yield return new WaitForSeconds(2f);
        Instantiate(shortAttackWeapon, shortAttackSpawnPos.transform.position, shortAttackSpawnPos.transform.rotation);
        Debug.Log("Short Attack end");
        yield return new WaitForSeconds(5f);
        Debug.Log("Short Attack CoolDown");
        shortAttackprogress = false;
    }




}
