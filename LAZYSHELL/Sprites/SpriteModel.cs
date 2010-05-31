using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    public class SpriteModel
    {
        private Model model;
        private byte[] data;
        private Sprite[] sprites; public Sprite[] Sprites { get { return this.sprites; } }
        private GraphicPalette[] graphicPalettes; public GraphicPalette[] GraphicPalettes { get { return this.graphicPalettes; } }
        private Animation[] animations; public Animation[] Animation { get { return this.animations; } }
        private SpritePalette[] spritePalettes; public SpritePalette[] SpritePalettes { get { return this.spritePalettes; } }

        private WorldMap[] worldMaps; public WorldMap[] WorldMaps { get { return this.worldMaps; } }
        private MapPoint[] mapPoints; public MapPoint[] MapPoints { get { return this.mapPoints; } }

        private Dialogue[] dialogues; public Dialogue[] Dialogues { get { return dialogues; } }
        private BattleDialogue[] battleDialogues; public BattleDialogue[] BattleDialogues { get { return battleDialogues; } }
        private BattleDialogue[] battleMessages; public BattleDialogue[] BattleMessages { get { return battleMessages; } }

        private FontCharacter[] fontMenu; public FontCharacter[] FontMenu { get { return this.fontMenu; } }
        private FontCharacter[] fontDialogue; public FontCharacter[] FontDialogue { get { return this.fontDialogue; } }
        private FontCharacter[] fontDescription; public FontCharacter[] FontDescription { get { return this.fontDescription; } }
        private FontCharacter[] fontTriangle; public FontCharacter[] FontTriangle { get { return this.fontTriangle; } }

        private Effect[] effects; public Effect[] Effects { get { return this.effects; } }
        private E_Animation[] e_animations; public E_Animation[] E_animations { get { return this.e_animations; } }
        
        public SpriteModel(byte[] data, Model model)
        {
            this.data = data;
            this.model = model;

            CreateSprites();
            CreateGraphicPalettes();
            CreateAnimations();
            CreateSpritePalettes();

            CreateWorldMaps();
            CreateMapPoints();

            CreateDialogue();
            CreateBattleDialogue();

            CreateFontCharacters();

            model.Data[0x331EB2] = 0x86;    // there is an effect animation with the incorrect data block length

            CreateEffects();
            CreateE_Animations();
        }
        private void CreateSprites()
        {
            sprites = new Sprite[1024];
            for (int i = 0; i < sprites.Length; i++)
                sprites[i] = new Sprite(data, i);
        }
        private void CreateGraphicPalettes()
        {
            graphicPalettes = new GraphicPalette[512];
            for (int i = 0; i < graphicPalettes.Length; i++)
                graphicPalettes[i] = new GraphicPalette(data, i);
        }
        private void CreateAnimations()
        {
            animations = new Animation[444];
            for (int i = 0; i < animations.Length; i++)
                animations[i] = new Animation(data, i);
        }
        private void CreateSpritePalettes()
        {
            spritePalettes = new SpritePalette[819];
            for (int i = 0; i < spritePalettes.Length; i++)
                spritePalettes[i] = new SpritePalette(data, i);
        }

        private void CreateWorldMaps()
        {
            worldMaps = new WorldMap[9];
            for (int i = 0; i < worldMaps.Length; i++)
                worldMaps[i] = new WorldMap(data, i);
        }
        private void CreateMapPoints()
        {
            mapPoints = new MapPoint[56];
            for (int i = 0; i < mapPoints.Length; i++)
                mapPoints[i] = new MapPoint(data, i);
        }

        private void CreateDialogue()
        {
            /******CREATE THE 3 NEW COMPRESSION TABLES: 'at' 'here' and ' for'******/
            BitManager.SetByte(data, 0x6935, 0xEF);     //set the charcode to read from table
            BitManager.SetByte(data, 0x6937, 0xEF);
            BitManager.SetShort(data, 0x693B, 0x60EF);

            BitManager.SetByte(data, 0x249016, 0x31);   //set the pointers for the table
            BitManager.SetByte(data, 0x24901A, 0x36);

            BitManager.SetShort(data, 0x24912E, 0x7461);    //set the new text
            BitManager.SetShort(data, 0x249130, 0x6800);
            BitManager.SetShort(data, 0x249132, 0x7265);
            BitManager.SetShort(data, 0x249134, 0x0065);
            BitManager.SetShort(data, 0x249136, 0x6620);
            BitManager.SetShort(data, 0x249138, 0x726F);
            BitManager.SetByte(data, 0x24913A, 0x00);
            /******/

            dialogues = new Dialogue[4096];
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogues[i] = new Dialogue(data, i);
                dialogues[i].SetDialogue(dialogues[i].GetDialogue(true), true);
            }
        }
        private void CreateBattleDialogue()
        {
            battleDialogues = new BattleDialogue[256];
            for (int i = 0; i < battleDialogues.Length; i++)
            {
                battleDialogues[i] = new BattleDialogue(data, i, 0);
            }
            battleMessages = new BattleDialogue[46];
            for (int i = 0; i < battleMessages.Length; i++)
            {
                battleMessages[i] = new BattleDialogue(data, i, 1);
            }
        }

        private void CreateFontCharacters()
        {
            fontMenu = new FontCharacter[128];
            for (int i = 0; i < fontMenu.Length; i++)
                fontMenu[i] = new FontCharacter(data, i, 0);

            fontDialogue = new FontCharacter[128];
            for (int i = 0; i < fontDialogue.Length; i++)
                fontDialogue[i] = new FontCharacter(data, i, 1);

            fontDescription = new FontCharacter[128];
            for (int i = 0; i < fontDescription.Length; i++)
                fontDescription[i] = new FontCharacter(data, i, 2);

            fontTriangle = new FontCharacter[14];
            for (int i = 0; i < fontTriangle.Length; i++)
                fontTriangle[i] = new FontCharacter(data, i, 3);
        }

        private void CreateEffects()
        {
            effects = new Effect[128];
            for (int i = 0; i < effects.Length; i++)
                effects[i] = new Effect(data, i);
        }
        private void CreateE_Animations()
        {
            e_animations = new E_Animation[64];
            for (int i = 0; i < e_animations.Length; i++)
                e_animations[i] = new E_Animation(data, i);
        }
    }
}
