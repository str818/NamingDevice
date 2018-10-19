using System;

//学生类
public class Person {

    public String id;//学号
    public String name;//姓名

    //被选中的概率，由于学生人数不确定，所以将概率值分为低中高三个档次:1、2、3
    public int probability;

    public Person(String id, String name, int probability){
        this.id = id;
        this.name = name;
        this.probability = probability;
    }
}
