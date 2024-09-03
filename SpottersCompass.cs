// Copyright (C)
// See LICENSE file for extended copyright information.
// This file is part of the repository from .

using ModShardLauncher;
using ModShardLauncher.Mods;

namespace SpottersCompass
{
    public class SpottersCompass : Mod
    {
        public override string Author => "Xaphedo";
        public override string Name => "Spotter's Compass";
        public override string Description => "Adds cardinal direction (South, South-East, etc) to \"is spotted\" and \"Enemy!\" messages";
        public override string Version => "1.1.0.0";
        public override string TargetVersion => "0.8.2.10";

    private static IEnumerable<string> LogTextIterator(IEnumerable<string> input)
    {
        string findtext = " \"enemyUnaware;"; //the string that the iterator is looking for
        
        string inserttext = "\"enemyDirectionEast;восток;East;东;ost;este;est;est;leste;wschód;doğu;東;동\", \"enemyDirectionNorthEast;северо-восток;North-East;东北;nordost;noreste;nord-est;nord-est;nordeste;północny-wschód;kuzeydoğu;北東;북동\", \"enemyDirectionNorth;север;North;北;nord;norte;nord;nord;norte;północ;kuzey;北;북\", \"enemyDirectionNorthWest;северо-запад;North-West;西北;nordwest;noroeste;nord-ouest;nord-ovest;noroeste;północny-zachód;kuzeybatı;北西;북서\", \"enemyDirectionWest;запад;West;西;west;oeste;ouest;ovest;oeste;zachód;batı;西;서\", \"enemyDirectionSouthWest;юго-запад;South-West;西南;südwest;suroeste;sud-ouest;sud-ovest;sudoeste;południowy-zachód;güneybatı;南西;남서\", \"enemyDirectionSouth;юг;South;南;süd;sur;sud;sud;sul;południe;güney;南;남\", \"enemyDirectionSouthEast;юго-восток;South-East;东南;südost;sureste;sud-est;sud-est;sudeste;południowy-wschód;güneydoğu;南東;남동\","; //the string that the iterator will insert
        
        foreach(string item in input)
        {
            if (item.Contains(findtext))
            {
                string newItem = item.Insert(item.IndexOf(findtext), inserttext); //this adds the new string just before the found string. To add it after, simply add ' + findtext.Length' right after 'item.Insert(item.IndexOf(findtext)'
                yield return newItem;
            }
            else
            {
                yield return item;
            }
        }
    }


    private static IEnumerable<string> SpeechIterator0(IEnumerable<string> input)
    {
        string findtext = "\"Ambush;Ambush;Ambush;Ambush;Ambush;Ambush;Ambush;Ambush;Ambush;Ambush;Ambush;Ambush;Ambush;"; //the string that the iterator is looking for
        
        string inserttext = "\"interruption_East;interruption_East;interruption_East;interruption_East;interruption_East;interruption_East;interruption_East;interruption_East;interruption_East;interruption_East;interruption_East;interruption_East;interruption_East\", \";Враг на Востоке!;Enemy to the East!;有敌人在东边！;Feind im osten!;¡Enemigo al este!;Ennemi à l'est !;Nemico ad est!;Inimigo ao leste!;Wróg na wschodzie!;Düşman doğuda!;東の敵だ！ / 東の敵よ！;동쪽이다 적!\", \"interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end;interruption_East_end\", \"interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast;interruption_NorthEast\", \";Враг на Северо-Востоке!;Enemy to the North-East!;有敌人在东北边！;Feind im nordosten!;¡Enemigo al noreste!;Ennemi au nord-est !;Nemico a nord-est!;Inimigo ao nordeste!;Wróg na północnym wschodzie!;Düşman kuzeydoğuda!;北東の敵だ！ / 北東の敵よ！;북동쪽이다 적!\", \"interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end;interruption_NorthEast_end\", \"interruption_North;interruption_North;interruption_North;interruption_North;interruption_North;interruption_North;interruption_North;interruption_North;interruption_North;interruption_North;interruption_North;interruption_North;interruption_North\", \";Враг на Севере!;Enemy to the North!;有敌人在北边！;Feind im norden!;¡Enemigo al norte!;Ennemi au nord !;Nemico a nord!;Inimigo ao norte!;Wróg na północy!;Düşman kuzeyde!;北の敵だ！ / 北の敵よ！;북쪽이다 적!\", \"interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end;interruption_North_end\", \"interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest;interruption_NorthWest\", \";Враг на Северо-Западе!;Enemy to the North-West!;有敌人在西北边！;Feind im nordwesten!;¡Enemigo al noroeste!;Ennemi au nord-ouest !;Nemico a nord-ovest!;Inimigo ao noroeste!;Wróg na północnym zachodzie!;Düşman kuzeybatıda!;北西の敵だ！ / 北西の敵よ！;북서쪽이다 적!\", \"interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end;interruption_NorthWest_end\", \"interruption_West;interruption_West;interruption_West;interruption_West;interruption_West;interruption_West;interruption_West;interruption_West;interruption_West;interruption_West;interruption_West;interruption_West;interruption_West\", \";Враг на Западе!;Enemy to the West!;有敌人在西边！;Feind im westen!;¡Enemigo al oeste!;Ennemi à l'ouest !;Nemico ad ovest!;Inimigo ao oeste!;Wróg na zachodzie!;Düşman batıda!;西の敵だ！ / 西の敵よ！;서쪽이다 적!\", \"interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end;interruption_West_end\", \"interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest;interruption_SouthWest\", \";Враг на Юго-Западе!;Enemy to the South-West!;有敌人在西南边！;Feind im südwesten!;¡Enemigo al suroeste!;Ennemi au sud-ouest !;Nemico a sud-ovest!;Inimigo ao sudoeste!;Wróg na południowym zachodzie!;Düşman güneybatıda!;南西の敵だ！ / 南西の敵よ！;남서쪽이다 적!\", \"interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end;interruption_SouthWest_end\", \"interruption_South;interruption_South;interruption_South;interruption_South;interruption_South;interruption_South;interruption_South;interruption_South;interruption_South;interruption_South;interruption_South;interruption_South;interruption_South\", \";Враг на Юге!;Enemy to the South!;有敌人在南边！;Feind im süden!;¡Enemigo al sur!;Ennemi au sud !;Nemico a sud!;Inimigo ao sul!;Wróg na południu!;Düşman güneyde!;南の敵だ！ / 南の敵よ！;남쪽이다 적!\", \"interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end;interruption_South_end\", \"interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast;interruption_SouthEast\", \";Враг на Юго-Востоке!;Enemy to the South-East!;有敌人在东南边！;Feind im südosten!;¡Enemigo al sureste!;Ennemi au sud-est !;Nemico a sud-est!;Inimigo ao sudeste!;Wróg na południowym wschodzie!;Düşman güneydoğuda!;南東の敵だ！ / 南東の敵よ！;남동쪽이다 적!\", \"interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end;interruption_SouthEast_end\", "; //the string that the iterator will insert
        
        foreach(string item in input)
        {
            if (item.Contains(findtext))
            {
                string newItem = item.Insert(item.IndexOf(findtext), inserttext); //this adds the new string just before the found string. To add it after, simply add ' + findtext.Length' right after 'item.Insert(item.IndexOf(findtext)'
                yield return newItem;
            }
            else
            {
                yield return item;
            }
        }
    }

    private static IEnumerable<string> SpeechIterator1(IEnumerable<string> input)
    {
        string findtext = "\"Ambush;100;100;"; //the string that the iterator is looking for
        
        string inserttext = "\"interruption_East;100;100;100;100;100;100;100;100;100;100;100;100\", \"interruption_NorthEast;100;100;100;100;100;100;100;100;100;100;100;100\", \"interruption_North;100;100;100;100;100;100;100;100;100;100;100;100\", \"interruption_NorthWest;100;100;100;100;100;100;100;100;100;100;100;100\", \"interruption_West;100;100;100;100;100;100;100;100;100;100;100;100\", \"interruption_SouthWest;100;100;100;100;100;100;100;100;100;100;100;100\", \"interruption_South;100;100;100;100;100;100;100;100;100;100;100;100\", \"interruption_SouthEast;100;100;100;100;100;100;100;100;100;100;100;100\", "; //the string that the iterator will insert
        
        foreach(string item in input)
        {
            if (item.Contains(findtext))
            {
                string newItem = item.Insert(item.IndexOf(findtext), inserttext); //this adds the new string just before the found string. To add it after, simply add ' + findtext.Length' right after 'item.Insert(item.IndexOf(findtext)'
                yield return newItem;
            }
            else
            {
                yield return item;
            }
        }
    }

        public override void PatchMod()
        {
            Msl.AddFunction(ModFiles.GetCode("gml_GlobalScript_scr_GetCardinalDirection.gml"), "scr_getCardinalDirection");

            Msl.LoadGML("gml_GlobalScript_table_log_text")
                .Apply(LogTextIterator)
                //.Peek()
                .Save();

            Msl.LoadGML("gml_GlobalScript_table_speech")
                .Apply(SpeechIterator0)
                //.Peek()
                .Save();

            Msl.LoadGML("gml_GlobalScript_table_speech")
                .Apply(SpeechIterator1)
                //.Peek()
                .Save();

            Msl.LoadGML("gml_Object_o_fogrender_Other_12")
                .MatchFrom("logFOVTurns = 20") // Finding the line
                .InsertBelow(ModFiles, "gml_Object_o_fogrender_Other_12_add0.gml")// Inserting the snippet below
                .Save(); 

            Msl.LoadGML("gml_Object_o_fogrender_Other_12")
                .MatchFrom("if (state == \"attack\")") // Finding the line
                .InsertAbove(ModFiles, "gml_Object_o_fogrender_Other_12_add1.gml") // Inserting the snippet above
                .Save();

            Msl.LoadGML("gml_Object_o_fogrender_Other_12") // Loading a script from the game's files
                .MatchFrom("scr_actionsLog(\"enemyHostileFOV\", [_name, _name])") // Finding the line
                .ReplaceBy("scr_actionsLog(\"enemyHostileFOV\", [_nameAndDirection, _name])")// Replacing it
                .Save();

            Msl.LoadGML("gml_Object_o_fogrender_Other_12")
                .MatchFrom("scr_actionsLog(\"enemyAlarmFOV\", [_name, _name])")
                .ReplaceBy("scr_actionsLog(\"enemyAlarmFOV\", [_nameAndDirection, _name])")
                .Save();

            Msl.LoadGML("gml_Object_o_fogrender_Other_12")
                .MatchFrom("scr_actionsLog(\"enemyUnawareFOV\", [_name, _name])")
                .ReplaceBy("scr_actionsLog(\"enemyUnawareFOV\", [_nameAndDirection, _name])")
                .Save();


            Msl.LoadGML("gml_GlobalScript_scr_stateAttack")
                .MatchFrom("scr_random_speech(\"interruption\", 100, o_player)") // Finding the line
                .ReplaceBy(ModFiles, "gml_GlobalScript_scr_stateAttack_add0.gml") // Replacing with
                .MatchFrom("scr_random_speech(\"interruption\", 100, o_player)") // Finding the line once again
                .ReplaceBy(ModFiles, "gml_GlobalScript_scr_stateAttack_add0.gml") // Replacing with once again
                //.Peek()
                .Save();
        }
    }
}
