using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GameScene : BaseScene
{
	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		SceneType = EScene.GameScene;

        // TODO

        StartLoadAssets();

        return true;
	}

	public override void Clear()
	{

	}

    void StartLoadAssets()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if (count == totalCount)
            {
                //Managers.Data.Init();
                //Managers.Resource.Instantiate("Human");
                Managers.Object.OutLine = Managers.Resource.Load<Material>("OutLine");

                Managers.Object.Spawn<PlayerController>(Vector3.zero);

                Managers.Object.Spawn<CookingAreaController>(Vector3.zero,(int)CookingAreaType.AirFryer);
            }
        });
    }
}
