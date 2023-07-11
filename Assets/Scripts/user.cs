using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user : MonoBehaviour
{
    public Slider user_hp; // 사용자의 체력을 표시하는 슬라이더
    private Animator animator; // 애니메이터
    public Animator otherAnimator; // 애니메이터

    public float maxhp = 100; // 최대 체력
    public float curhp = 100; // 현재 체력

    private com comScript; // com 스크립트
   public AudioSource audioSource;

    public AudioClip audioClip;

    
        public AudioClip audioClip_die;
    private void Awake()
    {
        comScript = FindObjectOfType<com>(); // com 스크립트 가져오기
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
    }
public void barctrl(){
      user_hp.value = (float)curhp / (float)maxhp; // 현재 체력을 슬라이더에 반영
        //Time.timeScale = 0.5f;
}
    void Start()
    {
        user_hp.value = (float)curhp / (float)maxhp; // 현재 체력을 슬라이더에 반영
        //Time.timeScale = 0.5f;
    }
bool die_bool = false;
    void Update()
    {
        HandleHp(); // 체력 업데이트

        if (curhp <= 0)
        {
            if(GameObject.Find("Canvas").GetComponent<GameManager>().respon_lv==true){
curhp=maxhp/2;
user_hp.value = (float)curhp / (float)maxhp; // 현재 체력을 슬라이더에 반영
            }else{
                     string savedData = comScript.scoretext.text; // com 스크립트에서 텍스트 가져오기

            GameObject bestTextObject = GameObject.Find("BestText"); // "BestText" 오브젝트 찾기
            if (bestTextObject != null)
            {
                Text bestText = bestTextObject.GetComponent<Text>(); // "BestText" 오브젝트에서 Text 컴포넌트 가져오기
                if (bestText != null)
                {
                    bestText.text = savedData; // "BestText" 텍스트 업데이트
                    if(die_bool){
   die_bool=false;
                    }else{
                           
  Time.timeScale = 0;
   

                }
            }
       
            }

            comScript.ResetHealth(); // com 스크립트의 체력 초기화
            comScript.showQuestionMark = false; // com 스크립트에서 물음표 표시를 비활성화
            comScript.UpdateScoreText(); // com 스크립트의 점수 텍스트 업데이트

          
        }
        }
        else
        {
            user_hp.value = curhp / maxhp; // 현재 체력을 슬라이더에 반영
        }
    }
    

    private void HandleHp()
    {
        user_hp.value = (float)curhp / (float)maxhp; // 현재 체력을 슬라이더에 반영
    }

    public void DefenseFail(float amount)
    {
        if(GameObject.Find("Canvas").GetComponent<GameManager>().bobble_lv){
            GameObject.Find("Canvas").GetComponent<GameManager>().bobble_lv=false;
        }else{
                 audioSource.clip=audioClip;
      audioSource.Play();
        otherAnimator.SetTrigger("Attack"); // 공격 애니메이션을 재생
        curhp -= amount; // 현재 체력 감소
        curhp = Mathf.Clamp(curhp, 0, maxhp); // 현재 체력이 최대 체력을 넘지 않도록 제한
        }

    }

    }
