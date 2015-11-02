# UnityStbEasyFont

A port of [stb_easy_font.h](https://github.com/nothings/stb/blob/master/stb_easy_font.h) to Unity/C#.

Primarily for the cases where you need some simple text, but don't want to use built-in Unity's UI/TextMesh/GUIText
for whatever reason. In my case, I needed some explanatory text on screen for automated graphics tests, that would never
change if/when our font system changes.

* SimpleTextMesh component: TextMesh equivalent (3D positioned text in world space)
* SimpleGUIText component: GUIText equivalent (screenspace pixel-size text)
