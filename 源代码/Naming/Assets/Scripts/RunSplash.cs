using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//闪屏类
public class RunSplash : MonoBehaviour {
    //exe文件所在的目录路径
    //  string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
    string path = "D:\\Files\\exe\\";//加载路径
    public Material splash;//闪屏的材质
    public Texture texture;//闪屏纹理图

    private void Awake() {
        StartCoroutine("LoadImg");//加载图片
      //  Screen.fullScreen = true;
    }

    void Start () {
        Invoke("goNextSence", 5);
        NameHandler.localText(path + "NameList.txt");
        //Debug.Log(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
    }
	
	void goNextSence() {
        Application.LoadLevel("Start");
    }

    //动态加载本地图片
    IEnumerator LoadImg() {
        //图片名称
        string fileName = "pic.jpg";
        WWW wwwTexture = new WWW("file://"+path+fileName);
        yield return wwwTexture;
        if(wwwTexture.texture != null) {
            splash.mainTexture = wwwTexture.texture;
        }
    }
}
