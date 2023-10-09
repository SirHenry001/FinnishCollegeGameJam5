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
    public float rotationSpeed;

    public float delayTime;
    public float bulletDistance = 10f;

    private void Awake()
    {

    }

    public void Shoot()
    {
        /*
        if(!core.shootCoolDown)
        {
            Vector3 forward = shotPoint.transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(shotPoint.transform.position, forward, Color.green);
            Instantiate(bulletPreFab, shotPoint.transform.position, shotPoint.transform.rotation);
            StartCoroutine(ShotCoolDown());
        }
        */

        if (!core.shootCoolDown)
        {
            RaycastHit hit;
            {
                GameObject bullet = Instantiate(bulletPreFab, shotPoint.transform.position, Quaternion.identity, bulletParent);
                AmmoScript bc = bullet.GetComponent<AmmoScript>();

                if (Physics.Raycast(core.cameraTransform.position, core.cameraTransform.forward, out hit, Mathf.Infinity))
                {
                    bc.Target = hit.point;
                    bc.Hit = true;
                }
                else
                {
                    bc.Target = core.cameraTransform.position + core.cameraTransform.forward * bulletDistance;// iof the raycast doesnt hit enything, it goe forward direction from camera
                    bc.Hit = false;
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

    public void LookFinal()
    {
        float targetAngle = core.cameraTransform.eulerAngles.y; // give the targetAngle the axis y rotation angle towards cmaeraTransfrom
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0); // internal variable targetrotation which defines the axis where to rotate based on targetAngle
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Rotate the PLayer between two points and certain rotationSpeed variable
    }

}
