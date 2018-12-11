#OpenGL Core

OpenGL Core is a back-end capable of supporting the latest OpenGL features on Windows, MacOS X and Linux. This scales from OpenGL 3.2 to OpenGL 4.5, depending on the OpenGL driver support.

## Enabling OpenGL Core

To set OpenGL Core as your default Graphics API in the Editor or Standalone Player, go to the **Player** window (menu: __Edit &gt; Project Settings__, then select the __Player__ category), and navigate to __Other Settings__. Disable the __Auto Graphics API for Windows__ property, and choose __OpenGLCore__ from the list. For more details, see [Graphics API support](Graphics APIs).

## OpenGL requirements

OpenGL Core has the following minimum requirements:

* Mac OS X 10.8 (OpenGL 3.2), MacOSX 10.9 (OpenGL 3.2 to 4.1)

* Windows with NVIDIA since 2006 (GeForce 8), AMD since 2006 (Radeon HD 2000), Intel since 2012 (HD 4000 / IvyBridge) (OpenGL 3.2 to OpenGL 4.5)

* Linux (OpenGL 3.2 to OpenGL 4.5)

## macOS OpenGL driver limitations

The macOS OpenGL backend for the Editor and Standalone supports OpenGL 3.x and 4.x features such as tessellation and geometry shaders. 

However, as Apple restricts the OpenGL version on OS X desktop to 4.1 at most, it does not support all DirectX 11 features (such as Unordered Access Views or Compute Shaders). This means that all shaders that are configured to target Shader Level 5.0 (with #pragma target 50) will fail to load on OS X.

Therefore a new shader target level is introduced: #pragma target gl4.1. This target level requires at least OpenGL 4.1 or DirectX 11.0 Shader Level 5 on desktop, or OpenGL ES 3.1 + Android Extension Pack on mobiles.

##OpenGL Core features

The new OpenGL back-end introduces many new features (previously mostly DX11/GLES3 only):

- Compute shaders (as well as ComputeBuffers and “random write” render textures)
- Tessellation and Geometry shaders
- Indirect draw (Graphics.DrawProcedural and Graphics.DrawProceduralIndirect)
- Advanced blend modes


##Shader changes

When using the existing <span class="docs-keyword">#pragma</span> targets, they map to following GL levels:

- \#pragma target 4.0 // OpenGL ES 3.1, desktop OpenGL 3.x, DX Shader Model 4.0
- \#pragma target gl4.1 // Desktop OpenGL 4.1, SM 4.0 + tessellation to match MacOSX 10.9 capabilities
- \#pragma target 5.0 // OpenGL ES 3.1 + Android Extension Pack, desktop OpenGL >= 4.2, DX Shader Model 5.0

For including and excluding shader platforms from using a specific shaders, the following <span class="docs-keyword">#pragma</span> only_renderers / exclude_renderers targets can be used:

- **#pragma only_renderers glcore**: Only compile for the desktop GL. Like the ES 3 target, this also scales up to contain all desktop GL versions, where basic shaders will support GL 2.x while shaders requiring SM5.0 features require OpenGL 4.2+.


##OpenGL core profile command line arguments

It’s possible to start the editor or the player with OpenGL using the command line arguments:

- **-force-opengl**: To use the legacy OpenGL back-end
- **-force-glcore**: To use the new OpenGL back-end. With this argument, Unity will detect all the features the platform support to run with the best OpenGL version possible and all available OpenGL extensions
- **-force-glcoreXY**: XY can be 32, 33, 40, 41, 42, 43, 44 or 45; each number representing a specific version of OpenGL. If the platform doesn’t support a specific version of OpenGL, Unity will fallback to a supported version
- **-force-clamped**: Request that Unity doesn’t use OpenGL extensions which guarantees that multiple platforms will execute the same code path. This is an approach to test if an issue is platform specific (a driver bug for example). 

##Native OpenGL ES on desktop command line arguments

OpenGL ES graphics API is available on Windows machines with Intel or NVIDIA GPUs with drivers supporting OpenGL ES.

- **-force-gles**: To use the new OpenGL back-end in OpenGL ES mode. With this argument, Unity will detect all the features the platform support to run with the best OpenGL ES version possible and all available OpenGL ES extensions
- **-force-glesXY**: XY can be 20, 30, 31 or 31aep; each number representing a specific version of OpenGL ES. If the platform doesn’t support a specific version of OpenGL ES, Unity will fallback to a supported version. If the platform doesn’t support OpenGL ES, Unity will fallback to another graphics API.
- **-force-clamped**: Request that Unity doesn’t use OpenGL extensions which guarantees that multiple platforms will execute the same code path. This is an approach to test if an issue is platform specific (a driver bug for example).

---

* <span class="page-edit">2018-06-02  <!-- include IncludeTextAmendPageYesEdit --></span>

