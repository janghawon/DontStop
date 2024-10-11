using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolingType
{
    SpeachBubble,
    SettingPanel,
    SceneChanger,
    LightningParticle,
    MainText,
    PartyFX
}

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private PoolListSO _poolList;
    private Dictionary<PoolingType, Pool<PoolableMono>> _poolDic = new Dictionary<PoolingType, Pool<PoolableMono>>();

    private void Awake()
    {
        foreach(var pool in _poolList.poolList)
        {
            CreatePool(pool.prefab, pool.type, pool.count);
        }
    }

    public void CreatePool(PoolableMono prefab, PoolingType poolingType, int count = 10)
    {
        _poolDic.Add(poolingType, new Pool<PoolableMono>(prefab, poolingType, transform, count));
    }

    public void Push(PoolableMono obj)
    {
        if (_poolDic.ContainsKey(obj.poolingType))
        {
            obj.Init();
            _poolDic[obj.poolingType].Push(obj);
        }
        else
        {
            Debug.LogError($"not have ${obj.name} pool");
        }
    }

    public PoolableMono Pop(PoolingType type)
    {
        if (!_poolDic.ContainsKey(type))
        {
            Debug.LogError($"not have [${type}] pool");
            return null;
        }

        PoolableMono obj = _poolDic[type].Pop();
        
        return obj;
    }

    public bool IsContainPoolMono(PoolableMono obj)
    {
        return _poolDic[obj.poolingType].Contain(obj);
    }
}
