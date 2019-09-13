﻿/*
 * Copyright 2019 Peter Han
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software
 * and associated documentation files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING
 * BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using PeterHan.PLib;
using System;
using UnityEngine;

namespace PeterHan.BulkSettingsChange {
	/// <summary>
	/// Stores sprites used in the bulk change tool.
	/// </summary>
	static class SpriteRegistry {
		/// <summary>
		/// Whether the sprites have been loaded.
		/// </summary>
		private static bool spritesLoaded;

		/// <summary>
		/// The sprite used for the placer icon.
		/// </summary>
		private static Sprite PLACE_ICON;

		/// <summary>
		/// The sprite used for the tool icon.
		/// </summary>
		private static Sprite TOOL_ICON;

		public static Sprite GetPlaceIcon() {
			LoadSprites();
			return PLACE_ICON;
		}

		public static Sprite GetToolIcon() {
			LoadSprites();
			return TOOL_ICON;
		}

		/// <summary>
		/// Loads the sprites if they are not already loaded.
		/// </summary>
		private static void LoadSprites() {
			if (!spritesLoaded) {
				PUtil.LogDebug("Loading sprites");
				try {
					PLACE_ICON = PUtil.LoadSprite("PeterHan.BulkSettingsChange.Placer.dds",
						256, 256);
					PLACE_ICON.name = BulkChangeStrings.PLACE_ICON_NAME;
					TOOL_ICON = PUtil.LoadSprite("PeterHan.BulkSettingsChange.Toggle.dds",
						32, 32);
					TOOL_ICON.name = BulkChangeStrings.TOOL_ICON_NAME;
				} catch (ArgumentException e) {
					// Could not load the icons, but better this than crashing
					PUtil.LogException(e);
				}
				spritesLoaded = true;
			}
		}
	}
}
