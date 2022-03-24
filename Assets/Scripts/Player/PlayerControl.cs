using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    
    [SerializeField] private Transform firepoint;
    [SerializeField] private int damage = 10;
    [SerializeField] private int range = 10;
    [SerializeField] private float moveSpeed;
        
    private Camera mainCamera;
    private Rigidbody myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 newVelocity = new Vector3(inputHorizontal * moveSpeed, 0.0f, inputVertical * moveSpeed);
        myRb.velocity = newVelocity;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        if (Input.GetMouseButtonDown(0))
            Shoot();        
    }

    private void Shoot()
    {
        RaycastHit hit;
        Ray ray = new Ray(firepoint.position, firepoint.forward);

        if (Physics.Raycast(ray, out hit, range))
        {            
            EnemyBase target = hit.transform.GetComponent<EnemyBase>();
            if (target != null)
                target.TakeDamage(damage);
                       
            ParticleFX.Instance.PlayExplosionFX(hit.point);
        }
    }
}
