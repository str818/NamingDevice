using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//闪屏类
public class RunSplash : MonoBehaviour {
    //exe文件所在的目录路径
    string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

    //闪屏的材质
    public Material splash;
    public Texture texture;

    private void Awake() {
        StartCoroutine("LoadImg");
        Screen.fullScreen = false;
    }

    void Start () {
        Invoke("goNextSence", 5);
        //NameHandler.localText("NameList.txt");
        NameHandler.localText(path + "NameList.txt");
        
        Debug.Log(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
    }
	
	void goNextSence() {
        Application.LoadLevel("Start");
    }

    //动态加载本地图片
    IEnumerator LoadImg() {
        //图片名称
        string fileName = "pic.jpg";
        WWW wwwTexture = new WWW("file://"+path+fileName);
        Debug.Log(wwwTexture.url);
        yield return wwwTexture;
        if(wwwTexture.texture != null) {
            splash.mainTexture = wwwTexture.texture;
        }
    }
}
