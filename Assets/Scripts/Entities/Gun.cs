using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private GameObject focalPoint;
    private Transform pivot;

    // [SerializeField] GameObject projectile;
    private bool reloadRequired = false;
    [SerializeField] float reloadSpeed;

    private GameObject shootingPoint;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        shootingPoint = transform.Find("Shooting Point").gameObject;

        pivot = focalPoint.transform;
        transform.parent = pivot;
    }

    // Update is called once per frame
    void Update()
    {
        // Position the gun
        pivot.position = focalPoint.transform.position;
        pivot.rotation = Quaternion.AngleAxis(getAimAngle() - 90, Vector3.forward);
    }

    public void Fire()
    {
        if (!reloadRequired)
        {
            reloadRequired = true;

            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = shootingPoint.transform.position;
                bullet.transform.rotation = Quaternion.AngleAxis(getAimAngle() - 90, Vector3.forward);
                bullet.SetActive(true);
            }

            // Instantiate(projectile, shootingPoint.transform.position, Quaternion.AngleAxis(getAimAngle() - 90, Vector3.forward));

            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        reloadRequired = false;
    }

    private float getAimAngle()
    {
        Vector3 playerVector = Camera.main.WorldToScreenPoint(focalPoint.transform.position);
        playerVector = Input.mousePosition - playerVector;
        float angle = Mathf.Atan2(playerVector.y, playerVector.x) * Mathf.Rad2Deg;

        return angle;
    }
}
