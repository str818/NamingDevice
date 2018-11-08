using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;

//名称选择类
public class NameHandler
{

    public static int audioState;

    //固定列表
    public static List<Person> staticPL = new List<Person>();

    //可变列表
    public static List<Person> PL = new List<Person>();

    //增加的数量值
    public static int P1Value = 1;
    public static int P2Value = 2;
    public static int P3Value = 3;

    //读取txt中的信息
    public static void localText(string path)
    {

        //清空固定列表
        staticPL.Clear();

        using (System.IO.StreamReader sr = new System.IO.StreamReader(
            path, Encoding.Default))
        {
            string str;                                                             //定义局部变量保存每行字符串
            while ((str = sr.ReadLine()) != null)
            {                                 //如果此行不为空
                str = str.Trim();                                                   //去掉空格
                string[] ss = str.Split(new char[] { ' ' });                        //根据空格分隔字符串
                if (ss.Length != 3) continue;                                       //防止出错,需要加载的内容分类三个部分，学生ID、姓名、与点到概率等级
                int p = int.Parse(ss[2]);                                           //概率等级
                p = p == 1 ? P1Value : (p == 2 ? P2Value : P3Value);                //修改对应的概率等级，将从文件中读取的等级1、2、3对应改成P1Value、P2Value与P3Value

                staticPL.Add(new Person(ss[0], ss[1], p));
                Debug.Log(ss[0] + " " + ss[1] + " " + p);
            }
        }
    }

    //随机抽取一人，当所有人都被点名过后，再重新初始列表，从头开始
    //由于需要考虑概率值的影响，所以如果某一学生的概率Value为5，那么在向列表中添加5个该学生对象，这样就增加了该学生被抽中的概率
    //抽中该学生后，将列表中该学生对象全部删除
    public static string randomPerson()
    {
        if (staticPL.Count == 0) return "暂无名单";

        //若待点名单为空，则重新加载名单
        if (PL.Count == 0)
        {
            PL = new List<Person>(staticPL);
            for (int i = 0; i < PL.Count; i++)
            {
                int tempP = PL[i].probability;
                while (tempP-- > 1)
                {
                    PL.Insert(0, PL[i++]);
                }
            }
        }


        //随机抽取学生
        int index = new System.Random(Guid.NewGuid().GetHashCode()).Next(0, PL.Count);
        string ans = PL[index].id + " " + PL[index].name;

        string id = PL[index].id;

        PL.RemoveAt(index);

        return ans;
    }
}
