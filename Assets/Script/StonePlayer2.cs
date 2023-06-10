using UnityEngine;

public class StonePlayer2 : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
private void Start() {
       
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" ){
            Destroy(other.gameObject);
        }
        
        else if(other.gameObject.tag =="Ground"){
            Destroy(this.gameObject);
        }
    }
}
