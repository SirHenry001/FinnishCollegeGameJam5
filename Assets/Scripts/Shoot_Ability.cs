using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Ability : MonoBehaviour
{
    //PLAYER CORE COMPONENT
    public PlayerCore core;

    //SHOOTING VARIABLES
    public GameObject shotPoint;
    public GameObject sightPos;
    public GameObject bulletPreFab;
    public Transform bulletParent;


    public float delayTime;
    public float bulletDistance = 10f;

    private void Awake()
    {

    }

    public void Shoot()
    {

        AudioManager.instance.PlaySoundFX(Random.Range(0,4));

        if (!core.shootCoolDown)
        {
            core.anim.SetTrigger("Shoot");
            core.rb.velocity = Vector3.zero;
            RaycastHit hit;
            {
                GameObject bullet = Instantiate(bulletPreFab, shotPoint.transform.position, Quaternion.identity, bulletParent);
                AmmoScript ammoScript = bullet.GetComponent<AmmoScript>();

                if (Physics.Raycast(core.cameraTransform.position, core.cameraTransform.forward, out hit, Mathf.Infinity))
                {
                    ammoScript.Target = hit.point;
                    ammoScript.Hit = true;
                }
                else
                {
                    ammoScript.Target = core.cameraTransform.position + core.cameraTransform.forward * bulletDistance;// iof the raycast doesnt hit enything, it goe forward direction from camera
                    ammoScript.Hit = false;
                }
            }
            StartCoroutine(ShotCoolDown());
        }
    }

    IEnumerator ShotCoolDown()
    {
        core.shootCoolDown = true;
        yield return new WaitForSecondsRealtime(delayTime);
        core.shootCoolDown = false;
    }



}
