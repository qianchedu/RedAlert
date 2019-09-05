/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              IAttrStrategy.cs 
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
    /// 角色属性策略模式
    /// </summary>
	public interface IAttrStrategy 
	{
        
        /// <summary>
        /// 额外增加的血量
        /// </summary>
        /// <param name="lv">等级</param>
        /// <returns></returns>
        int GetExtraHPValue(int lv);

        /// <summary>
        /// 防御伤害
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        int GetDmgDescValue(int lv);


        /// <summary>
        /// 暴击伤害
        /// </summary>
        /// <param name="critRate">暴击率</param>
        /// <returns></returns>
        int GetCritDmg(int critRate);

	}
}