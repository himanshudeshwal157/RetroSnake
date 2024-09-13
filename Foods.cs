using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    [SerializeField] BoxCollider2D Boundary;
    
    void Start()
    {
        SpawnFoodPosition();
       
        
    }

  
    
    
    void SpawnFoodPosition()
        {
            Bounds bounds = this.Boundary.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            this.transform.position = new Vector3 (Mathf.Round(x),Mathf.Round(y),0.0f);

        }
        void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.tag == "Player")
            {
                SpawnFoodPosition();
            }
            
        }
        
}
