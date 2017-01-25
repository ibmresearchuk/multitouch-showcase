## 2. Content

The content folder should contain all content related files in the installation. The top-level directory of the Experience menu is by default a folder called root located inside the data folder. All of the content accessible from the menu structure must be located under the root folder. The top-level of data folder besides the root sub-folder is reserved for additional data that some of the components of the content may need (see MultiTaction 3D model in example content).

A JavaScript file called init.js is also located in the data folder. If it exists, it is executed once during the initialization of Experience. Content-specific initialization procedures can be placed in this file. In the example content this file creates a secondary teaser to the application and defines some word replacements that are used with the menu bubbles (on disk, the folders are called example1, example2, etc. but for the application they have different names).

For example : 

```
Content
       \data\root
                 \folder1
                 \folder2
                 \folder3
       \data\init.js
```       


The rest of this page describes how different types of content can be used.

##### Images

Images are the most simple type of content supported by Experience. It is enough to place them in the content directory and they will be added automatically to the menu. Most common formats such as JPEG, PNG or TGA are supported. Menu icons will be automatically generated from images. Icons can be customized by setting the icon manually

##### Videos

Experience is able to play most of the common video formats. Videos can simply be added in the same way as images. The only difference is that videos create automatic icons based on a hardcoded frame of the video. If you don't like that frame as the video icon, you need to create one to your liking manually.

#### Books

There is a possibility to put a collection of images in a book-like container. This is achieved by creating a folder with a suffix .book and placing the images in this folder. For instance creating a book container called My brochure requires having folder called My brochure.book containing the images of the brochure. Pages of the book are placed in the alphabetical order of the file names. Also books need to have icons specified manually.

Experience has another way to show a collection of images. This is called an "item flow" in Cornerstone 2. The instructions for creating an item flow are similar to those for creating books but instead of using the .book suffix it uses the .flow suffix. So the only difference with books is the subfolder suffix. For example, My brochure.flow instead of My brochure.book.

#### Plugins 

Experience supports all plugins that are included in Cornerstone 2. The mechanism for loading these is the serialization and deserialization framework of Cornerstone 2. One can also add their own widgets by placing their serializations into the content folder. In practice this is achieved by creating an XML file describing the content to be opened. This section introduces some plugins that are commonly used in Experience. Note that all of these require manual specification of a menu icon.

####  - Twitter

Cornerstone 2 comes with a Twitter plugin that is specifically designed for Experience. To be able to use this, one needs to first configure access to Twitter. After this is done, it is enough to create a correspongind XML file under one of the content directories. The example below shows a definition of a TweetCloud item that searches Tweets with the keyword multitaction. Adding the multitaction.xml file described below and assigning it an icon will make it visible in the Experience menu:

```
<!DOCTYPE mtdoc>
<Styleable type="experience.TweetCloud">
    <queries>
        <string>multitaction</string>
        <string>@multitouchfi</string>
    </queries>
</Styleable>
```

####  - Web Browser

The web browser is a generic component included in Cornerstone 2. It can be added to your Experience menu in the same way as the other plugins. The following XML file creates a web browser with YouTube as a starting page:

```
<!DOCTYPE mtdoc>
<Styleable type="WebBrowserCef.BrowserWidget">
    <source>http://youtube.com</source>
</Styleable>
```

#### Menus 

The majority of the content in Experience needs to have a manually defined menu icon. The mechanism for adding menu icons is really straightforward. One needs just to add an PNG image file with the proper filename to the content directories. Assume we have folder called content1 in the content directory. We add an icon to this subfolder by creating an image file called icon-content1.png in the same directory. This applies to all menu items in Experience. Creating a menu icon for the X.ext file requires creating an PNG image file called icon-X.ext.png in the same directory.

Note
The file extension of the files is included in the name of the icon file. So for example, the icon file of the myvideo.mp4 file will be named icon-myvideo.mp4.png.

#### Sub-menus

Sub-menus in the menu structure are simply created by creating a folder under the content directory. The content in this folder will appear behind a sub-menu corresponding to this folder. One needs to also specify icons for the sub-menu items.