using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class com : MonoBehaviour
{
    public Slider com_hp; // 컴퓨터의 체력을 표시하는 슬라이더
    private Animator animator; // 애니메이터
    public Animator otherAnimator; // 애니메이터
    public Text scoretext; // 점수를 표시하는 텍스트
    public int currentscore; // 현재 점수
    public bool showQuestionMark = true; // 물음표 표시 여부
 
    public float maxhp = 100; // 최대 체력
    public float curhp = 100; // 현재 체력

    public Text G_text;
    public int G=0;

    public int my_at=20;
        

        public GameObject dmg_txt_pre;
          public GameObject bumo_obj;
        public Transform dmg_txt_pos;
          GameObject dmg_inst;

          public AudioSource audioSource;

    public AudioClip audioClip;

    
        public AudioClip audioClip_die;
    
    private void Awake()
    {
      
      
    }


    public void txtload(){
            G_text.text = G.ToString();
    }
    void Start()
    {
        G_text.text = G.ToString();
        com_hp.value = (float)curhp / (float)maxhp; // 현재 체력을 슬라이더에 반영

boss_text.text="";

        currentscore = 0; // 현재 점수 초기화
        UpdateScoreText(); // 점수 텍스트 업데이트
shop_visit();
 
    }
public Transform com_img;
public Transform com_hpbar;
public Text boss_text;

public void stage_fan(){
    maxhp=100;
    for(int i = 0;i<currentscore;i++){
        maxhp+=4;
    }

 for(int i = 0;i<currentscore;i+=10){
        maxhp+=50;
    }
    my_at=20;
   for(int i = 0;i<GameObject.Find("Canvas").GetComponent<GameManager>().at_lv;i++){
        my_at+=i;
    }  

    GameObject.Find("User").GetComponent<user>().maxhp=100;
   for(int i = 0;i<GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv;i++){
        GameObject.Find("User").GetComponent<user>().maxhp+=(i*10);
    }  

       if(currentscore%10 == 0){
com_img.localScale=new Vector3(12f, 12f, 0.0f);

com_hpbar.localScale=new Vector3(1.3f, 1.3f, 0.0f);
boss_text.text="BOSS";

    }else if(currentscore==0){
com_img.localScale=new Vector3(8f, 8f, 0.0f);

com_hpbar.localScale=new Vector3(1f, 1f, 0.0f);
boss_text.text="";
    }else{
        com_img.localScale=new Vector3(8f, 8f, 0.0f);

com_hpbar.localScale=new Vector3(1f, 1f, 0.0f);
boss_text.text="";
    }

ResetHealth();
    
}
public GameObject shop_pop;
public Text skill_1;
public Text skill_2;
public Text skill_3;
 private string[] skill_name = { "at", "hp", "def", "big_hp", "slow", "gold", "respon"};
public string skill_code_1;
public string skill_code_2;
public string skill_code_3;

public AudioSource shop_music;
public AudioSource zun_music;




public void shop_exit(){
     shop_music.Stop();
     zun_music.Play();
}

public void shop_visit(){
     shop_music.Play();
     zun_music.Stop();
shop_pop.SetActive(true);
     skill_code_1=skill_name[Random.Range(0,7)];
       skill_code_2=skill_name[Random.Range(0,7)];
         skill_code_3=skill_name[Random.Range(0,7)];
         if(skill_code_1==skill_code_2||skill_code_2==skill_code_3||skill_code_1==skill_code_3){
            shop_visit();
         }

        if(skill_code_1=="at"){
   skill_1.text="";
                 skill_1.text="공격력 증가 lv"+GameObject.Find("Canvas").GetComponent<GameManager>().at_lv+"->lv"+(GameObject.Find("Canvas").GetComponent<GameManager>().at_lv+1).ToString();
skill_1.text+="";
        }else if(skill_code_1=="hp"){
               skill_1.text="";
                 skill_1.text="최대 체력 증가 lv"+GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv+"->lv"+(GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv+1).ToString();
skill_1.text+="";
        }else if(skill_code_1=="def"){
              skill_1.text="";
               skill_1.text="다음판 보호막 1회";
skill_1.text+="";
        }else if(skill_code_1=="big_hp"){
              skill_1.text="";
               skill_1.text="구급상자";
skill_1.text+="";
        }else if(skill_code_1=="slow"){
              skill_1.text="";
               skill_1.text="다음판 스피드 다운";
skill_1.text+="";
        }else if(skill_code_1=="gold"){
              skill_1.text="";
               skill_1.text="골드 상자 (500골드~10000골드)";
skill_1.text+="";
        }else if(skill_code_1=="respon"){
              skill_1.text="";
               skill_1.text="반피로 부활 1회";
skill_1.text+="";
        }



               if(skill_code_2=="at"){
   skill_2.text="";
                 skill_2.text="공격력 증가 lv"+GameObject.Find("Canvas").GetComponent<GameManager>().at_lv+"->lv"+(GameObject.Find("Canvas").GetComponent<GameManager>().at_lv+1).ToString();
skill_2.text+="";
        }else if(skill_code_2=="hp"){
               skill_2.text="";
                 skill_2.text="최대 체력 증가 lv"+GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv+"->lv"+(GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv+1).ToString();
skill_2.text+="";
        }else if(skill_code_2=="def"){
              skill_2.text="";
               skill_2.text="다음판 보호막 1회";
skill_2.text+="";
        }else if(skill_code_2=="big_hp"){
              skill_2.text="";
               skill_2.text="구급상자";
skill_2.text+="";
        }else if(skill_code_2=="slow"){
              skill_2.text="";
               skill_2.text="다음판 스피드 다운";
skill_2.text+="";
        }else if(skill_code_2=="gold"){
              skill_2.text="";
               skill_2.text="골드 상자 (500골드~10000골드)";
skill_2.text+="";
        }else if(skill_code_2=="respon"){
              skill_2.text="";
               skill_2.text="반피로 부활 1회";
skill_2.text+="";
        }



               if(skill_code_3=="at"){
   skill_3.text="";
                 skill_3.text="공격력 증가 lv"+GameObject.Find("Canvas").GetComponent<GameManager>().at_lv+"->lv"+(GameObject.Find("Canvas").GetComponent<GameManager>().at_lv+1).ToString();
skill_3.text+="";
        }else if(skill_code_3=="hp"){
               skill_3.text="";
                 skill_3.text="최대 체력 증가 lv"+GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv+"->lv"+(GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv+1).ToString();
skill_3.text+="";
        }else if(skill_code_3=="def"){
              skill_3.text="";
               skill_3.text="다음판 보호막 1회";
skill_3.text+="";
        }else if(skill_code_3=="big_hp"){
              skill_3.text="";
               skill_3.text="구급상자";
skill_3.text+="";
        }else if(skill_code_3=="slow"){
              skill_3.text="";
               skill_3.text="다음판 스피드 다운";
skill_3.text+="";
        }else if(skill_code_3=="gold"){
              skill_3.text="";
               skill_3.text="골드 상자 (500골드~10000골드)";
skill_3.text+="";
        }else if(skill_code_3=="respon"){
              skill_3.text="";
               skill_3.text="반피로 부활 1회";
skill_3.text+="";
        }



}

public void skill_1_click(){
     if(skill_code_1=="at"){
GameObject.Find("Canvas").GetComponent<GameManager>().at_lv++;
        }else if(skill_code_1=="hp"){
             GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv++;
        }else if(skill_code_1=="def"){
           GameObject.Find("Canvas").GetComponent<GameManager>().bobble_lv=true;
        }else if(skill_code_1=="big_hp"){
           GameObject.Find("User").GetComponent<user>().curhp=GameObject.Find("User").GetComponent<user>().maxhp;
             GameObject.Find("User").GetComponent<user>().barctrl();
        }else if(skill_code_1=="slow"){
              GameObject.Find("Canvas").GetComponent<GameManager>().slow_lv=true;
                       GameObject.Find("Spawner").GetComponent<spawner>().speed_fan();
        }else if(skill_code_1=="gold"){
           G+=Random.Range(500,10001);
            G_text.text = G.ToString();
        }else if(skill_code_1=="respon"){
                GameObject.Find("Canvas").GetComponent<GameManager>().respon_lv=true;
        }


shop_pop.SetActive(false);
shop_exit();




}

public void skill_2_click(){
     if(skill_code_2=="at"){
GameObject.Find("Canvas").GetComponent<GameManager>().at_lv++;
        }else if(skill_code_2=="hp"){
             GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv++;
        }else if(skill_code_2=="def"){
           GameObject.Find("Canvas").GetComponent<GameManager>().bobble_lv=true;
        }else if(skill_code_2=="big_hp"){
            GameObject.Find("User").GetComponent<user>().curhp= GameObject.Find("User").GetComponent<user>().maxhp;
             GameObject.Find("User").GetComponent<user>().barctrl();
        }else if(skill_code_2=="slow"){
              GameObject.Find("Canvas").GetComponent<GameManager>().slow_lv=true;
                       GameObject.Find("Spawner").GetComponent<spawner>().speed_fan();
        }else if(skill_code_2=="gold"){
               G+=Random.Range(500,10001);
            G_text.text = G.ToString();
        }else if(skill_code_2=="respon"){
                GameObject.Find("Canvas").GetComponent<GameManager>().respon_lv=true;
        }


shop_pop.SetActive(false);
shop_exit();




}

public void skill_3_click(){
     if(skill_code_3=="at"){
GameObject.Find("Canvas").GetComponent<GameManager>().at_lv++;
        }else if(skill_code_3=="hp"){
             GameObject.Find("Canvas").GetComponent<GameManager>().hp_lv++;
        }else if(skill_code_3=="def"){
           GameObject.Find("Canvas").GetComponent<GameManager>().bobble_lv=true;
        }else if(skill_code_3=="big_hp"){
             GameObject.Find("User").GetComponent<user>().curhp=  GameObject.Find("User").GetComponent<user>().maxhp;
             GameObject.Find("User").GetComponent<user>().barctrl();
        }else if(skill_code_3=="slow"){
               GameObject.Find("Canvas").GetComponent<GameManager>().slow_lv=true;
                       GameObject.Find("Spawner").GetComponent<spawner>().speed_fan();
        }else if(skill_code_3=="gold"){
               G+=Random.Range(500,10001);
            G_text.text = G.ToString();
        }else if(skill_code_3=="respon"){
               GameObject.Find("Canvas").GetComponent<GameManager>().respon_lv=true;
        }


shop_pop.SetActive(false);
shop_exit();




}





    void Update()
    {
//             if((currentscore+1)%10 == 0){
// com_img.localScale=new Vector3(12f, 12f, 0.0f);

// com_hpbar.localScale=new Vector3(1.4f, 1.4f, 0.0f);

//     }else{
// com_img.localScale=new Vector3(8f, 8f, 0.0f);

// com_hpbar.localScale=new Vector3(1f, 1f, 0.0f);
//     }



        if (curhp <= 0)
        {
            ResetHealth(); // 체력 초기화
            showQuestionMark = false; // 물음표 표시를 비활성화
            currentscore++; // 점수 증가
            if(currentscore%5==0){
shop_pop.SetActive(true);
shop_visit();

            }
            stage_fan();
            G += 100+currentscore*8;
            audioSource.clip=audioClip_die;
            audioSource.Play();
            G_text.text = G.ToString();
           GameObject.Find("Center").GetComponent<TimerBar>().next_stage();
   
            UpdateScoreText(); // 점수 텍스트 업데이트
        }
        else
        {
            com_hp.value = curhp / maxhp; // 현재 체력을 슬라이더에 반영
        }
    }

    public void ResetHealth()
    {
        curhp = maxhp; // 체력을 최대 체력으로 초기화
    }

    public void UpdateScoreText()
    {
        if (showQuestionMark)
        {
            scoretext.text = "1 대 ? 의 전설"; // 물음표를 표시하는 경우
        }
        else
        {
            scoretext.text = "1 대 " + currentscore.ToString() + " 의 전설"; // 현재 점수를 표시하는 경우
        }
    }


    public void Attack(float amount)
    {

      
              audioSource.clip=audioClip;
            audioSource.Play();
        otherAnimator.SetTrigger("Attack"); // 공격 애니메이션을 재생
        curhp -= amount; // 현재 체력 감소
        curhp = Mathf.Clamp(curhp, 0, maxhp); // 현재 체력이 최대 체력을 넘지 않도록 제한

    GameObject dmg_inst = Instantiate(dmg_txt_pre) as GameObject;
dmg_inst.transform.SetParent(bumo_obj.transform, false);
Instantiate(dmg_txt_pre);
        



    }
}
