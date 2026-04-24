using UnityEngine;

public class ENVMovement : MonoBehaviour
{
    public float currentSpeedENV;
    public float moveSpeedENV;
    public float playerSpeed;

    public int xMin;
    public int xMax;
    void Start()
    {

    }



    void Update()
    {     
        currentSpeedENV = Time.deltaTime * moveSpeedENV;

        transform.position -= currentSpeedENV * transform.right;

        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (transform.position.x < 0 - xMin || transform.position.x > Screen.width + xMax)
        {
            Destroy(gameObject);
        }        
    }
}
