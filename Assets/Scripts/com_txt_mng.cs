using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class com_txt_mng : MonoBehaviour
{
    Color color;
    Text text;
 public int alpha=255;
    // Start is called before the first frame update
    void Start()
    {
     alpha=255;
   text = GetComponent<Text>();
   color=new Color(255/255f,0/255f,0/255f,alpha/255f);
   text.color=color;



        Destroy(gameObject,1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "-"+(GameObject.Find("Com").GetComponent<com>().my_at).ToString();
        transform.Translate(new Vector3(0,0.25f,0));
        alpha-=1;
   color=new Color(255/255f,0/255f,0/255f,alpha/255f);
   text.color=color;
        


    }
}
