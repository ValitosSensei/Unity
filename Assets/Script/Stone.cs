using UnityEngine;
public class Stone : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.tag =="Player2"){
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag =="Ground")
        {
            Destroy(this.gameObject);
        }
    }
        
    
}
