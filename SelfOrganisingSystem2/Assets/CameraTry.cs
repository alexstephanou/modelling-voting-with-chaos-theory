using UnityEngine;
 
public class CameraTry:MonoBehaviour 
{
    public float speed = 0f;
    public GameObject target;
 
    void Update() {
        transform.RotateAround(target.transform.position, 0*Vector3.up, speed * Time.deltaTime);
        
    }
}