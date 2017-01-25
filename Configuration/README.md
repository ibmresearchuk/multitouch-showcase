## 1. Configuration

### Menu Text ( via init.js ) 

By default, the text shown below each icon is the folder name or filename of the content in question. This can be changed using word replacements. The replacements are setup in the init.js file:

```javascript 
var mainWidget = $("CESAsymmetricMainWidget")[0];
var replacements = ["root", "",
                    "tactionmodel", "MultiTaction 3D model",
                    "input visualizer", "Input Visualizer"];
var data = new Radiant.BinaryData();
replacements.forEach(function(s) { data.writeString(s); });
data.rewind();
mainWidget.eventProcess("word-replacements", data);
```

In the code above, the array replacements contains pairs of strings. For example, "root" is replaced by an empty string, "tactionmodel" will be replaced by "MultiTaction 3D Model", etc.

### Setting up twitter

Experience can be configured to fetch tweets from Twitter. The file twitter-database-config.xml is similar to the database settings introduced earlier. This file defines the path for the database used for content caching of Tweets. The SQLite database is automatically created for Twitter if the database specified in the configuration file cannot be found. An example of twitter-database-config.xml is shown below:

```
<DB>
<type>QSQLITE</type>
<databasename>twitter.db</databasename>
</DB>
```

In order for the Twitter component to work, it needs to be associated to a Twitter user account. This is done using the file named Twitter.ini. This file contains necessary OAuth tokens for logging into Twitter. Cornerstone 2 includes a TwitterSetup executable that can be used to automatically create the Twitter.ini file. When executing TwitterSetup, the internet browser will open a Twitter login page. After a succesful login, TwitterSetup copies the user's OAuth tokens to Twitter.ini. In order to use this user account in Experience, one needs to move the generated Twitter.ini file to the configuration folder of Experience.

For example : 

```
Configuration
       \Twitter.ini
       \twitter-database-config.xml
```       