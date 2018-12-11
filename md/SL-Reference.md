# Shader Reference

Shaders in the built-in render pipeline in Unity are written in the following ways:

* as surface shaders,
* as vertex and fragment shaders, or
* as fixed function shaders.


To determine which shader best fits your needs, consult the [shader tutorial](Shaders).

Regardless of type, shader code is always wrapped by the ShaderLab language, which organizes the shader structure. Here is an example of creating ShaderLab wrapper without shader code:

````
Shader "MyShader" {
    Properties {
        _MyTexture ("My Texture", 2D) = "white" { }
        // place other properties here, such as colors or vectors.
    }
    SubShader {
        // place the shader code here for your:
        // - surface shader,
        // - vertex and program shader, or
        // - fixed function shader
    }
    SubShader {
        // a simpler version of the subshader above goes here.
        // this version is for supporting older graphics cards.
    }
}
````

To learn about shader basics and fixed function shaders, consult the [ShaderLab syntax](SL-Shader) section. For other supported shader types, see either [Writing Surface Shaders](SL-SurfaceShaders) or [Writing vertex and fragment shaders](SL-ShaderPrograms). You can also use [post-processing effects](PostProcessingOverview) with shaders to create full-screen filters and other interesting effects.

## See Also

* [Writing Surface Shaders](SL-SurfaceShaders).
* [Writing vertex and fragment shaders](SL-ShaderPrograms).
* [ShaderLab Syntax Reference](SL-Shader).
* [Shader Assets](class-Shader).
* [Advanced ShaderLab Topics](SL-AdvancedTopics).
