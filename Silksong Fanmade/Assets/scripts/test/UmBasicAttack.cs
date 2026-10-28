using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmBasicAttack : MonoBehaviour
{
    public GameObject projectile;

    public GameObject penumbra;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
        mainCamera = FindObjectOfType<Camera>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        

        //Face mouse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.yellow);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
          if (Input.GetMouseButtonDown (0))  
        {
            
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
         RaycastHit hit;
         if (Physics.Raycast (ray, out hit, 10000.0f)) 
            {
                Debug.Log("golpeo");
            Vector3 hitPoint = hit.point;
            //Instantiate(penumbra, transform.position, transform.rotation);
            //penumbra.transform.position = hitPoint;
            }
            GameObject bullet = (GameObject)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            

            Destroy (bullet.gameObject, 2);
        }
    }

}
