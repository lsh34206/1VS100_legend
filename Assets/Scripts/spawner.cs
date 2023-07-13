using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab; // 생성할 프리팹 오브젝트
    }

    public SpawnableObject[] objectsToSpawn; // 생성할 오브젝트 배열
    public float currentCoolTime = 0.1f; // 현재 쿨타임

    private float coolTime; // 쿨타임
    private float timer; // 타이머

    private void Start()
    {
    
        StartCoroutine( "spon_coru", 0.8f );
    }
    IEnumerator spon_coru(float delayTime)
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        SpawnableObject randomObject = objectsToSpawn[randomIndex];
        GameObject spawnedObject = Instantiate(randomObject.prefab, transform.position, Quaternion.identity); // 랜덤한 프리팹 생성
        Renderer renderer = spawnedObject.GetComponent<Renderer>();
        yield return new WaitForSeconds(delayTime);
        StartCoroutine( "spon_coru", 0.8f );
    }
  

    private void Update()
    {
  
     
    }
    
    

}







