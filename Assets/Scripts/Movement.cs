using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float normalSpeed = 3f;
    public float currentSpeed;

    public string nextSceneName;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {   // 자동으로 왼쪽에서 오른쪽으로 이동
        Vector3 movement = new Vector3(-currentSpeed, 0f, 0f);
        transform.Translate(movement * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            SceneManager.LoadScene(nextSceneName);  
        }
    }
}