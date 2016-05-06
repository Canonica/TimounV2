﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#

public class XInput : MonoBehaviour
{
    public static XInput instance = null;
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    bool[] buttondown;
    int[] vibePlayer;
    void Awake()
    {
        instance = this;
        buttondown = new bool[2];
        buttondown[0] = false;
        buttondown[1] = false;

        vibePlayer = new int[2];
        vibePlayer[0] = 0;
        vibePlayer[1] = 0;
    }

    void Update()
    {
        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }
        prevState = state;
        state = GamePad.GetState(playerIndex);
        // Set vibration according to triggers
        //GamePad.SetVibration(playerIndex, vibe.x, vibe.y);

        // Make the current object turn
        //transform.localRotation *= Quaternion.Euler(0.0f, state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, 0.0f);
    }

    public void useVibe(int id, float time, float force1, float force2)
    {
        vibePlayer[id]++;
        StartCoroutine(vibration((PlayerIndex)(id), time, force1, force2));
    }


    public float getTrigger(int id)
    {
        return GamePad.GetState((PlayerIndex)(id)).Triggers.Right;
    }

    public ButtonState getButton(int id, char bt)
    {

        switch (bt)
        {
            case 'A':
                return GamePad.GetState((PlayerIndex)id).Buttons.A;
            case 'B':
                return GamePad.GetState((PlayerIndex)id).Buttons.B;
            case 'X':
                return GamePad.GetState((PlayerIndex)id).Buttons.X;
            case 'Y':
                return GamePad.GetState((PlayerIndex)id).Buttons.Y;
            case 'L':
                return GamePad.GetState((PlayerIndex)id).Buttons.LeftShoulder;
            case 'R':
                return GamePad.GetState((PlayerIndex)id).Buttons.RightShoulder;
            default:
                Debug.Log("ERROR X INPUT");
                return ButtonState.Released;
        }
    }

    public ButtonState getDPad(int id, char bt)
    {
        switch (bt)
        {
            case 'U':
                return GamePad.GetState((PlayerIndex)id).DPad.Up;
            case 'D':
                return GamePad.GetState((PlayerIndex)id).DPad.Down;

            case 'L':
                return GamePad.GetState((PlayerIndex)id).DPad.Left;

            case 'R':
                return GamePad.GetState((PlayerIndex)id).DPad.Right;

            default:
                Debug.Log("ERROR X INPUT");
                return ButtonState.Released;
        }
    }
    public float getXStick(int id)
    {

        return GamePad.GetState((PlayerIndex)(id)).ThumbSticks.Left.X;
    }

    public float getYStick(int id)
    {

        return GamePad.GetState((PlayerIndex)(id)).ThumbSticks.Left.Y;
    }

    IEnumerator vibration(PlayerIndex id, float time, float force1, float force2)
    {
        GamePad.SetVibration(id, force1, force2);
        yield return new WaitForSeconds(time);
        vibePlayer[(int)id]--;
        if (vibePlayer[(int)id] == 0)
            GamePad.SetVibration(id, 0, 0);
    }

    void OnDestroy()
    {
        GamePad.SetVibration((PlayerIndex)0, 0, 0);
        GamePad.SetVibration((PlayerIndex)1, 0, 0);
    }
}