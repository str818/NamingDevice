using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//界面监听类
public class MenuListener : MonoBehaviour {

    public Sprite fullScreen;
    public Sprite closeFullScreen;
    public Image screenSwitch;
    //初始化
    void Start()
    {
        if(Screen.fullScreen == true)
        screenSwitch.sprite = closeFullScreen;
        else
        screenSwitch.sprite = fullScreen;
    }
  
    //进入宝箱点名
    public void goNextScene_box(){
        Application.LoadLevel("Main");
    }
    //进入地图点名
    public void goNextScene_map()
    {
        Application.LoadLevel("MapSeek");
    }
    //进入开始场景
    public void goLastScene() {
        Application.LoadLevel("Main");
    }
    //关闭游戏
    public void closeGame()
    {
        Application.Quit();
    }
    //是否全屏，默认全屏,并更换图标
    public void SwitchScreen()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
            screenSwitch.sprite = fullScreen;
            print(Screen.fullScreen);
        }
        else
        {
            Screen.fullScreen = true;
            screenSwitch.sprite =  closeFullScreen;
        }
    }
    private void Update() {
        //测试使用
        if (Input.GetKeyDown(KeyCode.A)) {
            for(int i = 0 ; i < 38; i++){
                NameHandler.randomPerson();

            }
        }

    }

}
