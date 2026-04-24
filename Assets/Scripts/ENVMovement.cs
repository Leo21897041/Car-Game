using UnityEngine;

public class ENVMovement : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }
    
    void Update()
    {
        Player playerScript = player.GetComponent<Player>();       
        
        transform.position -= Time.deltaTime * playerScript.currentSpeed * transform.right;        
    }
}
