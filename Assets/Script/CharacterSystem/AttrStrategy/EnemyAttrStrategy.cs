/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              EnemyAttrStrategy.cs 
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
    /// 敌人的策略模式(暴击、防御、血量)
    /// </summary>
	public class EnemyAttrStrategy : IAttrStrategy
    {
        public int GetCritDmg(int critRate)
        {

            if (UnityEngine.Random.Range(0, 1f) < critRate)
            {
                return (int)(10 * Random.Range(0.5f, 1f));
            }

            return 0;
        }

        public int GetDmgDescValue(int lv)
        {
            return 0;
        }

        public int GetExtraHPValue(int lv)
        {
            return 0;
        }
    }
}