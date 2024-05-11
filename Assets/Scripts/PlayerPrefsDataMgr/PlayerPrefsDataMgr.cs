using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerPrefsDataMgr
{
    private static PlayerPrefsDataMgr _instance = new PlayerPrefsDataMgr();
    public static PlayerPrefsDataMgr Instance
    {
        get => _instance;
    }
    private PlayerPrefsDataMgr() { }

    public void Save(object obj, string key)
    {
        Type type = obj.GetType();
        FieldInfo[] fieldInfos = type.GetFields();
        string saveKey = null;
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            FieldInfo tmp = fieldInfos[i];
            // tmp.Name �ֶε�����   tmp.FieldType.Name �ֶε���������
            saveKey = $"{key}_{type.Name}_{tmp.FieldType.Name}_{tmp.Name}";
            SaveValue(tmp.GetValue(obj), saveKey);
        }
        // ֻҪSave��һ��, �����ϴ���
        PlayerPrefs.Save();
    }

    void SaveValue(object value, string key)
    {
        if (value.GetType() == typeof(int))
        {
            PlayerPrefs.SetInt(key, (int)value);
        }
        else if (value.GetType() == typeof(float))
        {
            PlayerPrefs.SetFloat(key, (float)value);
        }
        else if (value.GetType() == typeof(string))
        {
            PlayerPrefs.SetString(key, (string)value);
        }
        else if (value.GetType() == typeof(bool))
        {
            PlayerPrefs.SetInt(key, (bool)value ? 1 : 0);
        }
        // ���value��������List<XXX>
        else if (typeof(IList).IsAssignableFrom(value.GetType()))
        {
            IList list = value as IList;
            PlayerPrefs.SetInt(key, list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                SaveValue(list[i], $"{key}_{i}");
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(value.GetType()))
        {
            IDictionary dic = value as IDictionary;
            PlayerPrefs.SetInt(key, dic.Count);
            int index = 0;
            foreach (object item in dic.Keys)
            {
                SaveValue(item, key + "_key_" + index.ToString());
                SaveValue(dic[item], key + "_value_" + index.ToString());
                index++;
            }
        }
        else
        {
            Save(value, key);
        }
    }

    public object Load(Type type, string key)
    {
        object v = Activator.CreateInstance(type);
        FieldInfo[] fieldInfos = type.GetFields();
        string loadKey = null;
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            FieldInfo tmp = fieldInfos[i];
            loadKey = $"{key}_{type.Name}_{tmp.FieldType.Name}_{tmp.Name}";
            // ��v������ֶθ�ֵ
            tmp.SetValue(v, LoadValue(tmp.FieldType, loadKey));
        }
        return v;
    }

    // �õ�������
    private object LoadValue(Type fieldType, string key)
    {
        //object v = Activator.CreateInstance(fieldType);
        // �����ֶ����͵��ò�ͬAPI
        if (fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(key, 0);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(key, 0);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(key, null);
        }
        else if (fieldType == typeof(bool))
        {
            return PlayerPrefs.GetInt(key) == 1;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            int len = PlayerPrefs.GetInt(key);
            IList list = Activator.CreateInstance(fieldType) as IList;
            for (int i = 0; i < len; i++)
            {
                Type[] types = fieldType.GetGenericArguments();
                list.Add(LoadValue(types[0], $"{key}_{i}"));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            int len = PlayerPrefs.GetInt(key);
            IDictionary dic = Activator.CreateInstance(fieldType) as IDictionary;
            Type[] types = fieldType.GetGenericArguments();
            string loadKey, loadValue;
            for (int i = 0; i < len; i++)
            {
                loadKey = $"{key}_key_{i}";
                loadValue = $"{key}_value_{i}";
                dic.Add(LoadValue(types[0], loadKey), LoadValue(types[1], loadValue));
            }
            return dic;
        }
        else
        {
            return Load(fieldType, key);
        }
    }

}

