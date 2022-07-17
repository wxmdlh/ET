using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView: AEvent<Unit, EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(Unit unit, EventType.AfterUnitCreate args)
        {

            switch (args.Unit.UnitType)
            {
                case UnitType.Player:
                    
                    break;
                case UnitType.Box:
                    
                    break;
                case UnitType.Monster:
                    
                    break;
                case UnitType.DropItem:
                    
                    break;
                default:
                    break;

            }
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");
	        
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            go.transform.position = unit.Position;
            unit.AddComponent<GameObjectComponent>().GameObject = go;
            unit.AddComponent<AnimatorComponent>();
            await ETTask.CompletedTask;
        }
    }
}