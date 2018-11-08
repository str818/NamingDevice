using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    // 抖动目标的transform
    public Transform chestTransform;

    //动画
    public Animation coinClip;

    //金币
    public GameObject coin;

    //文本框
    public GameObject Text;

    //持续抖动的时长
    public float shake = 0f;

    //音效
    public AudioClip shakeAudio;
    public AudioClip unlockAudio;
    public AudioClip coinAudio;

    //音源
    public AudioSource audioSource;

    //声音开关
    public Image audioImage;

    //开关图片
    public Sprite audioOpen;
    public Sprite audioClose;

    // 抖动幅度（振幅）
    //振幅越大抖动越厉害
    public float shakeAmount = 0.15f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void OnEnable() {
        originalPos = chestTransform.localPosition;
        if(NameHandler.audioState == -1) {
            switchAudio();
        }
    }

    //抖动并打开箱子
    void Start() {
        Invoke("openChest", 1.5f);
        Invoke("jumpCoin", 2f);
        shake = 0.7f;
        audioSource.Play();
    }

    //打开箱子
    void openChest() {
        audioSource.clip = unlockAudio;
        audioSource.Play();
        chestTransform.GetComponent<ActivateChest>()._open = true;
    }

    //弹出金币
    void jumpCoin() {
        //audioSource.clip = coinAudio;
        //audioSource.Play();
        Debug.Log("发送");
        coinClip.Play();
        string text = NameHandler.randomPerson();
        Text.GetComponent<TextMesh>().text = text;
        coin.active = true;
    }

    //抖动箱子
    void Update() {
        if (shake > 0) {
            chestTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
        }
        else {
            shake = 0f;
            chestTransform.localPosition = originalPos;
        }
    }

    //切换声音
    public void switchAudio() {
        if(audioSource.volume == 0) {
            audioSource.volume = 1;
            audioImage.sprite = audioOpen;
            NameHandler.audioState = 0;
        }
        else {
            audioSource.volume = 0;
            audioImage.sprite = audioClose;
            NameHandler.audioState = -1;
        }
    }
    //返回上一场景
    public void goLastScene()
    {
        Application.LoadLevel("Start");
    }

}
