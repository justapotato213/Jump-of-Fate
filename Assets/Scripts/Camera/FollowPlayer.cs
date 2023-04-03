using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // get player position, set as camera position and apply offset
        transform.position = target.position + offset;
    }
}
