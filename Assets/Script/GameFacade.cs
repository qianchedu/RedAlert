/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              GameFacade.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-04 
    *Description:           AedAlter
    *History:               自定义，可以不写内容，可以删除该行
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Red
{
	public class GameFacade 
	{

        private static GameFacade instance;
        private GameFacade() { }

        public static GameFacade Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new GameFacade();
                }

                return instance;
            }
        }

        //游戏是否结束
        private bool mIsGameOver = false;


        public bool isGameOver
        {
            get
            {
                return mIsGameOver;
            }
        }

		public void Init()
        {

        }


        public void Update()
        {

        }


        public void Release()
        {

        }
	}
}