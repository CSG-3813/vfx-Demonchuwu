/***
 * Author: Akram Taghavi-Burris
 * Created: 10-30-22
 * Modified:
 * Description: Add notes to the game object in editor
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    [TextArea(10, 30)]
    public string Note = "Comment Here"; //place note in editor 
}
