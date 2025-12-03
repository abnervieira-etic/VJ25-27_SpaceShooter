using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject bullet;
    Vector2 destination;

    [SerializeField] float pewpewRate = 1;

    void Start()
    {

        InvokeRepeating("PewPew", 0, pewpewRate);
    }
    void Update()
    {
       Movement();
    }

    void FixedUpdate()
    {
        
        Vector2 positionInBetween = Vector2.Lerp(transform.position,destination,speed *Time.fixedDeltaTime); // a c retorna b
        transform.position = positionInBetween;
        
    } 
    void Movement()
    {
         Camera cam = Camera.main;

       
        if (Input.touchSupported && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(
                touch.position.x,
                touch.position.y,
                cam.nearClipPlane  
            ));

            worldPos.z = transform.position.z;

            destination = worldPos;
        }

       
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                cam.nearClipPlane
            ));

            mousePos.z = transform.position.z;

            destination = mousePos;
        }
        else
        {
            destination = transform.position;
        }
    }
    void PewPew()
    {   
        
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}