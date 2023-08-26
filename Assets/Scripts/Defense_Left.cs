using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense_Left : MonoBehaviour
{
    private com comScript;
    private user userScript;
 

    private bool isInsideBox = false;
    private bool BoxCenter = false;

    private float moveSpeed = 20f;
 
    public int aim_lv;
 
    private void Start()
    {
  
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
       
    }


void OnTriggerEnter2D(Collider2D other) 
    {
        isInsideBox=true;
  if(other.gameObject.name=="perfect_col"){
            aim_lv=1;
        }
        
        if(other.gameObject.name=="good_col"){
   aim_lv=2;
   
        }
        
        if(other.gameObject.name=="ok_col"){
   aim_lv=3;
    
        }
        
        if(other.gameObject.name=="fail_col"){
   aim_lv=4;
     
        }else if (other.gameObject.name == "x_col")
        {
    
            
         

            GameObject.Find("User").GetComponent<user>().curhp--;
            GameObject.Find("User").GetComponent<user>().barctrl();
       
        }
    
       
          
    
}

void OnTriggerExit2D(Collider2D other) 
    {
      
        isInsideBox=false;
     
}



    private void Update()
    {   if (GameObject.Find("Canvas").GetComponent<GameManager>().slow_lv)
        {
            GameObject.Find("Canvas").GetComponent<GameManager>().move_speed = 7f;
            GameObject.Find("Canvas").GetComponent<GameManager>().slow_lv = false;
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<GameManager>().move_speed+=0.00001f;
        }
          moveSpeed = GameObject.Find("Canvas").GetComponent<GameManager>().move_speed;
  Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
                if (Input.GetKeyDown(KeyCode.LeftArrow)==true&&isInsideBox==true) {
                         comScript.Defense(0);
           Destroy(gameObject);
          if(aim_lv==1){
            
            GameObject.Find("Com").GetComponent<com>().pf_txt();
          
           }else if(aim_lv==2){
            
            GameObject.Find("Com").GetComponent<com>().good_txt();
             
           }else if(aim_lv==3){
            
            GameObject.Find("Com").GetComponent<com>().ok_txt();
         
           }else if(aim_lv==4){
            
            GameObject.Find("Com").GetComponent<com>().fail_txt();
           }
        }else if(isInsideBox==true && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))){
               userScript.DefenseFail(20);
            Destroy(gameObject);
        }
    }
}
