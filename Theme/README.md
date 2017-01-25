## 3. Theme

The looks of Experience can be heavily customized. This is achieved via CSS files. The Theme folder is specified from the command line using the --theme argument. The theme folder is required to have a style.css file that specifies the overall style of the application. The default theme shipped with Cornerstone 2 uses style.css to include the rest of the stylesheet files. The exhaustive documentation of the modifiable CSS attributes can be found in the comment sections of the CSS files themselves.

This page lists some of the sub-components and CSS parameters. All references to the file names assume that the default theme is in use.

### Email sending

The whole email sending can be enabled or disabled by adjusting the use-enriched-markers attribute of the CESAsymmetricMarkerDetector CSS type. The associated definition is located in line 6 of the markerdetector.css file in the Stylesheets subfolder of the default theme folder.

The style definitions of the hotspot-box that is spawned when the personalized marker is placed on the screen are located in contentsender.css.

### Floating teasers

The definitions of the floating teasers can be found in teasers.css. This file contains the movement definitions of the teaser bubbles and the image floating in the background.