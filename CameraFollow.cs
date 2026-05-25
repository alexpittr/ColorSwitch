using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transform.position.y < player.position.y)
        {
            transform.position = new Vector3 (transform.position.x, player.position.y, transform.position.z);
        }
        
    }
}
