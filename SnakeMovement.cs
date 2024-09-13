using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

   
    Vector2 direction = Vector2.right;

    // List of snake body segments
    List<Transform> segments = new List<Transform>();

    
    [SerializeField] Transform segmentPrefab;

    
    [SerializeField] int initialSize = 5;

    
    [SerializeField] Color normalColor = Color.yellow;
    [SerializeField] Color reversedColor = Color.red;

   
    private bool isReversed = false;

    
    void Start()
    {
       
        ResetTheGame();
    }

    
    void Update()
    {
        
        UserInput();
    }

   
    void UserInput()
    {
        
        if (isReversed)
        {
            
            ReverseMovement();
        }
        else
        {
         
            NormalMovement();
        }

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleReversal();
        }
    }

    
    void NormalMovement()
    {
       
        if (Input.GetKeyDown(KeyCode.W)) 
            direction = Vector2.up;       
        else if (Input.GetKeyDown(KeyCode.S)) 
            direction = Vector2.down;     
        else if (Input.GetKeyDown(KeyCode.A)) 
            direction = Vector2.left;   
        else if (Input.GetKeyDown(KeyCode.D)) 
            direction = Vector2.right;   
    }

   
    void ReverseMovement()
    {
        
        if (Input.GetKeyDown(KeyCode.W)) 
            direction = Vector2.down;    
        else if (Input.GetKeyDown(KeyCode.S)) 
            direction = Vector2.up;     
        else if (Input.GetKeyDown(KeyCode.A)) 
            direction = Vector2.right;    
        else if (Input.GetKeyDown(KeyCode.D)) 
            direction = Vector2.left;   
    }

    
    void FixedUpdate()
    {
        // Move each segment to  position of the previous segment
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

       
        this.transform.position = new Vector3
        (
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f 
        );
    }

    
    public void GrowSnake()
    {
        // Instantiate a new segment at the position of the last segment
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        
        segments.Add(segment);
    }

    
    void ResetTheGame()
    {
        // Destroy all segments except the head
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        // Clear the list of segments and add the snake's head back in
        segments.Clear();
        segments.Add(this.transform);

        // Rebuild the snake to its initial size
        for (int i = 1; i < this.initialSize; i++)
        {
            segments.Add(Instantiate(this.segmentPrefab));
        }

      
        this.transform.position = Vector3.zero;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Food")
        {
            
            GrowSnake();
            Score.instance.AddPoints();
        }
       
        else if (other.tag == "obstacle")
        {
            
            ResetTheGame();
        }
    }

    // Toggles the snake's movement direction and changes its color
    void ToggleReversal()
    {
        // Toggle (true/false)
        isReversed = !isReversed;

        // Change the snake's (normal or reversed)
        Color currentColor = isReversed ? reversedColor : normalColor;

        
        NewSnakeColor(currentColor);
    }

    // Changes the color of all snake segments
    void NewSnakeColor(Color newColor)
    {
        
        foreach (Transform segment in segments)
        {
            segment.GetComponent<SpriteRenderer>().color = newColor;
        }
    }
            
}
