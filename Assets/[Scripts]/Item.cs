using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { zero, one, two, three }
public class Item : MonoBehaviour
{
    public Type type;

    public int itemScore;

    public Vector3 startPos, finalPos;
    public Item sideItem;

    private void Start()
    {
        startPos = transform.position;

    }

    public void BaseState()
    {
        tag = "item";
        transform.position = startPos;
    }
}
