# Common types of Assets

## Image files
Unity supports most common image file types, such as BMP, TIF, TGA, JPG, and PSD. If you save your layered Photoshop (.psd) files into your Assets folder, Unity imports them as flattened images. You can find out more about [importing images with alpha channels from photoshop](HOWTO-alphamaps), or [importing your images as sprites](SpriteEditor)

## FBX and Model files
Since Unity supports the FBX file format, you can import data from any 3D modeling software that supports FBX. Unity also natively supports importing SketchUp files. For information on how to get the best results when exporting your FBX files from your 3D modeling software, see [Optimizing FBX files](HOWTO-importObject).

**Note:** You can also save your 3D files from most common 3D modeling software in their native format (for example, .max, .blend, .mb, .ma). When Unity finds them in your Assets folder, it imports them by calling back to your 3D modeling software's FBX export plug-in. However, it is recommended to export them as FBX 

## Meshes and animations
Whichever 3D modeling software you are using, Unity imports the Meshes and animations from each file. For a list of 3D modeling software that Unity supports, see [Model file formats](3D-formats).

Your Mesh file does not need to have an animation to be imported. If you do use animations, you can import all animations from a single file, or import separate files, each with a single animation. For more information about importing animations, see [Model import workflows](ImportingModelFiles).

## Audio files
If you save uncompressed audio files into your Assets folder, Unity imports them according to the compression settings specified. Read more about [importing audio files](AudioFiles).

## Other Asset types
In all cases, your original source file is never modified by Unity, even though within Unity you can often choose between various ways to compress, modify, or otherwise process the Asset. The import process reads your source file, and creates a game-ready representation of your Asset internally, matching your chosen import settings. If you modify the import settings for an Asset, or make a change to the source file in the Asset folder, that causes Unity to re-import the Asset again to reflect your changes.

**Note**: *Importing native 3D formats requires that the 3D modeling software be installed on the same computer as Unity. This is because Unity uses the 3D modeling software's FBX Exporter plug-in to read the file. Alternatively, you can directly export as FBX from your application and save into the Projects folder.*

<a name="Standard"></a>
## Standard Assets

Unity ships with multiple __Standard Assets__. These are collections of Assets that are widely used by most Unity customers. These include: 2D, Cameras, Characters, CrossPlatformInput, Effects, Environment, ParticleSystems, Prototyping, Utility, Vehicles.  

Unity transfers __Standard Assets__ in and out of Projects using __Asset packages__.

***Note:*** If you chose not to install Standard Assets when you installed Unity, you can [download them](AssetPackages#Standard) from the [Asset Store](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351).

---

* <span class="page-edit"> 2018-04-25  <!-- include IncludeTextAmendPageSomeEdit --></span>

