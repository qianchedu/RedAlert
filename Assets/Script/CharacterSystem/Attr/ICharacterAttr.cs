/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              ICharacterAttr.cs 
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
    /// <summary>
    /// 角色公共属性
    /// </summary>
	public class ICharacterAttr
	{
        protected string mName;
        protected int mMaxHP;
        protected float mMoveSpeed;

        protected int mCurrentHP;
        protected string mIconSprite;

        protected int mLv;              //等级
        protected float mCritRate;      //暴击率

        //增加的最大血量 抵御防御值，暴击增加的伤害
        protected IAttrStrategy mStrategy;

    }
}