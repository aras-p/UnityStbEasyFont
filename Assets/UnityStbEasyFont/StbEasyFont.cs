// port of stb_easy_font.h into Unity/C# - public domain
// Aras Pranckevicius, 2015 November
//
// Original one: https://github.com/nothings/stb/blob/master/stb_easy_font.h
// stb_easy_font.h - v0.6 - bitmap font for 3D rendering - public domain
// Sean Barrett, Feb 2015

using UnityEngine;
using System.Collections.Generic;

public class StbEasyFont
{
	struct CharInfo {
		public CharInfo(byte a, byte h, byte v)
		{
			advance = a;
			h_seg = h;
			v_seg = v;
		}
		public byte advance;
		public byte h_seg;
		public byte v_seg;
	};
	static CharInfo[] stb_easy_font_charinfo = new CharInfo[96] {
		new CharInfo(  5,  0,  0 ),  new CharInfo(  3,  0,  0 ),  new CharInfo(  5,  1,  1 ),  new CharInfo(  7,  1,  4 ),
		new CharInfo(  7,  3,  7 ),  new CharInfo(  7,  6, 12 ),  new CharInfo(  7,  8, 19 ),  new CharInfo(  4, 16, 21 ),
		new CharInfo(  4, 17, 22 ),  new CharInfo(  4, 19, 23 ),  new CharInfo( 23, 21, 24 ),  new CharInfo( 23, 22, 31 ),
		new CharInfo( 20, 23, 34 ),  new CharInfo( 22, 23, 36 ),  new CharInfo( 19, 24, 36 ),  new CharInfo( 21, 25, 36 ),
		new CharInfo(  6, 25, 39 ),  new CharInfo(  6, 27, 43 ),  new CharInfo(  6, 28, 45 ),  new CharInfo(  6, 30, 49 ),
		new CharInfo(  6, 33, 53 ),  new CharInfo(  6, 34, 57 ),  new CharInfo(  6, 40, 58 ),  new CharInfo(  6, 46, 59 ),
		new CharInfo(  6, 47, 62 ),  new CharInfo(  6, 55, 64 ),  new CharInfo( 19, 57, 68 ),  new CharInfo( 20, 59, 68 ),
		new CharInfo( 21, 61, 69 ),  new CharInfo( 22, 66, 69 ),  new CharInfo( 21, 68, 69 ),  new CharInfo(  7, 73, 69 ),
		new CharInfo(  9, 75, 74 ),  new CharInfo(  6, 78, 81 ),  new CharInfo(  6, 80, 85 ),  new CharInfo(  6, 83, 90 ),
		new CharInfo(  6, 85, 91 ),  new CharInfo(  6, 87, 95 ),  new CharInfo(  6, 90, 96 ),  new CharInfo(  7, 92, 97 ),
		new CharInfo(  6, 96,102 ),  new CharInfo(  5, 97,106 ),  new CharInfo(  6, 99,107 ),  new CharInfo(  6,100,110 ),
		new CharInfo(  6,100,115 ),  new CharInfo(  7,101,116 ),  new CharInfo(  6,101,121 ),  new CharInfo(  6,101,125 ),
		new CharInfo(  6,102,129 ),  new CharInfo(  7,103,133 ),  new CharInfo(  6,104,140 ),  new CharInfo(  6,105,145 ),
		new CharInfo(  7,107,149 ),  new CharInfo(  6,108,151 ),  new CharInfo(  7,109,155 ),  new CharInfo(  7,109,160 ),
		new CharInfo(  7,109,165 ),  new CharInfo(  7,118,167 ),  new CharInfo(  6,118,172 ),  new CharInfo(  4,120,176 ),
		new CharInfo(  6,122,177 ),  new CharInfo(  4,122,181 ),  new CharInfo( 23,124,182 ),  new CharInfo( 22,129,182 ),
		new CharInfo(  4,130,182 ),  new CharInfo( 22,131,183 ),  new CharInfo(  6,133,187 ),  new CharInfo( 22,135,191 ),
		new CharInfo(  6,137,192 ),  new CharInfo( 22,139,196 ),  new CharInfo(  5,144,197 ),  new CharInfo( 22,147,198 ),
		new CharInfo(  6,150,202 ),  new CharInfo( 19,151,206 ),  new CharInfo( 21,152,207 ),  new CharInfo(  6,155,209 ),
		new CharInfo(  3,160,210 ),  new CharInfo( 23,160,211 ),  new CharInfo( 22,164,216 ),  new CharInfo( 22,165,220 ),
		new CharInfo( 22,167,224 ),  new CharInfo( 22,169,228 ),  new CharInfo( 21,171,232 ),  new CharInfo( 21,173,233 ),
		new CharInfo(  5,178,233 ),  new CharInfo( 22,179,234 ),  new CharInfo( 23,180,238 ),  new CharInfo( 23,180,243 ),
		new CharInfo( 23,180,248 ),  new CharInfo( 22,189,248 ),  new CharInfo( 22,191,252 ),  new CharInfo(  5,196,252 ),
		new CharInfo(  3,203,252 ),  new CharInfo(  5,203,253 ),  new CharInfo( 22,210,253 ),  new CharInfo(  0,214,253 ),
	};
	static byte[] stb_easy_font_hseg = new byte[214] {
		97,37,69,84,28,51,2,18,10,49,98,41,65,25,81,105,33,9,97,1,97,37,37,36,
		81,10,98,107,3,100,3,99,58,51,4,99,58,8,73,81,10,50,98,8,73,81,4,10,50,
		98,8,25,33,65,81,10,50,17,65,97,25,33,25,49,9,65,20,68,1,65,25,49,41,
		11,105,13,101,76,10,50,10,50,98,11,99,10,98,11,50,99,11,50,11,99,8,57,
		58,3,99,99,107,10,10,11,10,99,11,5,100,41,65,57,41,65,9,17,81,97,3,107,
		9,97,1,97,33,25,9,25,41,100,41,26,82,42,98,27,83,42,98,26,51,82,8,41,
		35,8,10,26,82,114,42,1,114,8,9,73,57,81,41,97,18,8,8,25,26,26,82,26,82,
		26,82,41,25,33,82,26,49,73,35,90,17,81,41,65,57,41,65,25,81,90,114,20,
		84,73,57,41,49,25,33,65,81,9,97,1,97,25,33,65,81,57,33,25,41,25,
	};
	static byte[] stb_easy_font_vseg = new byte[253]{
		4,2,8,10,15,8,15,33,8,15,8,73,82,73,57,41,82,10,82,18,66,10,21,29,1,65,
		27,8,27,9,65,8,10,50,97,74,66,42,10,21,57,41,29,25,14,81,73,57,26,8,8,
		26,66,3,8,8,15,19,21,90,58,26,18,66,18,105,89,28,74,17,8,73,57,26,21,
		8,42,41,42,8,28,22,8,8,30,7,8,8,26,66,21,7,8,8,29,7,7,21,8,8,8,59,7,8,
		8,15,29,8,8,14,7,57,43,10,82,7,7,25,42,25,15,7,25,41,15,21,105,105,29,
		7,57,57,26,21,105,73,97,89,28,97,7,57,58,26,82,18,57,57,74,8,30,6,8,8,
		14,3,58,90,58,11,7,74,43,74,15,2,82,2,42,75,42,10,67,57,41,10,7,2,42,
		74,106,15,2,35,8,8,29,7,8,8,59,35,51,8,8,15,35,30,35,8,8,30,7,8,8,60,
		36,8,45,7,7,36,8,43,8,44,21,8,8,44,35,8,8,43,23,8,8,43,35,8,8,31,21,15,
		20,8,8,28,18,58,89,58,26,21,89,73,89,29,20,8,8,30,7,
	};

	static void stb_easy_font_draw_segs(float x, float y, byte[] segs, int segs_start, int num_segs, bool vertical, Color32 c, List<Vector3> vbuf, List<Color32> cbuf)
	{
	    int i,j;
	    for (i=segs_start; i < segs_start + num_segs; ++i){
	        int len = segs[i] & 7;
	        x += (float) ((segs[i] >> 3) & 1);
	        if (len != 0) {
	            float y0 = y + (float) (segs[i]>>4);
	            for (j=0; j < 4; ++j) {
					Vector3 pos = new Vector3(
						x  + (j==1 || j==2 ? (vertical ? 1 : len) : 0),
						y0 + (    j >= 2   ? (vertical ? len : 1) : 0),
						0.0f
					);
					vbuf.Add(pos);
					if (cbuf != null)
						cbuf.Add(c);
	            }
	        }
	    }
	}

	static float stb_easy_font_spacing_val = 0;
	static public void stb_easy_font_spacing(float spacing)
	{
	   stb_easy_font_spacing_val = spacing;
	}

	static public void stb_easy_font_print(float x, float y, string text, Color32 color, List<Vector3> vertex_buffer, List<Color32> color_buffer)
	{
	    float start_x = x;
		int max_verts = 64000/4;

		int textIndex = 0;
		int textLength = text.Length;
		while (textIndex < textLength && vertex_buffer.Count < max_verts)
		{
			char textChar = text[textIndex];
	        if (textChar == '\n') {
	            y += 12;
	            x = start_x;
	        } else {
				int charIndex = (int)textChar - 32;
				if (charIndex < 0 || charIndex >= stb_easy_font_charinfo.Length)
					charIndex = (int)'?' - 32;
	            byte advance = stb_easy_font_charinfo[charIndex].advance;
				float y_ch = (advance & 16) != 0 ? y+1 : y;
	            int h_seg, v_seg, num_h, num_v;
	            h_seg = stb_easy_font_charinfo[charIndex  ].h_seg;
				v_seg = stb_easy_font_charinfo[charIndex  ].v_seg;
				num_h = stb_easy_font_charinfo[charIndex+1].h_seg - h_seg;
				num_v = stb_easy_font_charinfo[charIndex+1].v_seg - v_seg;
				stb_easy_font_draw_segs(x, y_ch, stb_easy_font_hseg, h_seg, num_h, false, color, vertex_buffer, color_buffer);
				stb_easy_font_draw_segs(x, y_ch, stb_easy_font_vseg, v_seg, num_v, true, color, vertex_buffer, color_buffer);
	            x += advance & 15;
	            x += stb_easy_font_spacing_val;
	        }
	        ++textIndex;
	    }
	}

	static public int stb_easy_font_width(string text)
	{
	    float len = 0;
		int textIndex = 0;
		int textLength = text.Length;
		while (textIndex < textLength) {
			int charIndex = (int)text[textIndex] - 32;
			if (charIndex < 0 || charIndex >= stb_easy_font_charinfo.Length)
				charIndex = (int)'?' - 32;
	        len += stb_easy_font_charinfo[charIndex].advance & 15;
	        len += stb_easy_font_spacing_val;
			++textIndex;
	    }
		return Mathf.CeilToInt(len);
	}	
}

/*
// stb_easy_font.h - v0.6 - bitmap font for 3D rendering - public domain
// Sean Barrett, Feb 2015
//
//    Easy-to-deploy,
//    reasonably compact,
//    extremely inefficient performance-wise,
//    crappy-looking,
//    ASCII-only,
//    bitmap font for use in 3D APIs.
//
// Intended for when you just want to get some text displaying
// in a 3D app as quickly as possible.
//
// Doesn't use any textures, instead builds characters out of quads.
//
// DOCUMENTATION:
//
//   int stb_easy_font_width(char *text)
//
//      Takes a string without newlines and returns the horizontal size.
//
//   int stb_easy_font_print(float x, float y,
//                           char *text, byte color[4],
//                           void *vertex_buffer, int vbuf_size)
//
//      Takes a string (which can contain '\n') and fills out a
//      vertex buffer with renderable data to draw the string.
//      Output data assumes increasing x is rightwards, increasing y
//      is downwards.
//
//      The vertex data is divided into quads, i.e. there are four
//      vertices in the vertex buffer for each quad.
//
//      The vertices are stored in an interleaved format:
//
//         x:float
//         y:float
//         z:float
//         color:uint8[4]
//
//      You can ignore z and color if you get them from elsewhere
//      This format was chosen in the hopes it would make it
//      easier for you to reuse existing buffer-drawing code.
//
//      If you pass in NULL for color, it becomes 255,255,255,255.
//
//      Returns the number of quads.
//
//      If the buffer isn't large enough, it will truncate.
//      Expect it to use an average of ~270 bytes per character.
//
//      If your API doesn't draw quads, build a reusable index
//      list that allows you to render quads as indexed triangles.
//
//   void stb_easy_font_spacing(float spacing)
//
//      Use positive values to expand the space between characters,
//      and small negative values (no smaller than -1.5) to contract
//      the space between characters. 
//
//      E.g. spacing = 1 adds one "pixel" of spacing between the
//      characters. spacing = -1 is reasonable but feels a bit too
//      compact to me; -0.5 is a reasonable compromise as long as
//      you're scaling the font up.
//
// SAMPLE CODE:
//
//    Here's sample code for old OpenGL; it's a lot more complicated
//    to make work on modern APIs, and that's your problem.
//
// LICENSE
//
//   This software is in the public domain. Where that dedication is not
//   recognized, you are granted a perpetual, irrevocable license to copy,
//   distribute, and modify this file as you see fit.
//
// VERSION HISTORY
//
//   (2015-09-13)  0.6   #include <math.h>; updated license
//   (2015-02-01)  0.5   First release

#if 0
void print_string(float x, float y, char *text, float r, float g, float b)
{
  static char buffer[99999]; // ~500 chars
  int num_quads;

  num_quads = stb_easy_font_print(x, y, text, NULL, buffer, sizeof(buffer));

  glColor3f(r,g,b);
  glEnableClientState(GL_VERTEX_ARRAY);
  glVertexPointer(2, GL_FLOAT, 16, buffer);
  glDrawArrays(GL_QUADS, 0, num_quads*4);
  glDisableClientState(GL_VERTEX_ARRAY);
}
#endif

#ifndef INCLUDE_STB_EASY_FONT_H
#define INCLUDE_STB_EASY_FONT_H

#include <stdlib.h>
#include <math.h>

#endif
*/
