/* 'Nautilus' by Weyland Yutani (reworked by iq) (2010)

    Ported to Cornerstone by esa@multitouch.fi (2011)
*/
#version 150

layout(std140, column_major) uniform BaseBlock
{
  mat4 projMatrix;
  mat4 modelMatrix;
  vec4 color;
  float depth;
};

uniform float time;
uniform vec2 resolution;

uniform int fingerCount;
uniform sampler2D inputTex;
uniform sampler3D etex;

in vec2 fs_vertex_uv;
out vec4 frag_color;

#define FOREGROUND_COLOR_LIGHT vec3(54.0/255.0, 169.0/255.0, 225.0/255.0)
#define FOREGROUND_COLOR_DARK vec3(0, 56.0/255.0, 110.0/255.0)
#define BACKGROUND_COLOR_LIGHT vec3(230/255.0, 0, 126.0/255.0)
#define BACKGROUND_COLOR_DARK vec3(85.0/255.0, 15.0/255.0, 85.0/255.0)

// Increase to make the background lighter
#define BACKGROUND_LIGHTNESS 0.2

// Comment to speed up the shader but have worse banding artifacts
// #define USE_NOISE

// Comment to speed up the shader
// #define GAMMA_CORRECT

// Decrease to speed up the shader
#define STEPS 16

// Ambient occlusion steps, 3 is tolerable, 10 is good.
// Decrease to speed up the shader.
// Also change AO_*_FACTORS if you modify this!
#define AO_STEPS 3

// With AO_STEPS 3, these should be about 1.2 and 1.5
#define AO_LIGHT_FACTOR 1.5
#define AO_DARK_FACTOR 0.9

#define INPUT_TEX_SIZE 256

float e(vec3 c)
{
  vec3 c2 = c * vec3(0.15) + vec3(0.5);
  return texture(etex, c2).r;
}

float nrand( vec2 n )
{
 return fract(sin(dot(n.xy, vec2(12.9898, 78.233+fract(time)*100.0)))* (43758.5453+time));
}

vec4 backgroundColor()
{
  vec2 c=-1.0+2.0*fs_vertex_uv;
  c.x *= resolution.x / resolution.y;
  vec3 o=vec3(c.r,c.g,0.0),g=vec3(c.r,c.g,1.0)/128.0,v=vec3(0.5);
  float m = 0.4;

  for(int r=0;r<STEPS;r++)
  {
    float h = e(o)-m;
    o+=h*8.0*g;
    v+=h*0.02;
  }

  v *= BACKGROUND_COLOR_DARK * 0.5;
  v += e(o) * BACKGROUND_COLOR_LIGHT * BACKGROUND_LIGHTNESS;

  // ambient occlusion
  float a=0.0,b=0.0;
  for(float r=0;r<AO_STEPS;r++)
    a+=clamp(e(o+0.5*vec3(cos(1.1*r),cos(1.6*r),cos(1.4*r)))-m,0.0,0.25);
  for(float r=AO_STEPS;r<2*AO_STEPS;r++)
    b+=clamp(e(o+0.5*vec3(cos(1.03579*r),cos(1.85732*r),cos(1.235*r)))-m,0.0,0.25);
  a *= AO_LIGHT_FACTOR;
  b *= AO_DARK_FACTOR;
  vec3 v2 = a*FOREGROUND_COLOR_LIGHT*0.5 + b*FOREGROUND_COLOR_DARK;
  v = mix(v, v2, 2.0*a*b*pow(fs_vertex_uv.t, 3.0));

#ifdef USE_NOISE
  v += vec3(nrand(fs_vertex_uv.st)*0.01);
#endif

#ifdef GAMMA_CORRECT
  // Gamma correct (increase saturation)
  v=pow(v,vec3(1.1));
#endif

  return vec4(v, 1.0);
}

//////////////////////////////////////////

vec4 blobColor(vec2 p, vec2 fp)
{
  const float r = 16;

  float d = distance(p, fp);

  float w0 = r / d;

  float w = step(0.1, w0) * pow(w0, 3);
 
  // return vec4(FOREGROUND_COLOR_LIGHT, 1) * w;  
  return vec4(1, 0, 0, 1) * w;  
}

vec4 blobColorAll()
{
  vec2 p = fs_vertex_uv * resolution;

  vec4 color = vec4(0, 0, 0, 0);

  for(int i = 0; i < fingerCount; i++) {

    vec2 uu = vec2(float(i) / INPUT_TEX_SIZE + 0.5/INPUT_TEX_SIZE, 0);

    vec4 tex = texture(inputTex, uu);
    vec2 fingerPos = resolution.xy * tex.rg;
    float w = tex.b;
  
    color += blobColor(p, fingerPos) * w;
  }

  return color;
}

void main(void)
{
  vec4 color = backgroundColor();

  color += blobColorAll();

  frag_color = color;
}
