using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager
{
    public PlayerController Player { get; private set; }

    //public HashSet<CustomerController> Customers { get; } = new HashSet<CustomerController>();

    //public HashSet<CroassantController> Croassants { get; } = new HashSet<CroassantController>();

    public Dictionary<string, Sprite> DicSprite = new Dictionary<string, Sprite>();

    public Material OutLine;


    public T Spawn<T>(Vector3 position, int templateID = 0, Transform parent = null) where T : BaseController
    {
        System.Type type = typeof(T);

        if (Player==null && type == typeof(PlayerController))
        {
            GameObject go = Managers.Resource.Instantiate("Human");

            go.name = "Player";

            go.transform.position = position;

            PlayerController pc = go.GetOrAddComponent<PlayerController>();
            Player = pc;

            return pc as T;
        }
        else if(type == typeof(DeliverableStuffController))
        {
            if(templateID == 0)
            {
                GameObject go = Managers.Resource.Instantiate("FrenchFrice");

                go.transform.position = position;

                FrenchFriceController fc = go.GetOrAddComponent<FrenchFriceController>();

                return fc as T;
            }
            else if(templateID == 1)
            {
                GameObject go = Managers.Resource.Instantiate("Coke");

                go.transform.position = position;

                CokeContoller cc = go.GetOrAddComponent<CokeContoller>();

                return cc as T;
            }
            else if(templateID== 2)
            {
                GameObject go = Managers.Resource.Instantiate("Burger");

                go.transform.position = position;

                BurgerController bc = go.GetOrAddComponent<BurgerController>();

                return bc as T;
            }
            else if(templateID == 3)
            {
                GameObject go = Managers.Resource.Instantiate("Hotdog");

                go.transform.position = position;

                HotdogController hc = go.GetOrAddComponent<HotdogController>();

                return hc as T;
            }
        }
        else if(type==typeof(CookingAreaController))
        {
            if (templateID == 0)
            {
                GameObject go = Managers.Resource.Instantiate("AirFryer");

                go.transform.position = position;

                AirFryerController ac = go.GetOrAddComponent<AirFryerController>();

                return ac as T;
            }
            else if( templateID == 1)
            {
                GameObject go = Managers.Resource.Instantiate("DrinkMachine");

                go.transform.position = position;

                DrinkMachineController dm = go.GetOrAddComponent<DrinkMachineController>();

                return dm as T;
            }
            else if(templateID== 2)
            {
                GameObject go = Managers.Resource.Instantiate("GasStove");

                go.transform.position = position;

                BurgerMakerController bm = go.GetOrAddComponent<BurgerMakerController>();

                return bm as T;
            }
            else if(templateID== 3) 
            {
                GameObject go = Managers.Resource.Instantiate("GasStove");

                go.transform.position = position;

                HotdogMakerController hm = go.GetOrAddComponent<HotdogMakerController>();

                return hm as T;
            }
        }
        //else if (type == typeof(CustomerController))
        //{
        //    GameObject go = Manager.Resource.Instantiate("Prefabs\\Customer");

        //    go.transform.position = position;

        //    CustomerController cc = go.GetOrAddComponent<CustomerController>();
        //    Customers.Add(cc);

        //    return cc as T;
        //}
        //else if (type == typeof(CroassantController))
        //{
        //    GameObject go = Manager.Resource.Instantiate("Prefabs\\Croassant");

        //    go.transform.parent = parent;
        //    go.transform.localPosition = Vector3.zero;


        //    CroassantController crc = go.GetOrAddComponent<CroassantController>();
        //    Croassants.Add(crc);

        //    return crc as T;
        //}

        //else if (type == typeof(PaperBagController))
        //{
        //    GameObject go = Manager.Resource.Instantiate("Prefabs\\PaperBag");

        //    go.transform.parent = parent;
        //    go.transform.localPosition = Vector3.zero;


        //    PaperBagController pbc = go.GetOrAddComponent<PaperBagController>();

        //    return pbc as T;
        //}
        //else if (type == typeof(MoneyController))
        //{
        //    GameObject go = Manager.Resource.Instantiate("Prefabs\\Money");

        //    go.transform.parent = parent;
        //    go.transform.localPosition = position;


        //    MoneyController pbc = go.GetOrAddComponent<MoneyController>();

        //    return pbc as T;
        //}


        return null;
    }

    //public void Despawn<T>(T obj) where T : BaseController
    //{
    //    //if (obj.IsValid() == false)
    //    //{
    //    //    int a = 3;
    //    //}

    //    System.Type type = typeof(T);

    //    if (type == typeof(PlayerController))
    //    {
    //        // ?
    //    }
    //    else if (type == typeof(CroassantController))
    //    {
    //        Croassants.Remove(obj as CroassantController);
    //        Manager.Resource.Destroy(obj.gameObject);
    //    }
    //    else if (type == typeof(CustomerController))
    //    {
    //        Customers.Remove(obj as CustomerController);
    //        Manager.Resource.Destroy(obj.gameObject);
    //    }
    //    else if (type == typeof(MoneyController))
    //    {
    //        Manager.Resource.Destroy(obj.gameObject);
    //    }
    //}

    public Sprite GetSprite(string name)
    {
        Sprite newSprite;
        if (!DicSprite.TryGetValue(name, out newSprite))
        {
            newSprite = Resources.Load<Sprite>("Sprites\\" + name);
            DicSprite.Add(name, newSprite);
        }

        return newSprite;
    }
}
