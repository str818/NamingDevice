using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSeek : MonoBehaviour {

    public GameObject glass;//放大镜
    public GameObject text;//放大镜上的字体
    public Animation glass_anim;
    public Animator glass_animator;

    //音源
    public AudioSource audioSource;
    //声音开关
    public Image audioImage;
    //开关图片
    public Sprite audioOpen;
    public Sprite audioClose;

    void Start()
    {
        audioSource.Play();//播放音效
        text.GetComponent<TextMesh>().text = NameHandler.randomPerson();//得到名字
        glass_anim.Play();//播放动画
        glass_animator.SetBool("isReturn", false);//设置动画机参数
       
    }

   public void PlayAgain()//再次播放
    {
        glass_animator.SetBool("isReturn", true);//设置为TRUE后将会再播放一次
        audioSource.Play();//播放音效
        StartCoroutine("WaitFewSeconds_text");

    }

    void Update()
    {
        if (glass_animator.GetBool("isReturn")) StartCoroutine("WaitFewSeconds_anim");//如果isReturn为true,则延迟0.5s后设置为false
    }

    IEnumerator WaitFewSeconds_anim()//0.5s后更改isReturn,使动画不会循环播放
    {
        yield return new WaitForSeconds(0.5f);
        glass_animator.SetBool("isReturn", false);

    }

    IEnumerator WaitFewSeconds_text()//0.5s后随机更改名字,否则会使结果提前出现。待恢复动画 播放完再播放音效
    {
        yield return new WaitForSeconds(0.5f);
        text.GetComponent<TextMesh>().text = NameHandler.randomPerson();
        //audioSource.Play();//播放音效
    }
    //切换声音
    public void switchAudio()
    {
        if (audioSource.volume == 0)
        {
            audioSource.volume = 1;
            audioImage.sprite = audioOpen;
        }
        else {
            audioSource.volume = 0;
            audioImage.sprite = audioClose;
        }
    }
    //返回上一场景
    public void goLastScene()
    {
        Application.LoadLevel("Start");
    }

}
