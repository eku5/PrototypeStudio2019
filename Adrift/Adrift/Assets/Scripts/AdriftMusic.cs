using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// put this on the game soundtrack, make sure playonawake and looping are checked
/// doesn't destroy on load
/// </summary>
public class AdriftMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
