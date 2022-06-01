using System.Collections.Generic;
using System.Numerics;

namespace ET
{
    /// <summary>
    /// 扩展数据类型
    /// </summary>
    public partial class UnitConfig
    {
        public Vector3 TestValue;
    }

    /// <summary>
    /// 扩展类
    /// </summary>
    public class TestVector3
    {
        public Vector3 TestValue;
    }
    
    public partial class UnitConfigCategory
    {
        public List<TestVector3> TestVector3s = new List<TestVector3>();
        public override void AfterEndInit()
        {
            base.AfterEndInit();
            foreach (var config in this.dict.Values)
            {
                config.TestValue = new Vector3(config.Position, config.Height, config.Weight);
                this.TestVector3s.Add(new TestVector3(){TestValue = config.TestValue});
            }
        }
        public UnitConfig GetUnitConfigByHeight(int height)
        {
            UnitConfig unitConfig = null;
            foreach (var info in this.dict.Values)
            {
                if (info.Height == height)
                {
                    unitConfig = info;
                    break;
                }
            }

            return unitConfig;
        }
    }
}