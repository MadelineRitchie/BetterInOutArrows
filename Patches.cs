/*
 * A TON OF THIS CODE WAS TAKEN FROM THE PROLIFIC AND SKILLED AKI
 * go play with Aki's stuff
 * https://github.com/aki-art
 * go buy Aki a coffee
 * https://ko-fi.com/akisenkinn
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace BetterInOutArrows
{
    // BUG only loads _need_ items correctly
    // ideas:
    // try looking at other hooks
    // try looking at original source code for references
    // ask the discord of course
    [HarmonyPatch(typeof(Assets), "OnPrefabInit")]
    public class Assets_OnPrefabInit_Patch
    {
        public static string ModPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void Postfix()
        {
            var names = new List<string>
            {
                "input",
                "output",
                "status_item_need_supply_in",
                "status_item_need_supply_out",
                "legend_liquid_input",
                "legend_liquid_output",
            };

            foreach (var name in names)
            {
                var tex = LoadTexture(name, ModPath);
                var original = Assets.GetSprite(name);
                var sprite = Sprite.Create(tex, original.rect, original.pivot);

                Assets.Sprites[new HashedString(name)] = sprite;

                foreach (var tintedSprite in Assets.TintedSprites)
                {
                    if (tintedSprite.sprite.name == name)
                    {
                        tintedSprite.sprite = sprite;
                        break;
                    }
                }
            }
        }

        public static Texture2D LoadTexture(string name, string directory)
        {
            var path = Path.Combine(directory, name + ".png");

            var data = File.ReadAllBytes(path);
            var texture = new Texture2D(1, 1);
            texture.LoadImage(data);

            return texture;
        }
    }
}