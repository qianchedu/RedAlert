/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              T007Strategy.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-05 
    *Description:           AedAlter
    *History:               自定义，可以不写内容，可以删除该行
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    /// <summary>
    /// 策略模式
    /// </summary>
	public class T007Strategy : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
            StrategyContext context = new StrategyContext();
            context.stragegy = new ConcreteStrategyC();
            context.Cal();
		}

		// Update is called once per frame
		void Update()
		{
			
		}
	}


    /// <summary>
    /// 策略管理中心
    /// </summary>
    public class StrategyContext
    {
        public IStrategy stragegy;

        public void Cal()
        {
            stragegy.Cal();
        }
    }


    /// <summary>
    /// 相应实现的策略模式接口
    /// </summary>
    public interface IStrategy
    {
        void Cal();
    }

    /// <summary>
    /// 策略A
    /// </summary>
    public  class ConcreteStrategyA : IStrategy
    {
        public void Cal()
        {
            Debug.Log("策略A");
        }
    }


    /// <summary>
    /// 策略B
    /// </summary>
    public class ConcreteStrategyB : IStrategy
    {
        public void Cal()
        {
            Debug.Log("策略B");
        }
    }


    /// <summary>
    /// 策略c
    /// </summary>
    public class ConcreteStrategyC : IStrategy
    {
        public void Cal()
        {
            Debug.Log("策略C");
        }
    }
}