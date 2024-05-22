## AI Game Forge

### Game desing and development AI tool

<p>
AI Game Forge is a Unity tool that provides assistance in different processes of game design and development.
This tool is made up of two different parts, one more oriented to the generation of graphics by Artificial 
Intelligence and its adaptation with a U-NET model to the video game or Unity scene and the other oriented 
to the creation of elements that use AI within the video game itself such as enemies, environmental behaviour, with behaviour trees.	
</p>

<p>
We will also need an OpenAI account that allows us to make requests to its api and a generated token to be able to log in to the tool.
</p>

<p>
To use this tool you need to install Python on your computer and a number of libraries mentioned below:
</p>

<ul>
<li>Python  3.9.11</li>
<li>opencv-python  4.8.1.78</li>
<li>tensorflow  2.14.0</li>
<li>numpy  1.26.4</li>
</ul>

<p>
The following line needs to be added to your Packages/manifest.json file in your Unity Project under the dependencies section to add a custom package 
dependency:
</p>

<pre>
"com.h8man.2d.navmeshplus": "https://github.com/h8man/NavMeshPlus.git#master"
</pre>

<p>In this tool we find an initial menu that provides us with different functionalities:</p>

<ol>
<li>
Firstly, we find the image generation section. In this section we can use a prompt to generate an image with the OpenAI Dalle-3 model to use in our videogame.
</li>
<li>
Secondly we find the gallery of images generated by AI. This gallery corresponds directly to the generated images. Within this scene the images of the corresponding buttons can be assigned. The main functionality of this gallery is the generation of sprites. This generation is based on a U-NET model that by binary segmentation removes the background to create an image that can be used within the game.
</li>
<li>
Thirdly we find the sprite gallery. This is the gallery resulting from the images that have been subjected to the U-NET model. Also within this gallery you can assign values to all available sprites in the game.
</li>
<li>
Finally, we find the demo which demonstrates the uses of this tool.
</li>
</ol>

<p>
Regardless of the tool being used, a visual interface is available in runtime, facilitating the creation of behavior trees for integration into our video game. Users can craft new behaviors using the base nodes provided or recycle existing ones.
</p>