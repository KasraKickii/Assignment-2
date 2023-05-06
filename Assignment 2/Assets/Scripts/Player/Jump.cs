using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public PlayerMovement player;
    public void setboool()
    {
        if (player.canJump)
        {
            player.jumping = true;
            player.canJump = false;
        }
    }

}
