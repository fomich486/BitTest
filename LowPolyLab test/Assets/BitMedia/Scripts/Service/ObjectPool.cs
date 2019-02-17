using System.Collections.Generic;
using UnityEngine;
using BitMedia.TestProject.Gameplay.CharacterBehaviour;

public class ObjectPool : MonoBehaviour {

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPool Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void FillPool(List<Pool> pools)
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool p in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < p.size; i++)
            {
                GameObject g = Instantiate(p.pref.gameObject);
                g.SetActive(false);
                objectPool.Enqueue(g);
            }
            poolDictionary.Add(p.tag, objectPool);
        }
    }
    public GameObject GetFromPool(string tag, Vector3 position)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            print(string.Format("Doesn't contain this tag: {0}", tag));
            return null;
        }
        GameObject g = poolDictionary[tag].Dequeue();
        g.GetComponent<Character>().BackInPoolSetup();
        g.SetActive(true);
        g.transform.position = position;
        g.transform.LookAt(Vector3.zero);
        //g.transform.rotation = rotation;
        poolDictionary[tag].Enqueue(g);
        return g;
    }
}
