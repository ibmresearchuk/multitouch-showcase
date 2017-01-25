# Multi-touch Showcase features.

The following document describes how to create folder structures that will work with the Multitouch 'Showcase' software. Current documentation about this can be found via the link below however a brief guide is contained in this file. 

https://cornerstone.multitouch.fi/sites/default/files/generated-content/application-guide/experience.html

## Top Level Structure

At the top level there must be three folders : 

1. Configuration
   Definitions of databases and email sending functionality.
2. Content
   Content displayed by the application (e.g. Images, Videos, Widgets, etc.)
3. Theme
   Theme (looks) of the application
   
### 1. Configuration





### 2. Content

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

#### Sub-menus

#### Books

#### Plugins 

#### Twitter

#### Web Browser

#### Menus 

### 3. Theme


