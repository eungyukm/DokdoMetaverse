using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Network 관련 Global Class
/// </summary>
public static class NetworkGlobal
{
    public const char CLASS_SPLIT_SYMBOL = '／'; // 클래스 단위를 구분하는 심볼
    public const char VARIABLE_SPLIT_SYMBOL = '＋'; // 변수 단위를 구분하는 심볼
    public const char DATA_SPLIT_SYMBOL = '‘'; // 변수 데이터를 구분하는 심볼

    /// <summary>
    /// Packet List를 Serializeable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="packets"></param>
    /// <returns></returns>
    public static string SerializeArray<T>(this T[] packets) where T : IPacket
    {
        string str = string.Empty;
        for (int i = 0; i < packets.Length; i++)
        {
            str += packets[i].Serialize();
            if (i + 1 < packets.Length)
                str += NetworkGlobal.CLASS_SPLIT_SYMBOL;
        }
        return str;
    }
    public static string SerializeArray2<T>(this T[] packets) where T : IPacket
    {
        return null;
    }


    /// <summary>
    /// Packet List를 Deserializeable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="str"></param>
    /// <returns></returns>
    public static T[] DeserializeArray<T>(this string str) where T : IPacket, new()
    {
        if (str == null)
            return null;

        string[] datas = str.Split(NetworkGlobal.CLASS_SPLIT_SYMBOL);
        List<T> packets = new List<T>();
        for (int i = 0; i < datas.Length; i++)
        {
            T packet = new T();
            packet.Deserialize(datas[i]);
            packets.Add(packet);
        }

        // Sorting
        packets.Sort((x, y) => {
            if (x.GetTick() > y.GetTick())
                return 1;
            else if (x.GetTick() < y.GetTick())
                return -1;
            else
                return 0;
        });
        return packets.ToArray();
    }

    /// <summary>
    /// Packet Casting
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="origins"></param>
    /// <returns></returns>
    public static T[] CastTo<T>(this Packet[] origins) where T : Packet, new()
    {
        T[] result = new T[origins.Length];
        for (int i = 0; i < origins.Length; i++)
        {
            result[i] = origins[i].CastTo<T>();
        }
        return result;
    }
}

// Note ::
// - Label과 IMessenger는 추후 Network의 구조화를 조금 더 구체적으로 진행할 때 사용

//public interface ILabel
//{
//    int GetID();
//}

//public interface IMessenger
//{
//    void SendMessage(int from, int to, params object[] datas);

//    void ReciveMessage(int from, int to, params object[] datas);
//}

public enum EPacketID
{
    NONE,
    PLAYER,
    AI,
    TEST,
}

public interface IPacket
{
    public EPacketID GetPacketID();             // 패킷 ID
    public long GetTick();                      // 패킷 시간
    public string Serialize();                  // 직렬화
    public void Deserialize(string value);      // 역직렬화
}

public class Packet : IPacket
{
    protected long tick = 0;
    protected EPacketID id = EPacketID.NONE; // Packet Type

    protected List<string> datas = new List<string>(); // Packet Data
    protected int dataIndex = 0; // Data Index

    public Packet() { }

    public Packet(EPacketID id)
    {
        this.id = id;
        tick = DateTime.UtcNow.Ticks;
    }

    public Packet(string str)
    {
        Deserialize(str);
    }

    public void SetData(List<string> newDatas)
    {
        datas.Clear();
        for (int i = 0; i < newDatas.Count; i++)
        {
            datas.Add(newDatas[i]);
        }
    }

    public List<string> GetData()
    {
        return datas;
    }

    public void AddData(string str)
    {
        datas.Add(str);
    }

    public string NextData()
    {
        string result = string.Empty;
        if (datas.Count > dataIndex)
        {
            result = datas[dataIndex];
            dataIndex++;
        }
        return result;
    }

    public EPacketID GetPacketID()
    {
        return id;
    }

    public long GetTick()
    {
        return tick;
    }

    public string Serialize()
    {
        PrevSerialize();
        string str = string.Empty;
        for (int i = 0; i < datas.Count; i++)
        {
            str += datas[i];
            if (i + 1 < datas.Count)
                str += NetworkGlobal.VARIABLE_SPLIT_SYMBOL;
        }
        return str;
    }

    protected virtual void PrevSerialize() 
    { 
        datas.Clear();
        dataIndex = 0;
        AddData(SerializeInt((int)id));
        AddData(SerializeLong(tick));
    }

    public void Deserialize(string str)
    {
        datas = str.Split(NetworkGlobal.VARIABLE_SPLIT_SYMBOL).ToList();
        PostDeserialize();
    }

    protected virtual void PostDeserialize() 
    {
        dataIndex = 0;
        id = (EPacketID)DeserializeInt(NextData());
        tick = DeserializeLong(NextData());
    }

    // String
    public string SerializeString(string value)
    {
        return value;
    }

    public string DeserializeString(string value)
    {
        return value;
    }

    // bool
    public string SerializeBool(bool value)
    {
        if (value) return "1";
        else return "0";
    }

    public bool DeserializeBool(string value)
    {
        if (value.Equals("1")) return true;
        else return false;
    }

    // int
    public string SerializeInt(int value)
    {
        return value.ToString();
    }

    public int DeserializeInt(string str)
    {
        return int.Parse(str);
    }

    // Long
    public string SerializeLong(long value)
    {
        return value.ToString();
    }

    public long DeserializeLong(string str)
    {
        return long.Parse(str);
    }

    // Vector3
    public string SerializeVector3(Vector3 vector)
    {
        return $"{vector.x}{NetworkGlobal.DATA_SPLIT_SYMBOL}{vector.y}{NetworkGlobal.DATA_SPLIT_SYMBOL}{vector.z}";
    }

    public Vector3 DeserializeVector3(string str)
    {
        string[] datas = str.Split(NetworkGlobal.DATA_SPLIT_SYMBOL);
        Vector3 vector = Vector3.zero;
        vector.x = float.Parse(datas[0]);
        vector.y = float.Parse(datas[1]);
        vector.z = float.Parse(datas[2]);
        return vector;
    }

    // Quaternion
    public string SerializeQuaternion(Quaternion quaternion)
    {
        return SerializeVector3(quaternion.eulerAngles);
    }

    public Quaternion DeserializeQuaternion(string str)
    {
        return Quaternion.Euler(DeserializeVector3(str));
    }

    public T CastTo<T>() where T : Packet, new()
    {
        T result = new T();
        result.SetData(GetData());
        result.PostDeserialize();
        return result;
    }
}
