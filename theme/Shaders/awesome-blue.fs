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
uniform float invscale;

uniform int fingerCount;
uniform sampler2D inputTex;
uniform sampler3D etex;

in vec2 fs_vertex_uv;
out vec4 frag_color;

#define INPUT_TEX_SIZE 256

float e(vec3 c)
{
  vec3 c2 = c * vec3(0.25) + vec3(0.5);
  return texture(etex, c2).r;
}

vec4 backgroundColor()
{
  vec2 c=-1.0+2.0*fs_vertex_uv;
  c.x *= resolution.x / resolution.y;
  vec3 o=vec3(c.r,c.g,0.0),g=vec3(c.r,c.g,1.0)/128.0,v=vec3(0.5);
  float m = 0.4;

  for(int r=0;r<16;r++)
  {
    float h = e(o)-m;
    o+=h*10.0*g;
    v+=h*0.02;
  }
  // light (who needs a normal?)
  //v+=e(o+0.1)*vec3(0.1,0.36,0.0);
  v+=e(o+0.1)* vec3(0x13/255.0, 0xb5/255.0, 0xea/255.0);

  // ambient occlusion
  float a=0.0;
  for(float r=0;r<6;r++)
    a+=clamp(e(o+0.5*vec3(cos(1.1*r),cos(1.6*r),cos(1.4*r)))-m,0.0,0.25);
  v*=a*0.4;

  // Gamma correct (increase saturation)
  v=pow(v,vec3(1.2));

  return vec4(v, 1.0);
}

//////////////////////////////////////////

vec4 blobColor(vec2 p, vec2 fp)
{
  float r = 16 * invscale;

  float d = distance(p, fp);

  float w0 = r / d;

  float w = step(0.1, w0) * pow(w0, 3);
 
  return vec4(1, 1, 0, 1) * w;  
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
