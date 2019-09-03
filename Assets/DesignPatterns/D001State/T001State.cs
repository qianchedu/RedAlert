/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              T001State.cs 
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

namespace Demo
{
	public class T001State : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
            Context context = new Context();
            context.SetState(new ConcreteStateA(context));

           
            context.Handle(20);
      //      context.Handle(5);
        }

		// Update is called once per frame
		void Update()
		{
			
		}
	}

    public class Context
    {
        private IState mState;
        public void SetState(IState state)
        {
            mState = state;
        }

        public void Handle(int arg)
        {
            mState.Handle(arg);
        }
    }

    public interface IState
    {
        void Handle(int arg);
    }

    public class ConcreteStateA : IState
    {

        private Context mContext;

        public ConcreteStateA(Context context)
        {
            mContext = context;
        }
        public void Handle(int arg)
        {
            Debug.Log("ConcreteStateA" + arg);
            if(arg > 10)
            {
                mContext.SetState(new ConcreteStateB(mContext));
            }
        }
    }



    public class ConcreteStateB : IState
    {

        private Context mContext;
        public ConcreteStateB(Context context)
        {
            mContext = context;
        }
        public void Handle(int arg)
        {
            Debug.Log("ConcreteStateB" + arg);
            if (arg <= 10)
            {
                mContext.SetState(new ConcreteStateA(mContext));
            }
        }
    }

}