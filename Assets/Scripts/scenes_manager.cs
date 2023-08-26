using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes_manager : MonoBehaviour
{
    public void to_main()
    {
  
        SceneManager.LoadScene(3);
    
    }
    
    public void to_over()
    {
  
        SceneManager.LoadScene(6);
    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
