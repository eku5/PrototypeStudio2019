using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFriend : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundFriend me;
    
    void Awake()
    {
        me = this;
    }

}
