// /*
// MIT License
// 
// Copyright (c) $today.year Paul0665(as know as Paul)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// */

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
                GUI.Window(0, new Rect(0, 0, 250, 140), AleartWindows, "Unsupported Graphics API");
            }
        }
}
