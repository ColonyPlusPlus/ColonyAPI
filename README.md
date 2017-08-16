# ColonyAPI

## Using the API

Simply include the API as a reference for your mod, then use its functionality via the `ColonyAPI` namespace. You can find examples of mods in the Examples folder.

You can find a download the latest version of the API for use in your game [here](https://github.com/ColonyPlusPlus/ColonyAPI/releases). The API DLL needs to be present if you are making a mod (as a reference) or if you are playing (in your mods folder).

If you are a mod creator, please link to this repository instead of bundling the API with your mod.

## Building the API

You will need to add the following files from your `Colony Survival/colonyserver_Data/Managed` folder:

- Assembly-CSharp.dll
- UnityEngine.dll
- UnityEngine.UI.dll

And `APIProvider.dll` from `Colony Survival/gamedata/mods/Pipliz/APIProvider`
