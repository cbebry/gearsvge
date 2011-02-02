﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using Gears.Cloud; 

namespace GearsDebug
{
    //TODO: Move this into content-containing class section. 
    //          Menu should belong to Gears.Navigation.MenuEngineX.
    internal class MainMenu : GameState
    {
        //private bool _init = false; //whether or not this has been initialized

        private SpriteFont menuFont;
        private SpriteFont menuItemFont;

        private Vector2 menuTitlePosition;
        private Color menuTitleColor;
        private bool menuTitleToggle = false; //Special flag for scripted events

        private Vector2 menuItem1Position;
        private Vector2 menuItem2Position;


        public MainMenu()
        {
            Initialize();
            LoadContent();
        }
        private void Initialize()
        {
            //BAD HARDCODES
            //refactored from constructor-mapped to this function for later parameterization.
            menuTitlePosition = new Vector2(540, 120);
            menuTitleColor = new Color(255, 255, 255);

            menuItem1Position = new Vector2(800, 240);
            menuItem2Position = new Vector2(858, 268); //y offset: (16px font + 12px spacing)
        }
        private void LoadContent()
        {
            menuFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuFont");
            menuItemFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuItem");
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(menuFont, "Catalyst", menuTitlePosition, menuTitleColor);
            spriteBatch.DrawString(menuItemFont, "start game", menuItem1Position, Color.WhiteSmoke);
            spriteBatch.DrawString(menuItemFont, "options", menuItem2Position, Color.WhiteSmoke);
        }
        protected internal override void Update(GameTime gameTime)
        {
            Update_MenuTitleFontColor();
        }

        private void Update_MenuTitleFontColor()
        {
            if (!menuTitleToggle)
            {
                menuTitleColor.B--;
                menuTitleColor.G--;
                menuTitleColor.R--;
            }
            else
            {
                menuTitleColor.B++;
                menuTitleColor.G++;
                menuTitleColor.R++;
            }

            if (menuTitleColor.R == 0)
            {
                menuTitleToggle = true;
            }
            if (menuTitleColor.R == 255)
            {
                menuTitleToggle = false;
            }
        }
    }
}
