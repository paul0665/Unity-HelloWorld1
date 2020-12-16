using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderChecker : MonoBehaviour
{
    private Boolean openWindows = false;
    void Start()
    {
        if (SystemInfo.graphicsDeviceType != GraphicsDeviceType.Direct3D12)
            openWindows = true;
    }
    
    void AleartWindows(int windowID)
        {
            GUI.Label(new Rect(10,30,200,80), SystemInfo.graphicsDeviceType + " is not a support API.\n\nPlease use DX12 for stability.");
            if(GUI.Button(new Rect(10, 100, 80, 20), "Ok")) 
                return;
            if(GUI.Button(new Rect(160, 100, 80, 20), "Quit")) 
                Application.Quit();
        }
    
        void OnGUI()
        {
            if (openWindows)
            {
                GUI.Window(0, new Rect(110, 10, 250, 140), AleartWindows, "Basic Window");
            }
        }
}
