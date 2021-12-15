using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    int scoreNumber;
    [SerializeField] AudioClip appleEat;
    [SerializeField] AudioClip crash;

    [SerializeField] TextMeshProUGUI score;
    //[SerializeField] TextMeshProUGUI endGameScore;
    int endGameScoreNumber;
    
    private void Start() {
       // this.scoreNumber = 0;
        
        ResetState();
    }
    
    
    private void Update() {
        HandleInput();
    }

    private void FixedUpdate() {
        for(int i = segments.Count -1; i > 0; i--){
            segments[i].position = segments[i -1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y) + direction.y,0.0f);
    }

    private void Grow(){
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count -1].position;
        segments.Add(segment);
    }

    private void ResetState(){
        for(int i = 1; i < segments.Count; i++){
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);
        this.transform.position = Vector3.zero;
        //scoreNumber = 0;
        score.text = scoreNumber.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Food"){
            GetComponent<AudioSource>().PlayOneShot(appleEat);
            Grow();
            scoreNumber += 10;
            endGameScoreNumber += 10;
            
            score.text = scoreNumber.ToString();
            
        }else if (other.tag == "Wall" || other.tag == "Body"){      

            GetComponent<AudioSource>().PlayOneShot(crash);
            SceneManager.LoadScene(2);
            ResetState();
            //endGameScore.text = endGameScoreNumber.ToString();
        }
        
    }

    private void HandleInput(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
             if(direction != Vector2.down){
                   direction = Vector2.up;
                   transform.eulerAngles = new Vector3(0, 0, 0);
        
               } 
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
              if(direction != Vector2.up){
                direction = Vector2.down;
                transform.eulerAngles = new Vector3(0, 0, 180);
               }       
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
              if(direction != Vector2.right){
                direction = Vector2.left;
                transform.eulerAngles = new Vector3(0, 0, 90);
               } 
        }else if(Input.GetKeyDown(KeyCode.RightArrow)){
             if(direction != Vector2.left){
                 direction = Vector2.right;
                 transform.eulerAngles = new Vector3(0, 0, 270);
               } 
        }   

              
    }

    public void LoadEndMenu(){
        SceneManager.LoadScene(2);
        
    }

    public void LoadNewGame(){
        SceneManager.LoadScene(1);
        
    }

    public int GetScore(){
        return endGameScoreNumber;
    }
}
