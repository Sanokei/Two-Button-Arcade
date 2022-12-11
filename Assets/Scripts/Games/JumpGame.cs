using System.Collections.Generic;
using PixelGame;
using UnityEngine;
public class JumpGame : Game
{
    public override void StartGame()
    {
        // Create PixelGameObject's
        game.add("Main Canvas");
        game.add("Player");
        game.add("Floor");
        // Add all the components
        /* Floor */
        game["Floor"].add("Floor_Texture", typeof(PixelSprite)).add(
            game.SpriteStringMaker(
                new Dictionary<PixelPosition, char>()
                {
                    {new PixelPosition(0,0), 'c'},
                    {new PixelPosition(1,0), 'c'},
                    {new PixelPosition(2,0), 'c'},
                    {new PixelPosition(3,0), 'c'},
                    {new PixelPosition(4,0), 'c'},
                    {new PixelPosition(5,0), 'c'},
                    {new PixelPosition(6,0), 'c'},
                    {new PixelPosition(7,0), 'c'}
                }
            )
        );
        game["Floor"].add("pc", typeof(PixelCollider)).add(
            new List<PixelPosition>()
            {
                new PixelPosition(0,0),
                new PixelPosition(1,0),
                new PixelPosition(2,0),
                new PixelPosition(3,0),
                new PixelPosition(4,0),
                new PixelPosition(5,0),
                new PixelPosition(6,0),
                new PixelPosition(7,0)
            }
        );
        /* Player */
        game["Player"].add("Player_Still", typeof(PixelSprite)).add(
            game.SpriteStringMaker(
                new Dictionary<PixelPosition, char>()
                {
                    {new PixelPosition(0,0), 'c'},
                    {new PixelPosition(0,1), 'r'}
                }
            )
        );

        game["Player"].add("Transform", typeof(PixelTransform)).add(
            new PixelPosition(1,1)
        );
        game["Player"].add("rb", typeof(PixelRigidBody));
        game["Player"].add("pc", typeof(PixelCollider)).add(
            new List<PixelPosition>()
            {
                new PixelPosition(0,0),
                new PixelPosition(0,1)
            }
        );
        /* Main Canvas */
        game["Main Canvas"].add("Main Canvas", typeof(PixelSprite)).add(
            new string('b',64)
        );

        game["Player"].add("PlayerMovement", typeof(PixelBehaviourScript)).add(
            @"-- player movement script
            function Start()
                game.add('lol');
            end
            function Update()
                print('crash test')
            end
            function ButtonOnePress()
                print('button 1');
                Player['Transform'].move(0,2);
            end
            function ButtonTwoPress()
                print('button 2')
                Player['Transform'].move(1,0);
                
            end
            "
        );
        game["Player"]["PlayerMovement"].addPixelGameObjectToScriptGlobals("game",game);
        game["Player"]["PlayerMovement"].RunScript();
    }
}

/*
game['Player']['Transform'].move(0,-1)
game['lol'].add('test','PixelTransform')
game['lol'].add('still', 'PixelSprite');--.add(
--    {
--
--    }
-- );
-- game['lol'].add('script', typeof(PixelBehaviourScript)).add('function Start() print(\'Lua in Lua :o\') end');
-- game['Player']['PlayerMovement'].RunScript();
*/