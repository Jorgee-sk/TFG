# AI Game Forge

## Game desing and development AI tool

<p>
AI Game Forge is a Unity tool that provides assistance in different processes of game design and development.
This tool is made up of two different parts, one more oriented to the generation of graphics by Artificial 
Intelligence and its adaptation with a U-NET model to the video game or Unity scene and the other oriented 
to the creation of elements that use AI within the video game itself such as enemies, environmental behaviour, with behaviour trees.	
</p>

<p>
We will also need an OpenAI account that allows us to make requests to its api and a generated token to be able to log in to the tool.
</p>

[OpenAIApi](https://platform.openai.com/)

<p>
To use this tool you need to install Python on your computer and a number of libraries mentioned below:
</p>

<ul>
<li>Python  3.9.11</li>
<li>opencv-python  4.8.1.78</li>
<li>tensorflow  2.14.0</li>
<li>numpy  1.26.4</li>
</ul>

<pre>
pip install opencv-python==4.8.1.78
pip install tensorflow==2.14.0
pip install numpy==1.26.4
</pre>

<p>
After installing python dependecies, we will need to clone this project from the following link:
</p>

<pre>
https://github.com/Jorgee-sk/TFG.git
</pre>

<p>
With the Unity project installed, the following line needs to be added to your Packages/manifest.json file in your Unity Project under the dependencies section to add a custom package 
dependency:
</p>

<pre>
"com.h8man.2d.navmeshplus": "https://github.com/h8man/NavMeshPlus.git#master"
</pre>

## Tool guide

### Login screen

<p>
In this first screen there are two fields to fill in:
<ul>
<li>The API key: This is the token provided by the OpenAI Api to make requests.</li>
<li>The Organization Key: The token provided by OpenAI when we are going to make requests with an account that belongs to an organization.</li>
</ul>
Normally we can access the application with a valid API key. 
Once we have logged into the application our token will be saved for when we run the program again. If we want to disconnect and access with another token or simply not remember it, hitting the exit button when our user appears as available will work.
</p>

![Login](Resources/PantallaLogin.JPG)

### AI Tool menu screen

<p>
This screen corresponds to the run-time menu of the tool. In it we can see different buttons which allow us to access to several functions of the tool:

<ul>
<li>Dall-E: Allows the generation of images using the Dall-E model 3.</li>
<li>AI Gallery: Stores the generated images, allows us to generate sprites and allows us to assign images to game elements</li>
<li>Sprite Gallery: Stores the images generated by the U-NET model and allows to assign images to game elements</li>
<li>Demo: The game scene</li>
<li>Exit button</li>
</ul>
</p>

![Login](Resources/MenuTool.JPG)

### DallE generator screen

<p>
We find the image generation section. In this section we can use a prompt to generate an image with the OpenAI Dalle-3 model to use in our videogame.
</p>

![Login](Resources/GenerateDallEImage.JPG)

### DallE gallery screen

<p>
In this gallery we found the Dall-E 3 generated images. Within this scene the images of the corresponding buttons can be assigned. The main functionality of this gallery is the generation of sprites. This generation is based on a U-NET model that by binary segmentation removes the background to create an image that can be used within the game.
</p>

![Login](Resources/GalleryImagesGenerated.JPG)

### Sprite gallery screen

<p>
This is the gallery that save the resulting images that have been subjected to the U-NET model. Also within this gallery you can assign values to all available sprites in the game. There is also a checkbox that allow us to use animated graphics with concrete images.
</p>

![Login](Resources/PNGGallery.JPG)

<p>
A visual interface is also available at runtime that facilitates the creation of behavior trees to integrate them into our game. Users can create new behaviors using the provided base nodes or recycle existing ones.
</p>
