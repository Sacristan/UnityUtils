using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils
{
    public static class GameObjectExtensions
    {
        public static void SetLayerRecursively(this GameObject obj, string layerName)
        {
            int layer = LayerMask.NameToLayer(layerName);
            SetLayerRecursively(obj, layer);
        }

        public static bool IsInLayerMask(this GameObject go, LayerMask layermask)
        {
            return IsInLayerMask(go.layer, layermask);
        }

        public static bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }

        public static bool IsGameObjectLayer(this GameObject go, string layerName)
        {
            return go.layer == LayerMask.NameToLayer(layerName);
        }

        public static void SetLayerRecursively(this GameObject obj, int layer)
        {
            if (obj == null) return;

            obj.layer = layer;

            for (int i = 0; i < obj.transform.childCount; i++)
            {
                Transform child = obj.transform.GetChild(i);
                if (child != null) SetLayerRecursively(child.gameObject, layer);
            }
        }

        public static void EnableGameObjects(GameObject[] objects, bool flag)
        {
            if (objects == null || objects.Length == 0) return;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(flag);
            }
        }

        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            if (go.TryGetComponent<T>(out T component)) return component;
            else return go.AddComponent<T>();
        }

        public static T[] GetThisAndChildrenComponents<T>(this GameObject go) where T : Component
        {
            List<T> components = new List<T>();

            T[] same = go.GetComponents<T>();
            T[] children = go.GetComponentsInChildren<T>();

            if (same != null && same.Length > 0) components.AddRange(same);
            if (children != null && children.Length > 0) components.AddRange(children);

            return components.ToArray();
        }
    }
}