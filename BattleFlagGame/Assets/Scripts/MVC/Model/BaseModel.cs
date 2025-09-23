using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//模型基类
public class BaseModel 
{
    public BaseController controller;//每个模型关联对应的控制器
    public BaseModel(BaseController ctl)
    {
        this.controller = ctl;
    }
    public BaseModel()
    {

    }
    public  virtual void Init()
    {

    }
}
