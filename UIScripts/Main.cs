﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;

public class Main : MonoBehaviour 
{
	//关卡列表
	private List<Level> m_levels;

	void Start () 
	{
		Debug.Log ("14");
		//获取关卡
		m_levels = LevelSystem.LoadLevels ();
		Debug.Log ("test 16");
		//动态生成关卡
		foreach (Level l in m_levels) 
		{
			Debug.Log ("test19");
			//GameObject prefab=(GameObject)Instantiate((Resources.Load("Level") as GameObject));

			GameObject prefab;

			prefab =  (Resources.Load ("Level") as GameObject);


			string name = l.Name;
			Debug.Log(name+" 29");
			GameObject temp = GameObject.Find(name);
			temp.GetComponent<testLoadScene> ().level = l;//更新开锁
			DataBind(temp,l);


		}

		Debug.Log ("finish ini");

	}


	/// <summary>
	/// 数据绑定
	/// </summary>
	void DataBind(GameObject go,Level level)
	{
		Debug.Log ("test DataBind"+level.Name);
		//为关卡绑定关卡名称
		//go.transform.Find("LevelName").GetComponent<Text>().text=level.Name;
		//为关卡绑定关卡图片
		Texture2D tex2D;
		Debug.Log ("62");
		if(level.UnLock){
			
			Debug.Log (level.Name);
			tex2D=Resources.Load(level.Name) as Texture2D;
		}else{
			
			tex2D=Resources.Load("lock") as Texture2D;
		}
		Sprite sprite=Sprite.Create(tex2D,new Rect(0,0,tex2D.width,tex2D.height),new Vector2(0.5F,0.5F));
	
		go.transform.GetComponent<Image>().sprite=sprite;
	}
}