using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fan_text_ctrl : MonoBehaviour
{
    Color color;
    public SpriteRenderer img;
 public int alpha=255;
    // Start is called before the first frame update
    void Start()
    {
     alpha=255;





        Destroy(gameObject,1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=new Vector3(0,2f*Time.deltaTime,0);
      
        alpha-=2;
   color=new Color(img.color.r, img.color.g, img.color.b, 1f);
   img.color=color;
        


    }
}
