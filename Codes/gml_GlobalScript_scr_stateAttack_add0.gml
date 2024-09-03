                var _cardinalText = "unknown"
                if (instance_exists(o_player) && instance_exists(self))
                    _cardinalText = scr_getCardinalDirection(o_player, -1) //-1 = self
                if (_cardinalText != "unknown")
                {
                    var _interruptionDirection = string("interruption_" + _cardinalText)
                    scr_random_speech(_interruptionDirection, 100, o_player)
                }
                else
                {
                    _interruptionDefault = "interruption"
                    scr_random_speech(_interruptionDefault, 100, o_player)
                }
