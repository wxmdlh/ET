using UnityEngine;

namespace ET
{
    public static class PCMonitorsComponentSystem
    {
        public static void Start(this PCMonitorsComponent self)
        { 
            Log.Debug("启动屏幕");
        }
    }
}