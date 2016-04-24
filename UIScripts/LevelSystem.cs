using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class LevelSystem : MonoBehaviour
{


    public static List<Level> LoadLevels()//read xml
    {
        //创建Xml对象
        XmlDocument xmlDoc = new XmlDocument();

        string filePath;

#if UNITY_ANDROID
        Debug.Log("Android");

        filePath = Application.persistentDataPath + "/levels.xml";
        FileInfo file = new FileInfo(filePath);

        if (file.Exists)
        {
            xmlDoc.Load(Application.persistentDataPath + "/levels.xml");
        }
        else
        {//如果文件不存在重新建一个xml
            CreateFile(filePath);
            xmlDoc.Load(Application.persistentDataPath + "/levels.xml");
        }
#endif
#if UNITY_EDITOR||UNITY_STANDALONE
        Debug.Log("PC");
        filePath = Application.dataPath + "/Resources/levels.xml";
        //filePath=Application.persistentDataPath + "/levels.xml" ;	
        xmlDoc.Load(filePath);
#endif


        XmlElement root = xmlDoc.DocumentElement;

        XmlNodeList levelsNode = root.SelectNodes("/levels/level");

        //初始化关卡列表
        List<Level> levels = new List<Level>();
        foreach (XmlElement xe in levelsNode)
        {
            Debug.Log("test 45");
            Level l = new Level();
            l.ID = xe.GetAttribute("id");
            l.Name = xe.GetAttribute("name");

            //初始化场景中的关卡属性
            if (xe.GetAttribute("unlock") == "1")
            {
                l.UnLock = true;
            }
            else
            {
                l.UnLock = false;
            }
            Debug.Log(l.ID + " " + l.Name);
            levels.Add(l);
        }

        Debug.Log("levelCount" + levels.Count);
        return levels;
    }


    public static void SetLevels(string name, bool unlock)//update xml-state of level
    {

        Debug.Log("set level " + name + " " + unlock);
        //创建Xml对象
        XmlDocument xmlDoc = new XmlDocument();

        string filePath;
#if UNITY_ANDROID

        xmlDoc.Load(Application.persistentDataPath + "/levels.xml");

#endif
#if UNITY_EDITOR||UNITY_STANDALONE
        filePath = Application.dataPath + "/Resources/levels.xml";
        //filePath=Application.persistentDataPath + "/levels.xml" ;
        xmlDoc.Load(filePath);
        Debug.Log(filePath);

#endif

        XmlElement root = xmlDoc.DocumentElement;
        XmlNodeList levelsNode = root.SelectNodes("/levels/level");

        foreach (XmlElement xe in levelsNode)
        {
            //根据名称找到对应的关卡
            if (xe.GetAttribute("name") == name)
            {
                //Main.updateState(name);
                //unlock level!
                if (unlock)
                {
                    Debug.Log("unlock");
                    xe.SetAttribute("unlock", "1");//修改xml文件
                }
                else
                {
                    xe.SetAttribute("unlock", "0");
                }
            }
        }

#if UNITY_ANDROID
        xmlDoc.Save(Application.persistentDataPath + "/levels.xml");
        Debug.Log("update level " + name + " " + unlock);
#endif
#if UNITY_EDITOR||UNITY_STANDALONE
        xmlDoc.Save(Application.dataPath + "/Resources/levels.xml");
        Debug.Log("update level " + name + " " + unlock);
#endif

    }



    public static void CreateFile(string filePath)
    {
        //文件流
        StreamWriter writer;
        //判断文件目录是否存在
        //不存在则先创建目录
        Debug.Log(filePath);

        //如果文件不存在则创建，存在则追加内容
        FileInfo file = new FileInfo(filePath);
        if (!file.Exists)
        {
            writer = file.CreateText();
        }
        else
        {
            file.Delete();
            writer = file.CreateText();
        }

        //写入内容
        writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<levels>" +
            "<level id=\"1\" name=\"level1\" unlock=\"1\" />" +
            "<level id=\"2\" name=\"level2\" unlock=\"0\" />" +
            "<level id=\"3\" name=\"level3\" unlock=\"0\" />" +
            "<level id=\"4\" name=\"level4\" unlock=\"0\" />" +
            "<level id=\"5\" name=\"level5\" unlock=\"0\" />" +
            "<level id=\"6\" name=\"level6\" unlock=\"0\" />" +
            "<level id=\"7\" name=\"level7\" unlock=\"0\" />" +
            "<level id=\"8\" name=\"level8\" unlock=\"0\" />" +
            "<level id=\"9\" name=\"level9\" unlock=\"0\" />" +
            "<level id=\"10\" name=\"level10\" unlock=\"0\" />" +
            "<level id=\"11\" name=\"level11\" unlock=\"0\" />" +
            "<level id=\"12\" name=\"level12\" unlock=\"0\" />" +
            "<level id=\"13\" name=\"level13\" unlock=\"0\" />" +
            "<level id=\"14\" name=\"level14\" unlock=\"0\" />" +
            "<level id=\"15\" name=\"level15\" unlock=\"0\" />" +
            "</levels>");
        writer.Close();
        writer.Dispose();
    }
}