using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//界面监听类
public class MenuListener : MonoBehaviour {

    //进入主场景
    public void goNextScene() {
        Application.LoadLevel("Main");
    }

    //进入开始场景
    public void goLastScene() {
        Application.LoadLevel("Main");
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
