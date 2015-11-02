# UnityStbEasyFont

A port of [stb_easy_font.h](https://github.com/nothings/stb/blob/master/stb_easy_font.h) to Unity/C#.

Primarily for the cases where you need some simple text, but don't want to use built-in Unity's UI/TextMesh/GUIText
for whatever reason. In my case, I needed some explanatory text on screen for automated graphics tests, that would never
change if/when our font system changes.

![GameView](/Docs/GameView.png?raw=true "Simple text in game view")

*SimpleTextMesh* component: TextMesh equivalent (3D positioned text in world space)

![SimpleTextMesh](/Docs/InspectorSimpleTextMesh.png?raw=true "SimpleTextMesh")

*SimpleGUIText* component: GUIText equivalent (screenspace pixel-size text)

![SimpleGUIText](/Docs/InspectorSimpleGUIText.png?raw=true "SimpleGUIText")


## License

This software is in the public domain. Where that dedication is not
recognized, you are granted a perpetual, irrevocable license to copy,
distribute, and modify these files as you see fit.
