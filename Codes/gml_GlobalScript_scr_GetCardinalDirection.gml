function scr_getCardinalDirection(argument0, argument1) //gml_Script_scr_getCardinalDirection
{
    if (!instance_exists(o_player) || !instance_exists(self))
        return "unknown"
    if is_undefined(argument0)
        argument0 = o_player
    if is_undefined(argument1)
        argument1 = -1 //self
    var _cardinalDirection = point_direction(argument0.x, argument0.y, argument1.x, argument1.y)
    var _cardinalIndex = round(_cardinalDirection / 45)
    var _cardinalText = "unknown"
    switch _cardinalIndex
    {
        case 0:
            _cardinalText = "East"
            break
        case 1:
            _cardinalText = "NorthEast"
            break
        case 2:
            _cardinalText = "North"
            break
        case 3:
            _cardinalText = "NorthWest"
            break
        case 4:
            _cardinalText = "West"
            break
        case 5:
            _cardinalText = "SouthWest"
            break
        case 6:
            _cardinalText = "South"
            break
        case 7:
            _cardinalText = "SouthEast"
            break
        case 8:
            _cardinalText = "East"
            break
    }

    return _cardinalText;
}

