# bowling-game

C# using NUnit for testing

**Created as part of a specified basic aptitude assesment task**

Enter a bowling scorecard in a specific format to receive the total score for the game.

Format is: `[(Score|Miss(Score|Spare|Miss)|Strike)Boundary](repeated 10x)[BoundaryBonusBonus]`

Score = `1-9` adding up to maximum of `10` per frame

Miss = `-`

Spare = `/`

Strike = `X`

Boundary = `|`

Bonus = `1-9`

(Program is open ended to allow symbols to be changed)

eg: `X|7/|9-|X|-8|8/|-6|X|X|X||81` = Game score of `167`

Language files included to demonstrate other OO design concepts
