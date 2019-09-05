/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              D008TempleMethod.cs 
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

namespace Red
{
    /// <summary>
    /// 模板方法模式
    /// </summary>
	public class T008TempleMethod : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
            //这里就是调用了模板方法
            IPeople people = new SourthPeople();
            people.Eat();
		}

		// Update is called once per frame
		void Update()
		{
			
		}
	}


    public abstract class IPeople
    {
        public void Eat()
        {
            OrderFoods();
            EatSomething();
            PayBill();
        }


        /// <summary>
        /// 点单
        /// </summary>
        private void OrderFoods()
        {
            Debug.Log("点单");
        }


        /// <summary>
        /// 吃东西
        /// virtual：如果子类没有重写这个方法，就会调用这个的方法
        ///          如果子类重写(override)了这个方法，程序就会调用子类重写的方法
        /// 
        /// </summary>
        protected virtual void EatSomething()
        {
            Debug.Log("吃东西");
        }


        /// <summary>
        /// 买单
        /// </summary>
        private void PayBill()
        {
            Debug.Log("买单");
        }
    }



    public class NorthPeople : IPeople
    {
        protected override void EatSomething()
        {
            Debug.Log("North吃东西");
        }
    }


    public class SourthPeople : IPeople
    {
        //protected override void EatSomething()
        //{
        //    Debug.Log("Sourth吃东西");
        //}
    }
}