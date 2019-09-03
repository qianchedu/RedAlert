/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              GameLoop.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-03 
    *Description:           AedAlter
    *History:               自定义，可以不写内容，可以删除该行
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Red
{
	public class GameLoop : MonoBehaviour
	{

        private SceneStateController mController = null;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
        // Start is called before the first frame update
        void Start()
		{
            mController = new SceneStateController();
            mController.SetState(new StartState(mController),false);
		}


		// Update is called once per frame
		void Update()
		{
            mController.StateUpdate();
		}
	}
}